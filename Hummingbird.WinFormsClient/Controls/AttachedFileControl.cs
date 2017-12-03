using System;
using System.IO;
using System.Windows.Forms;

namespace Hummingbird.WinFormsClient.Controls
{
	public partial class AttachedFileControl : UserControl
	{
		private byte[] AttachedFile;

		public AttachedFileControl(string fileName, byte[] file)
		{
			InitializeComponent();
			FileNameLabel.Text = fileName;
			AttachedFile = file;
			SaveAttachDialog.FileName = fileName;
		}

		private void ControlClick(object sender, EventArgs e)
		{
			if(SaveAttachDialog.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllBytes(SaveAttachDialog.FileName, AttachedFile);
			}
		}
	}
}
