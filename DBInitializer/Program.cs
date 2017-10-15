using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Hummingbird.Model;

namespace DBInitializer
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
                db.Users.Add(new User { ID = Guid.NewGuid(), Nickname = "a1", Login = "a1", PasswordHash = "a1" });
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
            Console.WriteLine("Любая клавиша для выхода...");
            Console.Read();
        }
    }
}