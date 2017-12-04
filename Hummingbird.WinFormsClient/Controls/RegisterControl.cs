using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
    public partial class RegisterControl : UserControl
    {
        readonly string LoginPlaceholder = "Логин";
        readonly string PasswordPlaceholder = "Пароль";
        readonly string NicknamePlaceholder = "Имя пользователя";

        public RegisterControl()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
                return;

	        RegisterButton.Image = Properties.Resources.load_gif;
	        RegisterButton.Text = "";

	        RegisterBGW.RunWorkerAsync();
		}

	    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
	    {
		    if (e.KeyChar != 13)
			    return;

		    e.Handled = true;

		    RegisterButton_Click(sender, e);
	    }


		private void RegisterBGW_DoWork(object sender, DoWorkEventArgs e)
	    {
		    Thread.Sleep(1000);

		    User user = new User
		    {
			    Nickname = NicknameTextbox.Text,
			    Login = LoginTextbox.Text,
			    PasswordHash = ServiceClient.GetSHA512Hash(PasswordTextbox.Text)
		    };

		    e.Result = ServiceClient.RegisterUser(user);
	    }

	    private void RegisterBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	    {
		    RegisterButton.Image = null;
		    RegisterButton.Text = "Регистрация";

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
            WarningLabel.Text = "";

            if (NicknameTextbox.Text == NicknamePlaceholder || String.IsNullOrWhiteSpace(NicknameTextbox.Text))
            {
                NicknameTextbox.ForeColor = Properties.Settings.Default.WarnColor;
                ret = false;
            }
            else
            {
                NicknameTextbox.ForeColor = Properties.Settings.Default.PrimaryColor;
            }

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

        private void NicknameTextbox_Enter(object sender, EventArgs e)
        {
            NicknameTextbox.RemoveText(NicknamePlaceholder);
        }

        private void NicknameTextbox_Leave(object sender, EventArgs e)
        {
            NicknameTextbox.AddText(NicknamePlaceholder);
        }

		#endregion
	}
}
