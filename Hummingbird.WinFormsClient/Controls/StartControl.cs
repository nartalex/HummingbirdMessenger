using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
    public partial class StartControl : UserControl
    {
        public StartControl()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var parentForm = (this.Parent as StartForm);
            parentForm.ShowLoginForm();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var parentForm = (this.Parent as StartForm);
            parentForm.ShowRegisterForm();
        }
    }
}
