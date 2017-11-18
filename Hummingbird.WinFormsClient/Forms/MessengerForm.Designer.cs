namespace Hummingbird.WinFormsClient.Forms
{
	partial class MessengerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MessageTextBox = new System.Windows.Forms.TextBox();
			this.SendMessageButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.MessagesPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// MessageTextBox
			// 
			this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MessageTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MessageTextBox.Location = new System.Drawing.Point(0, 323);
			this.MessageTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.MessageTextBox.Multiline = true;
			this.MessageTextBox.Name = "MessageTextBox";
			this.MessageTextBox.Size = new System.Drawing.Size(384, 37);
			this.MessageTextBox.TabIndex = 0;
			// 
			// SendMessageButton
			// 
			this.SendMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SendMessageButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.send_message_purple;
			this.SendMessageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SendMessageButton.FlatAppearance.BorderSize = 0;
			this.SendMessageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.SendMessageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.SendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SendMessageButton.Location = new System.Drawing.Point(393, 323);
			this.SendMessageButton.Name = "SendMessageButton";
			this.SendMessageButton.Size = new System.Drawing.Size(32, 32);
			this.SendMessageButton.TabIndex = 1;
			this.SendMessageButton.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.photo;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(12, 259);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(50, 259);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(333, 32);
			this.label1.TabIndex = 3;
			this.label1.Text = "Привет";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Visible = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(50, 291);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.photo;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox2.Image = global::Hummingbird.WinFormsClient.Properties.Resources.add_friend;
			this.pictureBox2.Location = new System.Drawing.Point(389, 259);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 32);
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Visible = false;
			// 
			// MessagesPanel
			// 
			this.MessagesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessagesPanel.AutoScroll = true;
			this.MessagesPanel.Location = new System.Drawing.Point(0, 12);
			this.MessagesPanel.Name = "MessagesPanel";
			this.MessagesPanel.Size = new System.Drawing.Size(433, 268);
			this.MessagesPanel.TabIndex = 6;
			// 
			// MessengerForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(433, 360);
			this.Controls.Add(this.MessagesPanel);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.SendMessageButton);
			this.Controls.Add(this.MessageTextBox);
			this.Name = "MessengerForm";
			this.Text = "MessengerForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox MessageTextBox;
		private System.Windows.Forms.Button SendMessageButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Panel MessagesPanel;
	}
}