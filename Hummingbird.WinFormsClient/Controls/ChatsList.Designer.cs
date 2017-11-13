namespace Hummingbird.WinFormsClient.Controls
{
	partial class ChatsList
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
			this.ChatListView = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// ChatListView
			// 
			this.ChatListView.Location = new System.Drawing.Point(0, 0);
			this.ChatListView.Margin = new System.Windows.Forms.Padding(0);
			this.ChatListView.Name = "ChatListView";
			this.ChatListView.Size = new System.Drawing.Size(325, 400);
			this.ChatListView.TabIndex = 0;
			this.ChatListView.UseCompatibleStateImageBehavior = false;
			// 
			// ChatsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ChatListView);
			this.Name = "ChatsList";
			this.Size = new System.Drawing.Size(325, 400);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView ChatListView;
	}
}
