using System;

using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IUsersRepository
    {       
        object Register(User user, bool test);
        object Login(string login, string passwordHash);
        object DisableUser(Guid userId);
        object Get(Guid userId);
        object ChangePassword(Guid userId, string newPasswordHash);
        object ChangeAvatar(Guid userId, byte[] newAvatar);
        object ChangeNickname(Guid userId, string newNickname);
    }
}
