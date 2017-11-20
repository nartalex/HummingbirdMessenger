namespace Hummingbird.WinFormsClient.Controls
{
	partial class ChatButton
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
			this.ChatAvatar = new System.Windows.Forms.PictureBox();
			this.ChatNameLabel = new System.Windows.Forms.Label();
			this.LastMessageLabel = new System.Windows.Forms.Label();
			this.LastMessageTime = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// ChatAvatar
			// 
			this.ChatAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ChatAvatar.Location = new System.Drawing.Point(3, 3);
			this.ChatAvatar.Name = "ChatAvatar";
			this.ChatAvatar.Size = new System.Drawing.Size(64, 64);
			this.ChatAvatar.TabIndex = 0;
			this.ChatAvatar.TabStop = false;
			// 
			// ChatNameLabel
			// 
			this.ChatNameLabel.AutoSize = true;
			this.ChatNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ChatNameLabel.Location = new System.Drawing.Point(74, 4);
			this.ChatNameLabel.Name = "ChatNameLabel";
			this.ChatNameLabel.Size = new System.Drawing.Size(96, 25);
			this.ChatNameLabel.TabIndex = 1;
			this.ChatNameLabel.Text = "ChatLabel";
			// 
			// LastMessageLabel
			// 
			this.LastMessageLabel.AutoSize = true;
			this.LastMessageLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LastMessageLabel.Location = new System.Drawing.Point(74, 42);
			this.LastMessageLabel.Name = "LastMessageLabel";
			this.LastMessageLabel.Size = new System.Drawing.Size(98, 21);
			this.LastMessageLabel.TabIndex = 2;
			this.LastMessageLabel.Text = "LastMessage";
			// 
			// LastMessageTime
			// 
			this.LastMessageTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LastMessageTime.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LastMessageTime.Location = new System.Drawing.Point(234, 6);
			this.LastMessageTime.Name = "LastMessageTime";
			this.LastMessageTime.Size = new System.Drawing.Size(113, 23);
			this.LastMessageTime.TabIndex = 3;
			this.LastMessageTime.Text = "LastMessageTime";
			this.LastMessageTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ChatButton
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.LastMessageTime);
			this.Controls.Add(this.LastMessageLabel);
			this.Controls.Add(this.ChatNameLabel);
			this.Controls.Add(this.ChatAvatar);
			this.Name = "ChatButton";
			this.Size = new System.Drawing.Size(350, 70);
			this.Click += new System.EventHandler(this.ChatButton_Click);
			this.DoubleClick += new System.EventHandler(this.ChatButton_DoubleClick);
			((System.ComponentModel.ISupportInitialize)(this.ChatAvatar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox ChatAvatar;
		private System.Windows.Forms.Label ChatNameLabel;
		private System.Windows.Forms.Label LastMessageLabel;
		private System.Windows.Forms.Label LastMessageTime;
	}
}
