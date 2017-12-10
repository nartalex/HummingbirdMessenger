using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL.Tests
{
	[TestClass]
	public class MessagesRepositoryTests
	{
		DatabaseContext DB = new DatabaseContext();
		MessagesRepository messagesRepository = new MessagesRepository();

		[TestMethod]
		public void ShouldSendSimpleMessage()
		{
			Chat chat = Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				Text = "Текст"
			};

			var shouldBeMessage = messagesRepository.SendMessage(message);
			Assert.IsInstanceOfType(shouldBeMessage, typeof(Message));

			Message gottenMessage = DB.Messages.First(m => m.ID == shouldBeMessage.ID);

			Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
			Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
			Assert.AreEqual(message.Text, gottenMessage.Text);
			Assert.IsNotNull(gottenMessage.Time);
			Assert.AreNotEqual(gottenMessage.ID, new Guid());
		}

		[TestMethod]
		public void ShouldSendMessageWithAttach()
		{
			Chat chat = Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				AttachType = Message.AttachTypes.Image,
				Attach = new byte[] { 1, 2, 3, 4 },
				AttachName = "name"
			};

			var shouldBeMessage = messagesRepository.SendMessage(message);
			Assert.IsInstanceOfType(shouldBeMessage, typeof(Message));

			Message gottenMessage = DB.Messages.First(m => m.ID == (shouldBeMessage).ID);

			Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
			Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
			Assert.IsNotNull(gottenMessage.Time);
			Assert.IsTrue(String.IsNullOrWhiteSpace(gottenMessage.Text));
			Assert.IsTrue(gottenMessage.Attach.SequenceEqual(message.Attach));
			Assert.AreEqual("name", gottenMessage.AttachName);
		}

		[TestMethod]
		public void ShouldDeleteMessage()
		{
			Chat chat = Create.Chat();

			Message message = new Message
			{
				UserFromID = chat.Members.ToArray()[0].UserID,
				ChatToID = chat.ID,
				Text = "TextMessage"
			};

			Guid messageID = messagesRepository.SendMessage(message).ID;
			messagesRepository.DeleteMessage(messageID);

			int countAfter = DB.Messages.Count(m => m.ID == messageID);
			Assert.AreEqual(0, countAfter);
		}

		[TestMethod]
		public void ShouldGetLastMessage()
		{
			Chat chat = Create.Chat();

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

				last = messagesRepository.SendMessage(message);
			}

			Message gottenMessage = messagesRepository.GetLastMessage(chat.ID);

			Assert.AreEqual(last.ID, gottenMessage.ID);
			Assert.AreEqual(text, gottenMessage.Text);
		}

		[TestMethod]
		public void ShouldGetAmountOfMessages()
		{
			Chat chat = Create.Chat();

			for (int i = 0; i < 10; i++)
			{
				Message message = new Message
				{
					Text = "Message" + i,
					UserFromID = chat.Members.ToArray()[0].UserID,
					ChatToID = chat.ID
				};

				messagesRepository.SendMessage(message);
			}

			var messages = messagesRepository.GetAmountOfMessages(chat.ID, 0, 5);
			Assert.AreEqual(5, messages.Count());
		}
	}
}
