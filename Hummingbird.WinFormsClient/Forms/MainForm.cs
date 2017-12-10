using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Hummingbird.Model;
using Hummingbird.WinFormsClient.Controls;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class MainForm : Form
	{
		internal Dictionary<User, Chat> Friends = new Dictionary<User, Chat>();
		private int UpdaterDelay = 0;
		private bool KeepUpdating = true;

		public MainForm()
		{
			InitializeComponent();

			CurrentUserAvatar.BackgroundImage = ServiceClient.FromBytesToImage(Properties.Settings.Default.CurrentUser.Avatar);
			CurrentUserNameLabel.Text = Properties.Settings.Default.CurrentUser.Nickname;

			foreach (var c in UserButtonsTable.Controls.OfType<Button>())
			{
				_backgrounds.Add(c.BackgroundImage);
			}

			Text = Properties.Settings.Default.CurrentUser.Login + " - Hummingbird";

			ChatsUpdateBGW.RunWorkerAsync();
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

			if (createdChat.Private)
				Friends.Add(createdChat.Members.First(x => x.UserID != Properties.Settings.Default.CurrentUser.ID).User, createdChat);

			ChatsListTable.RowCount++;
			ChatsListTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, 70));
			ChatsListTable.Controls.Add(new ChatButton(createdChat, this), 0, ChatsListTable.RowCount - 1);
			ChatsListTable.RowCount++;
		}

		public void AddChatToForm(Chat chat)
		{
			Chat createdChat = ServiceClient.CreateChat(chat);

			if (createdChat.Private)
				Friends.Add(createdChat.Members.First(x => x.UserID != Properties.Settings.Default.CurrentUser.ID).User, createdChat);

			ChatsListTable.RowCount++;
			ChatsListTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, 70));
			ChatsListTable.Controls.Add(new ChatButton(createdChat, this), 0, ChatsListTable.RowCount - 1);
			ChatsListTable.RowCount++;
		}

		public void OpenChat(Chat chat)
		{
			var f = new MessengerForm(chat);
			f.Show();
		}

		#region Шапка

		private void GroupAddButton_Click(object sender, EventArgs e)
		{
			AddGroupChatForm f = new AddGroupChatForm(Friends.Keys.ToArray(), this);
			f.Show();
		}

		private void UserSearchButton_Click(object sender, EventArgs e)
		{
			var f = new UsersSearchForm(Friends, this);
			f.Show();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			Form f = new SettingsForm(this);
			f.Show();
		}

		private void UserExit_Click(object sender, EventArgs e)
		{
			KeepUpdating = false;

			//Properties.Settings.Default.CurrentUser = null;
			//Properties.Settings.Default.Save();
			Close();
			(new StartForm()).Show();
		}

		private bool _textIsShown = false;
		private List<Image> _backgrounds = new List<Image>();
		private List<string> _labels = new List<string>()
		{
			"Поиск", "Настройки", "Выход", "Новая группа"
		};

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

		#endregion

		public void ChangeAvatar(Image newAvatar)
		{
			CurrentUserAvatar.BackgroundImage = newAvatar;
		}

		public void ChangeUsername(string username)
		{
			CurrentUserNameLabel.Text = username;
		}

		private void ChatsUpdateBGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			Thread.Sleep(UpdaterDelay);

			e.Result = KeepUpdating
						? ServiceClient.GetUserChats(Properties.Settings.Default.CurrentUser.ID) as Chat[]
						: new Chat[0];
		}

		private void ChatsUpdateBGW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			ChatsListTable.Controls.Clear();
			ChatsListTable.RowCount = 1;
			Friends.Clear();

			foreach (var c in e.Result as Chat[])
			{
				ChatsListTable.RowCount++;
				ChatsListTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
				ChatsListTable.Controls.Add(new ChatButton(c, this), 0, ChatsListTable.RowCount - 1);

				if (c.Private)
					Friends.Add(c.Members.First(x => x.UserID != Properties.Settings.Default.CurrentUser.ID).User, c);
			}
			ChatsListTable.RowCount++;

			if (UpdaterDelay == 0)
				UpdaterDelay = 3000;

			if (KeepUpdating)
				ChatsUpdateBGW.RunWorkerAsync();
		}

		protected override bool ShowWithoutActivation => true;

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
