using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System;

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
                Height = 3,
                Dock = DockStyle.Bottom,
                BackColor = Properties.Settings.Default.PrimaryColorDark
            });
        }

        public void RemoveText(string placeholder)
        {
            if (Text != placeholder)
                return;

            var regularFont = new Font("Segoe UI", 18f, FontStyle.Regular);

            ForeColor = Color.Black;
            Font = regularFont;

            this.Text = "";
        }

        public void AddText(string placeholder)
        {
            if (String.IsNullOrWhiteSpace(this.Text))
            {
                var placeholderFont = new Font("Segoe UI Light", 18f, FontStyle.Italic);

                ForeColor = Properties.Settings.Default.PrimaryColorDark;
                Font = placeholderFont;

                this.Text = placeholder;
            }
        }
    }
}