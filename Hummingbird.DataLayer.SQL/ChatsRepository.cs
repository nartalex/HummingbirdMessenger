using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class ChatsRepository : IChatsRepository, IDisposable
    {
        private readonly DatabaseContext DB = new DatabaseContext();
        private readonly MessagesRepository _messagesRepository = new MessagesRepository();

        /// <summary>
        /// Добавление пользователей в чат
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object AddMembers(Guid chatId, IEnumerable<Guid> userIds)
        {
            try
            {
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
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object AddMembers(Chat chat)
        {
            if (!chat.Members.Any())
                return new Exception("Can't add zero members");

            return AddMembers(chat.ID, chat.Members.Select(m => m.UserID));
        }

        /// <summary>
        /// Изменение аватара в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newAvatar">Новый аватар</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object ChangeAvatar(Guid chatId, byte[] newAvatar)
        {
            try
            {
                DB.Chats.
                    Include(m => m.Members)
                    .First(c => c.ID == chatId)
                    .Avatar = (newAvatar.Any() ? newAvatar : null);
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object ChangeAvatar(Chat chat)
        {
            return ChangeAvatar(chat.ID, chat.Avatar);
        }

        /// <summary>
        /// Изменение названия указанного чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newName">Новое название</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object ChangeName(Guid chatId, string newName)
        {
            try
            {
                DB.Chats.Include(m => m.Members).First(c => c.ID == chatId).Name = newName;
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object ChangeName(Chat chat)
        {
            if (!chat.Name.Any())
                return new Exception("Chat name can't be empty");

            return ChangeName(chat.ID, chat.Name);
        }

        /// <summary>
        /// Создание чата
        /// </summary>
        /// <param name="chat">Объект Chat</param>
        /// <param name="members">Список участников</param>
        /// <returns>Объект Chat в случае успеха, Exceprion в случае ошибки</returns>
        public object Create(Chat chat, IEnumerable<Guid> members)
        {
            try
            {
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
                return newChat;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object Create(Chat chat)
        {
            if (!chat.Members.Any())
                return new Exception("Can't create chat with no members");

            return Create(chat, chat.Members.Select(m => m.UserID));
        }

        /// <summary>
        /// Удаление чата
        /// Также удаляются все сообщения
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object DeleteChat(Guid chatId)
        {
            try
            {
                DB.Messages.RemoveRange(DB.Messages.Where(c => c.ChatToID == chatId));
                DB.Chats.Remove(DB.Chats.First(c => c.ID == chatId));
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Удаление пользователей из чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object DeleteMembers(Guid chatId, IEnumerable<Guid> userIds)
        {
            try
            {
                foreach (var u in userIds)
                    DB.ChatMembers.Remove(DB.ChatMembers.First(m => m.UserID == u && m.ChatID == chatId));

                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object DeleteMembers(Chat chat)
        {
            if (!chat.Members.Any())
                return new Exception("Can't delete zero members");

            return DeleteMembers(chat.ID, chat.Members.Select(m => m.UserID));
        }

        /// <summary>
        /// Возвращает массив с чатами пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Массив с объектами Chat в случае успеха, Exceprion в случае ошибки</returns>
        public object GetUserChats(Guid userId)
        {
            try
            {
                var chats = DB.ChatMembers
                    .Include(c => c.Chat)
                    .Where(u => u.UserID == userId)
                    .Select(c => c.Chat)
                    .ToArray();

                foreach (var c in chats)
                {
                    c.Messages = new[] { (Message)_messagesRepository.GetLastMessage(c.ID) };
                }

                return chats.OrderBy(c => c.Messages.OrderBy(m => m.Time));
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public object GetChat(Guid id)
        {
            try
            {
                if (!DB.Chats.Any(c => c.ID == id))
                    throw new Exception("No chat found");
                else
                    return DB.Chats
                        .Include(c => c.Members.Select(m => m.User))
                        .First(c => c.ID == id);
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
