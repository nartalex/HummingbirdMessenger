using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

using Hummingbird.Model;

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

            User user = new User
            {
                Nickname = NicknameTextbox.Text,
                Login = LoginTextbox.Text,
                PasswordHash = ServiceClient.GetSHA512Hash(PasswordTextbox.Text)
            };

            object result=ServiceClient.RegisterUser(user);
            if (result is User)
            {
                Properties.Settings.Default.CurrentUser = result as User;
	            Properties.Settings.Default.Save();
				(Parent as StartForm).CloseAndContinue();
            }
            else if (result is string)
            {
                WarningLabel.Text = (string)result;
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
