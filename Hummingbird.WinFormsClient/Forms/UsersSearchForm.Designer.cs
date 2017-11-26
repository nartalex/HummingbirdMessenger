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
			this.SearchButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.UsersTable = new System.Windows.Forms.TableLayoutPanel();
			this.SearchTB = new Hummingbird.WinFormsClient.CustomTextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SearchButton
			// 
			this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.SearchButton.FlatAppearance.BorderSize = 0;
			this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SearchButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchButton.ForeColor = global::Hummingbird.WinFormsClient.Properties.Settings.Default.PrimaryColor;
			this.SearchButton.Location = new System.Drawing.Point(324, 3);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(47, 32);
			this.SearchButton.TabIndex = 2;
			this.SearchButton.Text = "🔍";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.82888F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.17112F));
			this.tableLayoutPanel1.Controls.Add(this.SearchButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.SearchTB, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 38);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// UsersTable
			// 
			this.UsersTable.ColumnCount = 3;
			this.UsersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.UsersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.UsersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.UsersTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UsersTable.Location = new System.Drawing.Point(0, 38);
			this.UsersTable.Name = "UsersTable";
			this.UsersTable.RowCount = 1;
			this.UsersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.UsersTable.Size = new System.Drawing.Size(374, 423);
			this.UsersTable.TabIndex = 4;
			// 
			// SearchTB
			// 
			this.SearchTB.BackColor = System.Drawing.Color.White;
			this.SearchTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SearchTB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SearchTB.ForeColor = System.Drawing.Color.Gray;
			this.SearchTB.Location = new System.Drawing.Point(3, 3);
			this.SearchTB.Name = "SearchTB";
			this.SearchTB.Size = new System.Drawing.Size(315, 32);
			this.SearchTB.TabIndex = 3;
			this.SearchTB.Text = "Имя пользователя";
			this.SearchTB.Enter += new System.EventHandler(this.SearchTB_Enter);
			this.SearchTB.Leave += new System.EventHandler(this.SearchTB_Leave);
			// 
			// UsersSearchForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(374, 461);
			this.Controls.Add(this.UsersTable);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(390, 15000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(390, 500);
			this.Name = "UsersSearchForm";
			this.ShowIcon = false;
			this.Text = "Поиск";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private CustomTextBox SearchTB;
		private System.Windows.Forms.TableLayoutPanel UsersTable;
	}
}