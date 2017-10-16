using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hummingbird.DataLayer;
using Hummingbird.Model;
using System.Data.Entity;


namespace Hummingbird.DataLayer.SQL
{
    public class UsersRepository : IUsersRepository
    {
        DatabaseContext DB = new DatabaseContext();

        public void ChangeAvatar(Guid userId, byte[] newAvatar)
        {
            DB.Users.First(u => u.ID == userId).Avatar = newAvatar;
            DB.SaveChanges();
        }

        public void ChangeNickname(Guid userId, string newNickname)
        {
            DB.Users.First(u => u.ID == userId).Nickname = newNickname;
            DB.SaveChanges();
        }

        public void ChangePassword(Guid userId, string newPasswordHash)
        {
            DB.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
            DB.SaveChanges();
        }

        public void DisableUser(Guid userId)
        {
            DB.Users.First(u => u.ID == userId).Disabled = true;
            DB.SaveChanges();
        }

        public User Get(Guid userId)
            => DB.Users.First(u => u.ID == userId);

        public bool Login(string login, string passwordHash)
        {
            int users = DB.Users.Count(u => u.Login == login && u.PasswordHash == passwordHash);

            if (users > 1)
                throw new Exception("More than one user found.");
            else
                return Convert.ToBoolean(users);
        }

        public void Register(User user)
        {
            DB.Users.Add(user);
            DB.SaveChanges();
        }
    }
}
