using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.DataLayer;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class MessagesRepository : IMessagesRepository
    {
        DatabaseContext DB = new DatabaseContext();

        public void DeleteMessage(Guid id)
        {
            DB.Messages.Remove(DB.Messages.First(m => m.ID == id));
            DB.SaveChanges();
        }

        public void EditMessage(Guid id, Message newMessage)
        {
            Message toEdit = DB.Messages.First(m => m.ID == id);
            toEdit.Text = newMessage.Text;
            toEdit.AttachType = newMessage.AttachType;
            toEdit.AttachPath = newMessage.AttachPath;
            toEdit.Edited = true;

            DB.SaveChanges();
        }

        //UNDONE: OrderBy Time не работает
        public IEnumerable<Message> GetAmountOfMessages(Guid chatId, int amount, int skip)
            => DB.Messages
            .Where(m => m.ChatToID == chatId)
            .OrderBy(m => m.Time)
            .Skip(skip)
            .Take(amount)
            .ToArray();

        public Message GetLastMessage(Guid chatId)
            => DB.Messages
            .Where(m => m.ChatToID == chatId)
            .OrderByDescending(m => m.Time)
            .ToArray()
            .Last();

        public void SendMessage(Message message)
        {
            if (message.ID == null)
                message.ID = Guid.NewGuid();
            message.Time = DateTime.Now;
            message.Edited = false;
            DB.Messages.Add(message);
            DB.SaveChanges();
        }
    }
}
