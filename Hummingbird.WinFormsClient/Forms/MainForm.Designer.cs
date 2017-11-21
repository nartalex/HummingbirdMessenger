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
			this.ChatsListPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.UserSearchButton = new System.Windows.Forms.Button();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.UserExit = new System.Windows.Forms.Button();
			this.CurrentUserNameLabel = new System.Windows.Forms.Label();
			this.CurrentUserAvatar = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// ChatsListPanel
			// 
			this.ChatsListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatsListPanel.Location = new System.Drawing.Point(0, 76);
			this.ChatsListPanel.Name = "ChatsListPanel";
			this.ChatsListPanel.Size = new System.Drawing.Size(334, 325);
			this.ChatsListPanel.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.CurrentUserNameLabel);
			this.panel1.Controls.Add(this.CurrentUserAvatar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 70);
			this.panel1.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.UserSearchButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.SettingsButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.UserExit, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(73, 37);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 30);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// UserSearchButton
			// 
			this.UserSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserSearchButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_search;
			this.UserSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.UserSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserSearchButton.FlatAppearance.BorderSize = 0;
			this.UserSearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.UserSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.UserSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UserSearchButton.Location = new System.Drawing.Point(3, 3);
			this.UserSearchButton.Name = "UserSearchButton";
			this.UserSearchButton.Size = new System.Drawing.Size(80, 24);
			this.UserSearchButton.TabIndex = 0;
			this.UserSearchButton.UseVisualStyleBackColor = true;
			this.UserSearchButton.Click += new System.EventHandler(this.UserSearchButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_settings;
			this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SettingsButton.FlatAppearance.BorderSize = 0;
			this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SettingsButton.Location = new System.Drawing.Point(89, 3);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(80, 24);
			this.SettingsButton.TabIndex = 1;
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// UserExit
			// 
			this.UserExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserExit.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_exit;
			this.UserExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.UserExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserExit.FlatAppearance.BorderSize = 0;
			this.UserExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.UserExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.UserExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UserExit.Location = new System.Drawing.Point(175, 3);
			this.UserExit.Name = "UserExit";
			this.UserExit.Size = new System.Drawing.Size(80, 24);
			this.UserExit.TabIndex = 2;
			this.UserExit.UseVisualStyleBackColor = true;
			this.UserExit.Click += new System.EventHandler(this.UserExit_Click);
			// 
			// CurrentUserNameLabel
			// 
			this.CurrentUserNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CurrentUserNameLabel.Location = new System.Drawing.Point(73, 3);
			this.CurrentUserNameLabel.Name = "CurrentUserNameLabel";
			this.CurrentUserNameLabel.Size = new System.Drawing.Size(258, 34);
			this.CurrentUserNameLabel.TabIndex = 1;
			this.CurrentUserNameLabel.Text = "username";
			this.CurrentUserNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CurrentUserAvatar
			// 
			this.CurrentUserAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.CurrentUserAvatar.Location = new System.Drawing.Point(3, 3);
			this.CurrentUserAvatar.Name = "CurrentUserAvatar";
			this.CurrentUserAvatar.Size = new System.Drawing.Size(64, 64);
			this.CurrentUserAvatar.TabIndex = 0;
			this.CurrentUserAvatar.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(334, 401);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ChatsListPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MinimumSize = new System.Drawing.Size(350, 440);
			this.Name = "MainForm";
			this.Text = "MessengerForm";
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.Panel ChatsListPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox CurrentUserAvatar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label CurrentUserNameLabel;
		private System.Windows.Forms.Button UserSearchButton;
		private System.Windows.Forms.Button SettingsButton;
		private System.Windows.Forms.Button UserExit;
	}
}