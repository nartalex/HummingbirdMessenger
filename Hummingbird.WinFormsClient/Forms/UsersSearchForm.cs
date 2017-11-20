using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Controls;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class UsersSearchForm : Form
	{
		public UsersSearchForm()
		{
			InitializeComponent();
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			User[] users = ServiceClient.SearchUsers(SearchTB.Text) as User[];

			if (users != null)
				for (int i = 0; i < users.Length; i++)
				{
					UserInSearch line = new UserInSearch(users[i]);

					line.Location = new Point(0, i * line.Height + 40);

					this.Controls.Add(line);
				}
			Invalidate();
		}

		internal void AddChatToForm(Chat chat)
		{
			(Parent as MainForm).AddChatToForm(chat);
			Close();
		}
	}
}
