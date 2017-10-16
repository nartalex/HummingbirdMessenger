using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;
using Hummingbird.DataLayer.SQL;
using System.Data.Entity;
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
        public void ShouldSendSimpleMessage()
        {
            Chat chat = Create.Chat();

            Message message = new Message
            {
                ID = Guid.NewGuid(),
                UserFromID = chat.Members.ToArray()[0].UserID,
                ChatToID = chat.ID,
                Text = "TextMessage"
            };

            messagesRepository.SendMessage(message);

            Message gottenMessage = DB.Messages.First(m => m.ID == message.ID);

            Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
            Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
            Assert.IsTrue(gottenMessage.Time != null);
            Assert.AreEqual(message.Text, gottenMessage.Text);
        }

        [TestMethod]
        public void ShouldSendMessageWithAttach()
        {
            Chat chat = Create.Chat();

            Message message = new Message
            {
                ID = Guid.NewGuid(),
                UserFromID = chat.Members.ToArray()[0].UserID,
                ChatToID = chat.ID,
                AttachType = Message.AttachTypes.Image,
                AttachPath = "path"
            };

            messagesRepository.SendMessage(message);

            Message gottenMessage = DB.Messages.First(m => m.ID == message.ID);

            Assert.AreEqual(chat.ID, gottenMessage.ChatToID);
            Assert.AreEqual(message.UserFromID, gottenMessage.UserFromID);
            Assert.IsNotNull(gottenMessage.Time);
            Assert.IsNull(gottenMessage.Text);
            Assert.AreEqual("path", gottenMessage.AttachPath);

        }

        [TestMethod]
        public void ShouldDeleteMessage()
        {
            Chat chat = Create.Chat();

            Message message = new Message
            {
                ID = Guid.NewGuid(),
                UserFromID = chat.Members.ToArray()[0].UserID,
                ChatToID = chat.ID,
                Text = "TextMessage"
            };

            messagesRepository.SendMessage(message);

            int countBefore = DB.Messages.Count(m => m.ID == message.ID);

            messagesRepository.DeleteMessage(message.ID);

            int countAfter = DB.Messages.Count(m => m.ID == message.ID);

            Assert.AreEqual(1, countBefore);
            Assert.AreEqual(0, countAfter);
        }

        [TestMethod]
        public void ShouldEditMessage()
        {
            Chat chat = Create.Chat();

            Message message = new Message
            {
                ID = Guid.NewGuid(),
                UserFromID = chat.Members.ToArray()[0].UserID,
                ChatToID = chat.ID,
                Text = "TextMessage"
            };

            messagesRepository.SendMessage(message);

            message.AttachType = Message.AttachTypes.Image;
            message.AttachPath = "path";

            messagesRepository.EditMessage(message.ID, message);

            Message gottenMessage = DB.Messages.First(m => m.ID == message.ID);

            Assert.IsNotNull(gottenMessage.AttachPath);
        }

        [TestMethod]
        public void ShouldGetLastMessage()
        {
            Chat chat = Create.Chat();

            Guid id = Guid.Empty;
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

                id = message.ID;
                text = message.Text;

                messagesRepository.SendMessage(message);
            }

            Message gottenMessage = messagesRepository.GetLastMessage(chat.ID);

            Assert.AreEqual(id, gottenMessage.ID);
            Assert.AreEqual(text, gottenMessage.Text);
        }

        [TestMethod]
        public void ShouldGetAmountOfMessages()
        {
            Chat chat = Create.Chat();

            string text7 = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                Message message = new Message
                {
                    ID = Guid.NewGuid(),
                    Text = "Message" + i,
                    UserFromID = chat.Members.ToArray()[0].UserID,
                    ChatToID = chat.ID
                };

                if (i == 7)
                    text7 = message.Text;

                messagesRepository.SendMessage(message);

                Thread.Sleep(2000);
            }

            Message[] gottenMessages = messagesRepository.GetAmountOfMessages(chat.ID, 5, 2).ToArray();

            Assert.AreEqual(5, gottenMessages.Length);
        }
    }
}
