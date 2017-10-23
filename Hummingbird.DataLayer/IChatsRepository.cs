using System;
using System.Collections.Generic;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IChatsRepository
    {
        object Create(Chat chat, IEnumerable<Guid> members);
        object GetUserChats(Guid userId);
        object DeleteChat(Guid chatId);
        object ChangeName(Guid chatId, string newName);
        object ChangeAvatar(Guid chatId, byte[] newAvatar);
        object AddMembers(Guid chatId, IEnumerable<Guid> userIds);
        object DeleteMembers(Guid chatId, IEnumerable<Guid> userIds);
    }
}
