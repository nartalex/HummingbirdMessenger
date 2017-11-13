namespace Hummingbird.WinFormsClient.Forms
{
    partial class MessengerForm
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
			this.chatsList1 = new Hummingbird.WinFormsClient.Controls.ChatsList();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.UsersSearchTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chatsList1
			// 
			this.chatsList1.Location = new System.Drawing.Point(0, 27);
			this.chatsList1.Name = "chatsList1";
			this.chatsList1.Size = new System.Drawing.Size(325, 373);
			this.chatsList1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersSearchTSM,
            this.SettingsTSM});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(717, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// UsersSearchTSM
			// 
			this.UsersSearchTSM.Name = "UsersSearchTSM";
			this.UsersSearchTSM.Size = new System.Drawing.Size(139, 20);
			this.UsersSearchTSM.Text = "Поиск пользователей";
			this.UsersSearchTSM.Click += new System.EventHandler(this.UsersSearchTSM_Click);
			// 
			// SettingsTSM
			// 
			this.SettingsTSM.Name = "SettingsTSM";
			this.SettingsTSM.Size = new System.Drawing.Size(79, 20);
			this.SettingsTSM.Text = "Настройки";
			// 
			// MessengerForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(717, 400);
			this.Controls.Add(this.chatsList1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(0, 439);
			this.Name = "MessengerForm";
			this.Text = "MessengerForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private Controls.ChatsList chatsList1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem UsersSearchTSM;
		private System.Windows.Forms.ToolStripMenuItem SettingsTSM;
	}
}