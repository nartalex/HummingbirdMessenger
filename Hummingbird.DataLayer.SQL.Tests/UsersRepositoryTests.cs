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
            object shouldBeUser = Create.User();

            //Assert.AreEqual(typeof(User), shouldBeUser.GetType());
            Assert.IsInstanceOfType(shouldBeUser, typeof(User));

            User user = (User)shouldBeUser;

            User result = DB.Users.Where(u => u.ID == user.ID).First();

            Assert.AreEqual(user.ID, result.ID);
            Assert.AreEqual(user.Nickname, result.Nickname);
        }

        [TestMethod]
        public void ShouldLogin()
        {
            User user = (User)Create.User();

            var shouldBeSuccess = usersRepository.Login(user.Login, user.PasswordHash);
            Assert.IsInstanceOfType(shouldBeSuccess, typeof(User));

            //Неправильный пароль
            var shouldBeFail = usersRepository.Login(user.Login, user.PasswordHash + "1");
            Assert.IsInstanceOfType(shouldBeFail, typeof(Exception));
            Assert.AreEqual("Password is incorrect", ((Exception)shouldBeFail).Message);

            //Неправильный логин
            var shouldBeFail2 = usersRepository.Login(user.Login + 1, user.PasswordHash);
            Assert.IsInstanceOfType(shouldBeFail2, typeof(Exception));
            Assert.AreEqual("Login is incorrect", ((Exception)shouldBeFail2).Message);
        }
        /*
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

       */
    }
}
