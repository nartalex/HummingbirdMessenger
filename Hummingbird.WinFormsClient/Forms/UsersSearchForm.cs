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
		private const string SearchPlaceholder = "Имя пользователя";
		private const int PictureSize = 48;
		private const int LabelSizeY = 48;
		private readonly MainForm _parentForm;

		public UsersSearchForm(MainForm parent)
		{
			InitializeComponent();
			_parentForm = parent;

			//ActiveControl = tableLayoutPanel2;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			User[] users = ServiceClient.SearchUsers(SearchTB.Text) as User[];

			if (users != null)
				foreach (var u in users)
				{
					UsersTable.RowCount++;
					UsersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, LabelSizeY));
					UsersTable.Controls.Add(
											   new Label()
											   {
												   Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204),
												   Name = u.ID.ToString(),
												   MinimumSize = new Size(0, LabelSizeY),
												   Text = u.Nickname,
												   TextAlign = ContentAlignment.MiddleLeft,
											   }, 1, UsersTable.RowCount - 1);

					UsersTable.Controls.Add(
											   new PictureBox()
											   {
												   BackgroundImage = ServiceClient.FromBytesToImage(u.Avatar),
												   BackgroundImageLayout = ImageLayout.Zoom,
												   Size = new Size(PictureSize, PictureSize),
											   }, 0, UsersTable.RowCount - 1);

					Button b = new Button()
					{
						Name = u.ID.ToString(),
						BackgroundImage = Properties.Resources.add_friend,
						BackgroundImageLayout = ImageLayout.Zoom,
						Size = new Size(32, 32)
					};
					b.Click += BOnClick;

					UsersTable.Controls.Add(b, 2, UsersTable.RowCount - 1);
				}
			Invalidate();
		}

		private void BOnClick(object sender, EventArgs eventArgs)
		{
			string id = ((Button)sender).Name;

			AddChatToForm(Guid.Parse(id));
		}

		internal void AddChatToForm(Guid id)
		{
			Close();
			_parentForm.CreateChat(new[] { id });
		}

		private void SearchTB_Enter(object sender, EventArgs e)
		{
			SearchTB.RemoveText(SearchPlaceholder);
		}

		private void SearchTB_Leave(object sender, EventArgs e)
		{
			SearchTB.AddText(SearchPlaceholder);
		}
	}
}
