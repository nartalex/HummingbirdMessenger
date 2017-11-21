﻿using System;
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
		public MainForm()
		{
			InitializeComponent();

			CurrentUserAvatar.BackgroundImage = ServiceClient.FromBytesToImage(Properties.Settings.Default.CurrentUser.Avatar);
			CurrentUserNameLabel.Text = Properties.Settings.Default.CurrentUser.Nickname;

			var chats = ServiceClient.GetUserChats(Properties.Settings.Default.CurrentUser.ID) as Chat[];

			if (chats != null && chats.Any())
			{
				for (int i = 0; i < chats?.Count(); i++)
				{
					ChatButton button = new ChatButton(chats[i]);

					button.Location = new Point(0, i * button.Height);
					button.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

					ChatsListPanel.Controls.Add(button);
				}
			}
		}

		public void AddChatToForm(Chat chat)
		{
			ChatButton cb = new ChatButton(chat);
		}

		private void UsersSearchTSM_Click(object sender, EventArgs e)
		{
			var f = new UsersSearchForm();
			f.Show();
		}

		private void ExitTSM_Click(object sender, EventArgs e)
		{

		}

		public void OpenChat(Chat chat)
		{
			var f = new MessengerForm(chat);
			f.Show();
		}

		private void UserSearchButton_Click(object sender, EventArgs e)
		{
			var f = new UsersSearchForm();
			f.Show();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{

		}

		private void UserExit_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.CurrentUser = null;
			Properties.Settings.Default.Save();
			Close();
			(new StartForm()).Show();
		}
	}
}
