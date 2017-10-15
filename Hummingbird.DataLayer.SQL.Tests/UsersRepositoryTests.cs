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

        [TestMethod]
        public void ShouldDisable()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user);
            usersRepository.DisableUser(userId);

            User gottenUser = DB.Users.Where(u => u.ID == userId).First();

            Assert.AreEqual(true, gottenUser.Disabled);
        }


        [TestMethod]
        public void ShouldGetUser()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user);

            User gottenUser = DB.Users.Where(u => u.ID == userId).First();

            Assert.AreEqual(user.Login, gottenUser.Login);
        }

        [TestMethod]
        public void ShouldChangePassword()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user);
            usersRepository.ChangePassword(userId, "password2");

            User gottenUser = DB.Users.Where(u => u.ID == userId).First();

            Assert.AreEqual("password2", gottenUser.PasswordHash);
        }

        [TestMethod]
        public void ShouldChangeAvatar()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user);

            byte[] newAvatar = { 1, 2, 3, 4 };
            usersRepository.ChangeAvatar(userId, newAvatar);

            User gottenUser = DB.Users.Where(u => u.ID == userId).First();

            //Assert.AreEqual(newAvatar,  gottenUser.Avatar);
            Assert.IsTrue(gottenUser.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldChangeNickname()
        {
            var userId = Guid.NewGuid();
            var user = new User
            {
                ID = userId,
                Nickname = "User1",
                Login = userId.ToString(),
                PasswordHash = "password1",
                Disabled = false
            };

            usersRepository.Register(user);
            usersRepository.ChangeNickname(userId, "ChangedNickname");

            User gottenUser = DB.Users.Where(u => u.ID == userId).First();

            Assert.AreEqual("ChangedNickname", gottenUser.Nickname);
        }
    }
}
