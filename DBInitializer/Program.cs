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
            Database.SetInitializer(new AppDbInitializer());
            var db = new DatabaseContext();
            db.Users.Add(new User { ID = Guid.NewGuid(), Nickname = "a1", Login = "a1", PasswordHash = "a1" });
            db.SaveChanges();
            Console.WriteLine(db.Users.Count());
            Console.Read();
        }
    }
}