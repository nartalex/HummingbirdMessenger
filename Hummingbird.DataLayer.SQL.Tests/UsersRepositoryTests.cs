using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;
using Hummingbird.DataLayer.SQL;
using System.Data.Entity;

namespace Hummingbird.DataLayer.SQL.Tests
{
    [TestClass]
    public class UsersRepositoryTests
    {
        List<User> _tempUsers = new List<User>();
        DatabaseContext DB = new DatabaseContext();
        UsersRepository usersRepository = new UsersRepository();

        [TestMethod]
        public void ShouldCreateUsers()
        {
            var userId = Guid.NewGuid();
            var user1 = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user1);

            User result = DB.Users.Where(u => u.ID == user1.ID).First();

            Assert.AreEqual(user1.ID, result.ID);
            Assert.AreEqual(user1.Nickname, result.Nickname);
        }

        [TestMethod]
        public void ShouldLogin()
        {
            User def = DB.Users.Where(u => u.Login == "Default").First();

            var shouldBeSuccess = usersRepository.Login(def.Login, def.PasswordHash);
            var shouldBeFail = usersRepository.Login(def.Login, def.PasswordHash + "1");

            Assert.AreEqual(shouldBeSuccess, true);
            Assert.AreEqual(shouldBeFail, false);
        }

        [TestCleanup]
        public void Clean()
        {
            DB.Users.RemoveRange(DB.Users);
        }

        void ClearTable()
        {
            foreach (var i in DB.Users)
            {
                DB.Users.Remove(i);
            }
            DB.SaveChanges();
        }
    }
}
