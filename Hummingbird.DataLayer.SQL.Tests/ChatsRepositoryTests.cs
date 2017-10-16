using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;
using System.Data.Entity;

namespace Hummingbird.DataLayer.SQL.Tests
{
    [TestClass]
    public class ChatsRepositoryTests
    {
        DatabaseContext DB = new DatabaseContext();
        ChatsRepository chatsRepository = new ChatsRepository();
        UsersRepository usersRepository = new UsersRepository();

        private User CreateUser()
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
        private Chat CreateChat(int usersAmount = 2)
        {
            Guid chatId = Guid.NewGuid();

            List<ChatMember> members = new List<ChatMember>();
            for (int i = 0; i < usersAmount; i++)
            {
                members.Add(
                    new ChatMember
                    {
                        ChatID = chatId,
                        UserID = CreateUser().ID
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

        [TestMethod]
        public void ShouldCreateChat()
        {
            int usersAmount = 5;

            Chat chat = CreateChat(usersAmount);

            Chat gottenChat = DB.Chats.Include(c => c.Members).Where(c => c.ID == chat.ID).First();

            Assert.AreEqual(chat.ID, gottenChat.ID);
            Assert.AreEqual(chat.Name, gottenChat.Name);
            for (int i = 0; i < usersAmount; i++)
            {
                Assert.AreEqual(chat.Members.OrderBy(m => m.UserID).ToArray()[i].UserID, gottenChat.Members.OrderBy(m => m.UserID).ToArray()[i].UserID);
            }
        }

        [TestMethod]
        public void ShouldAddMembers()
        {
            int usersAmount = 2;

            Chat chat = CreateChat(usersAmount);
            User userToAdd = CreateUser();

            chatsRepository.AddMembers(chat.ID, new[] { userToAdd.ID });
            Chat gottenChat = DB.Chats.Include(c => c.Members).Where(c => c.ID == chat.ID).First();

            Assert.AreEqual(chat.Members.Count, gottenChat.Members.Count);
            Assert.IsTrue(gottenChat.Members.Count > usersAmount);
        }

        [TestMethod]
        public void ShouldGetUserChats()
        {
            Chat[] chats =
            {
                CreateChat(),
                CreateChat()
            };
            chats = chats.OrderBy(c => c.ID).ToArray();

            User user = CreateUser();

            chatsRepository.AddMembers(chats[0].ID, new[] { user.ID });
            chatsRepository.AddMembers(chats[1].ID, new[] { user.ID });

            var gottenChats = chatsRepository.GetUserChats(user.ID).OrderBy(c => c.ID).ToArray();

            Assert.AreEqual(chats.Length, gottenChats.Length);
            Assert.AreEqual(chats[0].ID, gottenChats[0].ID);
            Assert.AreEqual(chats[1].ID, gottenChats[1].ID);

        }

        [TestMethod]
        public void ShouldDeleteChat()
        {
            Chat chat = CreateChat();

            int countBefore = DB.Chats.Count();

            chatsRepository.DeleteChat(chat.ID);

            int countAfter = DB.Chats.Count();

            Assert.AreEqual(0, DB.Chats.Count(c => c.ID == chat.ID));
            Assert.AreNotEqual(countBefore, countAfter);
        }

        [TestMethod]
        public void ShouldChangeName()
        {
            Chat chat = CreateChat();

            chatsRepository.ChangeName(chat.ID, "changedName");

            Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);

            Assert.AreEqual("changedName", gottenChat.Name);
        }

        [TestMethod]
        public void ShouldChangeAvatar()
        {
            Chat chat = CreateChat();

            byte[] newAvatar = { 1, 2, 3, 4 };
            chatsRepository.ChangeAvatar(chat.ID, newAvatar);

            Chat gottenChat = DB.Chats.First(c=>c.ID == chat.ID);

            Assert.IsTrue(gottenChat.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldDeleteMembers()
        {
            Chat chat = CreateChat(3);

            chatsRepository.DeleteMembers(chat.ID, new[] { chat.Members.ToArray()[0].UserID });
            Chat gottenChat = DB.Chats.Include(c=>c.Members).First(c=>c.ID==chat.ID);

            Assert.IsTrue(chat.Members.Count > gottenChat.Members.Count);
        }
    }
}
