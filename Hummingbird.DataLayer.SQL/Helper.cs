using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
	public static class Helper
	{
		private static readonly DatabaseContext Db = new DatabaseContext();
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

		public static void Initialize()
		{
			Db.Users.Any();
		}

		public static void ClearDatabase()
		{
			Db.Messages.RemoveRange(Db.Messages);
			Db.ChatMembers.RemoveRange(Db.ChatMembers);
			Db.Chats.RemoveRange(Db.Chats);

			Db.SaveChanges();
			//Database.SetInitializer(new AppDbInitializer());
		}

		public static void CheckUser(Guid id)
		{
			if (!Db.Users.Any(u => u.ID == id))
			{
				Logger.Error($"User ID is invalid: {id}");
				throw GenerateException("User ID is invalid", HttpStatusCode.BadRequest);
			}
		}

		public static void CheckChat(Guid id)
		{
			if (!Db.Chats.Any(c => c.ID == id))
			{
				Logger.Error($"Chat ID is invalid: {id}");
				throw GenerateException("Chat ID is invalid", HttpStatusCode.BadRequest);
			}
		}

		public static void CheckMessage(Guid id)
		{
			if (Db.Messages.Any(m => m.ID == id))
			{
				Logger.Error($"Message ID is invalid: {id}");
				throw GenerateException("Message ID is invalid", HttpStatusCode.BadRequest);
			}
		}

		public static Exception GenerateException(string message, HttpStatusCode code)
		{
			var ex = new HttpResponseMessage(code)
			{
				Content = new StringContent(message)
			};

			return new HttpResponseException(ex);
		}
	}
}
