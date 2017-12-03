using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class AttachedImageViewForm : Form
	{
		public AttachedImageViewForm(string name, Image image)
		{
			InitializeComponent();
			Text = name;
			ImagePB.BackgroundImage = image;

			Size = image.Size;
			if(image.Size.Width > 1000)
				Width = 1000;
			if(image.Size.Height > 500)
				Height = 500;
		}
	}
}
