namespace Hummingbird.WinFormsClient.Controls
{
    partial class RegisterControl
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
			this.BackToStartButton = new System.Windows.Forms.Button();
			this.RegisterButton = new System.Windows.Forms.Button();
			this.NicknameTextbox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.PasswordTextbox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.LoginTextbox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.WarningLabel = new System.Windows.Forms.Label();
			this.RegisterBGW = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// BackToStartButton
			// 
			this.BackToStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BackToStartButton.BackColor = System.Drawing.Color.Transparent;
			this.BackToStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BackToStartButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BackToStartButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.BackToStartButton.FlatAppearance.BorderSize = 0;
			this.BackToStartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.BackToStartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.BackToStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BackToStartButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BackToStartButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.BackToStartButton.Location = new System.Drawing.Point(0, 240);
			this.BackToStartButton.Margin = new System.Windows.Forms.Padding(0);
			this.BackToStartButton.Name = "BackToStartButton";
			this.BackToStartButton.Size = new System.Drawing.Size(100, 40);
			this.BackToStartButton.TabIndex = 3;
			this.BackToStartButton.Text = "Назад";
			this.BackToStartButton.UseVisualStyleBackColor = false;
			this.BackToStartButton.Click += new System.EventHandler(this.BackToStartButton_Click);
			// 
			// RegisterButton
			// 
			this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RegisterButton.BackColor = System.Drawing.Color.Transparent;
			this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RegisterButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.RegisterButton.FlatAppearance.BorderSize = 0;
			this.RegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.RegisterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RegisterButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RegisterButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.RegisterButton.Location = new System.Drawing.Point(215, 240);
			this.RegisterButton.Margin = new System.Windows.Forms.Padding(0);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(145, 40);
			this.RegisterButton.TabIndex = 4;
			this.RegisterButton.Text = "Регистрация";
			this.RegisterButton.UseVisualStyleBackColor = false;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// NicknameTextbox
			// 
			this.NicknameTextbox.BackColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.BackgroundColor;
			this.NicknameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NicknameTextbox.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.NicknameTextbox.ForeColor = System.Drawing.Color.Gray;
			this.NicknameTextbox.Location = new System.Drawing.Point(50, 30);
			this.NicknameTextbox.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
			this.NicknameTextbox.Name = "NicknameTextbox";
			this.NicknameTextbox.Size = new System.Drawing.Size(250, 35);
			this.NicknameTextbox.TabIndex = 0;
			this.NicknameTextbox.Text = "Имя пользователя";
			this.NicknameTextbox.Enter += new System.EventHandler(this.NicknameTextbox_Enter);
			this.NicknameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			this.NicknameTextbox.Leave += new System.EventHandler(this.NicknameTextbox_Leave);
			// 
			// PasswordTextbox
			// 
			this.PasswordTextbox.BackColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.BackgroundColor;
			this.PasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PasswordTextbox.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.PasswordTextbox.ForeColor = System.Drawing.Color.Gray;
			this.PasswordTextbox.Location = new System.Drawing.Point(50, 150);
			this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(5);
			this.PasswordTextbox.Name = "PasswordTextbox";
			this.PasswordTextbox.Size = new System.Drawing.Size(250, 35);
			this.PasswordTextbox.TabIndex = 2;
			this.PasswordTextbox.Text = "Пароль";
			this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
			this.PasswordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			this.PasswordTextbox.Leave += new System.EventHandler(this.PasswordTextbox_Leave);
			// 
			// LoginTextbox
			// 
			this.LoginTextbox.BackColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.BackgroundColor;
			this.LoginTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LoginTextbox.Font = new System.Drawing.Font("Segoe UI", 14F);
			this.LoginTextbox.ForeColor = System.Drawing.Color.Gray;
			this.LoginTextbox.Location = new System.Drawing.Point(50, 90);
			this.LoginTextbox.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
			this.LoginTextbox.Name = "LoginTextbox";
			this.LoginTextbox.Size = new System.Drawing.Size(250, 35);
			this.LoginTextbox.TabIndex = 1;
			this.LoginTextbox.Text = "Логин";
			this.LoginTextbox.Enter += new System.EventHandler(this.LoginTextbox_Enter);
			this.LoginTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			this.LoginTextbox.Leave += new System.EventHandler(this.LoginTextbox_Leave);
			// 
			// WarningLabel
			// 
			this.WarningLabel.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Bold);
			this.WarningLabel.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.WarnColor;
			this.WarningLabel.Location = new System.Drawing.Point(45, 200);
			this.WarningLabel.Name = "WarningLabel";
			this.WarningLabel.Size = new System.Drawing.Size(0, 25);
			this.WarningLabel.TabIndex = 5;
			// 
			// RegisterBGW
			// 
			this.RegisterBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RegisterBGW_DoWork);
			this.RegisterBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RegisterBGW_RunWorkerCompleted);
			// 
			// RegisterControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.WarningLabel);
			this.Controls.Add(this.NicknameTextbox);
			this.Controls.Add(this.BackToStartButton);
			this.Controls.Add(this.RegisterButton);
			this.Controls.Add(this.PasswordTextbox);
			this.Controls.Add(this.LoginTextbox);
			this.Name = "RegisterControl";
			this.Size = new System.Drawing.Size(360, 300);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToStartButton;
        private System.Windows.Forms.Button RegisterButton;
        private CustomTextBox PasswordTextbox;
        private CustomTextBox LoginTextbox;
        private CustomTextBox NicknameTextbox;
        private System.Windows.Forms.Label WarningLabel;
		private System.ComponentModel.BackgroundWorker RegisterBGW;
	}
}
