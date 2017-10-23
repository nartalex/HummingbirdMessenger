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
        public object SendMessage(Message message)
            => _messagesRepository.SendMessage(message);

        [HttpDelete, Route("api/messages/{id}")]
        public object DeleteMessage(Guid id)
            => _messagesRepository.DeleteMessage(id);

        [HttpPost, Route("api/messages/edit")]
        public object EditMessage(Message edits)
            => _messagesRepository.EditMessage(edits);

        [HttpGet, Route("api/messages/last/{id}")]
        public object LastMessage(Guid chatId)
            => _messagesRepository.GetLastMessage(chatId);

        [HttpGet, Route("api/messages/{chatId}/{skip}/{amount}")]
        public object GetMessages(Guid chatId, int skip, int amount)
            => _messagesRepository.GetAmountOfMessages(chatId, skip, amount);


    }
}
