using System;
using System.Linq;
using System.Data.Entity;
using Hummingbird.Model;
using NLog;

namespace Hummingbird.DBInitializer
{
    internal static class Program
    {
        private static void Main()
        {
            //Logger logger = LogManager.GetLogger("foo");
            //logger.Trace("Sample trace message");
            //logger.Debug("Sample debug message");
            //logger.Info("Sample informational message");
            //logger.Warn("Sample warning message");
            //logger.Error("Sample error message");
            //logger.Fatal("Sample fatal error message");

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