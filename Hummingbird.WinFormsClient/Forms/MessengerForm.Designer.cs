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
			this.MessageTextBox = new System.Windows.Forms.TextBox();
			this.SendMessageButton = new System.Windows.Forms.Button();
			this.MessagesPanel = new System.Windows.Forms.TableLayoutPanel();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// MessageTextBox
			// 
			this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MessageTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MessageTextBox.Location = new System.Drawing.Point(12, 323);
			this.MessageTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.MessageTextBox.Name = "MessageTextBox";
			this.MessageTextBox.Size = new System.Drawing.Size(372, 22);
			this.MessageTextBox.TabIndex = 1;
			this.MessageTextBox.Enter += new System.EventHandler(this.MessageTextBox_Enter);
			this.MessageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageTextBox_KeyPress);
			this.MessageTextBox.Leave += new System.EventHandler(this.MessageTextBox_Leave);
			// 
			// SendMessageButton
			// 
			this.SendMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SendMessageButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.send__1_;
			this.SendMessageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SendMessageButton.FlatAppearance.BorderSize = 0;
			this.SendMessageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.SendMessageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.SendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SendMessageButton.Location = new System.Drawing.Point(393, 323);
			this.SendMessageButton.Name = "SendMessageButton";
			this.SendMessageButton.Size = new System.Drawing.Size(32, 32);
			this.SendMessageButton.TabIndex = 2;
			this.SendMessageButton.UseVisualStyleBackColor = true;
			this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
			// 
			// MessagesPanel
			// 
			this.MessagesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessagesPanel.AutoScroll = true;
			this.MessagesPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.MessagesPanel.ColumnCount = 2;
			this.MessagesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.MessagesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.MessagesPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MessagesPanel.Location = new System.Drawing.Point(0, 0);
			this.MessagesPanel.Name = "MessagesPanel";
			this.MessagesPanel.RowCount = 1;
			this.MessagesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.MessagesPanel.Size = new System.Drawing.Size(433, 317);
			this.MessagesPanel.TabIndex = 3;
			this.MessagesPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MessagesPanel_ControlAdded);
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// MessengerForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(433, 360);
			this.Controls.Add(this.MessagesPanel);
			this.Controls.Add(this.SendMessageButton);
			this.Controls.Add(this.MessageTextBox);
			this.Name = "MessengerForm";
			this.Text = "MessengerForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox MessageTextBox;
		private System.Windows.Forms.Button SendMessageButton;
		private System.Windows.Forms.TableLayoutPanel MessagesPanel;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
	}
}