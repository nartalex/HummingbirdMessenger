using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Diagnostics;

using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly DatabaseContext DB = new DatabaseContext();
        private readonly MessagesRepository _messagesRepository = new MessagesRepository();

        /// <summary>
        /// Создание чата
        /// </summary>
        /// <param name="chat">Объект Chat</param>
        /// <param name="members">Список участников</param>
        /// <returns>Объект Chat в случае успеха</returns>
        public Chat Create(Chat chat, IEnumerable<Guid> members)
        {
            if (!members.Any())
                throw GenerateException("Can't create chat with no members", HttpStatusCode.BadRequest);

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

        public Chat GetChat(Guid id)
        {
            CheckChat(id);

            return DB.Chats
                .Include(c => c.Members.Select(m => m.User))
                .First(c => c.ID == id);
        }

        /// <summary>
        /// Удаление чата
        /// Также удаляются все сообщения
        /// </summary>
        /// <param name="chatId">ID чата</param>
        public void DeleteChat(Guid id)
        {
            CheckChat(id);

            DB.Messages.RemoveRange(DB.Messages.Where(c => c.ChatToID == id));
            DB.Chats.Remove(DB.Chats.First(c => c.ID == id));
            DB.SaveChanges();
        }

        /// <summary>
        /// Возвращает массив с чатами пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Массив с объектами Chat в случае успеха</returns>
        public IEnumerable<Chat> GetUserChats(Guid userId)
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

        /// <summary>
        /// Добавление пользователей в чат
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        public void AddMembers(Guid chatId, IEnumerable<Guid> userIds)
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
        }

        /// <summary>
        /// Удаление пользователей из чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Массив с ID пользователей</param>
        public void DeleteMembers(Guid chatId, IEnumerable<Guid> userIds)
        {
            CheckChat(chatId);

            if (!userIds.Any())
                throw GenerateException("Can't delete zero members", HttpStatusCode.BadRequest);

            foreach (var u in userIds)
                DB.ChatMembers.Remove(DB.ChatMembers.First(m => m.UserID == u && m.ChatID == chatId));

            DB.SaveChanges();
        }

        /// <summary>
        /// Изменение аватара в указанном чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newAvatar">Новый аватар</param>
        public void ChangeAvatar(Guid chatId, byte[] newAvatar)
        {
            CheckChat(chatId);

            DB.Chats.
                Include(m => m.Members)
                .First(c => c.ID == chatId)
                .Avatar = (newAvatar.Any() ? newAvatar : null);
            DB.SaveChanges();
        }

        /// <summary>
        /// Изменение названия указанного чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="newName">Новое название</param>
        public void ChangeName(Guid chatId, string newName)
        {
            CheckChat(chatId);

            if (!newName.Any())
                throw GenerateException("Chat name can't be empty", HttpStatusCode.BadRequest);

            DB.Chats.Include(m => m.Members).First(c => c.ID == chatId).Name = newName;
            DB.SaveChanges();
        }

        internal void CheckChat(Guid id)
        {
            if (!DB.Chats.Any(c => c.ID == id))
                throw GenerateException("Chat ID is invalid", HttpStatusCode.BadRequest);
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
