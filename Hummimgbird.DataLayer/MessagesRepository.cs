using System;
using System.Collections.Generic;
using System.Linq;

using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class MessagesRepository : IMessagesRepository, IDisposable
    {
        DatabaseContext DB = new DatabaseContext();

        /// <summary>
        /// Удаляет сообщение с указанным ID
        /// </summary>
        /// <param name="id">ID сообщения</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object DeleteMessage(Guid id)
        {
            try
            {
                DB.Messages.Remove(DB.Messages.First(m => m.ID == id));
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Изменение сообщения
        /// </summary>
        /// <param name="id">ID сообщения</param>
        /// <param name="newMessage">Объект Message, содержащий только исправления</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object EditMessage(Guid id, Message newMessage)
        {
            try
            {
                Message toEdit = DB.Messages.First(m => m.ID == id);
                // toEdit.Text = newMessage.Text ??;
                if (newMessage.Text != null)
                    toEdit.Text = newMessage.Text;

                if (newMessage.AttachType != null)
                    toEdit.AttachType = newMessage.AttachType;

                if (newMessage.AttachPath != null)
                    toEdit.AttachPath = newMessage.AttachPath;

                toEdit.Edited = true;

                DB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        //UNDONE: OrderBy Time не работает
        /// <summary>
        /// Возвращает указанное количество сообщений
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="amount">Количество возвращаемых сообщений</param>
        /// <param name="skip">Количество пропускаемых сообщений</param>
        /// <returns>Массив с сообщениями в случае успеха, Exceprion в случае ошибки</returns>
        public object GetAmountOfMessages(Guid chatId, int amount, int skip)
        {
            try
            {
                return DB.Messages
                           .Where(m => m.ChatToID == chatId)
                           .OrderBy(m => m.Time)
                           .Skip(skip)
                           .Take(amount)
                           .ToArray();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Возвращает последнее сообщение в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Объект Message в случае успеха, Exceprion в случае ошибки</returns>
        public object GetLastMessage(Guid chatId)
        {
            try
            {
                return DB.Messages
                           .Where(m => m.ChatToID == chatId)
                           .OrderBy(m => m.Time)
                           .ToArray()
                           .Last();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Отправление сообщения
        /// </summary>
        /// <param name="message">Отправляемое сообщение</param>
        /// <returns>Объект Message в случае успеха, Exceprion в случае ошибки</returns>
        public object SendMessage(Message message)
        {
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
                return newMessage;
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
