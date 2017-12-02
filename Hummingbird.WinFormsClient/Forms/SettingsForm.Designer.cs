using System.Drawing;

namespace Hummingbird.WinFormsClient.Forms
{
	partial class SettingsForm
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
			this.AvatarPB = new System.Windows.Forms.PictureBox();
			this.openAvatarDialog = new System.Windows.Forms.OpenFileDialog();
			this.ChooseNewAvatar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SaveNewAvatar = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SaveNewUsername = new System.Windows.Forms.Button();
			this.UsernameTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.SaveNewPassword = new System.Windows.Forms.Button();
			this.NewPasswordAgainTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.NewPasswordTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.CurrentPasswordTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.AvatarBGW = new System.ComponentModel.BackgroundWorker();
			this.UsernameBGW = new System.ComponentModel.BackgroundWorker();
			this.PasswordBGW = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.AvatarPB)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// AvatarPB
			// 
			this.AvatarPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.AvatarPB.Location = new System.Drawing.Point(22, 30);
			this.AvatarPB.Name = "AvatarPB";
			this.AvatarPB.Size = new System.Drawing.Size(128, 128);
			this.AvatarPB.TabIndex = 0;
			this.AvatarPB.TabStop = false;
			// 
			// openAvatarDialog
			// 
			this.openAvatarDialog.FileName = "openFileDialog1";
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
			this.ChooseNewAvatar.Size = new System.Drawing.Size(288, 40);
			this.ChooseNewAvatar.TabIndex = 1;
			this.ChooseNewAvatar.Text = "Выбрать аватар";
			this.ChooseNewAvatar.UseVisualStyleBackColor = true;
			this.ChooseNewAvatar.Click += new System.EventHandler(this.ChooseNewAvatar_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.SaveNewAvatar);
			this.groupBox1.Controls.Add(this.AvatarPB);
			this.groupBox1.Controls.Add(this.ChooseNewAvatar);
			this.groupBox1.ForeColor = System.Drawing.Color.Black;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(461, 184);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Аватар";
			// 
			// SaveNewAvatar
			// 
			this.SaveNewAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SaveNewAvatar.Enabled = false;
			this.SaveNewAvatar.FlatAppearance.BorderSize = 0;
			this.SaveNewAvatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.SaveNewAvatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.SaveNewAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveNewAvatar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveNewAvatar.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.SaveNewAvatar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.SaveNewAvatar.Location = new System.Drawing.Point(167, 118);
			this.SaveNewAvatar.Name = "SaveNewAvatar";
			this.SaveNewAvatar.Size = new System.Drawing.Size(288, 40);
			this.SaveNewAvatar.TabIndex = 2;
			this.SaveNewAvatar.Text = "Сохранить";
			this.SaveNewAvatar.UseVisualStyleBackColor = true;
			this.SaveNewAvatar.Click += new System.EventHandler(this.SaveNewAvatar_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SaveNewUsername);
			this.groupBox2.Controls.Add(this.UsernameTB);
			this.groupBox2.ForeColor = System.Drawing.Color.Black;
			this.groupBox2.Location = new System.Drawing.Point(12, 202);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(461, 78);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Имя пользователя";
			// 
			// SaveNewUsername
			// 
			this.SaveNewUsername.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SaveNewUsername.Enabled = false;
			this.SaveNewUsername.FlatAppearance.BorderSize = 0;
			this.SaveNewUsername.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.SaveNewUsername.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.SaveNewUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveNewUsername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveNewUsername.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.SaveNewUsername.Location = new System.Drawing.Point(323, 32);
			this.SaveNewUsername.Name = "SaveNewUsername";
			this.SaveNewUsername.Size = new System.Drawing.Size(132, 40);
			this.SaveNewUsername.TabIndex = 3;
			this.SaveNewUsername.Text = "Сохранить";
			this.SaveNewUsername.UseVisualStyleBackColor = true;
			this.SaveNewUsername.Click += new System.EventHandler(this.SaveNewUsername_Click);
			// 
			// UsernameTB
			// 
			this.UsernameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UsernameTB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UsernameTB.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.UsernameTB.Location = new System.Drawing.Point(22, 32);
			this.UsernameTB.Name = "UsernameTB";
			this.UsernameTB.Size = new System.Drawing.Size(295, 33);
			this.UsernameTB.TabIndex = 0;
			this.UsernameTB.TextChanged += new System.EventHandler(this.UsernameTB_TextChanged);
			this.UsernameTB.Enter += new System.EventHandler(this.UsernameTB_Enter);
			this.UsernameTB.Leave += new System.EventHandler(this.UsernameTB_Leave);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.SaveNewPassword);
			this.groupBox3.Controls.Add(this.NewPasswordAgainTB);
			this.groupBox3.Controls.Add(this.NewPasswordTB);
			this.groupBox3.Controls.Add(this.CurrentPasswordTB);
			this.groupBox3.Location = new System.Drawing.Point(12, 286);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(461, 141);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Пароль";
			// 
			// SaveNewPassword
			// 
			this.SaveNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SaveNewPassword.Enabled = false;
			this.SaveNewPassword.FlatAppearance.BorderSize = 0;
			this.SaveNewPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.SaveNewPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.SaveNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveNewPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveNewPassword.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.SaveNewPassword.Location = new System.Drawing.Point(323, 97);
			this.SaveNewPassword.Name = "SaveNewPassword";
			this.SaveNewPassword.Size = new System.Drawing.Size(132, 40);
			this.SaveNewPassword.TabIndex = 4;
			this.SaveNewPassword.Text = "Сохранить";
			this.SaveNewPassword.UseVisualStyleBackColor = true;
			this.SaveNewPassword.Click += new System.EventHandler(this.SaveNewPassword_Click);
			// 
			// NewPasswordAgainTB
			// 
			this.NewPasswordAgainTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NewPasswordAgainTB.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NewPasswordAgainTB.ForeColor = System.Drawing.Color.Gray;
			this.NewPasswordAgainTB.Location = new System.Drawing.Point(22, 97);
			this.NewPasswordAgainTB.Name = "NewPasswordAgainTB";
			this.NewPasswordAgainTB.Size = new System.Drawing.Size(295, 33);
			this.NewPasswordAgainTB.TabIndex = 2;
			this.NewPasswordAgainTB.Text = "Введите новый пароль ещё раз";
			this.NewPasswordAgainTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
			this.NewPasswordAgainTB.Enter += new System.EventHandler(this.NewPasswordAgainTB_Enter);
			this.NewPasswordAgainTB.Leave += new System.EventHandler(this.NewPasswordAgainTB_Leave);
			// 
			// NewPasswordTB
			// 
			this.NewPasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NewPasswordTB.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NewPasswordTB.ForeColor = System.Drawing.Color.Gray;
			this.NewPasswordTB.Location = new System.Drawing.Point(22, 58);
			this.NewPasswordTB.Name = "NewPasswordTB";
			this.NewPasswordTB.Size = new System.Drawing.Size(295, 33);
			this.NewPasswordTB.TabIndex = 1;
			this.NewPasswordTB.Text = "Введите новый пароль";
			this.NewPasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
			this.NewPasswordTB.Enter += new System.EventHandler(this.NewPasswordTB_Enter);
			this.NewPasswordTB.Leave += new System.EventHandler(this.NewPasswordTB_Leave);
			// 
			// CurrentPasswordTB
			// 
			this.CurrentPasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CurrentPasswordTB.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CurrentPasswordTB.ForeColor = System.Drawing.Color.Gray;
			this.CurrentPasswordTB.Location = new System.Drawing.Point(22, 19);
			this.CurrentPasswordTB.Name = "CurrentPasswordTB";
			this.CurrentPasswordTB.Size = new System.Drawing.Size(295, 33);
			this.CurrentPasswordTB.TabIndex = 0;
			this.CurrentPasswordTB.Text = "Введите старый пароль";
			this.CurrentPasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
			this.CurrentPasswordTB.Enter += new System.EventHandler(this.CurrentPasswordTB_Enter);
			this.CurrentPasswordTB.Leave += new System.EventHandler(this.CurrentPasswordTB_Leave);
			// 
			// AvatarBGW
			// 
			this.AvatarBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AvatarBGW_DoWork);
			this.AvatarBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AvatarBGW_RunWorkerCompleted);
			// 
			// UsernameBGW
			// 
			this.UsernameBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UsernameBGW_DoWork);
			this.UsernameBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UsernameBGW_RunWorkerCompleted);
			// 
			// PasswordBGW
			// 
			this.PasswordBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PasswordBGW_DoWork);
			this.PasswordBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PasswordBGW_RunWorkerCompleted);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(485, 443);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SettingsForm";
			this.Text = "Настройки профиля";
			((System.ComponentModel.ISupportInitialize)(this.AvatarPB)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox AvatarPB;
		private System.Windows.Forms.OpenFileDialog openAvatarDialog;
		private System.Windows.Forms.Button ChooseNewAvatar;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button SaveNewAvatar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button SaveNewUsername;
		private CustomTextBox UsernameTB;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button SaveNewPassword;
		private CustomTextBox NewPasswordAgainTB;
		private CustomTextBox NewPasswordTB;
		private CustomTextBox CurrentPasswordTB;
		private System.ComponentModel.BackgroundWorker AvatarBGW;
		private System.ComponentModel.BackgroundWorker UsernameBGW;
		private System.ComponentModel.BackgroundWorker PasswordBGW;
	}
}