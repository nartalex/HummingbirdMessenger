using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System;
using System.Linq;

namespace Hummingbird.WinFormsClient
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false; //Allows you to change height to have bottom padding
            Controls.Add(new Label()
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.Gray,
                Name = "TextboxUnderline"
            });
        }

        public void RemoveText(string placeholder, float fontSize = 16)
        {
	        this.Controls.Find("TextboxUnderline", true).First().BackColor = Properties.Settings.Default.PrimaryColor;

			if (Text != placeholder)
                return;

            ForeColor = Properties.Settings.Default.PrimaryColor;
            Font = new Font("Segoe UI", fontSize, FontStyle.Regular);

            this.Text = "";
        }

        public void AddText(string placeholder, float fontSize = 16)
        {
			if (String.IsNullOrWhiteSpace(this.Text))
            {
                ForeColor = Color.Gray;
                Font = new Font("Segoe UI Light", fontSize, FontStyle.Regular);

                this.Text = placeholder;
	            this.Controls.Find("TextboxUnderline", true).First().BackColor = Color.Gray;
			}
		}

    }
}