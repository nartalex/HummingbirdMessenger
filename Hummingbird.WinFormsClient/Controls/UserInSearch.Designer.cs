namespace Hummingbird.WinFormsClient.Controls
{
	partial class UserInSearch
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.UserAvatar = new System.Windows.Forms.PictureBox();
			this.UserName = new System.Windows.Forms.Label();
			this.AddUserButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// UserAvatar
			// 
			this.UserAvatar.Location = new System.Drawing.Point(3, 3);
			this.UserAvatar.Name = "UserAvatar";
			this.UserAvatar.Size = new System.Drawing.Size(64, 64);
			this.UserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.UserAvatar.TabIndex = 0;
			this.UserAvatar.TabStop = false;
			// 
			// UserName
			// 
			this.UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.UserName.AutoSize = true;
			this.UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UserName.Location = new System.Drawing.Point(73, 23);
			this.UserName.Name = "UserName";
			this.UserName.Size = new System.Drawing.Size(116, 21);
			this.UserName.TabIndex = 1;
			this.UserName.Text = "Naaaaameeeee";
			// 
			// AddUserButton
			// 
			this.AddUserButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.add_friend;
			this.AddUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.AddUserButton.FlatAppearance.BorderSize = 0;
			this.AddUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddUserButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AddUserButton.Location = new System.Drawing.Point(310, 19);
			this.AddUserButton.Name = "AddUserButton";
			this.AddUserButton.Size = new System.Drawing.Size(32, 32);
			this.AddUserButton.TabIndex = 2;
			this.AddUserButton.UseVisualStyleBackColor = true;
			this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
			// 
			// UserInSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.AddUserButton);
			this.Controls.Add(this.UserName);
			this.Controls.Add(this.UserAvatar);
			this.Name = "UserInSearch";
			this.Size = new System.Drawing.Size(350, 70);
			((System.ComponentModel.ISupportInitialize)(this.UserAvatar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox UserAvatar;
		private System.Windows.Forms.Label UserName;
		private System.Windows.Forms.Button AddUserButton;
	}
}
