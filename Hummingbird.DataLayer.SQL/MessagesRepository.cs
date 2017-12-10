using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

using Hummingbird.Model;
using NLog;

namespace Hummingbird.DataLayer.SQL
{
	public class MessagesRepository : IMessagesRepository
	{
		private readonly DatabaseContext _db = new DatabaseContext();
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly Stopwatch _timer = new Stopwatch();
		private const int MaxTime = 1000;

		/// <summary>
		/// Удаляет сообщение с указанным ID
		/// </summary>
		/// <param name="id">ID сообщения</param>
		public void DeleteMessage(Guid id)
		{
			_logger.Info($"Удаление сообщения {id}");

			try
			{
				_timer.Restart();

				_db.Messages.Remove(_db.Messages.First(m => m.ID == id));
				_db.SaveChanges();

				_logger.Info($"Удаление сообщения {id} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Удаление сообщения {id} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при удалении сообщения {id}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Изменение сообщения
		/// </summary>
		/// <param name="edits">Исправления</param>
		public void EditMessage(Message edits)
		{
			string log = $"Изменение сообщения {edits.ID} с исправлениями: ";
			if (edits.Text.Any())
				log += "текста, ";
			if (edits.AttachType != Message.AttachTypes.Null)
				log += "типа аттача, ";
			if (edits.Attach != null && edits.Attach.Any())
				log += "аттача";
			_logger.Info(log.TrimEnd(',', ' '));

			try
			{
				_timer.Restart();

				Helper.CheckMessage(edits.ID);
				Message toEdit = _db.Messages.First(m => m.ID == edits.ID);
				if (edits.Text.Any())
					toEdit.Text = edits.Text;
				if (edits.AttachType != Message.AttachTypes.Null)
					toEdit.AttachType = edits.AttachType;
				if (edits.Attach != null && edits.Attach.Any())
					toEdit.Attach = edits.Attach;
				if(String.IsNullOrWhiteSpace(edits.AttachName))
					toEdit.AttachName = edits.AttachName;
				toEdit.Edited = true;
				_db.SaveChanges();

				_logger.Info($"Изменение сообщения {edits.ID} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Изменение сообщения {edits.ID} заняло {_timer.ElapsedMilliseconds} мс");
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при изменении сообщения {edits.ID}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает указанное количество сообщений
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <param name="amount">Количество возвращаемых сообщений</param>
		/// <param name="skip">Количество пропускаемых сообщений</param>
		/// <returns>Массив с сообщениями в случае успеха</returns>
		public IEnumerable<Message> GetAmountOfMessages(Guid chatId, int skip, int amount)
		{
			_logger.Info($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip}");

			try
			{
				_timer.Restart();

				Helper.CheckChat(chatId);
				if (amount <= 0)
				{
					_logger.Info($"Получение сообщений в чате {chatId}: ноль сообщений запрошено. Создаем исключение.");
					throw Helper.GenerateException("Can't get zero messages", HttpStatusCode.BadRequest);
				}

				var ret = _db.Messages.Any(m => m.ChatToID == chatId)
						?
							_db.Messages
								.Include(x => x.User)
								.Where(m => m.ChatToID == chatId)
								.OrderByDescending(m => m.Time)
								.Skip(skip)
								.Take(amount)
								.ToArray()
								.Reverse()
						:
							new Message[0];

				_logger.Info($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Получение сообщений в чате {chatId} в количестве {amount} с пропуском {skip} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при получении сообщений в чате {chatId}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Возвращает последнее сообщение в указанном чате
		/// </summary>
		/// <param name="chatId">ID чата</param>
		/// <returns>Объект Message в случае успеха</returns>
		public Message GetLastMessage(Guid chatId)
		{
			_logger.Info($"Получение последнего сообщения в чате {chatId}");

			try
			{
				_timer.Restart();

				Message ret = _db.Messages.Any(m => m.ChatToID == chatId)
							?
								_db.Messages
								   .Where(m => m.ChatToID == chatId)
								   .OrderByDescending(m => m.Time)
								   .First()
							:
								null;

				_logger.Info($"Получение последнего сообщения в чате {chatId} - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Получение последнего сообщения в чате {chatId} заняло {_timer.ElapsedMilliseconds} мс");

				return ret;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при получении последнего сообщения в чате  {chatId}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}

		/// <summary>
		/// Отправление сообщения
		/// </summary>
		/// <param name="message">Отправляемое сообщение</param>
		public Message SendMessage(Message message)
		{
			_logger.Info($"Отправление сообщения в чат {message.ChatToID} от пользователя {message.UserFromID}");

			try
			{
				_timer.Restart();

				Message newMessage = new Message
				{
					ID = Guid.NewGuid(),
					UserFromID = message.UserFromID,
					User = _db.Users.First(x => x.ID == message.UserFromID),
					ChatToID = message.ChatToID,
					Time = DateTime.Now,
					AttachType = message.AttachType,
					Attach = message.Attach,
					AttachName = message.AttachName,
					Text = message.Text,
					Edited = false
				};

				_db.Messages.Add(newMessage);
				_db.SaveChanges();

				_logger.Info($"Отправление сообщения в чат - успешно за {_timer.ElapsedMilliseconds} мс");
				if (_timer.ElapsedMilliseconds > MaxTime)
					_logger.Warn($"Отправление сообщения в чат заняло {_timer.ElapsedMilliseconds} мс");

				return newMessage;
			}
			catch (HttpResponseException)
			{
				throw;
			}
			catch (Exception e)
			{
				_logger.Error(e, $"Ошибка при отправлении сообщения в чат {message.ChatToID} от пользователя {message.UserFromID}");
				throw Helper.GenerateException(e.Message, HttpStatusCode.InternalServerError);
			}
			finally
			{
				_timer.Stop();
			}
		}
	}
}
