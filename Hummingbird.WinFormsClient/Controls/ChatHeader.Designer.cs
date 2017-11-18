namespace Hummingbird.WinFormsClient.Controls
{
	partial class ChatHeader
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
			this.chatAvatar = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ChatMembersButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chatAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// chatAvatar
			// 
			this.chatAvatar.Location = new System.Drawing.Point(3, 3);
			this.chatAvatar.Name = "chatAvatar";
			this.chatAvatar.Size = new System.Drawing.Size(64, 64);
			this.chatAvatar.TabIndex = 0;
			this.chatAvatar.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(73, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// ChatMembersButton
			// 
			this.ChatMembersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ChatMembersButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.members_icon;
			this.ChatMembersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ChatMembersButton.FlatAppearance.BorderSize = 0;
			this.ChatMembersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChatMembersButton.Location = new System.Drawing.Point(373, 23);
			this.ChatMembersButton.Name = "ChatMembersButton";
			this.ChatMembersButton.Size = new System.Drawing.Size(32, 32);
			this.ChatMembersButton.TabIndex = 2;
			this.ChatMembersButton.UseVisualStyleBackColor = true;
			// 
			// ChatHeader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Controls.Add(this.ChatMembersButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chatAvatar);
			this.Name = "ChatHeader";
			this.Size = new System.Drawing.Size(408, 70);
			((System.ComponentModel.ISupportInitialize)(this.chatAvatar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox chatAvatar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ChatMembersButton;
	}
}
