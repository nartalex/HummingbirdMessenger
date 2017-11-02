using System;
using System.Collections.Generic;

using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IUsersRepository
    {
        User Register(User user);
        User Login(string login, string passwordHash);
        void DisableUser(Guid userId);
        User Get(Guid userId);
        void ChangePassword(Guid userId, string newPasswordHash);
        void ChangeAvatar(Guid userId, byte[] newAvatar);
        void ChangeNickname(Guid userId, string newNickname);
        IEnumerable<User> Search(string login);
    }
}
