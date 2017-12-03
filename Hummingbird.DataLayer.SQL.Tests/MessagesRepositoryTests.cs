using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;
using System.Threading;

namespace Hummingbird.DataLayer.SQL.Tests
{
	[TestClass]
	public class MessagesRepositoryTests
	{
		DatabaseContext DB = new DatabaseContext();
		ChatsRepository chatsRepository = new ChatsRepository();
		UsersRepository usersRepository = new UsersRepository();
		MessagesRepository messagesRepository = new MessagesRepository();

		[TestMethod]
		public void MessagesSending()
		{
			var user1 = DB.Users.First(x => x.Login.Contains("Nartalex"));
			var user2 = DB.Users.First(x => x.Login.Contains("orange"));
			var chatid = DB.ChatMembers.First(x => x.UserID == user1.ID).ChatID;

			for (int i = 0; i < 20; i++)
			{
				Message m = new Message()
				{
					ChatToID = chatid,
					Text = "message" + i,
					UserFromID = i % 4 == 0 ? user1.ID : user2.ID
				};

				messagesRepository.SendMessage(m);

				Thread.Sleep(2000);
			}
		}

		[TestMethod]
		public void ShouldSendSimpleMessage()
		{
			Chat chat = (Chat)Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				Text = "Текст"
			};

			var shouldBeMessage = messagesRepository.SendMessage(message);
			Assert.IsInstanceOfType(shouldBeMessage, typeof(Message));

			Message gottenMessage = DB.Messages.First(m => m.ID == ((Message)shouldBeMessage).ID);

			Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
			Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
			Assert.AreEqual(message.Text, gottenMessage.Text);
			Assert.IsNotNull(gottenMessage.Time);
			Assert.IsNotNull(gottenMessage.ID);
		}

		[TestMethod]
		public void ShouldSendMessageWithAttach()
		{
			Chat chat = (Chat)Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				AttachType = Message.AttachTypes.Image,
				//AttachPath = "path"
			};

			var shouldBeMessage = messagesRepository.SendMessage(message);
			Assert.IsInstanceOfType(shouldBeMessage, typeof(Message));

			Message gottenMessage = DB.Messages.First(m => m.ID == ((Message)shouldBeMessage).ID);

			Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
			Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
			Assert.IsNotNull(gottenMessage.Time);
			Assert.IsNull(gottenMessage.Text);
			//Assert.AreEqual("path", gottenMessage.AttachPath);
		}

		[TestMethod]
		public void ShouldDeleteMessage()
		{
			Chat chat = (Chat)Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				Text = "TextMessage"
			};

			var shouldBeMessage = messagesRepository.SendMessage(message);
			Assert.IsInstanceOfType(shouldBeMessage, typeof(Message));
			Guid messageID = ((Message)shouldBeMessage).ID;

			int countBefore = DB.Messages.Count(m => m.ID == messageID);
			Assert.AreEqual(1, countBefore);

			//var shouldBeTrue = messagesRepository.DeleteMessage(messageID);
			//Assert.AreEqual(true, shouldBeTrue);

			int countAfter = DB.Messages.Count(m => m.ID == messageID);
			Assert.AreEqual(0, countAfter);
		}



		[TestMethod]
		public void ShouldEditMessage()
		{
			Chat chat = (Chat)Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				Text = "TextMessage"
			};

			message = (Message)messagesRepository.SendMessage(message);

			message.AttachType = Message.AttachTypes.Image;
		//message.AttachPath = "path";

			//var shouldBeTrue = messagesRepository.EditMessage(message);
			//Assert.AreEqual(true, shouldBeTrue);

			Message gottenMessage = DB.Messages.First(m => m.ID == message.ID);
			//Assert.IsNotNull(gottenMessage.AttachPath);
		}

		[TestMethod]
		public void ShouldGetLastMessage()
		{
			Chat chat = (Chat)Create.Chat();

			Message last = null;
			string text = String.Empty;
			for (int i = 0; i < 10; i++)
			{
				Message message = new Message
				{
					ID = Guid.NewGuid(),
					Text = "Message" + i,
					UserFromID = chat.Members.ToArray()[0].UserID,
					ChatToID = chat.ID
				};

				text = message.Text;

				last = (Message)messagesRepository.SendMessage(message);
			}

			Message gottenMessage = (Message)messagesRepository.GetLastMessage(chat.ID);

			Assert.AreEqual(last.ID, gottenMessage.ID);
			Assert.AreEqual(text, gottenMessage.Text);
		}

		[TestMethod]
		public void ShouldGetAmountOfMessages()
		{
			Chat chat = (Chat)Create.Chat();

			for (int i = 0; i < 10; i++)
			{
				Message message = new Message
				{
					Text = "Message" + i,
					UserFromID = chat.Members.ToArray()[0].UserID,
					ChatToID = chat.ID
				};

				messagesRepository.SendMessage(message);

				Thread.Sleep(2000);
			}
		}
	}
}
