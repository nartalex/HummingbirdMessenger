using System;
using System.Web.Http;
using Hummingbird.DataLayer.SQL;
using Hummingbird.Model;
using System.Collections.Generic;

namespace Hummingbird.API.Controllers
{
    public class UsersController : ApiController
    {
        readonly UsersRepository _usersRepository = new UsersRepository();

        [HttpGet, Route("api/users/{id}")]
        public User Get(Guid id)
            => _usersRepository.Get(id);

        [HttpDelete, Route("api/users/{id}")]
        public void Disable(Guid id)
            => _usersRepository.DisableUser(id);

        [HttpPost, Route("api/users/register")]
        public User Register([FromBody] User user)
            => _usersRepository.Register(user);

        [HttpPost, Route("api/users/login")]
        public User Login([FromBody] User user)
            => _usersRepository.Login(user.Login, user.PasswordHash);

        [HttpPost, Route("api/users/changePassword")]
        public void ChangePassword([FromBody] User user)
            => _usersRepository.ChangePassword(user.ID, user.PasswordHash);

        [HttpPost, Route("api/users/changeAvatar")]
        public void ChangeAvatar([FromBody] User user)
            => _usersRepository.ChangeAvatar(user.ID, user.Avatar);

        [HttpPost, Route("api/users/changeNickname")]
        public void ChangeNickname([FromBody] User user) 
            => _usersRepository.ChangeNickname(user.ID, user.Nickname);

        [HttpGet, Route("api/users/search/{login}")]
        public IEnumerable<User> Search(string login) 
            => _usersRepository.Search(login);

    }
}
