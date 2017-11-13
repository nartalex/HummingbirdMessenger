using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Diagnostics;

using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly DatabaseContext DB = new DatabaseContext();
        private readonly UsersRepository _usersRepository = new UsersRepository();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Stopwatch timer = new Stopwatch();
        private readonly int MAX_TIME = 1000;


        /// <summary>
        /// Создание чата
        /// </summary>
        /// <param name="chat">Объект Chat</param>
        /// <param name="members">Список участников</param>
        /// <returns>Объект Chat в случае успеха</returns>
        public Chat Create(Chat chat, IEnumerable<Guid> members)
        {
	        if(members.Count() == 2 && String.IsNullOrEmpty(chat.Name))
	        {
		        var m = members.ToArray();
				chat.Name = DB.Users.First(x=>x.ID==m[0]).Nickname + " - " + DB.Users.First(x => x.ID == m[1]).Nickname;
	        }

            logger.Info($"Создание чата с именем {chat.Name} и количеством участников {members.Count()}");
            timer.Restart();

            try
            {
                if (!chat.Name.Any())
                {
                    logger.Error("Создание чата: пустое название. Создаем исключение.");
                    throw GenerateException("Can't create chat with empty name", HttpStatusCode.BadRequest);
                }
                if (!members.Any())
                {
                    logger.Error("Создание чата: пустой список участников. Создаем исключение.");
                    throw GenerateException("Can't create chat with no members", HttpStatusCode.BadRequest);
                }

                Guid newChatID = Guid.NewGuid();
                List<ChatMember> chatMembers = new List<ChatMember>();
                foreach (var m in members)
                {
                    chatMembers.Add(new ChatMember
                    {
                        ChatID = newChatID,
                        UserID = m
                    }
                    );
                }
                Chat newChat = new Chat
                {
                    ID = newChatID,
                    Name = chat.Name,
                    Avatar = chat.Avatar,
                    Members = chatMembers
                };
                DB.Chats.Add(newChat);
                DB.SaveChanges();

                logger.Info($"Создание чата {newChatID} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Регистрация пользователя {newChatID} заняла {timer.ElapsedMilliseconds} мс");

                return newChat;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при cоздании чата с именем {chat.Name} и количеством участников {members.Count()}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        public Chat GetChat(Guid id)
        {
            logger.Info($"Получение информации о чате {id}");
            timer.Restart();

            try
            {
                CheckChat(id);
                var ret = DB.Chats
                    .Include(c => c.Members.Select(m => m.User))
                    .First(c => c.ID == id);

                logger.Info($"Получение информации о чате {id} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Получение информации о чате {id} заняло {timer.ElapsedMilliseconds} мс");

                return ret;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при получении информации о чате {id}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Удаление чата
        /// Также удаляются все сообщения
        /// </summary>
        /// <param name="chatId">ID чата</param>
        public void DeleteChat(Guid id)
        {
            logger.Info($"Удаление чата {id}");
            timer.Restart();

            try
            {
                CheckChat(id);
                DB.Messages.RemoveRange(DB.Messages.Where(c => c.ChatToID == id));
                DB.Chats.Remove(DB.Chats.First(c => c.ID == id));
                DB.SaveChanges();

                logger.Info($"Удаление чата {id} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Удаление чата {id} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при удалении чата {id}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Возвращает массив с чатами пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Массив с объектами Chat в случае успеха</returns>
        public IEnumerable<Chat> GetUserChats(Guid userId)
        {
            logger.Info($"Получение списка чатов для пользователя {userId}");
            timer.Restart();

            try
            {
                _usersRepository.CheckUser(userId);
                MessagesRepository _messagesRepository = new MessagesRepository();

                var chats = DB.ChatMembers
                            .Include(c => c.Chat)
                            .Where(u => u.UserID == userId)
                            .Select(c => c.Chat)
                            .ToArray();
                foreach (var c in chats)
                {
                    c.Messages = new[] { _messagesRepository.GetLastMessage(c.ID) };
                }
                var ret = chats.OrderBy(c => c.Messages.OrderBy(m => m.Time));

                logger.Info($"Получение списка чатов для пользователя {userId} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Получение списка чатов для пользователя {userId} заняло {timer.ElapsedMilliseconds} мс");

                return ret;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при получении списка чатов для пользователя {userId}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Добавление пользователей в чат
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        public void AddMembers(Guid chatId, IEnumerable<Guid> userIds)
        {
            logger.Info($"Добавление в чат {chatId} пользователей в количестве {userIds.Count()}");
            timer.Restart();

            try
            {
                CheckChat(chatId);
                if (!userIds.Any())
                    throw new Exception("Can't add zero members");
                foreach (var u in userIds)
                {
                    ChatMember member = new ChatMember
                    {
                        ChatID = chatId,
                        UserID = u
                    };
                    DB.ChatMembers.Add(member);
                }
                DB.SaveChanges();

                logger.Info($"Добавление в чат {chatId} пользователей в количестве {userIds.Count()} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Добавление в чат {chatId} пользователей в количестве {userIds.Count()} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при добавлении в чат {chatId} пользователей в количестве {userIds.Count()}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Удаление пользователей из чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        public void DeleteMembers(Guid chatId, IEnumerable<Guid> userIds)
        {
            logger.Info($"Удаление из чата {chatId} пользователей в количестве {userIds.Count()}");
            timer.Restart();

            try
            {
                CheckChat(chatId);
                if (!userIds.Any())
                {
                    logger.Error($"Удаление из чата {chatId}: список пользователей пуст. Создаем исключение.");
                    throw GenerateException("Can't delete zero members", HttpStatusCode.BadRequest);
                }
                foreach (var u in userIds)
                    DB.ChatMembers.Remove(DB.ChatMembers.First(m => m.UserID == u && m.ChatID == chatId));
                DB.SaveChanges();

                logger.Info($"Удаление из чата {chatId} пользователей в количестве {userIds.Count()} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Удаление из чата {chatId} пользователей в количестве {userIds.Count()} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при удалении из чата {chatId} пользователей в количестве {userIds.Count()}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Изменение аватара в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newAvatar">Новый аватар</param>
        public void ChangeAvatar(Guid chatId, byte[] newAvatar)
        {
            logger.Info($"Изменение аватара в чате {chatId}, размер нового аватара {newAvatar.Length}");
            timer.Restart();
            try
            {
                CheckChat(chatId);

                DB.Chats.
                    Include(m => m.Members)
                    .First(c => c.ID == chatId)
                    .Avatar = (newAvatar.Any() ? newAvatar : null);
                DB.SaveChanges();

                logger.Info($"Изменение аватара в чате {chatId} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Изменение аватара в чате {chatId}, размер нового аватара {newAvatar.Length} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при изменении аватара в чате {chatId}, размер нового аватара {newAvatar.Length}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Изменение названия указанного чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newName">Новое название</param>
        public void ChangeName(Guid chatId, string newName)
        {
            logger.Info($"Изменение имени чата {chatId}, новое имя: {newName}");
            timer.Restart();

            try
            {
                CheckChat(chatId);

                if (!newName.Any())
                {
                    logger.Error($"Изменение имени чата {chatId}: пустое название. СОздаем исключение.");
                    throw GenerateException("Chat name can't be empty", HttpStatusCode.BadRequest);
                }
                DB.Chats.Include(m => m.Members).First(c => c.ID == chatId).Name = newName;
                DB.SaveChanges();

                logger.Info($"Изменение имени чата {chatId}, новое имя: {newName} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Изменение имени чата {chatId}, новое имя: {newName}, заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при изменении имени чата {chatId}, новое имя: {newName}");
                throw;
            }
            finally
            {
                timer.Stop();
            }
        }

        internal void CheckChat(Guid id)
        {
            if (!DB.Chats.Any(c => c.ID == id))
            {
                logger.Error($"Chat ID is invalid: {id}");
                throw GenerateException("Chat ID is invalid", HttpStatusCode.BadRequest);
            }
        }

        private Exception GenerateException(string message, HttpStatusCode code)
        {
            var ex = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };

            return new HttpResponseException(ex);
        }
    }
}
