using System;
using System.Collections.Generic;

using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IMessagesRepository
    {
        Message GetLastMessage(Guid chatId);
        IEnumerable<Message> GetAmountOfMessages(Guid chatId, int amount, int skip);
        Message SendMessage(Message message);
        void DeleteMessage(Guid id);
        void EditMessage(Message edits);
    }
}
