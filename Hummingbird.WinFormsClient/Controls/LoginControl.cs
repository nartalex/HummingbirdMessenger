using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using Hummingbird.Model;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class LoginControl : UserControl
	{
		readonly string LoginPlaceholder = "Логин";
		readonly string PasswordPlaceholder = "Пароль";

		public LoginControl()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			if (!CheckFields())
				return;

			LoginButton.Image = Properties.Resources.load_gif;
			LoginButton.Text = "";

			LoginBGW.RunWorkerAsync();
		}

		private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 13)
				return;

			LoginButton_Click(sender, e);
		}

		private void LoginBGW_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(1000);

			User user = new User
			{
				Login = LoginTextbox.Text,
				PasswordHash = ServiceClient.GetSHA512Hash(PasswordTextbox.Text)
			};

			e.Result = ServiceClient.LoginUser(user);
		}

		private void LoginBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			LoginButton.Image = null;
			LoginButton.Text = "Войти";

			if (e.Result is User)
			{
				Properties.Settings.Default.CurrentUser = (User)e.Result;
				Properties.Settings.Default.CurrentUserID = ((User)e.Result).ID;
				Properties.Settings.Default.Save();
				(Parent as StartForm).CloseAndContinue();
			}
			else if (e.Result is string)
			{
				WarningLabel.Text = (string)e.Result;
			}
			else
			{
				MessageBox.Show(e.Result.ToString());
			}
		}

		private bool CheckFields()
		{
			bool ret = true;

			if (LoginTextbox.Text == LoginPlaceholder || String.IsNullOrWhiteSpace(LoginTextbox.Text))
			{
				LoginTextbox.ForeColor = Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
			{
				LoginTextbox.ForeColor = Properties.Settings.Default.PrimaryColor;
			}

			if (PasswordTextbox.Text == PasswordPlaceholder || String.IsNullOrWhiteSpace(PasswordTextbox.Text))
			{
				PasswordTextbox.ForeColor = Properties.Settings.Default.WarnColor;
				ret = false;
			}
			else
			{
				PasswordTextbox.ForeColor = Properties.Settings.Default.PrimaryColor;
			}
			return ret;
		}

		#region Управление контролами

		private void LoginTextbox_Enter(object sender, EventArgs e)
		{
			LoginTextbox.RemoveText(LoginPlaceholder);
		}

		private void LoginTextbox_Leave(object sender, EventArgs e)
		{
			LoginTextbox.AddText(LoginPlaceholder);
		}

		private void PasswordTextbox_Enter(object sender, EventArgs e)
		{
			PasswordTextbox.RemoveText(PasswordPlaceholder);
			PasswordTextbox.PasswordChar = '●';
		}

		private void PasswordTextbox_Leave(object sender, EventArgs e)
		{
			PasswordTextbox.AddText(PasswordPlaceholder);
			if (String.IsNullOrWhiteSpace(PasswordTextbox.Text) || PasswordTextbox.Text == PasswordPlaceholder)
				PasswordTextbox.PasswordChar = '\0';
		}

		private void BackToStartButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			var parentForm = (this.Parent as StartForm);
			parentForm.BackToStartForm();
		}

		#endregion
	}
}
