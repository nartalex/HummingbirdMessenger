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

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class AddGroupChatForm : Form
	{
		private const string ChatnamePlaceholder = "Введите название чата";
		private bool AvatarChanged = false;
		private readonly MainForm _owner;

		public AddGroupChatForm(IEnumerable<User> users, MainForm owner)
		{
			InitializeComponent();
			_owner = owner;
			foreach (var u in users)
			{
				UsersCheckBoxList.Items.Add(u);
			}
		}

		private void ChatnameTB_Enter(object sender, EventArgs e)
		{
			ChatnameTB.RemoveText(ChatnamePlaceholder);
		}

		private void ChatnameTB_Leave(object sender, EventArgs e)
		{
			ChatnameTB.AddText(ChatnamePlaceholder);
		}

		private void ChooseNewAvatar_Click(object sender, EventArgs e)
		{
			if (OpenAvatarDialog.ShowDialog() == DialogResult.OK)
			{
				ChatAvatarPB.BackgroundImage = Image.FromFile(OpenAvatarDialog.FileName);
				AvatarChanged = true;
			}
		}

		private void CreateChatButton_Click(object sender, EventArgs e)
		{
			List<ChatMember> members = (from object m in UsersCheckBoxList.CheckedItems select new ChatMember()
			{
				UserID = ((User)m).ID
			}).ToList();

			members.Add(new ChatMember{UserID = Properties.Settings.Default.CurrentUser.ID});

			Chat c = new Chat
			{
				Name = String.IsNullOrWhiteSpace(ChatnameTB.Text)
						|| ChatnameTB.Text == ChatnamePlaceholder
						?
						null : ChatnameTB.Text,
				Avatar = AvatarChanged ? ServiceClient.FromImageToBytes(ChatAvatarPB.BackgroundImage) : null,
				Members = members
			};

			_owner.AddChatToForm(c);
			Close();
		}

		private void UsersCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreateChatButton.Enabled = UsersCheckBoxList.CheckedItems.Count != 0;
		}
	}
}
