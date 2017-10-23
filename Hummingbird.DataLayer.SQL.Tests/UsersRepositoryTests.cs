using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL.Tests
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private readonly DatabaseContext DB = new DatabaseContext();
        private readonly UsersRepository usersRepository = new UsersRepository();

        [TestMethod]
        public void ShouldCreateUsers()
        {
            object shouldBeUser = Create.User();

            //Assert.AreEqual(typeof(User), shouldBeUser.GetType());
            Assert.IsInstanceOfType(shouldBeUser, typeof(User));

            User user = (User)shouldBeUser;

            User result = DB.Users.First(u => u.ID == user.ID);

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

        [TestMethod]
        public void ShouldDisable()
        {
            var user = Create.User();

            var shouldBeTrue = usersRepository.DisableUser(((User)user).ID);
            Assert.AreEqual(true, shouldBeTrue);

            User gottenUser = DB.Users.First(u => u.ID == ((User)user).ID);
            Assert.AreEqual(true, gottenUser.Disabled);
        }

        [TestMethod]
        public void ShouldGetUser()
        {
            var user = Create.User();

            var shouldBeUser = usersRepository.Get(((User)user).ID);
            Assert.IsInstanceOfType(shouldBeUser, typeof(User));
            Assert.AreEqual(((User)user).Login, ((User)shouldBeUser).Login);

            var shouldBeException = usersRepository.Get(Guid.NewGuid());
            Assert.IsInstanceOfType(shouldBeException, typeof(Exception));
            Assert.AreEqual("No user found", ((Exception)shouldBeException).Message);
        }

        [TestMethod]
        public void ShouldChangePassword()
        {
            User user = (User)Create.User();

            var shouldBeTrue = usersRepository.ChangePassword(user.ID, "password2");
            Assert.AreEqual(true, shouldBeTrue);

            User gottenUser = DB.Users.First(u => u.ID == user.ID);
            Assert.AreEqual("password2", gottenUser.PasswordHash);
        }
        
        [TestMethod]
        public void ShouldChangeAvatar()
        {
            User user = (User)Create.User();

            byte[] newAvatar = { 1, 2, 3, 4 };
            var shouldBeTrue = usersRepository.ChangeAvatar(user.ID, newAvatar);
            Assert.AreEqual(true, shouldBeTrue);

            User gottenUser = DB.Users.First(u => u.ID == user.ID);
            Assert.IsTrue(gottenUser.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldChangeNickname()
        {
            User user = (User)Create.User();
            
            var shouldBeTrue = usersRepository.ChangeNickname(user.ID, "ChangedNickname");
            Assert.AreEqual(true, shouldBeTrue);

            User gottenUser = DB.Users.First(u => u.ID == user.ID);
            Assert.AreEqual("ChangedNickname", gottenUser.Nickname);
        }
    }
}
