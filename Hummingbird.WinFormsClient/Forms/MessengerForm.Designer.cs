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
			this.components = new System.ComponentModel.Container();
			this.SendMessageButton = new System.Windows.Forms.Button();
			this.MessagesPanel = new System.Windows.Forms.TableLayoutPanel();
			this.MessageUpdateBGW = new System.ComponentModel.BackgroundWorker();
			this.MessageTextBox = new Hummingbird.WinFormsClient.CustomTextBox();
			this.AttachButton = new System.Windows.Forms.Button();
			this.AttachContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RemoveAttachButton = new System.Windows.Forms.ToolStripMenuItem();
			this.AttachOFD = new System.Windows.Forms.OpenFileDialog();
			this.AttachContextMenu.SuspendLayout();
			this.SuspendLayout();
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
			this.SendMessageButton.Location = new System.Drawing.Point(491, 407);
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
			this.MessagesPanel.ColumnCount = 3;
			this.MessagesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.MessagesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.MessagesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.MessagesPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MessagesPanel.Location = new System.Drawing.Point(0, 0);
			this.MessagesPanel.Name = "MessagesPanel";
			this.MessagesPanel.RowCount = 1;
			this.MessagesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.MessagesPanel.Size = new System.Drawing.Size(531, 401);
			this.MessagesPanel.TabIndex = 3;
			this.MessagesPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MessagesPanel_ControlAdded);
			// 
			// MessageUpdateBGW
			// 
			this.MessageUpdateBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.MessageUpdateBGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// MessageTextBox
			// 
			this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MessageTextBox.Location = new System.Drawing.Point(12, 407);
			this.MessageTextBox.Name = "MessageTextBox";
			this.MessageTextBox.Size = new System.Drawing.Size(427, 32);
			this.MessageTextBox.TabIndex = 4;
			this.MessageTextBox.Text = " ";
			this.MessageTextBox.Enter += new System.EventHandler(this.MessageTextBox_Enter);
			this.MessageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageTextBox_KeyPress);
			this.MessageTextBox.Leave += new System.EventHandler(this.MessageTextBox_Leave);
			// 
			// AttachButton
			// 
			this.AttachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AttachButton.BackgroundImage = global::Hummingbird.WinFormsClient.Properties.Resources.attach;
			this.AttachButton.ContextMenuStrip = this.AttachContextMenu;
			this.AttachButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AttachButton.FlatAppearance.BorderSize = 0;
			this.AttachButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.AttachButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.AttachButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AttachButton.Location = new System.Drawing.Point(446, 407);
			this.AttachButton.Name = "AttachButton";
			this.AttachButton.Size = new System.Drawing.Size(32, 32);
			this.AttachButton.TabIndex = 5;
			this.AttachButton.UseVisualStyleBackColor = true;
			this.AttachButton.Click += new System.EventHandler(this.AttachButton_Click);
			// 
			// AttachContextMenu
			// 
			this.AttachContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveAttachButton});
			this.AttachContextMenu.Name = "AttachContextMenu";
			this.AttachContextMenu.Size = new System.Drawing.Size(177, 26);
			// 
			// RemoveAttachButton
			// 
			this.RemoveAttachButton.Name = "RemoveAttachButton";
			this.RemoveAttachButton.Size = new System.Drawing.Size(176, 22);
			this.RemoveAttachButton.Text = "Удалить вложение";
			this.RemoveAttachButton.Click += new System.EventHandler(this.RemoveAttachButton_Click);
			// 
			// AttachOFD
			// 
			this.AttachOFD.Filter = "Изображения|*.jpg;*.jpeg;*.gif;*.bmp;*.png|Все файлы|*.*";
			// 
			// MessengerForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(531, 444);
			this.Controls.Add(this.AttachButton);
			this.Controls.Add(this.MessageTextBox);
			this.Controls.Add(this.MessagesPanel);
			this.Controls.Add(this.SendMessageButton);
			this.Name = "MessengerForm";
			this.Text = "MessengerForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessengerForm_FormClosing);
			this.AttachContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button SendMessageButton;
		private System.Windows.Forms.TableLayoutPanel MessagesPanel;
		private System.ComponentModel.BackgroundWorker MessageUpdateBGW;
		private CustomTextBox MessageTextBox;
		private System.Windows.Forms.Button AttachButton;
		private System.Windows.Forms.OpenFileDialog AttachOFD;
		private System.Windows.Forms.ContextMenuStrip AttachContextMenu;
		private System.Windows.Forms.ToolStripMenuItem RemoveAttachButton;
	}
}