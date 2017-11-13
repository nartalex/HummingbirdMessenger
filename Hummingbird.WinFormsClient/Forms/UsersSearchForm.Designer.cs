namespace Hummingbird.WinFormsClient.Forms
{
	partial class UsersSearchForm
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
			this.SearchTB = new System.Windows.Forms.TextBox();
			this.SearchButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SearchTB
			// 
			this.SearchTB.BackColor = System.Drawing.Color.White;
			this.SearchTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SearchTB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchTB.Location = new System.Drawing.Point(12, 10);
			this.SearchTB.Name = "SearchTB";
			this.SearchTB.Size = new System.Drawing.Size(313, 25);
			this.SearchTB.TabIndex = 1;
			// 
			// SearchButton
			// 
			this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SearchButton.FlatAppearance.BorderSize = 0;
			this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SearchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchButton.ForeColor = System.Drawing.Color.Black;
			this.SearchButton.Location = new System.Drawing.Point(337, 9);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(25, 25);
			this.SearchButton.TabIndex = 2;
			this.SearchButton.Text = "🔍";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// UsersSearchForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(374, 461);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.SearchTB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(390, 15000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(390, 500);
			this.Name = "UsersSearchForm";
			this.ShowIcon = false;
			this.Text = "Поиск";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox SearchTB;
		private System.Windows.Forms.Button SearchButton;
	}
}