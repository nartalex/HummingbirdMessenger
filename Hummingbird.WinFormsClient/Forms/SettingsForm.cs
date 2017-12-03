using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hummingbird.Model;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class SettingsForm : Form
	{
		private readonly string ButtonPlaceholder = "Сохранить";
		private readonly string SuccessPlaceholer = "Сохранено";
		private readonly string UsernameTBPlaceholder = "Введите новое имя";
		private readonly string CurrentPasswordTBPlaceholder = "Введите старый пароль";
		private readonly string NewPasswordTBPlaceholder = "Введите новый пароль";
		private readonly string NewPasswordAgainTBPlaceholder = "Введите новый пароль ещё раз";

		private readonly MainForm _parentForm;

		public SettingsForm(MainForm parent)
		{
			InitializeComponent();
			_parentForm = parent;
			//AvatarPB.BackgroundImage = ServiceClient.FromBytesToImage(Properties.Settings.Default.CurrentUser.Avatar);
			UsernameTB.Text = Properties.Settings.Default.CurrentUser.Nickname;
			UsernameTB.Controls.Find("TextboxUnderline", true).First().BackColor = Properties.Settings.Default.PrimaryColor;

			if (Properties.Settings.Default.CurrentUser.Avatar != null && Properties.Settings.Default.CurrentUser.Avatar.Any())
				AvatarPB.BackgroundImage = ServiceClient.FromBytesToImage(Properties.Settings.Default.CurrentUser.Avatar);
			else
				AvatarPB.BackgroundImage = Properties.Resources.empty_avatar_big;

		}

		#region Avatar

		private void ChooseNewAvatar_Click(object sender, EventArgs e)
		{
			if (openAvatarDialog.ShowDialog() == DialogResult.OK)
			{
				SaveNewAvatar.Enabled = true;
				SaveNewAvatar.Text = ButtonPlaceholder;
				AvatarPB.BackgroundImage = Image.FromFile(openAvatarDialog.FileName);
			}
		}

		private void SaveNewAvatar_Click(object sender, EventArgs e)
		{
			SaveNewAvatar.Image = Properties.Resources.load_gif;
			SaveNewAvatar.Text = "";
			AvatarBGW.RunWorkerAsync();
		}

		private void AvatarBGW_DoWork(object sender, DoWorkEventArgs e)
		{
			User u = new User
			{
				Avatar = ServiceClient.FromImageToBytes(AvatarPB.BackgroundImage),
				ID = Properties.Settings.Default.CurrentUser.ID
			};

			ServiceClient.ChangeAvatar(u);
		}

		private void AvatarBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			SaveNewAvatar.Image = null;
			SaveNewAvatar.Text = SuccessPlaceholer;
			SaveNewAvatar.Enabled = false;

			Properties.Settings.Default.CurrentUser.Avatar = ServiceClient.FromImageToBytes(AvatarPB.BackgroundImage);
			_parentForm.ChangeAvatar(AvatarPB.BackgroundImage);
		}

		#endregion

		#region Nickname

		private void UsernameTB_Enter(object sender, EventArgs e)
		{
			UsernameTB.RemoveText(UsernameTBPlaceholder);
		}

		private void UsernameTB_Leave(object sender, EventArgs e)
		{
			UsernameTB.AddText(UsernameTBPlaceholder);
		}

		private void UsernameTB_TextChanged(object sender, EventArgs e)
		{
			SaveNewUsername.Text = ButtonPlaceholder;

			if (String.IsNullOrWhiteSpace(UsernameTB.Text)
				|| UsernameTB.Text == UsernameTBPlaceholder
				|| UsernameTB.Text == Properties.Settings.Default.CurrentUser.Nickname)
				SaveNewUsername.Enabled = false;
			else
				SaveNewUsername.Enabled = true;
		}

		private void SaveNewUsername_Click(object sender, EventArgs e)
		{
			SaveNewUsername.Image = Properties.Resources.load_gif;
			SaveNewUsername.Text = "";
			UsernameBGW.RunWorkerAsync();
		}

		private void UsernameBGW_DoWork(object sender, DoWorkEventArgs e)
		{
			User u = new User
			{
				ID = Properties.Settings.Default.CurrentUser.ID,
				Nickname = UsernameTB.Text
			};

			ServiceClient.ChangeUsername(u);
		}

		private void UsernameBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			SaveNewUsername.Image = null;
			SaveNewUsername.Text = SuccessPlaceholer;
			SaveNewUsername.Enabled = false;

			Properties.Settings.Default.CurrentUser.Nickname = UsernameTB.Text;
			_parentForm.ChangeUsername(UsernameTB.Text);
		}

		#endregion

		#region Password

		private void CurrentPasswordTB_Enter(object sender, EventArgs e)
		{
			CurrentPasswordTB.RemoveText(CurrentPasswordTBPlaceholder);
			CurrentPasswordTB.PasswordChar = '●';
		}

		private void CurrentPasswordTB_Leave(object sender, EventArgs e)
		{
			CurrentPasswordTB.AddText(CurrentPasswordTBPlaceholder);
			if (String.IsNullOrWhiteSpace(CurrentPasswordTB.Text) || CurrentPasswordTB.Text == CurrentPasswordTBPlaceholder)
				CurrentPasswordTB.PasswordChar = '\0';
		}

		private void NewPasswordTB_Enter(object sender, EventArgs e)
		{
			NewPasswordTB.RemoveText(NewPasswordTBPlaceholder);
			NewPasswordTB.PasswordChar = '●';
		}

		private void NewPasswordTB_Leave(object sender, EventArgs e)
		{
			NewPasswordTB.AddText(NewPasswordTBPlaceholder);
			if (String.IsNullOrWhiteSpace(NewPasswordTB.Text) || NewPasswordTB.Text == NewPasswordTBPlaceholder)
				NewPasswordTB.PasswordChar = '\0';
		}

		private void NewPasswordAgainTB_Enter(object sender, EventArgs e)
		{
			NewPasswordAgainTB.RemoveText(NewPasswordAgainTBPlaceholder);
			NewPasswordAgainTB.PasswordChar = '●';
		}

		private void NewPasswordAgainTB_Leave(object sender, EventArgs e)
		{
			NewPasswordAgainTB.AddText(NewPasswordAgainTBPlaceholder);
			if (String.IsNullOrWhiteSpace(NewPasswordAgainTB.Text) || NewPasswordAgainTB.Text == NewPasswordAgainTBPlaceholder)
				NewPasswordAgainTB.PasswordChar = '\0';
		}

		private void PasswordTB_TextChanged(object sender, EventArgs e)
		{
			SaveNewPassword.Text = ButtonPlaceholder;
			SaveNewPassword.Enabled = true;
		}

		private void SaveNewPassword_Click(object sender, EventArgs e)
		{
			if (!CheckFields())
				return;

			if (!CheckEquality())
				return;

			SaveNewPassword.Image = Properties.Resources.load_gif;
			SaveNewPassword.Text = "";
			PasswordBGW.RunWorkerAsync();
		}

		private bool CheckFields()
		{
			bool ret = true;

			if (CurrentPasswordTB.Text == CurrentPasswordTBPlaceholder
				|| String.IsNullOrWhiteSpace(CurrentPasswordTB.Text)
				|| ServiceClient.GetSHA512Hash(CurrentPasswordTB.Text) != Properties.Settings.Default.CurrentUser.PasswordHash)
			{
				CurrentPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
				CurrentPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.PrimaryColor;

			if (NewPasswordTB.Text == NewPasswordTBPlaceholder
				|| String.IsNullOrWhiteSpace(NewPasswordTB.Text))
			{
				NewPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
				NewPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.PrimaryColor;

			if (NewPasswordAgainTB.Text == NewPasswordAgainTBPlaceholder
				|| String.IsNullOrWhiteSpace(NewPasswordAgainTB.Text))
			{
				NewPasswordAgainTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
				NewPasswordAgainTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.PrimaryColor;

			return ret;
		}

		private bool CheckEquality()
		{
			bool ret = true;

			if (NewPasswordTB.Text != NewPasswordAgainTB.Text)
			{
				NewPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.WarnColor;
				NewPasswordAgainTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
			{
				NewPasswordTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.PrimaryColor;
				NewPasswordAgainTB.Controls.Find("TextboxUnderline", true).First().BackColor
					= Properties.Settings.Default.PrimaryColor;
			}

			return ret;
		}

		private void PasswordBGW_DoWork(object sender, DoWorkEventArgs e)
		{
			User u = new User
			{
				ID = Properties.Settings.Default.CurrentUser.ID,
				PasswordHash = ServiceClient.GetSHA512Hash(NewPasswordTB.Text)
			};

			ServiceClient.ChangePassword(u);
		}

		private void PasswordBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Properties.Settings.Default.CurrentUser.PasswordHash = ServiceClient.GetSHA512Hash(NewPasswordTB.Text);

			CurrentPasswordTB.Text = "";
			CurrentPasswordTB_Leave(sender, e);

			NewPasswordTB.Text = "";
			NewPasswordTB_Leave(sender, e);

			NewPasswordAgainTB.Text = "";
			NewPasswordAgainTB_Leave(sender, e);

			SaveNewPassword.Image = null;
			SaveNewPassword.Text = SuccessPlaceholer;
			SaveNewPassword.Enabled = false;
		}

		#endregion
	}
}
