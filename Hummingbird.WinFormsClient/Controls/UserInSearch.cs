﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class UserInSearch : UserControl
	{
		private Guid UserID;

		public UserInSearch(User user)
		{
			InitializeComponent();

			UserName.Text = user.Nickname;
			UserAvatar.Image = user.Avatar != null && user.Avatar.Any()
							 ? (Bitmap)new ImageConverter().ConvertFrom(user.Avatar)
							 : Properties.Resources.empty_avatar;
			UserID = user.ID;
		}

		private void AddUserButton_Click(object sender, EventArgs e)
		{
			(Parent as UsersSearchForm).AddChatToForm(UserID);
		}
	}
}
