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

        internal static User User()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "TestUser",
                Login = userId.ToString(),
                PasswordHash = "TestPassword",
                Disabled = false
            };
            usersRepository.Register(user);
            return user;
        }
        internal static Chat Chat(int usersAmount = 2)
        {
            Guid chatId = Guid.NewGuid();

            List<ChatMember> members = new List<ChatMember>();
            for (int i = 0; i < usersAmount; i++)
            {
                members.Add(
                    new ChatMember
                    {
                        ChatID = chatId,
                        UserID = User().ID
                    }
                );
            }

            Chat chat = new Chat
            {
                ID = chatId,
                Name = "TestChat",
                Members = members
            };

            chatsRepository.Create(chat);
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
