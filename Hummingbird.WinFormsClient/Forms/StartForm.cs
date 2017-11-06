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

namespace Hummingbird.WinFormsClient
{
    public partial class StartForm : Form
    {
        int h, w;
        public StartForm()
        {
            InitializeComponent();
            h = StartControl.Top;
            w = StartControl.Left;
        }

        public void ShowLoginForm()
        {           
            StartControl.Hide();

            LoginControl loginControl = new LoginControl
            {
                Top = h,
                Left = w
            };
            this.Controls.Add(loginControl);
        }

        public void ShowRegisterForm()
        {
            StartControl.Hide();

            RegisterControl registerControl = new RegisterControl
            {
                Top = h,
                Left = w
            };
            this.Controls.Add(registerControl);
        }

        public void BackToStartForm()
        {
            StartControl.Show();
        }
    }
}
