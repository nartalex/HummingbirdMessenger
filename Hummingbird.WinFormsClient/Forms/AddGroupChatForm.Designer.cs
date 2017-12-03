namespace Hummingbird.WinFormsClient.Forms
{
	partial class AddGroupChatForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChatAvatarPB = new System.Windows.Forms.PictureBox();
			this.ChooseNewAvatar = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ChatnameTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.UsersCheckBoxList = new System.Windows.Forms.CheckedListBox();
			this.OpenAvatarDialog = new System.Windows.Forms.OpenFileDialog();
			this.CreateChatButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatarPB)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.ChatAvatarPB);
			this.groupBox1.Controls.Add(this.ChooseNewAvatar);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.ForeColor = System.Drawing.Color.Black;
			this.groupBox1.Location = new System.Drawing.Point(12, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(460, 184);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Аватар";
			// 
			// ChatAvatarPB
			// 
			this.ChatAvatarPB.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.empty_chat_avatar_big;
			this.ChatAvatarPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ChatAvatarPB.Location = new System.Drawing.Point(22, 30);
			this.ChatAvatarPB.Name = "ChatAvatarPB";
			this.ChatAvatarPB.Size = new System.Drawing.Size(128, 128);
			this.ChatAvatarPB.TabIndex = 0;
			this.ChatAvatarPB.TabStop = false;
			// 
			// ChooseNewAvatar
			// 
			this.ChooseNewAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ChooseNewAvatar.FlatAppearance.BorderSize = 0;
			this.ChooseNewAvatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.ChooseNewAvatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.ChooseNewAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChooseNewAvatar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ChooseNewAvatar.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.ChooseNewAvatar.Location = new System.Drawing.Point(167, 30);
			this.ChooseNewAvatar.Name = "ChooseNewAvatar";
			this.ChooseNewAvatar.Size = new System.Drawing.Size(288, 128);
			this.ChooseNewAvatar.TabIndex = 1;
			this.ChooseNewAvatar.Text = "Выбрать аватар";
			this.ChooseNewAvatar.UseVisualStyleBackColor = true;
			this.ChooseNewAvatar.Click += new System.EventHandler(this.ChooseNewAvatar_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ChatnameTB);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.ForeColor = System.Drawing.Color.Black;
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(460, 78);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Название чата";
			// 
			// ChatnameTB
			// 
			this.ChatnameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChatnameTB.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
			this.ChatnameTB.ForeColor = System.Drawing.Color.Gray;
			this.ChatnameTB.Location = new System.Drawing.Point(7, 32);
			this.ChatnameTB.Name = "ChatnameTB";
			this.ChatnameTB.Size = new System.Drawing.Size(447, 33);
			this.ChatnameTB.TabIndex = 0;
			this.ChatnameTB.Text = "Введите название чата";
			this.ChatnameTB.Enter += new System.EventHandler(this.ChatnameTB_Enter);
			this.ChatnameTB.Leave += new System.EventHandler(this.ChatnameTB_Leave);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.UsersCheckBoxList);
			this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox3.Location = new System.Drawing.Point(13, 286);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(459, 173);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Пользователи";
			// 
			// UsersCheckBoxList
			// 
			this.UsersCheckBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UsersCheckBoxList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UsersCheckBoxList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UsersCheckBoxList.FormattingEnabled = true;
			this.UsersCheckBoxList.Location = new System.Drawing.Point(6, 23);
			this.UsersCheckBoxList.Name = "UsersCheckBoxList";
			this.UsersCheckBoxList.Size = new System.Drawing.Size(447, 144);
			this.UsersCheckBoxList.Sorted = true;
			this.UsersCheckBoxList.TabIndex = 0;
			this.UsersCheckBoxList.SelectedIndexChanged += new System.EventHandler(this.UsersCheckBoxList_SelectedIndexChanged);
			// 
			// OpenAvatarDialog
			// 
			this.OpenAvatarDialog.FileName = "openFileDialog1";
			// 
			// CreateChatButton
			// 
			this.CreateChatButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CreateChatButton.Enabled = false;
			this.CreateChatButton.FlatAppearance.BorderSize = 0;
			this.CreateChatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.CreateChatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.CreateChatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateChatButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CreateChatButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.CreateChatButton.Location = new System.Drawing.Point(13, 465);
			this.CreateChatButton.Name = "CreateChatButton";
			this.CreateChatButton.Size = new System.Drawing.Size(459, 39);
			this.CreateChatButton.TabIndex = 6;
			this.CreateChatButton.Text = "Создать";
			this.CreateChatButton.UseVisualStyleBackColor = true;
			this.CreateChatButton.Click += new System.EventHandler(this.CreateChatButton_Click);
			// 
			// AddGroupChatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(484, 516);
			this.Controls.Add(this.CreateChatButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AddGroupChatForm";
			this.Text = "AddGroupChatForm";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatarPB)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox ChatAvatarPB;
		private System.Windows.Forms.Button ChooseNewAvatar;
		private System.Windows.Forms.GroupBox groupBox2;
		private CustomTextBox ChatnameTB;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckedListBox UsersCheckBoxList;
		private System.Windows.Forms.OpenFileDialog OpenAvatarDialog;
		private System.Windows.Forms.Button CreateChatButton;
	}
}