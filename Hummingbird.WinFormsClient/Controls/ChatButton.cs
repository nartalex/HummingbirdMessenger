using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class ChatButton : UserControl
	{
		private Guid ChatID;

		public ChatButton(Image avatar, string chatName, string lastMessage, DateTime time, Guid chatId)
		{
			InitializeComponent();
			ChatAvatar.Image = avatar;
			ChatNameLabel.Text = chatName;
			LastMessageLabel.Text = lastMessage;
			LastMessageTime.Text = (DateTime.Now - time).Days < 1 ? time.ToShortTimeString() : time.ToShortDateString() ;
			ChatID = chatId;
		}

		private void ChatButton_Click(object sender, EventArgs e)
		{

		}
	}
}
