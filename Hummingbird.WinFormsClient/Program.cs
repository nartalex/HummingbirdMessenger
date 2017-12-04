using System;
using System.Windows.Forms;
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

			var startForm = new StartForm();
			startForm.Show();

			Application.Run();
		}
	}
}
