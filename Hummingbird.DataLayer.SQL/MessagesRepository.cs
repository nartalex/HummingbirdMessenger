using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class MessagesRepository : IMessagesRepository
    {
        DatabaseContext DB = new DatabaseContext();
        ChatsRepository _chatsRepository = new ChatsRepository();

        /// <summary>
        /// Удаляет сообщение с указанным ID
        /// </summary>
        /// <param name="id">ID сообщения</param>
        public void DeleteMessage(Guid id)
        {
            CheckMessage(id);

            DB.Messages.Remove(DB.Messages.First(m => m.ID == id));
            DB.SaveChanges();
        }

        /// <summary>
        /// Изменение сообщения
        /// </summary>
        /// <param name="edits">Исправления</param>
        public void EditMessage(Message edits)
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
        }

        //UNDONE: OrderBy Time не работает
        /// <summary>
        /// Возвращает указанное количество сообщений
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="amount">Количество возвращаемых сообщений</param>
        /// <param name="skip">Количество пропускаемых сообщений</param>
        /// <returns>Массив с сообщениями в случае успеха</returns>
        public IEnumerable<Message> GetAmountOfMessages(Guid chatId, int skip, int amount)
        {
            _chatsRepository.CheckChat(chatId);
            if (amount <= 0)
                throw GenerateException("Can't get zero messages", HttpStatusCode.BadRequest);

            return DB.Messages
             .Where(m => m.ChatToID == chatId)
             .OrderBy(m => m.Time)
             .Skip(skip)
             .Take(amount)
             .ToArray();
        }

        /// <summary>
        /// Возвращает последнее сообщение в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Объект Message в случае успеха</returns>
        public Message GetLastMessage(Guid chatId)
        {
            _chatsRepository.CheckChat(chatId);

            return DB.Messages
                       .Where(m => m.ChatToID == chatId)
                       .OrderBy(m => m.Time)
                       .Last();

        }

        /// <summary>
        /// Отправление сообщения
        /// </summary>
        /// <param name="message">Отправляемое сообщение</param>
        public Message SendMessage(Message message)
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

        private void CheckMessage(Guid id)
        {
            if (DB.Messages.Any(m => m.ID == id))
                throw GenerateException("Message ID is invalid", HttpStatusCode.BadRequest);
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
