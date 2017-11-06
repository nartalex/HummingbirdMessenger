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

        private void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
