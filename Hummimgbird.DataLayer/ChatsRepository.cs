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

        public void AddMembers(Guid chatId, Guid[] userIds)
        {
            foreach (var u in userIds)
            {
                ChatMember member = new ChatMember
                {
                    ChatID = chatId,
                    UserID = u
                };
                DB.ChatMembers.Add(member);
            }
            DB.SaveChanges();
        }

        public void ChangeAvatar(Guid chatId, byte[] newAvatar)
        {
            DB.Chats.First(c => c.ID == chatId).Avatar = newAvatar;
            DB.SaveChanges();
        }

        public void ChangeName(Guid chatId, string newName)
        {
            DB.Chats.First(c => c.ID == chatId).Name = newName;
            DB.SaveChanges();
        }

        public void Create(Chat chat)
        {
            DB.Chats.Add(chat);
            DB.SaveChanges();
        }

        public void DeleteChat(Guid chatId)
        {
            DB.Messages.RemoveRange(DB.Messages.Where(c => c.ChatToID == chatId));
            DB.Chats.Remove(DB.Chats.First(c => c.ID == chatId));
            DB.SaveChanges();
        }

        public void DeleteMembers(Guid chatId, Guid[] userIds)
        {
            foreach(var u in userIds)
            {
                DB.ChatMembers.Remove(DB.ChatMembers.First(m => m.UserID == u && m.ChatID == chatId));
            }
            DB.SaveChanges();
        }

        public IEnumerable<Chat> GetUserChats(Guid userId)
        {
            // UNDONE
            var chats = new List<Chat>();
            var ids = DB.ChatMembers.Where(c => c.UserID == userId);

            foreach (var i in ids)
            {
                chats.Add(DB.Chats.First(c => c.ID == i.ChatID));
            }

            return chats;
        }
    }
}
