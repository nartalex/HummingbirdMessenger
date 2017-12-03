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
			this.panel1 = new System.Windows.Forms.Panel();
			this.UserButtonsTable = new System.Windows.Forms.TableLayoutPanel();
			this.UserSearchButton = new System.Windows.Forms.Button();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.UserExit = new System.Windows.Forms.Button();
			this.GroupAddButton = new System.Windows.Forms.Button();
			this.CurrentUserAvatar = new System.Windows.Forms.PictureBox();
			this.ChatsListTable = new System.Windows.Forms.TableLayoutPanel();
			this.CurrentUserNameLabel = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.UserButtonsTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.UserButtonsTable);
			this.panel1.Controls.Add(this.CurrentUserNameLabel);
			this.panel1.Controls.Add(this.CurrentUserAvatar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 72);
			this.panel1.TabIndex = 3;
			// 
			// UserButtonsTable
			// 
			this.UserButtonsTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserButtonsTable.ColumnCount = 4;
			this.UserButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.UserButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.UserButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.UserButtonsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.UserButtonsTable.Controls.Add(this.UserSearchButton, 1, 0);
			this.UserButtonsTable.Controls.Add(this.SettingsButton, 2, 0);
			this.UserButtonsTable.Controls.Add(this.UserExit, 3, 0);
			this.UserButtonsTable.Controls.Add(this.GroupAddButton, 0, 0);
			this.UserButtonsTable.Location = new System.Drawing.Point(73, 36);
			this.UserButtonsTable.Name = "UserButtonsTable";
			this.UserButtonsTable.RowCount = 1;
			this.UserButtonsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.UserButtonsTable.Size = new System.Drawing.Size(258, 33);
			this.UserButtonsTable.TabIndex = 2;
			this.UserButtonsTable.Resize += new System.EventHandler(this.UserButtonsTable_Resize);
			// 
			// UserSearchButton
			// 
			this.UserSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserSearchButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_search;
			this.UserSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.UserSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserSearchButton.FlatAppearance.BorderSize = 0;
			this.UserSearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.UserSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.UserSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UserSearchButton.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F);
			this.UserSearchButton.Location = new System.Drawing.Point(67, 3);
			this.UserSearchButton.Name = "UserSearchButton";
			this.UserSearchButton.Size = new System.Drawing.Size(58, 27);
			this.UserSearchButton.TabIndex = 0;
			this.UserSearchButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.UserSearchButton.UseVisualStyleBackColor = true;
			this.UserSearchButton.Click += new System.EventHandler(this.UserSearchButton_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_settings;
			this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SettingsButton.FlatAppearance.BorderSize = 0;
			this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SettingsButton.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F);
			this.SettingsButton.Location = new System.Drawing.Point(131, 3);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(58, 27);
			this.SettingsButton.TabIndex = 1;
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// UserExit
			// 
			this.UserExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UserExit.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.user_exit;
			this.UserExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.UserExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserExit.FlatAppearance.BorderSize = 0;
			this.UserExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.UserExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.UserExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UserExit.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F);
			this.UserExit.Location = new System.Drawing.Point(195, 3);
			this.UserExit.Name = "UserExit";
			this.UserExit.Size = new System.Drawing.Size(60, 27);
			this.UserExit.TabIndex = 2;
			this.UserExit.UseVisualStyleBackColor = true;
			this.UserExit.Click += new System.EventHandler(this.UserExit_Click);
			// 
			// GroupAddButton
			// 
			this.GroupAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GroupAddButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.add_group_chat;
			this.GroupAddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.GroupAddButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.GroupAddButton.FlatAppearance.BorderSize = 0;
			this.GroupAddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.GroupAddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.GroupAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GroupAddButton.Font = new System.Drawing.Font("Segoe UI Semilight", 10.5F);
			this.GroupAddButton.Location = new System.Drawing.Point(3, 3);
			this.GroupAddButton.Name = "GroupAddButton";
			this.GroupAddButton.Size = new System.Drawing.Size(58, 27);
			this.GroupAddButton.TabIndex = 3;
			this.GroupAddButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.GroupAddButton.UseVisualStyleBackColor = true;
			this.GroupAddButton.Click += new System.EventHandler(this.GroupAddButton_Click);
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
			// ChatsListTable
			// 
			this.ChatsListTable.AutoScroll = true;
			this.ChatsListTable.BackColor = System.Drawing.SystemColors.Control;
			this.ChatsListTable.ColumnCount = 1;
			this.ChatsListTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ChatsListTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChatsListTable.Location = new System.Drawing.Point(0, 72);
			this.ChatsListTable.Name = "ChatsListTable";
			this.ChatsListTable.RowCount = 1;
			this.ChatsListTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
			this.ChatsListTable.Size = new System.Drawing.Size(334, 329);
			this.ChatsListTable.TabIndex = 4;
			// 
			// CurrentUserNameLabel
			// 
			this.CurrentUserNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentUserNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CurrentUserNameLabel.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.CurrentUserNameLabel.Location = new System.Drawing.Point(73, 3);
			this.CurrentUserNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.CurrentUserNameLabel.Name = "CurrentUserNameLabel";
			this.CurrentUserNameLabel.Size = new System.Drawing.Size(258, 30);
			this.CurrentUserNameLabel.TabIndex = 1;
			this.CurrentUserNameLabel.Text = "Uqtby";
			this.CurrentUserNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(334, 401);
			this.Controls.Add(this.ChatsListTable);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MinimumSize = new System.Drawing.Size(350, 440);
			this.Name = "MainForm";
			this.Text = "MessengerForm";
			this.panel1.ResumeLayout(false);
			this.UserButtonsTable.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CurrentUserAvatar)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox CurrentUserAvatar;
		private System.Windows.Forms.TableLayoutPanel UserButtonsTable;
		private System.Windows.Forms.Label CurrentUserNameLabel;
		private System.Windows.Forms.Button UserSearchButton;
		private System.Windows.Forms.Button SettingsButton;
		private System.Windows.Forms.Button UserExit;
		private System.Windows.Forms.TableLayoutPanel ChatsListTable;
		private System.Windows.Forms.Button GroupAddButton;
	}
}