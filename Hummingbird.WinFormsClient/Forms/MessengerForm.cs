using System;
using System.Collections.Generic;
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

		private delegate void UpdateMessages(IEnumerable<Model.Message> messages);

		public MessengerForm(Chat chat)
		{
			InitializeComponent();
			_chat = chat;

			// Устанавливаем имя чата
			Text = _chat.Private
				? chat.Name.Split('-').First(x => x != Properties.Settings.Default.CurrentUser.Nickname)
				: _chat.Name;

			// Обновляем сообщения
			_chat.Messages = ServiceClient.GetMessages(chat.ID, 0, 20).ToList();
			UpdateAllMessages(_chat.Messages.ToArray());
			ScrollToBottom(MessagesPanel);

			// Ставим плейсхолдер в поле сообщения
			ActiveControl = MessagesPanel;
			MessageTextBox_Leave(new Object(), EventArgs.Empty);

			var ts = new ThreadStart(BackgroundUpdate);
			var backgroundThread = new Thread(ts);
			//backgroundThread.Start();		
		}

		#region Messages

		private void UpdateAllMessages(IEnumerable<Model.Message> messages)
		{
			Guid lastMessageUserID = new Guid();

			foreach (var m in messages)
			{
				if (lastMessageUserID == m.UserFromID)
				{
					AddMessage("", m.Text);
				}
				else
				{
					lastMessageUserID = m.UserFromID;
					AddMessage("", m.Text, avatar: _chat.Members.First(x => x.UserID == m.UserFromID).User.Avatar);
				}
			}
		}

		private void BackgroundUpdate()
		{

			while (true)
			{
				Thread.Sleep(2000);

				var messages = ServiceClient.GetMessages(_chat.ID, 0, 10);

				var newIDs = messages.Select(x => x.ID).Except(_chat.Messages.Select(x => x.ID));

				var newMessages = newIDs.Select(id => messages.First(x => x.ID == id)).ToList();

				UpdateAllMessages(newMessages);
			}
		}

		#endregion

		#region Getters

		private void AddMessage(string name, string text, int sizeY = LabelSizeY, byte[] avatar = null)
		{
			MessagesPanel.RowCount++;
			MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, LabelSizeY));
			MessagesPanel.Controls.Add(
				new Label()
				{
					Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
					Name = name,
					MinimumSize = new Size(0, LabelSizeY),
					//Height = sizeY,
					Text = text,
					TextAlign = ContentAlignment.MiddleLeft,
				},
				1,
				MessagesPanel.RowCount - 1);

			MessagesPanel.Controls.Add(
				new PictureBox()
				{
					BackgroundImage = avatar == null ? null : (Bitmap)new ImageConverter().ConvertFrom(avatar),
					BackgroundImageLayout = ImageLayout.Zoom,
					Size = new Size(PictureSize, PictureSize),
				},
				0,
				MessagesPanel.RowCount - 1);
		}

		#endregion

		#region Controls

		private void MessageTextBox_Enter(object sender, EventArgs e)
		{
			if (MessageTextBox.Text != MessageTextBoxPlaceholder)
				return;

			MessageTextBox.ForeColor = Color.Black;
			MessageTextBox.Font = new Font("Segoe UI", 14f, FontStyle.Regular);

			MessageTextBox.Text = "";
		}

		private void MessageTextBox_Leave(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(MessageTextBox.Text))
			{
				MessageTextBox.ForeColor = Color.Gray;
				MessageTextBox.Font = new Font("Segoe UI Light", 14f, FontStyle.Regular);

				MessageTextBox.Text = MessageTextBoxPlaceholder;
			}
		}

		private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != 13)
				return;

			SendMessageButton.PerformClick();
		}

		private void SendMessageButton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(MessageTextBox.Text) || MessageTextBox.Text == MessageTextBoxPlaceholder)
				return;

			Model.Message returned = ServiceClient.SendMessage(_chat.ID, MessageTextBox.Text);

			if (!_chat.Messages.Any())
			{
				AddMessage(returned.ID.ToString(), returned.Text, avatar: Properties.Settings.Default.CurrentUser.Avatar);
				return;
			}

			if (_chat.Messages.Last().UserFromID == Properties.Settings.Default.CurrentUser.ID)
				AddMessage(returned.ID.ToString(), returned.Text);

			else
				AddMessage(returned.ID.ToString(), returned.Text, avatar: Properties.Settings.Default.CurrentUser.Avatar);

			MessageTextBox.Text = "";
		}

		private void ScrollToBottom(Panel p)
		{
			using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
			{
				p.ScrollControlIntoView(c);
				c.Parent = null;
			}
		}

		#endregion
	}
}
