using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    interface IMessagesRepository
    {
        Message GetLastMessage(Guid userId, Guid chatId);
        IEnumerable<Message> GetAmountOfMessages(Guid chatId, int amount);
        void DeleteMessage(Guid id);
        void EditMessage(Guid id);
    }
}
