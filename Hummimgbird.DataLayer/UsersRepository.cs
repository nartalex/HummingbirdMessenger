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
            DB.Users.Where(u => u.ID == userId).First().Avatar = newAvatar;
            DB.SaveChanges();
        }

        public void ChangeNickname(Guid userId, string newNickname)
        {
            DB.Users.Where(u => u.ID == userId).First().Nickname = newNickname;
            DB.SaveChanges();
        }

        public void ChangePassword(Guid userId, string newPasswordHash)
        {
            DB.Users.Where(u => u.ID == userId).First().PasswordHash = newPasswordHash;
            DB.SaveChanges();
        }

        public void DisableUser(Guid userId)
        {
            DB.Users.Where(u => u.ID == userId).First().Disabled = true;
            DB.SaveChanges();
        }

        public User Get(Guid userId)
            => DB.Users.Where(u => u.ID == userId).First();

        public bool Login(string login, string passwordHash)
        {
            int users = DB.Users.Where(u => u.Login == login && u.PasswordHash == passwordHash).Count();

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
