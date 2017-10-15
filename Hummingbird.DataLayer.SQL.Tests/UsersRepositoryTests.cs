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
        List<Guid> _tempUsers = new List<Guid>();
        DatabaseContext DB = new DatabaseContext();
        UsersRepository usersRepository = new UsersRepository();


        [TestMethod]
        public void ShouldCreateUsers()
        {
            //UsersRepository usersRepository = new UsersRepository();

            var user1 = new User
            {
                ID = Guid.NewGuid(),
                Nickname = "User1",
                Login = "user1login",
                PasswordHash = "password1",
                Disabled = false
            };
            usersRepository.Register(user1);
            _tempUsers.Add(user1.ID);

            var user2 = new User
            {
                ID = Guid.NewGuid(),
                Nickname = "Пользователь2",
                Login = "user2login",
                PasswordHash = "password2",
                Disabled = false
            };
            usersRepository.Register(user2);
            _tempUsers.Add(user2.ID);

            var result = DB.Users.ToArray();

            Assert.AreEqual(user1.ID, result[0].ID);
            Assert.AreEqual(user2.ID, result[1].ID);
            Assert.AreEqual(user1.Nickname, result[0].Nickname);
            Assert.AreEqual(user2.Nickname, result[1].Nickname);
        }

        [TestMethod]
        public void ShouldLogin()
        {
            var user1 = new User
            {
                ID = Guid.NewGuid(),
                Nickname = "User1",
                Login = "user1login",
                PasswordHash = "password1",
                Disabled = false
            };
            usersRepository.Register(user1);
            _tempUsers.Add(user1.ID);

            var shouldBeSuccess = usersRepository.Login(user1.Login, user1.PasswordHash);
            var shouldBeFail = usersRepository.Login(user1.Login, user1.PasswordHash + "1");

            Assert.AreEqual(shouldBeSuccess, true);
            Assert.AreEqual(shouldBeFail, false);
        }

        [TestCleanup]
        public void Clean()
        {
            DB.Users.RemoveRange(DB.Users);
        }
    }
}
