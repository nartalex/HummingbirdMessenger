using Hummingbird.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hummingbird.DataLayer.SQL;

namespace Hummingbird.API.Controllers
{
    public class MessagesController : ApiController
    {
        MessagesRepository _messagesRepository = new MessagesRepository();

        [HttpPost, Route("api/messages/send")]
        public Message SendMessage([FromBody] Message message)
            => _messagesRepository.SendMessage(message);

        [HttpDelete, Route("api/messages/{id}")]
        public void DeleteMessage(Guid id)
            => _messagesRepository.DeleteMessage(id);

        [HttpPost, Route("api/messages/edit")]
        public void EditMessage([FromBody] Message edits)
            => _messagesRepository.EditMessage(edits);

        [HttpGet, Route("api/messages/last/{chatId}")]
        public Message LastMessage(Guid chatId)
            => _messagesRepository.GetLastMessage(chatId);

        [HttpGet, Route("api/messages/{chatId}/{skip}/{amount}")]
        public IEnumerable<Message> GetMessages(Guid chatId, int skip, int amount)
            => _messagesRepository.GetAmountOfMessages(chatId, skip, amount);
    }
}
