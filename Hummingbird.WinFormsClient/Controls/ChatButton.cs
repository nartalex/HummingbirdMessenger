using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class ChatButton : UserControl
	{
		private readonly Chat _thisChat;
		private readonly MainForm _owner;

		public ChatButton(Chat chat, MainForm owner)
		{
			InitializeComponent();

			_thisChat = chat;
			_owner = owner;

			Anchor = AnchorStyles.Left | AnchorStyles.Right;

			if (chat.Private)
			{
				var otherPerson = chat.Members.First(x => x.UserID != Properties.Settings.Default.CurrentUser.ID).User;

				ChatAvatar.BackgroundImage = ServiceClient.FromBytesToImage(otherPerson.Avatar);

				ChatNameLabel.Text = otherPerson.Nickname;
			}
			else
			{
				ChatAvatar.BackgroundImage = ServiceClient.FromBytesToImage(_thisChat.Avatar, true);

				ChatNameLabel.Text = _thisChat.Name;

				RemoveChatToolStripMenuItem.Text = "Выйти из чата";
			}

			LastMessageLabel.Text = _thisChat.Messages.Any()
									? _thisChat.Messages.First().Text
									: String.Empty;

			LastMessageTime.Text = _thisChat.Messages.Any()
									   ? (DateTime.Now - _thisChat.Messages.Last().Time).Days < 1
											 ? _thisChat.Messages.Last().Time.ToShortTimeString()
											 : _thisChat.Messages.Last().Time.ToShortDateString()
									   : String.Empty;
		}

		private void ChatButton_DoubleClick(object sender, EventArgs e)
		{
			((MainForm)Parent.Parent).OpenChat(_thisChat);
		}

		private void ChatSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChatSettingsForm f = new ChatSettingsForm(_thisChat, _owner.Friends.Keys);
			f.Show();
		}

		private void RemoveChatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string variant = _thisChat.Private ? "удалить этот чат" : "выйти из этого чата";

			if(MessageBox.Show($"Действительно {variant}? Обратить действие будет невозможно.", "", MessageBoxButtons.YesNo)
			   != DialogResult.Yes)
				return;

			if (_thisChat.Private)
				ServiceClient.DeleteChat(_thisChat.ID);
			else
			{
				Chat c = new Chat
				{
					ID = _thisChat.ID,
					Members = new[]
					{
						new ChatMember
						{
							UserID = Properties.Settings.Default.CurrentUser.ID,
							ChatID = _thisChat.ID
						}
					}
				};

				ServiceClient.RemoveMembersFromChat(c);
			}
		}
	}
}
