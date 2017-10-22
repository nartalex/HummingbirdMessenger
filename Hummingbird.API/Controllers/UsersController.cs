using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hummingbird.DataLayer;
using Hummingbird.DataLayer.SQL;
using Hummingbird.Model;

namespace Hummingbird.API.Controllers
{
    public class UsersController : ApiController
    {
        UsersRepository usersRepository = new UsersRepository();

        [HttpGet]
        [Route("api/users/get/{id}")]
        public object Get(Guid id)
            => usersRepository.Get(id);

        [HttpPost]
        [Route("api/users/register")]
        public object Register([FromBody] User user)
            => usersRepository.Register(user);

        [HttpPost]
        [Route("api/users/login")]
        public object Login([FromBody] User user)
            => usersRepository.Login(user.Login, user.PasswordHash);

        [HttpPost]
        [Route("api/users/changePassword")]
        public object ChangePassword([FromBody] User user)
            => usersRepository.ChangePassword(user.ID, user.PasswordHash);

        [HttpGet]
        [Route("api/users/disable/{id}")]
        public object Disable(Guid id)
            => usersRepository.DisableUser(id);

        [HttpPost]
        [Route("api/users/changeAvatar")]
        public object ChangeAvatar([FromBody] User user)
            => usersRepository.ChangeAvatar(user.ID, user.Avatar);

        [HttpPost]
        [Route("api/users/changeNickname")]
        public object ChangeNickname([FromBody] User user)
            => usersRepository.ChangeNickname(user.ID, user.Nickname);
    }
}
