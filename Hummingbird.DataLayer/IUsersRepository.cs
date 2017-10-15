using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.Model;

namespace Hummingbird.DataLayer
{
    public interface IUsersRepository
    {
        
        void Register(User user);
        bool Login(string login, string passwordHash);
        void DisableUser(Guid userId);
        User Get(Guid userId);
        void ChangePassword(Guid userId, string newPasswordHash);
        void ChangeAvatar(Guid userId, byte[] newAvatar);
        void ChangeNickname(Guid userId, string newNickname);
    }
}
