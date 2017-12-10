using System;
using System.Collections.Generic;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IChatsRepository
    {
        Chat Create(Chat chat);
        IEnumerable<Chat> GetUserChats(Guid userId);
        void DeleteChat(Guid chatId);
        void ChangeName(Guid chatId, string newName);
        void ChangeAvatar(Guid chatId, byte[] newAvatar);
        void AddMembers(Guid chatId, IEnumerable<Guid> userIdsEnum);
        void DeleteMembers(Guid chatId, IEnumerable<Guid> userIdsEnum);
    }
}
