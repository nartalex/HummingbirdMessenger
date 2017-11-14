using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.Model;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class ChatButton : UserControl
	{
		private Chat thisChat;

		public ChatButton(Chat chat)
		{
			InitializeComponent();

			thisChat = chat;

			if (chat.Private)
			{
				var otherPerson = chat.Members.First(x => x.UserID != Properties.Settings.Default.CurrentUser.ID).User;

				ChatAvatar.Image = chat.Avatar != null && chat.Avatar.Any()
									   ? (Bitmap)new ImageConverter().ConvertFrom(otherPerson.Avatar)
									   : Properties.Resources.empty_avatar;

				ChatNameLabel.Text = otherPerson.Nickname;
			}
			else
			{
				ChatAvatar.Image = thisChat.Avatar != null && thisChat.Avatar.Any()
									   ? (Bitmap)new ImageConverter().ConvertFrom(thisChat.Avatar)
									   : Properties.Resources.empty_chat_avatar;
				ChatNameLabel.Text = thisChat.Name;
			}

			LastMessageLabel.Text = thisChat.Messages.Any()
									? thisChat.Messages.First().Text
									: String.Empty;
			LastMessageTime.Text = thisChat.Messages.Any()
									   ? (DateTime.Now - thisChat.Messages.Last().Time).Days < 1
											 ? thisChat.Messages.Last().Time.ToShortTimeString()
											 : thisChat.Messages.Last().Time.ToShortDateString()
									   : String.Empty;
		}

		private void ChatButton_Click(object sender, EventArgs e)
		{

		}

		private void ChatButton_DoubleClick(object sender, EventArgs e)
		{
			MessageBox.Show("dclick");
		}
	}
}
