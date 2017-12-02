using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Controls;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class MainForm : Form
	{
		private bool _textIsShown = false;
		private List<Image> _backgrounds = new List<Image>();
		private List<string> _labels = new List<string>()
		{
			 "Поиск", "Настройки", "Выход", "Новая группа"
		};

		public MainForm()
		{
			InitializeComponent();

			CurrentUserAvatar.BackgroundImage = ServiceClient.FromBytesToImage(Properties.Settings.Default.CurrentUser.Avatar);
			CurrentUserNameLabel.Text = Properties.Settings.Default.CurrentUser.Nickname;

			var chats = ServiceClient.GetUserChats(Properties.Settings.Default.CurrentUser.ID) as Chat[];

			if (chats != null && chats.Any())
			{
				foreach (var c in chats)
				{
					ChatsListTable.RowCount++;
					ChatsListTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
					ChatsListTable.Controls.Add(new ChatButton(c), 0, ChatsListTable.RowCount - 1);
				}
				ChatsListTable.RowCount++;
			}

			foreach (var c in UserButtonsTable.Controls.OfType<Button>())
			{
				_backgrounds.Add(c.BackgroundImage);
			}
		}

		public void CreateChat(Guid[] userIds)
		{
			Chat chat = new Chat()
			{
				Members = new List<ChatMember>()
			};

			foreach (var id in userIds)
			{
				chat.Members.Add(new ChatMember() { UserID = id });
			}

			chat.Members.Add(new ChatMember() { UserID = Properties.Settings.Default.CurrentUser.ID });

			Chat createdChat = ServiceClient.CreateChat(chat);

			ChatsListTable.RowCount++;
			ChatsListTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, 70));
			ChatsListTable.Controls.Add(new ChatButton(createdChat), 0, ChatsListTable.RowCount - 1);
			ChatsListTable.RowCount++;
		}

		public void OpenChat(Chat chat)
		{
			var f = new MessengerForm(chat);
			f.Show();
		}

		private void UserSearchButton_Click(object sender, EventArgs e)
		{
			var f = new UsersSearchForm(this);
			f.Show();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			Form f = new SettingsForm(this);
			f.Show();
		}

		private void UserExit_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.CurrentUser = null;
			Properties.Settings.Default.Save();
			Close();
			(new StartForm()).Show();
		}

		private void UserButtonsTable_Resize(object sender, EventArgs e)
		{
			if (Width > 530 && !_textIsShown)
			{
				var controls = UserButtonsTable.Controls.OfType<Button>().ToArray();
				_textIsShown = true;

				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].BackgroundImage = null;
					controls[i].Text = _labels[i];
				}
			}
			else if (Width <= 530 && _textIsShown)
			{
				var controls = UserButtonsTable.Controls.OfType<Button>().ToArray();
				_textIsShown = false;

				for (int i = 0; i < controls.Length; i++)
				{
					controls[i].Text = "";
					controls[i].BackgroundImage = _backgrounds[i];
				}
			}
		}

		public void ChangeAvatar(Image newAvatar)
		{
			CurrentUserAvatar.BackgroundImage = newAvatar;
		}

		public void ChangeUsername(string username)
		{
			CurrentUserNameLabel.Text = username;
		}
	}
}
