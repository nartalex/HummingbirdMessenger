using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
    public class MessagesRepository : IMessagesRepository
    {
        DatabaseContext DB = new DatabaseContext();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Stopwatch timer = new Stopwatch();
        private readonly int MAX_TIME = 1000;

        /// <summary>
        /// Удаляет сообщение с указанным ID
        /// </summary>
        /// <param name="id">ID сообщения</param>
        public void DeleteMessage(Guid id)
        {
            logger.Info($"Удаление сообщения {id}");
            timer.Restart();

            try
            {
                CheckMessage(id);
                DB.Messages.Remove(DB.Messages.First(m => m.ID == id));
                DB.SaveChanges();

                logger.Info($"Удаление сообщения {id} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Удаление сообщения {id} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при удалении сообщения {id}");
                throw e;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Изменение сообщения
        /// </summary>
        /// <param name="edits">Исправления</param>
        public void EditMessage(Message edits)
        {
            string log = $"Изменение сообщения {edits.ID} с исправлениями: ";
            if (edits.Text.Any())
                log += "текста, ";
            if (edits.AttachType != null)
                log += "типа аттача, ";
            if (edits.AttachPath.Any())
                log += "аттача";
            logger.Info(log.TrimEnd(new[] { ',', ' ' }));
            timer.Restart();

            try
            {
                CheckMessage(edits.ID);
                Message toEdit = DB.Messages.First(m => m.ID == edits.ID);
                if (edits.Text.Any())
                    toEdit.Text = edits.Text;
                if (edits.AttachType != null)
                    toEdit.AttachType = edits.AttachType;
                if (edits.AttachPath.Any())
                    toEdit.AttachPath = edits.AttachPath;
                toEdit.Edited = true;
                DB.SaveChanges();

                logger.Info($"Изменение сообщения {edits.ID} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Изменение сообщения {edits.ID} заняло {timer.ElapsedMilliseconds} мс");
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при изменении сообщения {edits.ID}");
                throw e;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Возвращает указанное количество сообщений
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="amount">Количество возвращаемых сообщений</param>
        /// <param name="skip">Количество пропускаемых сообщений</param>
        /// <returns>Массив с сообщениями в случае успеха</returns>
        public IEnumerable<Message> GetAmountOfMessages(Guid chatId, int skip, int amount)
        {
            logger.Info($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip}");
            timer.Restart();

            try
            {
                ChatsRepository _chatsRepository = new ChatsRepository();
                _chatsRepository.CheckChat(chatId);
                if (amount <= 0)
                {
                    logger.Info($"Получение сообщений в чате {chatId}: ноль сообщений запрошено. Создаем исключение.");
                    throw GenerateException("Can't get zero messages", HttpStatusCode.BadRequest);
                }
                var ret = DB.Messages
                  .Where(m => m.ChatToID == chatId)
                  .OrderBy(m => m.Time)
                  .Skip(skip)
                  .Take(amount)
                  .ToArray();

                logger.Info($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip} заняло {timer.ElapsedMilliseconds} мс");

                return ret;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при получении сообщений в чате {chatId}");
                throw e;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Возвращает последнее сообщение в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Объект Message в случае успеха</returns>
        public Message GetLastMessage(Guid chatId)
        {
            logger.Info($"Получение последнего сообщения в чате {chatId}");
            timer.Restart();

            try
            {
                ChatsRepository _chatsRepository = new ChatsRepository();
                _chatsRepository.CheckChat(chatId);
                var ret = DB.Messages
                           .Where(m => m.ChatToID == chatId)
                           .OrderByDescending(m => m.Time)
                           .First();

                logger.Info($"Получение последнего сообщения в чате {chatId} - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Получение последнего сообщения в чате {chatId} заняло {timer.ElapsedMilliseconds} мс");

                return ret;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при получении последнего сообщения в чате  {chatId}");
                throw e;
            }
            finally
            {
                timer.Stop();
            }
        }

        /// <summary>
        /// Отправление сообщения
        /// </summary>
        /// <param name="message">Отправляемое сообщение</param>
        public Message SendMessage(Message message)
        {
            logger.Info($"Отправление сообщения в чат {message.ChatToID} от пользователя {message.UserFromID}");
            timer.Restart();

            try
            {
                Message newMessage = new Message
                {
                    ID = Guid.NewGuid(),
                    UserFromID = message.UserFromID,
                    ChatToID = message.ChatToID,
                    Time = DateTime.Now,
                    TimeToLive = message.TimeToLive,
                    AttachType = message.AttachType,
                    AttachPath = message.AttachPath,
                    Text = message.Text,
                    Edited = false
                };

                DB.Messages.Add(newMessage);
                DB.SaveChanges();

                logger.Info($"Отправление сообщения в чат - успешно за {timer.ElapsedMilliseconds} мс");
                if (timer.ElapsedMilliseconds > MAX_TIME)
                    logger.Warn($"Отправление сообщения в чат заняло {timer.ElapsedMilliseconds} мс");

                return newMessage;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Ошибка при отправлении сообщения в чат {message.ChatToID} от пользователя {message.UserFromID}");
                throw e;
            }
            finally
            {
                timer.Stop();
            }
        }

        private void CheckMessage(Guid id)
        {
            if (DB.Messages.Any(m => m.ID == id))
            {
                logger.Error($"Message ID is invalid: {id}");
                throw GenerateException("Message ID is invalid", HttpStatusCode.BadRequest);
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
