using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Hummingbird.Model;

namespace Hummingbird.DBInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Установка инициализатора. ");
            Database.SetInitializer(new AppDbInitializer());
            Console.WriteLine("Успешно.");

            try
            {
                Console.Write("Получение контекста БД. ");
                var db = new DatabaseContext();
                Console.WriteLine("Успешно. ");

                Console.Write("Добавление данных. ");
                db.Users.Add(new User { ID = Guid.NewGuid(), Nickname = "Default User", Login = "Default", PasswordHash = "Default" });
                db.SaveChanges();
                if (db.Users.Count() == 0)
                    Console.WriteLine("Неудача.");
                else
                    Console.WriteLine("Успешно.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Неудача. \r\nОшибка: " + e.Message);
            }
            Console.Write("Любая клавиша для выхода...");
            Console.ReadKey();
        }
    }
}