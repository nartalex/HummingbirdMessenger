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

		[TestMethod]
		public void ShouldCreateChat()
		{
			int usersAmount = 5;

			var chat = Create.Chat(usersAmount);
			Assert.IsInstanceOfType(chat, typeof(Chat));
			Assert.AreEqual("TestChat", chat.Name);
			Assert.AreEqual(0, chat.Messages.Count);
			Assert.AreNotEqual(new Guid(), chat.ID);
			Assert.AreEqual(usersAmount, chat.Members.Count);
		}

		[TestMethod]
		public void ShouldAddMembers()
		{
			int usersAmount = 2;

			Chat chat = Create.Chat(usersAmount);
			User userToAdd = Create.User();

			chatsRepository.AddMembers(chat.ID, new[] { userToAdd.ID });
			Chat gottenChat = DB.Chats.Include(c => c.Members).First(c => c.ID == chat.ID);

			Assert.IsTrue(gottenChat.Members.Count > usersAmount);
		}

		[TestMethod]
		public void ShouldDeleteMembers()
		{
			int usersBefore = 3;
			Chat chat = Create.Chat(usersBefore);

			chatsRepository.DeleteMembers(chat.ID, new[] { chat.Members.ToArray()[0].UserID });
			Chat gottenChat = DB.Chats.Include(c => c.Members).First(c => c.ID == chat.ID);

			Assert.IsTrue(usersBefore > gottenChat.Members.Count);
		}

		[TestMethod]
		public void ShouldGetUserChats()
		{
			Chat[] chats =
			{
				Create.Chat(),
				Create.Chat()
			};
			chats = chats.OrderBy(c => c.ID).ToArray();

			User user = Create.User();

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
			Chat chat = Create.Chat();

			chatsRepository.DeleteChat(chat.ID);

			Assert.AreEqual(0, DB.Chats.Count(c => c.ID == chat.ID));

			try
			{
				chatsRepository.GetChat(chat.ID);
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void ShouldChangeName()
		{
			Chat chat = Create.Chat();

			chatsRepository.ChangeName(chat.ID, "changedName");

			Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);
			Assert.AreEqual("changedName", gottenChat.Name);
		}

		[TestMethod]
		public void ShouldChangeAvatar()
		{
			Chat chat = Create.Chat();

			byte[] newAvatar = { 1, 2, 3, 4 };
			chatsRepository.ChangeAvatar(chat.ID, newAvatar);

			Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);
			Assert.IsTrue(gottenChat.Avatar.SequenceEqual(newAvatar));
		}

		[TestMethod]
		public void ShouldChangeTTL()
		{
			Chat chat = Create.Chat();

			int newTTL = 10;
			chatsRepository.ChangeTTL(chat.ID, newTTL);

			Chat gottenChat = DB.Chats.First(c => c.ID == chat.ID);
			Assert.AreEqual(newTTL, gottenChat.TimeToLive);
		}
	}
}
