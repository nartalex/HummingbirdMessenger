using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hummingbird.Model;
using Hummingbird.WinFormsClient.Forms;

namespace Hummingbird.WinFormsClient
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			ServiceClient.Initialize();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Properties.Settings.Default.Upgrade();
			//if (Properties.Settings.Default.CurrentUserID == new Guid())
			//{
				var startForm = new StartForm();
				startForm.Show();
			//}
			//else
			//{
				//object result = ServiceClient.LoginUser(Properties.Settings.Default.CurrentUser);
				//if (result is User)
				//{
					//var messengerForm = new MainForm();
					//messengerForm.Show();
				//}
				//else
				//{
				//	var startForm = new StartForm();
				//	startForm.Show();
				//}
			//}

			Application.Run();
		}
	}
}
