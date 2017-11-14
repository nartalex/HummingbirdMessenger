namespace Hummingbird.WinFormsClient.Forms
{
    partial class ChatsListForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.UsersSearchTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitTSM = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.White;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersSearchTSM,
            this.SettingsTSM,
            this.ExitTSM});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(334, 24);
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
			// ExitTSM
			// 
			this.ExitTSM.Name = "ExitTSM";
			this.ExitTSM.Size = new System.Drawing.Size(53, 20);
			this.ExitTSM.Text = "Выход";
			this.ExitTSM.Click += new System.EventHandler(this.ExitTSM_Click);
			// 
			// ChatsListForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(334, 401);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(350, 440);
			this.Name = "ChatsListForm";
			this.Text = "MessengerForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem UsersSearchTSM;
		private System.Windows.Forms.ToolStripMenuItem SettingsTSM;
		private System.Windows.Forms.ToolStripMenuItem ExitTSM;
	}
}