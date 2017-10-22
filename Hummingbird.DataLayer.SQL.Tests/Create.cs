using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;
using System.Data.Entity;

namespace Hummingbird.DataLayer.SQL.Tests
{
    internal static class Create
    {
        static ChatsRepository chatsRepository = new ChatsRepository();
        static UsersRepository usersRepository = new UsersRepository();

        internal static object User()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                Nickname = "TestUser",
                PasswordHash = "TestPassword",
            };

            return usersRepository.Register(user, true);
        }

        internal static object Chat(int usersAmount = 2)
        {
            Guid chatId = Guid.NewGuid();

            List<Guid> members = new List<Guid>();
            for (int i = 0; i < usersAmount; i++)
            {
                members.Add(((User)User()).ID);
            }

            Chat chat = new Chat
            {
                ID = chatId,
                Name = "TestChat"
            };

            chatsRepository.Create(chat, members.ToArray());
            return chat;
        }
        //internal static Message Message(User from, Chat to)
        //{
        //    Message m = new Message
        //    {
        //        ID = Guid.NewGuid(),
        //        UserFromID = from.ID,
        //        ChatToID = to.ID,
        //        Text = "TestMessage",

        //    };
        //}
    }
}
