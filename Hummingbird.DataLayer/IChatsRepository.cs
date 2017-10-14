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
        void ChangeName(Guid chatId);
        void ChangeAvatar(Guid chatId);
        void AddMembers(Guid[] userIds);
        void DeleteMembers(Guid[] userIds);
    }
}
