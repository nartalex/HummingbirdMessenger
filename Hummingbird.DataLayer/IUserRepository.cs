using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IUserRepository
    {
        void Register(User user);
        void Login(string login, string passwordHash);
        void DesableUser(Guid userId);
        User Get(Guid userId);
        void ChangePassword(Guid userId, string newPasswordHash);
        void ChangeAvatar(Guid userId, byte[] newAvatar);
        void ChangeNickname(Guid userId, string newNickname);
    }
}
