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
	public partial class ChatSettingsForm : Form
	{
		private readonly Chat _chat;
		private const string ChatnamePlaceholder = "Введите название чата";
		private bool AvatarChanged = false;

		public ChatSettingsForm(Chat chat, IEnumerable<User> friends)
		{
			InitializeComponent();

			_chat = chat;

			TimeToLiveNUD.Value = _chat.TimeToLive;

			if(_chat.Private)
			{
				TimerGB.Location = NameGB.Location;
				NameGB.Visible = AvatarGB.Visible = UsersGB.Visible = false;
				Height -= (NameGB.Height + AvatarGB.Height + UsersGB.Height);
				SaveChatButton.Top -= (NameGB.Height + AvatarGB.Height + UsersGB.Height);
				SaveChatButton.Enabled = true;
			}
			else
			{
				ChatAvatarPB.BackgroundImage = ServiceClient.FromBytesToImage(chat.Avatar);
				ChatnameTB.Text = chat.Name;
				ChatnameTB.Controls.Find("TextboxUnderline", true).First().BackColor = Properties.Settings.Default.PrimaryColor;

				foreach (var u in chat.Members)
				{
					if (u.UserID != Properties.Settings.Default.CurrentUser.ID)
						RemoveMemersCLB.Items.Add(u.User);
				}

				foreach (var f in friends)
				{
					if (!chat.Members.Select(x => x.UserID).Contains(f.ID))
						AddMembersCLB.Items.Add(f);
				}
			}
		}

		private void ChooseNewAvatar_Click(object sender, EventArgs e)
		{
			if (AvatarOFD.ShowDialog() == DialogResult.OK)
			{
				ChatAvatarPB.BackgroundImage = Image.FromFile(AvatarOFD.FileName);
				AvatarChanged = true;
			}
		}

		private void SaveChatButton_Click(object sender, EventArgs e)
		{
			if(!_chat.Private)
			{
				if(_chat.Name != ChatnameTB.Text)
					ServiceClient.ChangeChatname(new Chat
					{
						ID = _chat.ID,
						Name = ChatnameTB.Text
					});

				if(AvatarChanged)
					ServiceClient.ChangeChatAvatar(new Chat
					{
						ID = _chat.ID,
						Avatar = ServiceClient.FromImageToBytes(ChatAvatarPB.BackgroundImage)
					});

				if(AddMembersCLB.CheckedItems.Count > 0)
				{
					List<ChatMember> cm = (from object i in AddMembersCLB.CheckedItems select new ChatMember
					{
						ChatID = _chat.ID,
						UserID = (i as User).ID
					}).ToList();

					ServiceClient.AddMembersToChat(new Chat
					{
						ID = _chat.ID,
						Members = cm
					});
				}

				if(RemoveMemersCLB.CheckedItems.Count > 0)
				{
					List<ChatMember> cm = (from object i in RemoveMemersCLB.CheckedItems select new ChatMember
					{
						ChatID = _chat.ID,
						UserID = (i as User).ID
					}).ToList();

					ServiceClient.RemoveMembersFromChat(new Chat
					{
						ID = _chat.ID,
						Members = cm
					});
				}
			}

			ServiceClient.ChangeTTL(new Chat{ID=_chat.ID, TimeToLive = (int)TimeToLiveNUD.Value});

			Close();
		}

		private void ChatnameTB_TextChanged(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(ChatnameTB.Text) || ChatnameTB.Text == ChatnamePlaceholder)
				SaveChatButton.Enabled = false;
			else
				SaveChatButton.Enabled = true;
		}
	}
}
