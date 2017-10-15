using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;
using System.Data.Entity;


namespace Hummingbird.DataLayer.SQL
{
    public class ChatsRepository : IChatsRepository
    {
        DatabaseContext DB = new DatabaseContext();

        public void AddMembers(Guid[] userIds)
        {
            throw new NotImplementedException();
        }

        public void ChangeAvatar(Guid chatId)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(Guid chatId)
        {
            throw new NotImplementedException();
        }

        public void Create(Chat chat)
        {
            DB.Chats.Add(chat);
            DB.SaveChanges();
        }

        public void DeleteChat(Guid chatId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMembers(Guid[] userIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> GetUserChats(Guid userId)
        {
            // UNDONE
            var chats = new List<Chat>();
            var ids = DB.ChatMembers.Where(c => c.UserID == userId);

            foreach (var i in ids)
            {
                chats.Add(DB.Chats.Where(c => c.ID == i.ChatID).First());
            }

            return chats;
        }
    }
}
