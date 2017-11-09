using Hummingbird.WinFormsClient.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveAnimation;

namespace Hummingbird.WinFormsClient
{
    public partial class StartForm : Form
    {
        int h, w;
        public StartForm()
        {
            InitializeComponent();
            h = startControl.Top;
            w = startControl.Left;
        }

        public void ShowLoginForm()
        {
            startControl.Hide();

            LoginControl loginControl = new LoginControl
            {
                Top = h,
                Left = w
            };
            this.Controls.Add(loginControl);
        }

        public void ShowRegisterForm()
        {
            startControl.Hide();

            RegisterControl registerControl = new RegisterControl
            {
                Top = h,
                Left = w
            };
            this.Controls.Add(registerControl);
        }

        private void StartForm_Shown(object sender, EventArgs e)
        {

        }

        public void BackToStartForm()
        {
            startControl.Show();
        }
    }
}
