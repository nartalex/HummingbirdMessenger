using System;
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
        public void ShouldRegister()
        {
            User user = Create.User();

            User gottenUser = usersRepository.Get(user.ID);

            Assert.AreEqual(user.Login, gottenUser.Login);
            Assert.AreEqual(user.PasswordHash, gottenUser.PasswordHash);

        }

        [TestMethod]
        public void ShouldLogin()
        {
            User user = Create.User();

            var gottenUser = usersRepository.Login(user.Login, user.PasswordHash);
            Assert.IsInstanceOfType(gottenUser, typeof(User));
            Assert.AreEqual(user.Login, gottenUser.Login);
            Assert.AreEqual(user.PasswordHash, gottenUser.PasswordHash);

            //Неправильный пароль
            try
            {
                usersRepository.Login(user.Login, user.PasswordHash + "1");
                Assert.Fail();
            }
            catch (Exception e)
            {
                
            }

            //Неправильный логин
            try
            {
                usersRepository.Login(user.Login + "1", user.PasswordHash);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void ShouldDisable()
        {
            //var user = Create.User();

            //var shouldBeTrue = usersRepository.DisableUser(((User)user).ID);
            //Assert.AreEqual(true, shouldBeTrue);

            //User gottenUser = DB.Users.First(u => u.ID == ((User)user).ID);
            //Assert.AreEqual(true, gottenUser.Disabled);
        }

        [TestMethod]
        public void ShouldGetUser()
        {
            //var user = Create.User();

            //var shouldBeUser = usersRepository.Get(((User)user).ID);
            //Assert.IsInstanceOfType(shouldBeUser, typeof(User));
            //Assert.AreEqual(((User)user).Login, ((User)shouldBeUser).Login);

            //var shouldBeException = usersRepository.Get(Guid.NewGuid());
            //Assert.IsInstanceOfType(shouldBeException, typeof(Exception));
            //Assert.AreEqual("No user found", ((Exception)shouldBeException).Message);
        }

        [TestMethod]
        public void ShouldChangePassword()
        {
            //User user = (User)Create.User();

            //var shouldBeTrue = usersRepository.ChangePassword(user.ID, "password2");
            //Assert.AreEqual(true, shouldBeTrue);

            //User gottenUser = DB.Users.First(u => u.ID == user.ID);
            //Assert.AreEqual("password2", gottenUser.PasswordHash);
        }

        [TestMethod]
        public void ShouldChangeAvatar()
        {
            //User user = (User)Create.User();

            //byte[] newAvatar = { 1, 2, 3, 4 };
            //var shouldBeTrue = usersRepository.ChangeAvatar(user.ID, newAvatar);
            //Assert.AreEqual(true, shouldBeTrue);

            //User gottenUser = DB.Users.First(u => u.ID == user.ID);
            //Assert.IsTrue(gottenUser.Avatar.SequenceEqual(newAvatar));
        }

        [TestMethod]
        public void ShouldChangeNickname()
        {
            //User user = (User)Create.User();

            //var shouldBeTrue = usersRepository.ChangeNickname(user.ID, "ChangedNickname");
            //Assert.AreEqual(true, shouldBeTrue);

            //User gottenUser = DB.Users.First(u => u.ID == user.ID);
            //Assert.AreEqual("ChangedNickname", gottenUser.Nickname);
        }
    }
}
