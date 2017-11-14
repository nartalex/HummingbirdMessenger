using System;
using System.Collections.Generic;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL.Tests
{
    internal static class Create
    {
        static ChatsRepository chatsRepository = new ChatsRepository();
        static UsersRepository usersRepository = new UsersRepository();

        internal static User User()
        {
            var user = new User
            {
                Nickname = "TestUser",
                Login = Guid.NewGuid().ToString(),
                PasswordHash = "TestPassword"
            };

            return usersRepository.Register(user);
        }

        internal static Chat Chat(int usersAmount = 2)
        {
            List<Guid> members = new List<Guid>();
            for (int i = 0; i < usersAmount; i++)
            {
                members.Add(User().ID);
            }

            Chat chat = new Chat
            {
                Name = "TestChat"
            };

            return chatsRepository.Create(chat);
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
