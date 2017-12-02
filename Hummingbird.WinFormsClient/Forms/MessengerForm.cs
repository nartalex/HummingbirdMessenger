using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Hummingbird.Model;

namespace Hummingbird.WinFormsClient.Forms
{
	public partial class MessengerForm : Form
	{
		private Chat _chat;
		private const int PictureSize = 32;
		private const int LabelSizeY = 32;
		private const int PictureMargin = 12;
		private const int LabelLocationX = 50;
		private const int GapBetwenMessages = 7;
		private const string MessageTextBoxPlaceholder = "Сообщение";
		private Guid LastMessageUserID = new Guid();

		public MessengerForm(Chat chat)
		{
			InitializeComponent();
			_chat = chat;

			// Устанавливаем имя чата
			Text = _chat.Private
				? chat.Name.Split('-').First(x => x != Properties.Settings.Default.CurrentUser.Nickname)
				: _chat.Name;

			// Обновляем сообщения
			_chat.Messages.Clear();
			var messages = ServiceClient.GetMessages(chat.ID, 0, 5).ToList();
			UpdateAllMessages(messages);
			_chat.Messages = messages;
			ScrollToBottom(MessagesPanel);

			// Ставим плейсхолдер в поле сообщения
			ActiveControl = MessagesPanel;
			MessageTextBox_Leave(new Object(), EventArgs.Empty);

			backgroundWorker.RunWorkerAsync();
		}

		#region Messages

		private void UpdateAllMessages(IEnumerable<Model.Message> messages)
		{
			foreach (var m in messages)
			{
				AddMessage(m);
			}
		}

		private void AddMessage(Model.Message message)
		{
			if (LastMessageUserID == new Guid() || LastMessageUserID != message.UserFromID)
			{
				LastMessageUserID = message.UserFromID;

				MessagesPanel.RowCount++;
				MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, LabelSizeY / 2));
				MessagesPanel.Controls.Add(
				                           new Label()
				                           {
					                           Anchor = AnchorStyles.Left | AnchorStyles.Right,
					                           //BorderStyle = BorderStyle.FixedSingle,
											   ForeColor = Properties.Settings.Default.PrimaryColor,
					                           Font = new Font("Segoe UI Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
					                           Name = message.UserFromID.ToString(),
					                           MinimumSize = new Size(0, LabelSizeY / 2),
											   Margin = new Padding(3,5,0,0),
					                           Text = message.User.Nickname,
					                           TextAlign = ContentAlignment.MiddleLeft,
				                           },
				                           1,
				                           MessagesPanel.RowCount - 1);
			}

			MessagesPanel.RowCount++;
			MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, LabelSizeY));
			MessagesPanel.Controls.Add(
			                           new Label()
			                           {
				                           Anchor = AnchorStyles.Left | AnchorStyles.Right,
				                           //BorderStyle = BorderStyle.FixedSingle,
				                           Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
				                           Name = message.ID.ToString(),
				                           MinimumSize = new Size(0, LabelSizeY),
				                           Text = message.Text,
				                           TextAlign = ContentAlignment.MiddleLeft,
			                           },
			                           1,
			                           MessagesPanel.RowCount - 1);

			//MessagesPanel.ScrollControlIntoView();

			//MessagesPanel.Controls.Add(
			//	new PictureBox()
			//	{
			//		BackgroundImage = avatar == null ? null : ServiceClient.FromBytesToImage(avatar),
			//		BackgroundImageLayout = ImageLayout.Zoom,
			//		Size = new Size(PictureSize, PictureSize),
			//	},
			//	0,
			//	MessagesPanel.RowCount - 1);

			MessagesPanel.RowCount++;
		}

		#endregion

		#region Controls

		private void MessageTextBox_Enter(object sender, EventArgs e)
		{
			MessageTextBox.RemoveText(MessageTextBoxPlaceholder);
			MessageTextBox.ForeColor = Color.Black;

			//if (MessageTextBox.Text != MessageTextBoxPlaceholder)
			//	return;

			//MessageTextBox.ForeColor = Color.Black;
			//MessageTextBox.Font = new Font("Segoe UI", 14f, FontStyle.Regular);

			//MessageTextBox.Text = "";
		}

		private void MessageTextBox_Leave(object sender, EventArgs e)
		{
			MessageTextBox.AddText(MessageTextBoxPlaceholder);

			//if (String.IsNullOrWhiteSpace(MessageTextBox.Text))
			//{
			//	MessageTextBox.ForeColor = Color.Gray;
			//	MessageTextBox.Font = new Font("Segoe UI Light", 14f, FontStyle.Regular);

			//	MessageTextBox.Text = MessageTextBoxPlaceholder;
			//}
		}

		private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 13)
				return;

			e.Handled = true;

			SendMessageButton.PerformClick();
		}

		private void SendMessageButton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(MessageTextBox.Text) || MessageTextBox.Text == MessageTextBoxPlaceholder)
				return;

			Model.Message returned = ServiceClient.SendMessage(_chat.ID, MessageTextBox.Text);

			AddMessage(returned);

			MessageTextBox.Text = "";
		}

		private void ScrollToBottom(Panel p)
		{
			using (Control c = new Control() { Parent = p, Dock = DockStyle.Top })
			{
				p.ScrollControlIntoView(c);
				c.Parent = null;
			}
		}

		#endregion

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(2000);

			var messages = ServiceClient.GetMessages(_chat.ID, 0, 5);
			var newIDs = messages
						.Where(x => x.UserFromID != Properties.Settings.Default.CurrentUserID)
						.Select(x => x.ID)
						.Except(_chat.Messages.Select(x => x.ID));
			var newMessages = newIDs
							 .Select(id => messages.First(x => x.ID == id))
							 .ToList();

			e.Result = newMessages;
		}

		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var messages = e.Result as List<Model.Message>;

			if (messages.Any())
			{
				foreach (var m in messages)
				{
					_chat.Messages.Add(m);
				}

				for (int i = 0; i < messages.Count; i++)
				{
					messages[i].Text += "fromBG";
				}


				UpdateAllMessages(messages);
			}

			//ScrollToBottom(MessagesPanel);

			backgroundWorker.RunWorkerAsync();
		}

		private void MessagesPanel_ControlAdded(object sender, ControlEventArgs e)
		{
			//MessagesPanel.ScrollControlIntoView(e.Control);
		}
	}
}
