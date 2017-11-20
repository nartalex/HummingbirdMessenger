using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Hummingbird.Model;
using NLog;
using System.Drawing;
using System.Threading;

namespace Hummingbird.DataLayer.SQL
{
	public class UsersRepository : IUsersRepository
	{
		private readonly DatabaseContext DB = new DatabaseContext();
		private readonly Logger logger = LogManager.GetCurrentClassLogger();
		private readonly Stopwatch timer = new Stopwatch();
		private readonly int MAX_TIME = 1000;

		/// <summary>
		/// Меняет аватар указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newAvatar">Новый аватар</param>
		public void ChangeAvatar(Guid userId, byte[] newAvatar)
		{
			logger.Info($"Изменение аватара пользователя {userId}, размер аватара: {newAvatar.Length}");

			try
			{
				timer.Restart();

				CheckUser(userId);
				DB.Users.First(u => u.ID == userId).Avatar = (newAvatar.Any() ? newAvatar : null);
				DB.SaveChanges();

				logger.Info($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} заняло {timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при изменении аватара пользователя {userId} при аватаре размером {newAvatar.Length}");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		/// <summary>
		/// Меняет псевдоним указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newNickname">Новый псевдоним</param>
		public void ChangeNickname(Guid userId, string newNickname)
		{
			logger.Info($"Изменение имени пользователя {userId}, новое имя: {newNickname}");

			try
			{
				timer.Restart();

				CheckUser(userId);
				if (!newNickname.Any())
				{
					logger.Error($"Изменение имени пользователя {userId}: новое имя пусто. Создаем исключение.");
					throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				DB.Users.First(u => u.ID == userId).Nickname = newNickname;
				DB.SaveChanges();

				logger.Info($"Изменение имени пользователя {userId} при новом имени {newNickname} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Изменение имени пользователя {userId} при новом имени {newNickname} заняло {timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при изменении имени пользователя {userId} при новом имени {newNickname}");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		/// <summary>
		/// Меняет пароль указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newPasswordHash">Новый пароль</param>
		public void ChangePassword(Guid userId, string newPasswordHash)
		{
			logger.Info($"Изменение пароля пользователя {userId}, новый хэш: {newPasswordHash}");

			try
			{
				timer.Restart();

				CheckUser(userId);
				if (!newPasswordHash.Any())
				{
					logger.Error($"Изменение пароля пользователя {userId}: новый пароль пустой. Создаем исключение.");
					throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}
				DB.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
				DB.SaveChanges();

				logger.Info($"Изменение пароля пользователя {userId} при новом хэше {newPasswordHash} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Изменение пароля пользователя {userId} при новом хэше {newPasswordHash} заняло {timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при изменении пароля пользователя {userId} при новом хэше {newPasswordHash}");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		/// <summary>
		/// Отключает учетную запись указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		public void DisableUser(Guid userId)
		{
			logger.Info($"Отключение пользователя {userId}");

			try
			{
				timer.Restart();

				CheckUser(userId);
				DB.Users.First(u => u.ID == userId).Disabled = true;
				DB.SaveChanges();

				logger.Info($"Отключение пользователя {userId} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Отключение пользователя {userId} заняло {timer.ElapsedMilliseconds} мс");
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при отключении пользователя {userId}");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает информацию о пользователе
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <returns>Объект User в случае успеха</returns>
		public User Get(Guid userId)
		{
			logger.Info($"Получение информации о пользователе {userId}");

			try
			{
				timer.Restart();

				CheckUser(userId);
				var ret = DB.Users.First(u => u.ID == userId);

				logger.Info($"Получение информации о пользователе {userId} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Получение информации о пользователе {userId} заняло {timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (Exception e)
			{
				logger.Error(e, $"Oшибка при получении информации о пользователе {userId}");
				throw;
			}
			finally
			{
				timer.Stop();
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
			logger.Info($"Попытка входа с логином {login} и хэшем {passwordHash}");

			try
			{
				if (!DB.Users.Any(u => u.Login == login))
				{
					logger.Error($"Попытка входа с логином {login}: логин не найден. Создаем исключение.");
					throw GenerateException("Login is invalid", HttpStatusCode.BadRequest);
				}
				User user = DB.Users.First(u => u.Login == login);

				if (user.PasswordHash != passwordHash)
				{
					logger.Error($"Попытка входа с логином {login} и хэшем {passwordHash}: пароль неверный. Создаем исключение.");
					throw GenerateException("Password is invalid", HttpStatusCode.BadRequest);
				}
				return user;
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при попытке входа с логином {login} и хэшем {passwordHash}");
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

			logger.Info(log);

			try
			{
				timer.Restart();

				if (!user.Login.Any())
				{
					logger.Error($"Попытка регистрации: пустой логин. Создаем исключение.");
					throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				if (DB.Users.Any(u => u.Login == user.Login))
				{
					logger.Error($"Попытка регистрации: логин уже занят. Создаем исключение.");
					throw GenerateException("Login is already taken", HttpStatusCode.BadRequest);
				}
				if (!user.Nickname.Any())
				{
					logger.Error($"Попытка регистрации: пустой ник. Создаем исключение.");
					throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				if (!user.PasswordHash.Any())
				{
					logger.Error($"Попытка регистрации: пустой пароль. Создаем исключение.");
					throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}

				byte[] avatar;
				{
					Random rnd = new Random();
					string path = Directory.GetFiles(
						Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars"), "*.png")
						.OrderBy(x => rnd.Next()).First();
					ImageConverter converter = new ImageConverter();
					avatar = (byte[])converter.ConvertTo(Image.FromFile(path), typeof(byte[]));
				}

				User newUser = new User
				{
					ID = Guid.NewGuid(),
					Nickname = user.Nickname,
					Avatar = avatar,
					Login = user.Login,
					PasswordHash = user.PasswordHash,
					Disabled = false
				};

				DB.Users.Add(newUser);
				DB.SaveChanges();

				logger.Info($"Регистрация пользователя {newUser.ID} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Регистрация пользователя {newUser.ID} заняла {timer.ElapsedMilliseconds} мс");

				return newUser;
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при регистрации пользователя.");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает массив пользователей с указанным логином
		/// </summary>
		/// <param name="login">Логин, по которому идет поиск</param>
		/// <returns>Массив пользователей</returns>
		public IEnumerable<User> Search(string login)
		{
			logger.Info($"Поиск пользователей по логину {login}");

			try
			{
				timer.Restart();

				if (!login.Any())
				{
					logger.Error($"Поиск: пустой логин. Создаем исключение.");
					throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				var ret = DB.Users.Where(u => u.Login.Contains(login)).ToArray();

				timer.Stop();
				logger.Info($"Поиск пользователей по логину {login} - успешно за {timer.ElapsedMilliseconds} мс");
				if (timer.ElapsedMilliseconds > MAX_TIME)
					logger.Warn($"Поиск пользователей по логину {login} заняла {timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (Exception e)
			{
				logger.Error(e, $"Ошибка при поиске пользователей по логину {login}");
				throw;
			}
			finally
			{
				timer.Stop();
			}
		}

		public void Initialize()
		{
			DB.Users.Any();

			foreach (var u in DB.Users)
			{
				Random rnd = new Random();
				string path = Directory.GetFiles(
												 Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Avatars"), "*.png")
									   .OrderBy(x => rnd.Next()).First();
				ImageConverter converter = new ImageConverter();
				u.Avatar = (byte[])converter.ConvertTo(Image.FromFile(path), typeof(byte[]));

				Thread.Sleep(150);
			}

			//DB.SaveChanges();
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
			if (!DB.Users.Any(u => u.ID == id))
			{
				logger.Error($"User ID is invalid: {id}");
				throw GenerateException("User ID is invalid", HttpStatusCode.BadRequest);
			}
		}
	}
}
