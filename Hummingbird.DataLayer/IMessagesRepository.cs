using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IMessagesRepository
    {
        Message GetLastMessage(Guid chatId);
        IEnumerable<Message> GetAmountOfMessages(Guid chatId, int amount, int skip);
        void SendMessage(Message message);
        void DeleteMessage(Guid id);
        void EditMessage(Guid id, Message newMessage);
    }
}
