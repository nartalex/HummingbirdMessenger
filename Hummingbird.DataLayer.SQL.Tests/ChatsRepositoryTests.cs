using System;
using System.Linq;
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

        [TestMethod]
        public void ShouldCreateChat()
        {
            int usersAmount = 5;

            var shouldBeChat = Create.Chat(usersAmount);
            Assert.IsInstanceOfType(shouldBeChat, typeof(Chat));

            Chat chat = (Chat)shouldBeChat;

            Chat gottenChat = DB.Chats.Include(c => c.Members).First(c => c.ID == chat.ID);

            Assert.AreEqual(chat.ID, gottenChat.ID);
            Assert.AreEqual(chat.Name, gottenChat.Name);
            for (int i = 0; i < usersAmount; i++)
            {
                Assert.AreEqual(
                    chat.Members.OrderBy(m => m.UserID).ToArray()[i].UserID,
                    gottenChat.Members.OrderBy(m => m.UserID).ToArray()[i].UserID
                    );
            }
        }

        [TestMethod]
        public void ShouldAddMembers()
        {
            int usersAmount = 2;

            Chat chat = (Chat)Create.Chat(usersAmount);
            User userToAdd = (User)Create.User();

            var shouldBeTrue = chatsRepository.AddMembers(chat.ID, new[] { userToAdd.ID });
            Assert.AreEqual(true, shouldBeTrue);
            Chat gottenChat = DB.Chats.Include(c => c.Members).First(c => c.ID == chat.ID);

            Assert.IsTrue(gottenChat.Members.Count > usersAmount);
        }

        [TestMethod]
        public void ShouldGetUserChats()
        {
            Chat[] chats =
            {
                (Chat)Create.Chat(),
                (Chat)Create.Chat()
            };
            chats = chats.OrderBy(c => c.ID).ToArray();

            User user = (User)Create.User();

            var shouldBeTrue = chatsRepository.AddMembers(chats[0].ID, new[] { user.ID });
            var shouldBeTrue2 = chatsRepository.AddMembers(chats[1].ID, new[] { user.ID });
            Assert.AreEqual(true, shouldBeTrue);
            Assert.AreEqual(true, shouldBeTrue2);

            var gottenChats = ((Chat[])chatsRepository.GetUserChats(user.ID)).OrderBy(c => c.ID).ToArray();

            Assert.AreEqual(chats.Length, gottenChats.Length);
            Assert.AreEqual(chats[0].ID, gottenChats[0].ID);
            Assert.AreEqual(chats[1].ID, gottenChats[1].ID);
        }

        [TestMethod]
        public void ShouldDeleteChat()
        {
            Chat chat = (Chat)Create.Chat();

            int countBefore = DB.Chats.Count();

            chatsRepository.DeleteChat(chat.ID);

            int countAfter = DB.Chats.Count();

            Assert.AreEqual(0, DB.Chats.Count(c => c.ID == chat.ID));
            Assert.AreNotEqual(countBefore, countAfter);

            var shouldBeException = chatsRepository.GetChat(chat.ID);
            Assert.IsInstanceOfType(shouldBeException, typeof(Exception));
        }

        [TestMethod]
        public void ShouldChangeName()
        {
            Chat chat = (Chat)Create.Chat();

            var shouldBeTrue = chatsRepository.ChangeName(chat.ID, "changedName");
            Assert.AreEqual(true, shouldBeTrue);

            Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);
            Assert.AreEqual("changedName", gottenChat.Name);
        }

        [TestMethod]
        public void ShouldChangeAvatar()
        {
            Chat chat = (Chat)Create.Chat();

            byte[] newAvatar = { 1, 2, 3, 4 };
            var shouldBeTrue = chatsRepository.ChangeAvatar(chat.ID, newAvatar);
            Assert.AreEqual(true, shouldBeTrue);

            Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);
            Assert.IsTrue(gottenChat.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldDeleteMembers()
        {
            int usersBefore = 3;
            Chat chat = (Chat)Create.Chat(usersBefore);

            var shouldBeTrue = chatsRepository.DeleteMembers(chat.ID, new[] { chat.Members.ToArray()[0].UserID });
            Assert.AreEqual(true, shouldBeTrue);

            Chat gottenChat = DB.Chats.Include(c => c.Members).First(c => c.ID == chat.ID);
            Assert.IsTrue(usersBefore > gottenChat.Members.Count);
        }

    }
}
