namespace Hummingbird.WinFormsClient.Controls
{
	partial class AttachedFileControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Icon = new System.Windows.Forms.PictureBox();
			this.FileNameLabel = new System.Windows.Forms.Label();
			this.SaveAttachDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
			this.SuspendLayout();
			// 
			// Icon
			// 
			this.Icon.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.file;
			this.Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Icon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Icon.Location = new System.Drawing.Point(0, 0);
			this.Icon.Margin = new System.Windows.Forms.Padding(0);
			this.Icon.Name = "Icon";
			this.Icon.Size = new System.Drawing.Size(32, 32);
			this.Icon.TabIndex = 0;
			this.Icon.TabStop = false;
			this.Icon.Click += new System.EventHandler(this.ControlClick);
			// 
			// FileNameLabel
			// 
			this.FileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FileNameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FileNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FileNameLabel.ForeColor = System.Drawing.Color.Black;
			this.FileNameLabel.Location = new System.Drawing.Point(37, 0);
			this.FileNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.FileNameLabel.Name = "FileNameLabel";
			this.FileNameLabel.Size = new System.Drawing.Size(149, 32);
			this.FileNameLabel.TabIndex = 1;
			this.FileNameLabel.Text = "Qwertyq";
			this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.FileNameLabel.Click += new System.EventHandler(this.ControlClick);
			// 
			// AttachedFileControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.FileNameLabel);
			this.Controls.Add(this.Icon);
			this.Name = "AttachedFileControl";
			this.Size = new System.Drawing.Size(200, 32);
			((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox Icon;
		private System.Windows.Forms.Label FileNameLabel;
		private System.Windows.Forms.SaveFileDialog SaveAttachDialog;
	}
}
