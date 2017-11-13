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
	public partial class MessengerForm : Form
	{
		public MessengerForm()
		{
			InitializeComponent();

			var chats = ServiceClient.GetUserChats(Properties.Settings.Default.CurrentUserID) as Chat[];

			//chats.

			if (chats != null && chats.Any())
			{
				for (int i = 0; i < chats?.Count(); i++)
				{
					ChatButton button = new ChatButton(
													   (Bitmap)new ImageConverter().ConvertFrom(chats[i].Avatar),
													   chats[i].Name,
													   chats[i].Messages.First().Text,
													   chats[i].Messages.First().Time,
													   chats[i].ID
													  );

					button.Location = new Point(0, i * button.Height);
				}
			}
		}

		private void UsersSearchTSM_Click(object sender, EventArgs e)
		{
			var f = new UsersSearchForm();
			f.Show();
		}
	}
}
