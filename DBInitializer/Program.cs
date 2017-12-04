using System;
using System.Linq;
using System.Data.Entity;
using Hummingbird.Model;

namespace Hummingbird.DBInitializer
{
    internal static class Program
    {
        private static void Main()
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
				Console.WriteLine(!db.Users.Any() ? "Неудача." : "Успешно.");
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