namespace Hummingbird.WinFormsClient.Forms
{
	partial class ChatSettingsForm
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
			this.UsersGB = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.RemoveMemersCLB = new System.Windows.Forms.CheckedListBox();
			this.AddMembersCLB = new System.Windows.Forms.CheckedListBox();
			this.NameGB = new System.Windows.Forms.GroupBox();
			this.AvatarGB = new System.Windows.Forms.GroupBox();
			this.ChatAvatarPB = new System.Windows.Forms.PictureBox();
			this.ChooseNewAvatar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.TimerGB = new System.Windows.Forms.GroupBox();
			this.AvatarOFD = new System.Windows.Forms.OpenFileDialog();
			this.SaveChatButton = new System.Windows.Forms.Button();
			this.TimeToLiveNUD = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.ChatnameTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.UsersGB.SuspendLayout();
			this.NameGB.SuspendLayout();
			this.AvatarGB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatarPB)).BeginInit();
			this.TimerGB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TimeToLiveNUD)).BeginInit();
			this.SuspendLayout();
			// 
			// UsersGB
			// 
			this.UsersGB.Controls.Add(this.label2);
			this.UsersGB.Controls.Add(this.label1);
			this.UsersGB.Controls.Add(this.RemoveMemersCLB);
			this.UsersGB.Controls.Add(this.AddMembersCLB);
			this.UsersGB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UsersGB.Location = new System.Drawing.Point(13, 286);
			this.UsersGB.Name = "UsersGB";
			this.UsersGB.Size = new System.Drawing.Size(460, 198);
			this.UsersGB.TabIndex = 8;
			this.UsersGB.TabStop = false;
			this.UsersGB.Text = "Пользователи";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(233, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(221, 21);
			this.label2.TabIndex = 7;
			this.label2.Text = "Исключить пользователей:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 21);
			this.label1.TabIndex = 6;
			this.label1.Text = "Добавить пользователей:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RemoveMemersCLB
			// 
			this.RemoveMemersCLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveMemersCLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RemoveMemersCLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RemoveMemersCLB.FormattingEnabled = true;
			this.RemoveMemersCLB.Location = new System.Drawing.Point(234, 47);
			this.RemoveMemersCLB.Name = "RemoveMemersCLB";
			this.RemoveMemersCLB.Size = new System.Drawing.Size(220, 146);
			this.RemoveMemersCLB.Sorted = true;
			this.RemoveMemersCLB.TabIndex = 5;
			// 
			// AddMembersCLB
			// 
			this.AddMembersCLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddMembersCLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AddMembersCLB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AddMembersCLB.FormattingEnabled = true;
			this.AddMembersCLB.Location = new System.Drawing.Point(6, 47);
			this.AddMembersCLB.Name = "AddMembersCLB";
			this.AddMembersCLB.Size = new System.Drawing.Size(221, 146);
			this.AddMembersCLB.Sorted = true;
			this.AddMembersCLB.TabIndex = 4;
			// 
			// NameGB
			// 
			this.NameGB.Controls.Add(this.ChatnameTB);
			this.NameGB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NameGB.ForeColor = System.Drawing.Color.Black;
			this.NameGB.Location = new System.Drawing.Point(12, 12);
			this.NameGB.Name = "NameGB";
			this.NameGB.Size = new System.Drawing.Size(460, 78);
			this.NameGB.TabIndex = 7;
			this.NameGB.TabStop = false;
			this.NameGB.Text = "Название чата";
			// 
			// AvatarGB
			// 
			this.AvatarGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AvatarGB.Controls.Add(this.ChatAvatarPB);
			this.AvatarGB.Controls.Add(this.ChooseNewAvatar);
			this.AvatarGB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AvatarGB.ForeColor = System.Drawing.Color.Black;
			this.AvatarGB.Location = new System.Drawing.Point(12, 96);
			this.AvatarGB.Name = "AvatarGB";
			this.AvatarGB.Size = new System.Drawing.Size(460, 184);
			this.AvatarGB.TabIndex = 6;
			this.AvatarGB.TabStop = false;
			this.AvatarGB.Text = "Аватар";
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
			this.ChooseNewAvatar.Text = "Выбрать новый аватар";
			this.ChooseNewAvatar.UseVisualStyleBackColor = true;
			this.ChooseNewAvatar.Click += new System.EventHandler(this.ChooseNewAvatar_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(6, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(262, 30);
			this.label3.TabIndex = 9;
			this.label3.Text = "Время жизни сообщений:";
			// 
			// TimerGB
			// 
			this.TimerGB.Controls.Add(this.label4);
			this.TimerGB.Controls.Add(this.TimeToLiveNUD);
			this.TimerGB.Controls.Add(this.label3);
			this.TimerGB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TimerGB.Location = new System.Drawing.Point(13, 490);
			this.TimerGB.Name = "TimerGB";
			this.TimerGB.Size = new System.Drawing.Size(460, 69);
			this.TimerGB.TabIndex = 10;
			this.TimerGB.TabStop = false;
			this.TimerGB.Text = "Сообщения";
			// 
			// SaveChatButton
			// 
			this.SaveChatButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SaveChatButton.Enabled = false;
			this.SaveChatButton.FlatAppearance.BorderSize = 0;
			this.SaveChatButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.SaveChatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.SaveChatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveChatButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveChatButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.SaveChatButton.Location = new System.Drawing.Point(13, 565);
			this.SaveChatButton.Name = "SaveChatButton";
			this.SaveChatButton.Size = new System.Drawing.Size(460, 39);
			this.SaveChatButton.TabIndex = 11;
			this.SaveChatButton.Text = "Сохранить";
			this.SaveChatButton.UseVisualStyleBackColor = true;
			this.SaveChatButton.Click += new System.EventHandler(this.SaveChatButton_Click);
			// 
			// TimeToLiveNUD
			// 
			this.TimeToLiveNUD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeToLiveNUD.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TimeToLiveNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.TimeToLiveNUD.Location = new System.Drawing.Point(276, 25);
			this.TimeToLiveNUD.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
			this.TimeToLiveNUD.Name = "TimeToLiveNUD";
			this.TimeToLiveNUD.Size = new System.Drawing.Size(60, 31);
			this.TimeToLiveNUD.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(348, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 30);
			this.label4.TabIndex = 11;
			this.label4.Text = "сек.";
			// 
			// ChatnameTB
			// 
			this.ChatnameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChatnameTB.Font = new System.Drawing.Font("Segoe UI", 15.75F);
			this.ChatnameTB.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.ChatnameTB.Location = new System.Drawing.Point(7, 32);
			this.ChatnameTB.Name = "ChatnameTB";
			this.ChatnameTB.Size = new System.Drawing.Size(447, 33);
			this.ChatnameTB.TabIndex = 0;
			this.ChatnameTB.Text = "Введите название чата";
			this.ChatnameTB.TextChanged += new System.EventHandler(this.ChatnameTB_TextChanged);
			// 
			// ChatSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(484, 610);
			this.Controls.Add(this.SaveChatButton);
			this.Controls.Add(this.TimerGB);
			this.Controls.Add(this.UsersGB);
			this.Controls.Add(this.NameGB);
			this.Controls.Add(this.AvatarGB);
			this.Name = "ChatSettingsForm";
			this.Text = "ChatSettingsForm";
			this.UsersGB.ResumeLayout(false);
			this.NameGB.ResumeLayout(false);
			this.AvatarGB.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatarPB)).EndInit();
			this.TimerGB.ResumeLayout(false);
			this.TimerGB.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TimeToLiveNUD)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox UsersGB;
		private System.Windows.Forms.GroupBox NameGB;
		private CustomTextBox ChatnameTB;
		private System.Windows.Forms.GroupBox AvatarGB;
		private System.Windows.Forms.PictureBox ChatAvatarPB;
		private System.Windows.Forms.Button ChooseNewAvatar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox RemoveMemersCLB;
		private System.Windows.Forms.CheckedListBox AddMembersCLB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox TimerGB;
		private System.Windows.Forms.OpenFileDialog AvatarOFD;
		private System.Windows.Forms.Button SaveChatButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown TimeToLiveNUD;
	}
}