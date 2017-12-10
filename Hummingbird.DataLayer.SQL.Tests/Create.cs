using System;
using System.Collections.Generic;
using Hummingbird.Model;

namespace Hummingbird.DataLayer.SQL.Tests
{
	internal static class Create
	{
		private static readonly ChatsRepository ChatsRepository = new ChatsRepository();
		private static readonly UsersRepository UsersRepository = new UsersRepository();

		internal static User User()
		{
			var user = new User
			{
				Nickname = "TestUser",
				Login = Guid.NewGuid().ToString(),
				PasswordHash = "TestPassword"
			};

			return UsersRepository.Register(user);
		}

		internal static Chat Chat(int usersAmount = 2)
		{
			var members = new List<ChatMember>();
			for (int i = 0; i < usersAmount; i++)
			{
				members.Add(new ChatMember { UserID = User().ID });
			}

			Chat chat = new Chat
			{
				Name = "TestChat",
				Members = members
			};

			return ChatsRepository.Create(chat);
		}
		//internal static Message Message(User from, Chat to)
		//{
		//    Message m = new Message
		//    {
		//        ID = Guid.NewGuid(),
		//        UserFromID = from.ID,
		//        ChatToID = to.ID,
		//        Text = "TestMessage",

		//    };
		//}
	}
}
