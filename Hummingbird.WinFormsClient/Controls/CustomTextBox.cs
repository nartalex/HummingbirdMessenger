using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System;
using System.Linq;
using ReactiveAnimation;
using VisualEffects;
using VisualEffects.Animations.Effects;

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

        public void RemoveText(string placeholder)
        {
            if (Text != placeholder)
                return;

            ForeColor = Properties.Settings.Default.PrimaryColor;
            Font = new Font("Segoe UI", 16f, FontStyle.Regular);

            this.Text = "";
            this.Controls.Find("TextboxUnderline", true).First().BackColor = Properties.Settings.Default.PrimaryColor;
        }

        public void AddText(string placeholder)
        {
            if (String.IsNullOrWhiteSpace(this.Text))
            {
                ForeColor = Color.Gray;
                Font = new Font("Segoe UI Light", 16f, FontStyle.Regular);

                this.Text = placeholder;
                this.Controls.Find("TextboxUnderline", true).First().BackColor = Color.Gray;
            }
        }

    }
}