using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IChatsRepository
    {
        void Create(Chat chat);
        IEnumerable<Chat> GetUserChats(Guid userId);
        void DeleteChat(Guid chatId);
        void ChangeName(Guid chatId, string newName);
        void ChangeAvatar(Guid chatId, byte[] newAvatar);
        void AddMembers(Guid chatId, Guid[] userIds);
        void DeleteMembers(Guid chatId, Guid[] userIds);
    }
}
