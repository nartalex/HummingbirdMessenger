﻿using System;
using System.Linq;
using System.Data.Entity;

using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        DatabaseContext DB = new DatabaseContext();

        /// <summary>
        /// Меняет аватар указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newAvatar">Новый аватар</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object ChangeAvatar(Guid userId, byte[] newAvatar)
        {
            try
            {
                DB.Users.First(u => u.ID == userId).Avatar = (newAvatar.Any() ? newAvatar : null);
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object ChangeAvatar(User user)
        {
            return ChangeAvatar(user.ID, user.Avatar);
        }

        /// <summary>
        /// Меняет псевдоним указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newNickname">Новый псевдоним</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object ChangeNickname(Guid userId, string newNickname)
        {
            if (!newNickname.Any())
                return new Exception("Nickname can't be empty");

            try
            {
                DB.Users.First(u => u.ID == userId).Nickname = newNickname;
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object ChangeNickname(User user)
        {
            return ChangeNickname(user.ID, user.Nickname);
        }

        /// <summary>
        /// Меняет пароль указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="newPasswordHash">Новый пароль</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object ChangePassword(Guid userId, string newPasswordHash)
        {
            try
            {
                DB.Users.First(u => u.ID == userId).PasswordHash = newPasswordHash;
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object ChangePassword(User user)
        {
            return ChangePassword(user.ID, user.PasswordHash);
        }

        /// <summary>
        /// Отключает учетную запись указанного пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>True в случае успеха, Exceprion в случае ошибки</returns>
        public object DisableUser(Guid userId)
        {
            try
            {
                DB.Users.First(u => u.ID == userId).Disabled = true;
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        /// <summary>
        /// Возвращает информацию о пользователе
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Объект User в случае успеха, Exceprion в случае ошибки</returns>
        public object Get(Guid userId)
        {
            try
            {
                if (DB.Users.Count(u => u.ID == userId) == 0)
                    return new Exception("No user found");
                else
                    return DB.Users.First(u => u.ID == userId);
            }
            catch (Exception e)
            {
                return e;
            }
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
        /// <returns>Объект User в случае успеха, Exceprion в случае ошибки</returns>
        public object Login(string login, string passwordHash)
        {
            try
            {
                if (DB.Users.Count(u => u.Login == login) == 0)
                    return new Exception("Login is incorrect");

                User user = DB.Users.First(u => u.Login == login);

                if (user.PasswordHash != passwordHash)
                    return new Exception("Password is incorrect");

                return user;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public object Login(User user)
        {
            return Login(user.Login, user.PasswordHash);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="user">Объект User</param>
        /// <returns>Объект User в случае успеха, Exceprion в случае ошибки</returns>
        public object Register(User user, bool test = false)
        {
            try
            {
                Guid newID = Guid.NewGuid();

                User newUser = new User
                {
                    ID = newID,
                    Nickname = user.Nickname,
                    Avatar = user.Avatar,
                    Login = test ? newID.ToString() : user.Login,
                    PasswordHash = user.PasswordHash,
                    Disabled = false
                };

                DB.Users.Add(newUser);
                DB.SaveChanges();
                return newUser;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
