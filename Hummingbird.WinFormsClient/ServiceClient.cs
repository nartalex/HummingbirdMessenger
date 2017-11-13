﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


using Hummingbird.Model;

namespace Hummingbird.WinFormsClient
{
	static class ServiceClient
	{
		private static HttpClient _client;

		public static void Initialize()
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri(@"http://localhost:12345/api/")
			};
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public static string GetSHA512Hash(string input)
		{
			SHA512 shaM = new SHA512Managed();
			byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			shaM.Dispose();
			return sBuilder.ToString();
		}

		public static object RegisterUser(User user)
		{
			var pesponse = _client.PostAsJsonAsync(@"users/register", user).Result.Content;

			try
			{
				user = pesponse.ReadAsAsync<User>().Result;
				return user;
			}
			catch (UnsupportedMediaTypeException)
			{
				return pesponse.ReadAsStringAsync().Result;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return new User();
		}

		public static object LoginUser(User user)
		{
			var pesponse = _client.PostAsJsonAsync(@"users/login", user).Result.Content;

			try
			{
				user = pesponse.ReadAsAsync<User>().Result;
				return user;
			}
			catch (UnsupportedMediaTypeException)
			{
				return pesponse.ReadAsStringAsync().Result;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return new User();
		}

		public static object GetUserChats(Guid id)
		{
			var response = _client.GetAsync(@"chats/userchats/" + id).Result;

			try
			{
				response.EnsureSuccessStatusCode();

				var chats = response.Content.ReadAsAsync<Chat[]>().Result;

				return chats;
			}
			catch (UnsupportedMediaTypeException)
			{
				MessageBox.Show(response.Content.ReadAsStringAsync().Result);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return null;
		}

		public static object CreateChat(Chat chat)
		{
			var pesponse = _client.PostAsJsonAsync(@"chats/create/", chat).Result.Content;

			try
			{
				var ret = pesponse.ReadAsAsync<Chat>().Result;
				return ret;
			}
			catch (UnsupportedMediaTypeException)
			{
				MessageBox.Show(pesponse.ReadAsStringAsync().Result);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return null;
		}

		public static object SearchUsers(string nick)
		{
			var response = _client.GetAsync(@"users/search/" + nick).Result;

			try
			{
				response.EnsureSuccessStatusCode();
				var ret = response.Content.ReadAsAsync<User[]>().Result;
				return ret;
			}
			catch (UnsupportedMediaTypeException)
			{
				MessageBox.Show(response.Content.ReadAsStringAsync().Result);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return null;
		}
	}
}
