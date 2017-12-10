using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL.Tests
{
	[TestClass]
	public class UsersRepositoryTests
	{
		private readonly DatabaseContext _db = new DatabaseContext();
		private readonly UsersRepository _usersRepository = new UsersRepository();

		[TestMethod]
		public void ShouldRegister()
		{
			User user = Create.User();

			User gottenUser = _usersRepository.Get(user.ID);

			Assert.IsInstanceOfType(gottenUser, typeof(User));
			Assert.AreEqual(user.Login, gottenUser.Login);
			Assert.AreEqual(user.Nickname, gottenUser.Nickname);
			Assert.AreEqual(user.PasswordHash, gottenUser.PasswordHash);
			Assert.AreNotEqual(gottenUser.ID, new Guid());
		}

		[TestMethod]
		public void ShouldLogin()
		{
			User user = Create.User();

			var gottenUser = _usersRepository.Login(user.Login, user.PasswordHash);
			Assert.IsInstanceOfType(gottenUser, typeof(User));
			Assert.AreEqual(user.Login, gottenUser.Login);
			Assert.AreEqual(user.Nickname, gottenUser.Nickname);
			Assert.AreEqual(user.PasswordHash, gottenUser.PasswordHash);
			Assert.AreNotEqual(gottenUser.ID, new Guid());
		}

		[TestMethod]
		public void ShouldNotLogin()
		{
			User user = Create.User();

			//Неправильный пароль
			try
			{
				_usersRepository.Login(user.Login, user.PasswordHash + "1");
				Assert.Fail();
			}
			catch
			{
			}

			//Неправильный логин
			try
			{
				_usersRepository.Login(user.Login + "1", user.PasswordHash);
				Assert.Fail();
			}
			catch
			{
			}
		}

		[TestMethod]
		public void ShouldDisable()
		{
			User user = Create.User();

			_usersRepository.DisableUser(user.ID);

			User gottenUser = _db.Users.First(u => u.ID == user.ID);
			Assert.AreEqual(true, gottenUser.Disabled);
		}

		[TestMethod]
		public void ShouldGetUser()
		{
			var user = Create.User();

			var shouldBeUser = _usersRepository.Get(user.ID);
			Assert.IsInstanceOfType(shouldBeUser, typeof(User));
			Assert.AreEqual(user.Login, shouldBeUser.Login);
		}

		[TestMethod]
		public void ShouldNotGetUser()
		{
			try
			{
				_usersRepository.Get(Guid.NewGuid());
				Assert.Fail();
			}
			catch { }
		}

		[TestMethod]
		public void ShouldChangePassword()
		{
			User user = Create.User();

			_usersRepository.ChangePassword(user.ID, "password2");

			User gottenUser = _db.Users.First(u => u.ID == user.ID);
			Assert.AreEqual("password2", gottenUser.PasswordHash);
		}

		[TestMethod]
		public void ShouldChangeAvatar()
		{
			User user = Create.User();

			byte[] newAvatar = { 1, 2, 3, 4 };
			_usersRepository.ChangeAvatar(user.ID, newAvatar);

			User gottenUser = _db.Users.First(u => u.ID == user.ID);
			Assert.IsTrue(gottenUser.Avatar.SequenceEqual(newAvatar));
		}

		[TestMethod]
		public void ShouldChangeNickname()
		{
			User user = Create.User();

			_usersRepository.ChangeNickname(user.ID, "ChangedNickname");

			User gottenUser = _db.Users.First(u => u.ID == user.ID);
			Assert.AreEqual("ChangedNickname", gottenUser.Nickname);
		}
	}
}
