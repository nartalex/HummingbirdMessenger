using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System;

public class CustomTextBox : TextBox
{
    string Placeholder;

    public CustomTextBox(string placeholder)
    {
        BorderStyle = System.Windows.Forms.BorderStyle.None;
        AutoSize = false; //Allows you to change height to have bottom padding
        Controls.Add(new Label()
        {
            Height = 1,
            Dock = DockStyle.Bottom,
            BackColor = Color.Black
        });

        this.Text = Placeholder = placeholder;
    }

    public void RemoveText(object sender, EventArgs e)
    {
        this.Text = "";
    }

    public void AddText(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(this.Text))
            this.Text = Placeholder;
    }
}