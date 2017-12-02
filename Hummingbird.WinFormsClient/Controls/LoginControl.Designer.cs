namespace Hummingbird.WinFormsClient.Controls
{
    partial class LoginControl
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
			this.LoginButton = new System.Windows.Forms.Button();
			this.BackToStartButton = new System.Windows.Forms.Button();
			this.PasswordTextbox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.LoginTextbox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.WarningLabel = new System.Windows.Forms.Label();
			this.LoginBGW = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// LoginButton
			// 
			this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LoginButton.BackColor = System.Drawing.Color.Transparent;
			this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LoginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.LoginButton.FlatAppearance.BorderSize = 0;
			this.LoginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.LoginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoginButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.LoginButton.Location = new System.Drawing.Point(260, 240);
			this.LoginButton.Margin = new System.Windows.Forms.Padding(0);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(100, 40);
			this.LoginButton.TabIndex = 3;
			this.LoginButton.Text = "Войти";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// BackToStartButton
			// 
			this.BackToStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BackToStartButton.BackColor = System.Drawing.Color.Transparent;
			this.BackToStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
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
			this.BackToStartButton.TabIndex = 4;
			this.BackToStartButton.Text = "Назад";
			this.BackToStartButton.UseVisualStyleBackColor = false;
			this.BackToStartButton.Click += new System.EventHandler(this.BackToStartButton_Click);
			// 
			// PasswordTextbox
			// 
			this.PasswordTextbox.BackColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.BackgroundColor;
			this.PasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PasswordTextbox.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PasswordTextbox.ForeColor = System.Drawing.Color.Gray;
			this.PasswordTextbox.Location = new System.Drawing.Point(50, 110);
			this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(5);
			this.PasswordTextbox.Name = "PasswordTextbox";
			this.PasswordTextbox.Size = new System.Drawing.Size(250, 35);
			this.PasswordTextbox.TabIndex = 1;
			this.PasswordTextbox.Text = "Пароль";
	        this.LoginTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
			this.PasswordTextbox.Leave += new System.EventHandler(this.PasswordTextbox_Leave);
			// 
			// LoginTextbox
			// 
			this.LoginTextbox.BackColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.BackgroundColor;
			this.LoginTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LoginTextbox.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoginTextbox.ForeColor = System.Drawing.Color.Gray;
			this.LoginTextbox.Location = new System.Drawing.Point(50, 50);
			this.LoginTextbox.Margin = new System.Windows.Forms.Padding(15, 5, 5, 5);
			this.LoginTextbox.Name = "LoginTextbox";
			this.LoginTextbox.Size = new System.Drawing.Size(250, 35);
			this.LoginTextbox.TabIndex = 0;
			this.LoginTextbox.Text = "Логин";
			this.LoginTextbox.Enter += new System.EventHandler(this.LoginTextbox_Enter);
			this.LoginTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			this.LoginTextbox.Leave += new System.EventHandler(this.LoginTextbox_Leave);
			// 
			// WarningLabel
			// 
			this.WarningLabel.AutoSize = true;
			this.WarningLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.WarningLabel.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.WarnColor;
			this.WarningLabel.Location = new System.Drawing.Point(45, 200);
			this.WarningLabel.Name = "WarningLabel";
			this.WarningLabel.Size = new System.Drawing.Size(0, 25);
			this.WarningLabel.TabIndex = 5;
			// 
			// LoginBGW
			// 
			this.LoginBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoginBGW_DoWork);
			this.LoginBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginBGW_RunWorkerCompleted);
			// 
			// LoginControl
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.WarningLabel);
			this.Controls.Add(this.BackToStartButton);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.PasswordTextbox);
			this.Controls.Add(this.LoginTextbox);
			this.Name = "LoginControl";
			this.Size = new System.Drawing.Size(360, 300);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CustomTextBox LoginTextbox;
        private CustomTextBox PasswordTextbox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button BackToStartButton;
        private System.Windows.Forms.Label WarningLabel;
		private System.ComponentModel.BackgroundWorker LoginBGW;
	}
}
