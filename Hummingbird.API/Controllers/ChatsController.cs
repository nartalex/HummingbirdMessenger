using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hummingbird.Model;
using Hummingbird.DataLayer;
using Hummingbird.DataLayer.SQL;

namespace Hummingbird.API.Controllers
{
    public class ChatsController : ApiController
    {
        private readonly ChatsRepository _chatsRepository = new ChatsRepository();

        [HttpPost, Route("api/chats/create")]
        public object Create([FromBody] Chat chat)
            => _chatsRepository.Create(chat);

        [HttpGet, Route("api/chats/{id}")]
        public object GetChat(Guid id) 
            => _chatsRepository.GetChat(id);

        [HttpDelete, Route("api/chats/{id}")]
        public object DeleteChat(Guid id)
            => _chatsRepository.DeleteChat(id);

        [HttpGet, Route("api/chats/userchats/{id}")]
        public object GetUserChats(Guid id)
            => _chatsRepository.GetUserChats(id);

        [HttpPost, Route("api/chats/addMembers")]
        public object AddMembers([FromBody] Chat chat)
            => _chatsRepository.AddMembers(chat);

        [HttpPost, Route("api/chats/deleteMembers")]
        public object DeleteMembers([FromBody] Chat chat)
            => _chatsRepository.DeleteMembers(chat);

        [HttpPost, Route("api/chats/changeAvatar")]
        public object ChangeAvatar([FromBody] Chat chat)
            => _chatsRepository.ChangeAvatar(chat);

        [HttpPost, Route("api/chats/changeName")]
        public object ChangeName([FromBody] Chat chat)
            => _chatsRepository.ChangeName(chat);
    }
}
