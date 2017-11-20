namespace Hummingbird.WinFormsClient.Forms
{
    partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.UsersSearchTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.ChatsListPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.CurrentUserAvatar = new System.Windows.Forms.PictureBox();
			this.CurrentUserNameLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.White;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersSearchTSM,
            this.SettingsTSM,
            this.ExitTSM});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(334, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// UsersSearchTSM
			// 
			this.UsersSearchTSM.Name = "UsersSearchTSM";
			this.UsersSearchTSM.Size = new System.Drawing.Size(54, 20);
			this.UsersSearchTSM.Text = "Поиск";
			this.UsersSearchTSM.Click += new System.EventHandler(this.UsersSearchTSM_Click);
			// 
			// SettingsTSM
			// 
			this.SettingsTSM.Name = "SettingsTSM";
			this.SettingsTSM.Size = new System.Drawing.Size(79, 20);
			this.SettingsTSM.Text = "Настройки";
			// 
			// ExitTSM
			// 
			this.ExitTSM.Name = "ExitTSM";
			this.ExitTSM.Size = new System.Drawing.Size(53, 20);
			this.ExitTSM.Text = "Выход";
			this.ExitTSM.Click += new System.EventHandler(this.ExitTSM_Click);
			// 
			// ChatsListPanel
			// 
			this.ChatsListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatsListPanel.Location = new System.Drawing.Point(0, 100);
			this.ChatsListPanel.Name = "ChatsListPanel";
			this.ChatsListPanel.Size = new System.Drawing.Size(334, 301);
			this.ChatsListPanel.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.CurrentUserNameLabel);
			this.panel1.Controls.Add(this.CurrentUserAvatar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 70);
			this.panel1.TabIndex = 3;
			// 
			// CurrentUserAvatar
			// 
			this.CurrentUserAvatar.Location = new System.Drawing.Point(3, 3);
			this.CurrentUserAvatar.Name = "CurrentUserAvatar";
			this.CurrentUserAvatar.Size = new System.Drawing.Size(64, 64);
			this.CurrentUserAvatar.TabIndex = 0;
			this.CurrentUserAvatar.TabStop = false;
			// 
			// CurrentUserNameLabel
			// 
			this.CurrentUserNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentUserNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CurrentUserNameLabel.Location = new System.Drawing.Point(73, 3);
			this.CurrentUserNameLabel.Name = "CurrentUserNameLabel";
			this.CurrentUserNameLabel.Size = new System.Drawing.Size(258, 26);
			this.CurrentUserNameLabel.TabIndex = 1;
			this.CurrentUserNameLabel.Text = "username";
			this.CurrentUserNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(73, 33);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 34);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(334, 401);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ChatsListPanel);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(350, 440);
			this.Name = "MainForm";
			this.Text = "MessengerForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem UsersSearchTSM;
		private System.Windows.Forms.ToolStripMenuItem SettingsTSM;
		private System.Windows.Forms.ToolStripMenuItem ExitTSM;
		private System.Windows.Forms.Panel ChatsListPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox CurrentUserAvatar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label CurrentUserNameLabel;
	}
}