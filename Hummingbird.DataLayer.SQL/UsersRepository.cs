using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Hummingbird.Model;
using System.Diagnostics;

namespace Hummingbird.DataLayer.SQL
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private readonly DatabaseContext DB = new DatabaseContext();
        //private readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Stopwatch timer = new Stopwatch();

        /// <summary>
        /// Меняет аватар указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newAvatar">Новый аватар</param>
        public void ChangeAvatar(Guid userId, byte[] newAvatar)
        {
            CheckUser(userId);

            //logger.Info($"Изменение аватара пользователя {userId}, размер аватара: {newAvatar.Length}");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            DB.Users.First(u => u.ID == userId).Avatar = (newAvatar.Any() ? newAvatar : null);
            DB.SaveChanges();
            timer.Stop();
            //logger.Info($"Изменение аватара пользователя {userId} - успешно за {timer.ElapsedMilliseconds} мс");
            //if (timer.ElapsedMilliseconds > 1000) logger.Warn($"Изменение аватара пользователя {userId} заняло {timer.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Меняет псевдоним указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newNickname">Новый псевдоним</param>
        public void ChangeNickname(Guid userId, string newNickname)
        {
            CheckUser(userId);
            if (!newNickname.Any())
                throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);

            DB.Users.First(u => u.ID == userId).Nickname = newNickname;
            DB.SaveChanges();
        }

        /// <summary>
        /// Меняет пароль указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newPasswordHash">Новый пароль</param>
        public void ChangePassword(Guid userId, string newPasswordHash)
        {
            CheckUser(userId);
            if (!newPasswordHash.Any())
                throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);

            DB.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
            DB.SaveChanges();
        }

        /// <summary>
        /// Отключает учетную запись указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        public void DisableUser(Guid userId)
        {
            CheckUser(userId);

            DB.Users.First(u => u.ID == userId).Disabled = true;
            DB.SaveChanges();
        }

        /// <summary>
        /// Возвращает информацию о пользователе
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Объект User в случае успеха</returns>
        public User Get(Guid userId)
        {
            CheckUser(userId);

            return DB.Users.First(u => u.ID == userId);
        }

        /*
        /// <summary>
        /// Возвращает чаты пользователя
        /// </summary>
        /// <param name="userId">ID пользоваля</param>
        /// <returns>Массив Chat в случае успеха, Exception в случае ошибки</returns>
        public object GetChats(Guid userId)
        {
            try
            {
                return DB.ChatMembers
                    .Include(c => c.Chat)
                    .Where(c => c.UserID == userId)
                    .Select(c => c.Chat)
                    .ToArray();
            }
            catch(Exception e)
            {
                return e;
            }
        }
*/

        /// <summary>
        /// Вход в учетную запись
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="passwordHash">Пароль пользователя</param>
        /// <returns>Объект User в случае успеха</returns>
        public User Login(string login, string passwordHash)
        {
            if (!DB.Users.Any(u => u.Login == login))
                throw GenerateException("Login is invalid", HttpStatusCode.BadRequest);

            User user = DB.Users.First(u => u.Login == login);

            if (user.PasswordHash != passwordHash)
                throw GenerateException("Password is invalid", HttpStatusCode.BadRequest);

            return user;
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="user">Объект User</param>
        /// <returns>Объект User в случае успеха</returns>
        public User Register(User user)
        {
            if (!user.Login.Any())
                throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);
            if (DB.Users.Any(u => u.Login == user.Login))
                throw GenerateException("Login is already taken", HttpStatusCode.BadRequest);
            if (!user.Nickname.Any())
                throw GenerateException("Nickname can't be empty", HttpStatusCode.BadRequest);
            if (!user.PasswordHash.Any())
                throw GenerateException("Password can't be empty", HttpStatusCode.BadRequest);

            User newUser = new User
            {
                ID = Guid.NewGuid(),
                Nickname = user.Nickname,
                Avatar = user.Avatar,
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                Disabled = false
            };

            DB.Users.Add(newUser);
            DB.SaveChanges();
            return newUser;
        }

        /// <summary>
        /// Возвращает массив пользователей с указанным логином
        /// </summary>
        /// <param name="login">Логин, по которому идет поиск</param>
        /// <returns>Массив пользователей</returns>
        public IEnumerable<User> Search(string login)
        {
            if (!login.Any())
                throw GenerateException("Login can't be empty", HttpStatusCode.BadRequest);

            return DB.Users.Where(u => u.Login.Contains(login)).ToArray();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        private Exception GenerateException(string message, HttpStatusCode code)
        {
            var ex = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };

            return new HttpResponseException(ex);
        }

        private void CheckUser(Guid id)
        {
            if (!DB.Users.Any(u => u.ID == id))
                throw GenerateException("User ID is invalid", HttpStatusCode.BadRequest);
        }
    }
}
