using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
    public partial class StartControl : UserControl
    {
        Form Owner;

        public StartControl()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Form parentForm = (this.Parent as Form);
        }
    }
}
