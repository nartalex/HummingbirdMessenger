using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Diagnostics;
using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
	public class UsersRepository : IUsersRepository
	{
		private readonly DatabaseContext _db = new DatabaseContext();
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly Stopwatch _timer = new Stopwatch();
		private const int MAX_TIME = 1000;

		/// <summary>
		/// Меняет аватар указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newAvatar">Новый аватар</param>
		public void ChangeAvatar(Guid userId, byte[] newAvatar)
		{
			_logger.Info($"Изменение аватара пользователя {userId}, размер аватара: {newAvatar.Length} / Changing avatar of user {userId}, avatar zise: {newAvatar.Length} ");

			try
			{
				_timer.Restart();

				CheckUser(userId);
				_db.Users.First(u => u.ID == userId).Avatar = (newAvatar.Any() ? newAvatar : null);
				_db.SaveChanges();

				_logger.Info($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при изменении аватара пользователя {userId} при аватаре размером {newAvatar.Length}");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Меняет псевдоним указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newNickname">Новый псевдоним</param>
		public void ChangeNickname(Guid userId, string newNickname)
		{
			_logger.Info($"Изменение имени пользователя {userId}, новое имя: {newNickname}");

			try
			{
				_timer.Restart();

				CheckUser(userId);
				if (!newNickname.Any())
				{
					_logger.Error($"Изменение имени пользователя {userId}: новое имя пусто. Создаем исключение.");
					throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				_db.Users.First(u => u.ID == userId).Nickname = newNickname;
				_db.SaveChanges();

				_logger.Info($"Изменение имени пользователя {userId} при новом имени {newNickname} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Изменение имени пользователя {userId} при новом имени {newNickname} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при изменении имени пользователя {userId} при новом имени {newNickname}");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Меняет пароль указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newPasswordHash">Новый пароль</param>
		public void ChangePassword(Guid userId, string newPasswordHash)
		{
			_logger.Info($"Изменение пароля пользователя {userId}, новый хэш: {newPasswordHash}");

			try
			{
				_timer.Restart();

				CheckUser(userId);
				if (!newPasswordHash.Any())
				{
					_logger.Error($"Изменение пароля пользователя {userId}: новый пароль пустой. Создаем исключение.");
					throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}
				_db.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
				_db.SaveChanges();

				_logger.Info($"Изменение пароля пользователя {userId} при новом хэше {newPasswordHash} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Изменение пароля пользователя {userId} при новом хэше {newPasswordHash} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при изменении пароля пользователя {userId} при новом хэше {newPasswordHash}");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Отключает учетную запись указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		public void DisableUser(Guid userId)
		{
			_logger.Info($"Отключение пользователя {userId}");

			try
			{
				_timer.Restart();

				CheckUser(userId);
				_db.Users.First(u => u.ID == userId).Disabled = true;
				_db.SaveChanges();

				_logger.Info($"Отключение пользователя {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Отключение пользователя {userId} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при отключении пользователя {userId}");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает информацию о пользователе
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <returns>Объект User в случае успеха</returns>
		public User Get(Guid userId)
		{
			_logger.Info($"Получение информации о пользователе {userId} / Getting info about user {userId}");

			try
			{
				_timer.Restart();

				CheckUser(userId);
				var ret = _db.Users.First(u => u.ID == userId);

				_logger.Info($"Получение информации о пользователе {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Получение информации о пользователе {userId} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (Exception e)
			{
				_logger.Error(e.Message, $"Oшибка при получении информации о пользователе {userId} / Getting info about user {userId} is failed");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Вход в учетную запись
		/// </summary>
		/// <param name="login">Логин пользователя</param>
		/// <param name="passwordHash">Пароль пользователя</param>
		/// <returns>Объект User в случае успеха</returns>
		public User Login(string login, string passwordHash)
		{
			_logger.Info($"Попытка входа с логином {login} и хэшем {passwordHash}");

			try
			{
				if (!_db.Users.Any(u => u.Login == login))
				{
					_logger.Error($"Попытка входа с логином {login}: логин не найден. Создаем исключение.");
					throw GenerateException("Login is invalid", HttpStatusCode.BadRequest);
				}
				User user = _db.Users.First(u => u.Login == login);

				if (user.PasswordHash != passwordHash)
				{
					_logger.Error($"Попытка входа с логином {login} и хэшем {passwordHash}: пароль неверный. Создаем исключение.");
					throw GenerateException("Password is invalid", HttpStatusCode.BadRequest);
				}
				return user;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при попытке входа с логином {login}: " + e.Message);
				throw;
			}
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name="user">Объект User</param>
		/// <returns>Объект User в случае успеха</returns>
		public User Register(User user)
		{
			string log = $"Попытка регистрации с логином {user.Login}, именем {user.Nickname}, хэшем {user.PasswordHash}";
			if (user.Avatar != null)
				log += $", аватаром длиной { user.Avatar.Length}";

			_logger.Info(log);

			try
			{
				_timer.Restart();

				if (!user.Login.Any())
				{
					_logger.Error($"Попытка регистрации: пустой логин. Создаем исключение.");
					throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				if (_db.Users.Any(u => u.Login == user.Login))
				{
					_logger.Error($"Попытка регистрации: логин уже занят. Создаем исключение.");
					throw GenerateException("Login is already taken", HttpStatusCode.BadRequest);
				}
				if (!user.Nickname.Any())
				{
					_logger.Error($"Попытка регистрации: пустой ник. Создаем исключение.");
					throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				if (!user.PasswordHash.Any())
				{
					_logger.Error($"Попытка регистрации: пустой пароль. Создаем исключение.");
					throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}

				//byte[] avatar;
				//{
				//	Random rnd = new Random();
				//	string path = Directory.GetFiles(
				//		Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars"), "*.png")
				//		.OrderBy(x => rnd.Next()).First();
				//	ImageConverter converter = new ImageConverter();
				//	avatar = (byte[])converter.ConvertTo(Image.FromFile(path), typeof(byte[]));
				//}

				User newUser = new User
				{
					ID = Guid.NewGuid(),
					Nickname = user.Nickname,
					//Avatar = avatar,
					Login = user.Login,
					PasswordHash = user.PasswordHash,
					Disabled = false
				};

				_db.Users.Add(newUser);
				_db.SaveChanges();

				_logger.Info($"Регистрация пользователя {newUser.ID} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Регистрация пользователя {newUser.ID} заняла {_timer.ElapsedMilliseconds} мс");

				return newUser;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при регистрации пользователя: " + e.Message);
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает массив пользователей с указанным логином
		/// </summary>
		/// <param name="login">Логин, по которому идет поиск</param>
		/// <returns>Массив пользователей</returns>
		public IEnumerable<User> Search(string login)
		{
			_logger.Info($"Поиск пользователей по логину {login}");

			try
			{
				_timer.Restart();

				if (!login.Any())
				{
					_logger.Error($"Поиск: пустой логин. Создаем исключение.");
					throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				var ret = _db.Users.Where(u => u.Login.Contains(login)).ToArray();

				_timer.Stop();
				_logger.Info($"Поиск пользователей по логину {login} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MAX_TIME)
					_logger.Warn($"Поиск пользователей по логину {login} заняла {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при поиске пользователей по логину {login}");
				throw;
			}
			finally
			{
				_timer.Stop();
			}
		}

		public void Initialize()
		{
			_db.Users.Any();
		}

		public void ClearDatabase()
		{
			//DB.Messages.RemoveRange(DB.Messages);
			//DB.ChatMembers.RemoveRange(DB.ChatMembers);
			//DB.Chats.RemoveRange(DB.Chats);

			//DB.SaveChanges();
			Database.SetInitializer(new AppDbInitializer());
		}

		private Exception GenerateException(string message, HttpStatusCode code)
		{
			var ex = new HttpResponseMessage(code)
			{
				Content = new StringContent(message),
			};

			return new HttpResponseException(ex);
		}

		public void CheckUser(Guid id)
		{
			if (!_db.Users.Any(u => u.ID == id))
			{
				_logger.Error($"User ID is invalid: {id}");
				throw GenerateException("User ID is invalid", HttpStatusCode.BadRequest);
			}
		}
	}
}
