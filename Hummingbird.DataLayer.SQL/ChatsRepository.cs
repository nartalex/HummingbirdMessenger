using System;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
	public class ChatsRepository : IChatsRepository
	{
		private readonly DatabaseContext _db = new DatabaseContext();
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly Stopwatch _timer = new Stopwatch();
		private const int MaxTime = 1000;

		/// <summary>
		/// Создание чата
		/// </summary>
		/// <param name="chat">Объект Chat</param>
		/// <returns>Объект Chat в случае успеха</returns>
		public Chat Create(Chat chat)
		{
			_logger.Info($"Создание чата с количеством участников {chat.Members.Count}");

			try
			{
				_timer.Restart();

				if (chat.Members.Count < 2)
				{
					_logger.Error("Создание чата: пустой список участников. Создаем исключение.");
					throw Helper.GenerateException("Can't create chat with no members", HttpStatusCode.BadRequest);
				}

				string name;
				if (chat.Members.Count == 2 || String.IsNullOrWhiteSpace(chat.Name))
				{
					StringBuilder sb = new StringBuilder("");
					foreach (var m in chat.Members)
					{
						sb.Append(_db.Users.First(x => x.ID == m.UserID).Nickname);
						sb.Append("-");
					}

					name = sb.ToString().Substring(0, sb.Length - 1);
				}
				else
					name = chat.Name;

				Guid newChatID = Guid.NewGuid();
				Chat newChat = new Chat
				{
					ID = newChatID,
					Name = name,
					Avatar = chat.Avatar,
					Members = chat.Members,
					Messages = new List<Message>(),
					Private = chat.Members.Count == 2
				};
				_db.Chats.Add(newChat);
				_db.SaveChanges();

				_logger.Info($"Создание чата {newChatID} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Регистрация пользователя {newChatID} заняла {_timer.ElapsedMilliseconds} мс");

				return newChat;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при cоздании чата с количеством участников {chat.Members.Count}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает информацию о чате
		/// </summary>
		/// <param name="id">ID чата</param>
		/// <returns>Объект Chat</returns>
		public Chat GetChat(Guid id)
		{
			_logger.Info($"Получение информации о чате {id}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(id);
				var ret = _db.Chats
					.Include(c => c.Members.Select(cm => cm.User))
					.First(c => c.ID == id);

				ret.Messages = new List<Message>();

				var m = new MessagesRepository().GetLastMessage(ret.ID);
				if (m != null)
					ret.Messages.Add(m);

				_logger.Info($"Получение информации о чате {id} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Получение информации о чате {id} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при получении информации о чате {id}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Удаление чата. Также удаляются все сообщения
		/// </summary>
		/// <param name="id">Идентификатор чата</param>
		public void DeleteChat(Guid id)
		{
			_logger.Info($"Удаление чата {id}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(id);
				_db.Messages.RemoveRange(_db.Messages.Where(c => c.ChatToID == id));
				_db.Chats.Remove(_db.Chats.First(c => c.ID == id));
				_db.SaveChanges();

				_logger.Info($"Удаление чата {id} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Удаление чата {id} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при удалении чата {id}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает массив с чатами пользователя
		/// </summary>
		/// <param name="userId">ID пользователя</param>
		/// <returns>Массив с объектами Chat в случае успеха</returns>
		public IEnumerable<Chat> GetUserChats(Guid userId)
		{
			_logger.Info($"Получение списка чатов для пользователя {userId}");

			try
			{
				_timer.Restart();

				Helper.CheckUser(userId);

				MessagesRepository messagesRepository = new MessagesRepository();

				var chats = _db.ChatMembers
							   .Include(c => c.Chat)
							   .Where(u => u.UserID == userId)
							   .Select(c => c.Chat)
							   .Include(c => c.Members.Select(u => u.User))
							   .ToArray();

				// Достаем последнее сообщение для каждого чата
				foreach (var c in chats)
				{
					c.Messages = new List<Message>();

					var m = messagesRepository.GetLastMessage(c.ID);
					c.Messages.Add(m ?? new Message());
				}

				var ret = chats.OrderByDescending(t => t.Messages.Min(m => m.Time));

				_logger.Info($"Получение списка чатов для пользователя {userId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Получение списка чатов для пользователя {userId} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при получении списка чатов для пользователя {userId}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Добавление пользователей в чат
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <param name="userIdsEnum">Массив с ID пользователей</param>
		public void AddMembers(Guid chatId, IEnumerable<Guid> userIdsEnum)
		{
			var userIds = userIdsEnum as Guid[] ?? userIdsEnum.ToArray();

			_logger.Info($"Добавление в чат {chatId} пользователей в количестве {userIds.Length}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);
				if (!userIds.Any())
					throw new Exception("Can't add zero members");

				foreach (var u in userIds)
				{
					ChatMember member = new ChatMember
					{
						ChatID = chatId,
						UserID = u
					};
					_db.ChatMembers.Add(member);
				}
				_db.SaveChanges();

				_logger.Info($"Добавление в чат {chatId} пользователей в количестве {userIds.Count()} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Добавление в чат {chatId} пользователей в количестве {userIds.Count()} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при добавлении в чат {chatId} пользователей в количестве {userIds.Length}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Удаление пользователей из чата
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <param name="userIdsEnum">Массив с ID пользователей</param>
		public void DeleteMembers(Guid chatId, IEnumerable<Guid> userIdsEnum)
		{
			var userIds = userIdsEnum as Guid[] ?? userIdsEnum.ToArray();

			_logger.Info($"Удаление из чата {chatId} пользователей в количестве {userIds.Length}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);
				if (!userIds.Any())
				{
					_logger.Error($"Удаление из чата {chatId}: список пользователей пуст. Создаем исключение.");
					throw Helper.GenerateException("Can't delete zero members", HttpStatusCode.BadRequest);
				}

				foreach (var u in userIds)
					_db.ChatMembers.Remove(_db.ChatMembers.First(m => m.UserID == u && m.ChatID == chatId));
				_db.SaveChanges();

				_logger.Info($"Удаление из чата {chatId} пользователей в количестве {userIds.Length} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Удаление из чата {chatId} пользователей в количестве {userIds.Length} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при удалении из чата {chatId} пользователей в количестве {userIds.Length}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Изменение аватара в указанном чате
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <param name="newAvatar">Новый аватар</param>
		public void ChangeAvatar(Guid chatId, byte[] newAvatar)
		{
			_logger.Info($"Изменение аватара в чате {chatId}, размер нового аватара {newAvatar.Length}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);

				_db.Chats.
					Include(m => m.Members)
					.First(c => c.ID == chatId)
					.Avatar = newAvatar.Any() ? newAvatar : null;
				_db.SaveChanges();

				_logger.Info($"Изменение аватара в чате {chatId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение аватара в чате {chatId}, размер нового аватара {newAvatar.Length} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении аватара в чате {chatId}, размер нового аватара {newAvatar.Length}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Изменение названия указанного чата
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <param name="newName">Новое название</param>
		public void ChangeName(Guid chatId, string newName)
		{
			_logger.Info($"Изменение имени чата {chatId}, новое имя: {newName}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);

				if (!newName.Any())
				{
					_logger.Error($"Изменение имени чата {chatId}: пустое название. СОздаем исключение.");
					throw Helper.GenerateException("Chat name can't be empty", HttpStatusCode.BadRequest);
				}

				_db.Chats.Include(m => m.Members).First(c => c.ID == chatId).Name = newName;
				_db.SaveChanges();

				_logger.Info($"Изменение имени чата {chatId}, новое имя: {newName} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение имени чата {chatId}, новое имя: {newName}, заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении имени чата {chatId}, новое имя: {newName}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Изменяет время жизни сообщений в чате
		/// </summary>
		/// <param name="chatId">ИД чата</param>
		/// <param name="newTTL">Новое время жизни. 0 - бесконечно</param>
		public void ChangeTTL(Guid chatId, int newTTL)
		{
			_logger.Info($"Изменение TTL сообщений чата {chatId}, новое значение: {newTTL}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);

				_db.Chats.First(x => x.ID == chatId).TimeToLive = newTTL;
				_db.SaveChanges();

				_logger.Info($"Изменение TTL сообщений чата {chatId}, новое значение: {newTTL} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение TTL сообщений чата {chatId}, новое значение: {newTTL}, заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error($"Ошибка при изменении TTL сообщений чата {chatId}, новое значение: {newTTL}: {e.Message}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}
	}
}
