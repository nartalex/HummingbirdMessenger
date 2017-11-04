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
        public Chat Create([FromBody] Chat chat)
            => _chatsRepository.Create(chat, chat.Members.Select(m => m.UserID));

        [HttpGet, Route("api/chats/{id}")]
        public Chat GetChat(Guid id) 
            => _chatsRepository.GetChat(id);

        [HttpDelete, Route("api/chats/{id}")]
        public void DeleteChat(Guid id)
            => _chatsRepository.DeleteChat(id);

        [HttpGet, Route("api/chats/userchats/{id}")]
        public IEnumerable<Chat> GetUserChats(Guid id)
            => _chatsRepository.GetUserChats(id);

        [HttpPost, Route("api/chats/addMembers")]
        public void AddMembers([FromBody] Chat chat)
            => _chatsRepository.AddMembers(chat.ID, chat.Members.Select(m => m.UserID));

        [HttpPost, Route("api/chats/deleteMembers")]
        public void DeleteMembers([FromBody] Chat chat)
            => _chatsRepository.DeleteMembers(chat.ID, chat.Members.Select(m => m.UserID));

        [HttpPost, Route("api/chats/changeAvatar")]
        public void ChangeAvatar([FromBody] Chat chat)
            => _chatsRepository.ChangeAvatar(chat.ID, chat.Avatar);

        [HttpPost, Route("api/chats/changeName")]
        public void ChangeName([FromBody] Chat chat)
            => _chatsRepository.ChangeName(chat.ID, chat.Name);
    }
}
