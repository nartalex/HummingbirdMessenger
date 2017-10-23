using System;
using System.Web.Http;
using Hummingbird.DataLayer.SQL;
using Hummingbird.Model;

namespace Hummingbird.API.Controllers
{
    public class UsersController : ApiController
    {
        readonly UsersRepository _usersRepository = new UsersRepository();

        [HttpGet, Route("api/users/{id}")]
        public object Get(Guid id)
            => _usersRepository.Get(id);

        [HttpDelete, Route("api/users/{id}")]
        public object Disable(Guid id)
            => _usersRepository.DisableUser(id);

        [HttpPost, Route("api/users/register")]
        public object Register([FromBody] User user)
            => _usersRepository.Register(user);

        [HttpPost, Route("api/users/login")]
        public object Login([FromBody] User user)
            => _usersRepository.Login(user);

        [HttpPost, Route("api/users/changePassword")]
        public object ChangePassword([FromBody] User user)
            => _usersRepository.ChangePassword(user);

        [HttpPost, Route("api/users/changeAvatar")]
        public object ChangeAvatar([FromBody] User user)
            => _usersRepository.ChangeAvatar(user);

        [HttpPost, Route("api/users/changeNickname")]
        public object ChangeNickname([FromBody] User user)
            => _usersRepository.ChangeNickname(user);
    }
}
