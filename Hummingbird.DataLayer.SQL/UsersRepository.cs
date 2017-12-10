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
		private const int MaxTime = 1000;

		/// <summary>
		/// Меняет аватар указанного пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <param name="newAvatar">Новый аватар</param>
		public void ChangeAvatar(Guid userId, byte[] newAvatar)
		{
			_logger.Info($"Изменение аватара пользователя {userId}, размер аватара: {newAvatar.Length}");

			try
			{
				_timer.Restart();

				Helper.CheckUser(userId);
				_db.Users.First(u => u.ID == userId).Avatar = newAvatar.Any() ? newAvatar : null;
				_db.SaveChanges();

				_logger.Info($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение аватара пользователя {userId} при аватаре размером {newAvatar.Length} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении аватара пользователя {userId} при аватаре размером {newAvatar.Length}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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

				Helper.CheckUser(userId);
				if (!newNickname.Any())
				{
					_logger.Error($"Изменение имени пользователя {userId}: новое имя пусто. Создаем исключение.");
					throw Helper.GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				_db.Users.First(u => u.ID == userId).Nickname = newNickname;
				_db.SaveChanges();

				_logger.Info($"Изменение имени пользователя {userId} при новом имени {newNickname} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение имени пользователя {userId} при новом имени {newNickname} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении имени пользователя {userId} при новом имени {newNickname}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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
			_logger.Info($"Изменение пароля пользователя {userId}");

			try
			{
				_timer.Restart();

				Helper.CheckUser(userId);
				if (!newPasswordHash.Any())
				{
					_logger.Error($"Изменение пароля пользователя {userId}: новый пароль пустой. Создаем исключение.");
					throw Helper.GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}
				_db.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
				_db.SaveChanges();

				_logger.Info($"Изменение пароля пользователя {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение пароля пользователя {userId} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении пароля пользователя {userId}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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

				Helper.CheckUser(userId);
				_db.Users.First(u => u.ID == userId).Disabled = true;
				_db.SaveChanges();

				_logger.Info($"Отключение пользователя {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Отключение пользователя {userId} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при отключении пользователя {userId}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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

				Helper.CheckUser(userId);
				var ret = _db.Users.First(u => u.ID == userId);

				_logger.Info($"Получение информации о пользователе {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Получение информации о пользователе {userId} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Oшибка при получении информации о пользователе {userId}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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
			_logger.Info($"Попытка входа с логином {login}");

			try
			{
				_timer.Restart();

				if (!_db.Users.Any(u => u.Login == login))
				{
					_logger.Error($"Попытка входа с логином {login}: логин не найден. Создаем исключение.");
					throw Helper.GenerateException("Login is invalid", HttpStatusCode.BadRequest);
				}
				User user = _db.Users.First(u => u.Login == login);

				if (user.PasswordHash != passwordHash)
				{
					_logger.Error($"Попытка входа с логином {login}: пароль неверный. Создаем исключение.");
					throw Helper.GenerateException("Password is invalid", HttpStatusCode.BadRequest);
				}

				if (user.Disabled)
				{
					_logger.Error($"Попытка входа с логином {login}: профиль отключен. Создаем исключение.");
					throw Helper.GenerateException("Accuount is disabled", HttpStatusCode.BadRequest);
				}

				_logger.Info($"Вход пользователя {user.ID} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Вход пользователя {user.ID} занял {_timer.ElapsedMilliseconds} мс");

				return user;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при попытке входа с логином {login}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name="user">Объект User</param>
		/// <returns>Объект User в случае успеха</returns>
		public User Register(User user)
		{
			_logger.Info($"Попытка регистрации с логином {user.Login}, именем {user.Nickname}");

			try
			{
				_timer.Restart();

				if (!user.Login.Any())
				{
					_logger.Error($"Попытка регистрации: пустой логин. Создаем исключение.");
					throw Helper.GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				if (_db.Users.Any(u => u.Login == user.Login))
				{
					_logger.Error($"Попытка регистрации: логин уже занят. Создаем исключение.");
					throw Helper.GenerateException("Login is already taken", HttpStatusCode.BadRequest);
				}
				if (!user.Nickname.Any())
				{
					_logger.Error($"Попытка регистрации: пустой ник. Создаем исключение.");
					throw Helper.GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
				}
				if (!user.PasswordHash.Any())
				{
					_logger.Error($"Попытка регистрации: пустой пароль. Создаем исключение.");
					throw Helper.GenerateException("Password can't be empty", HttpStatusCode.BadRequest);
				}

				User newUser = new User
				{
					ID = Guid.NewGuid(),
					Nickname = user.Nickname,
					Login = user.Login,
					PasswordHash = user.PasswordHash,
					Disabled = false
				};

				_db.Users.Add(newUser);
				_db.SaveChanges();

				_logger.Info($"Регистрация пользователя {newUser.ID} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Регистрация пользователя {newUser.ID} заняла {_timer.ElapsedMilliseconds} мс");

				return newUser;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при регистрации пользователя: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
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
					throw Helper.GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
				}
				var ret = _db.Users.Where(u => u.Login.Contains(login)).ToArray();

				_timer.Stop();
				_logger.Info($"Поиск пользователей по логину {login} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Поиск пользователей по логину {login} заняла {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при поиске пользователей по логину {login}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}
	}
}
