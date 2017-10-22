using System;

using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IMessagesRepository
    {
        object GetLastMessage(Guid chatId);
        object GetAmountOfMessages(Guid chatId, int amount, int skip);
        object SendMessage(Message message);
        object DeleteMessage(Guid id);
        object EditMessage(Guid id, Message newMessage);
    }
}
