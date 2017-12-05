using System;
using System.Windows.Forms;
using Hummingbird.WinFormsClient.Controls;

namespace Hummingbird.WinFormsClient.Forms
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
			Controls.Add(loginControl);
        }

        public void ShowRegisterForm()
        {
            startControl.Hide();

            RegisterControl registerControl = new RegisterControl
            {
                Top = h,
                Left = w
            };
			Controls.Add(registerControl);
        }

        public void BackToStartForm()
        {
            startControl.Show();
        }

		private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//Application.Exit();
		}

		public void CloseAndContinue()
        {
            Close();
            var newForm = new MainForm();
            
            newForm.Show();
        }		
    }
}
