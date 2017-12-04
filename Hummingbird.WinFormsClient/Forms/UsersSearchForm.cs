using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hummingbird.Model;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class UsersSearchForm : Form
	{
		private const string SearchPlaceholder = "Имя пользователя";
		private const int PictureSize = 48;
		private const int LabelSizeY = 48;
		private readonly MainForm _parentForm;
		private readonly Dictionary<User, Chat> _friendsList;

		public UsersSearchForm(Dictionary<User, Chat> friendsList, MainForm parent)
		{
			InitializeComponent();
			_parentForm = parent;
			_friendsList = friendsList;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			if (ServiceClient.SearchUsers(SearchTB.Text) is User[] users)
				foreach (var u in users)
				{
					if(u.ID==Properties.Settings.Default.CurrentUser.ID)
						continue;

					var frinendsIds = _friendsList.Keys.Select(x => x.ID).ToArray();

					UsersTable.RowCount++;
					UsersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, LabelSizeY));
					UsersTable.Controls.Add(GetPictureBox(u), 0, UsersTable.RowCount - 1);
					UsersTable.Controls.Add(GetLabel(u), 1, UsersTable.RowCount - 1);
					UsersTable.Controls.Add(GetButton(u, frinendsIds.Contains(u.ID)), 2, UsersTable.RowCount - 1);
				}
			UsersTable.RowCount++;
		}

		private void AddUser(object sender, EventArgs eventArgs)
		{
			string id = ((Button)sender).Name;
			_parentForm.CreateChat(new[] { Guid.Parse(id) });
			Close();
		}

		private void OpenChat(object sender, EventArgs eventArgs)
		{
			string id = ((Button)sender).Name;
			_parentForm.OpenChat(_friendsList[_friendsList.Keys.First(x => x.ID == Guid.Parse(id))]);
			Close();
		}

		#region Getters

		private Label GetLabel(User user)
		{
			return new Label()
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204),
				Name = user.ID.ToString(),
				MinimumSize = new Size(MinimumSize.Width - LabelSizeY * 2 - 20, LabelSizeY),
				Text = user.Nickname,
				TextAlign = ContentAlignment.MiddleLeft,
			};
		}

		private PictureBox GetPictureBox(User user)
		{
			return new PictureBox()
			{
				BackgroundImage = ServiceClient.FromBytesToImage(user.Avatar),
				BackgroundImageLayout = ImageLayout.Zoom,
				Size = new Size(PictureSize, PictureSize),
			};
		}

		private Button GetButton(User user, bool isFriend)
		{
			Button b = new Button()
			{
				Name = user.ID.ToString(),
				BackgroundImage = isFriend
					                  ? Properties.Resources.chat_black
					                  : Properties.Resources.add_friend,
				BackgroundImageLayout = ImageLayout.Zoom,
				Size = new Size(32, 32),
				FlatAppearance = {
					BorderSize = 0,
					MouseDownBackColor = Color.Transparent,
					MouseOverBackColor = Color.Transparent},
				FlatStyle = FlatStyle.Flat,
				Margin = new Padding(0, 16, 0, 16),
				Padding = new Padding(0),
				Cursor = Cursors.Hand
			};

			if (isFriend)
				b.Click += OpenChat;
			else
				b.Click += AddUser;

			return b;
		}

		#endregion

		#region Controls

		private void SearchTB_Enter(object sender, EventArgs e)
		{
			SearchTB.RemoveText(SearchPlaceholder);
		}

		private void SearchTB_Leave(object sender, EventArgs e)
		{
			SearchTB.AddText(SearchPlaceholder);
		}

		#endregion
	}
}
