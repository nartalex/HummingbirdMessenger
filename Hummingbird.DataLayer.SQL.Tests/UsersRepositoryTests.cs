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
        DatabaseContext DB = new DatabaseContext();
        UsersRepository usersRepository = new UsersRepository();

        private User CreateUser()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "TestUser",
                Login = userId.ToString(),
                PasswordHash = "TestPassword",
                Disabled = false
            };
            usersRepository.Register(user);
            return user;
        }

        [TestMethod]
        public void ShouldCreateUsers()
        {
            var user = CreateUser();

            User result = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual(user.ID, result.ID);
            Assert.AreEqual(user.Nickname, result.Nickname);
        }

        [TestMethod]
        public void ShouldLogin()
        {
            User user = CreateUser();

            var shouldBeSuccess = usersRepository.Login(user.Login, user.PasswordHash);
            var shouldBeFail = usersRepository.Login(user.Login, user.PasswordHash + "1");

            Assert.AreEqual(shouldBeSuccess, true);
            Assert.AreEqual(shouldBeFail, false);
        }

        [TestMethod]
        public void ShouldDisable()
        {
            var user = CreateUser();

            usersRepository.DisableUser(user.ID);

            User gottenUser = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual(true, gottenUser.Disabled);
        }

        [TestMethod]
        public void ShouldGetUser()
        {
            var user = CreateUser();

            User gottenUser = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual(user.Login, gottenUser.Login);
        }

        [TestMethod]
        public void ShouldChangePassword()
        {
            var user = CreateUser();

            usersRepository.ChangePassword(user.ID, "password2");

            User gottenUser = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual("password2", gottenUser.PasswordHash);
        }

        [TestMethod]
        public void ShouldChangeAvatar()
        {
            var user = CreateUser();

            byte[] newAvatar = { 1, 2, 3, 4 };
            usersRepository.ChangeAvatar(user.ID, newAvatar);

            User gottenUser = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.IsTrue(gottenUser.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldChangeNickname()
        {
            var user = CreateUser();

            usersRepository.ChangeNickname(user.ID, "ChangedNickname");

            User gottenUser = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual("ChangedNickname", gottenUser.Nickname);
        }
    }
}
