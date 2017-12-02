using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class ChatButton : UserControl
	{
		private readonly Chat _thisChat;

		public ChatButton(Chat chat)
		{
			InitializeComponent();

			_thisChat = chat;

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

		private void ChatButton_Click(object sender, EventArgs e)
		{

		}

		private void ChatButton_DoubleClick(object sender, EventArgs e)
		{
			((MainForm)Parent.Parent).OpenChat(_thisChat);
		}
	}
}
