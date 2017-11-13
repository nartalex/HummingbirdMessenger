﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

	        if(Properties.Settings.Default.CurrentUserID != null
	           && Properties.Settings.Default.CurrentUserID.ToString() == Guid.Empty.ToString())
	        {
		        var startForm = new StartForm();
		        startForm.Show();
	        }
	        else
	        {
		        var messengerForm = new MessengerForm();
				messengerForm.Show();
	        }

	        Application.Run();
        }
    }
}
