using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Hummingbird.Model;
using Hummingbird.WinFormsClient.Controls;
using Message = Hummingbird.Model.Message;

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
		private Guid _lastMessageUserID = new Guid();
		private Attach _attachedFile = null;
		private bool KeepUpdating = true;

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
			//ScrollToBottom(MessagesPanel);

			// Ставим плейсхолдер в поле сообщения
			ActiveControl = MessagesPanel;
			MessageTextBox_Leave(new Object(), EventArgs.Empty);

			MessageUpdateBGW.RunWorkerAsync();
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
			if (_lastMessageUserID == new Guid() || _lastMessageUserID != message.UserFromID)
			{
				_lastMessageUserID = message.UserFromID;

				MessagesPanel.RowCount++;
				MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				MessagesPanel.Controls.Add(GetUsername(message), 1, MessagesPanel.RowCount - 1);
			}

			MessagesPanel.RowCount++;
			MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			MessagesPanel.Controls.Add(GetLabel(message), 1, MessagesPanel.RowCount - 1);

			//if (_chat.TimeToLive > 0)
			//{
			//	MessagesPanel.Controls.Add(new PictureBox
			//	{
			//		BackgroundImage = Properties.Resources.timer,
			//		BackgroundImageLayout = ImageLayout.Zoom,
			//		Width = Height = 16,
			//		//Anchor = AnchorStyles.Left | AnchorStyles.Right
			//	},
			//	0, MessagesPanel.RowCount - 1);
			//}

			if (message.AttachType == Message.AttachTypes.File)
			{
				MessagesPanel.RowCount++;
				MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				MessagesPanel.Controls.Add(new AttachedFileControl(message.AttachName, message.Attach), 1, MessagesPanel.RowCount - 1);
			}
			else if (message.AttachType == Message.AttachTypes.Image)
			{
				MessagesPanel.RowCount++;
				MessagesPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				MessagesPanel.Controls.Add(GetPictureBox(message), 1, MessagesPanel.RowCount - 1);
			}

			MessagesPanel.RowCount++;

		}

		private void SendMessage()
		{
			if ((String.IsNullOrWhiteSpace(MessageTextBox.Text)
				|| MessageTextBox.Text == MessageTextBoxPlaceholder)
				&& _attachedFile == null)
				return;

			Message m = new Message
			{
				Text = MessageTextBox.Text,
				ChatToID = _chat.ID,
				UserFromID = Properties.Settings.Default.CurrentUser.ID
			};

			if (_attachedFile != null)
			{
				m.AttachType = _attachedFile.Type;
				m.Attach = _attachedFile.File;
				m.AttachName = _attachedFile.Path.Split('\\').Last();
				AttachButton.BackgroundImage = Properties.Resources.attach;
				_attachedFile = null;
			}

			Message returned = ServiceClient.SendMessage(m);

			AddMessage(returned);

			if (_chat.TimeToLive > 0)
			{
				Dictionary<Guid, int> arg = new Dictionary<Guid, int>()
				{
					{
						returned.ID,
						MessagesPanel.GetRow(MessagesPanel.Controls.Find(returned.ID.ToString(), true).First())
					}
				};

				BackgroundWorker bgw = new BackgroundWorker();
				bgw.DoWork += SelfDestroyMessage_DoWork;
				bgw.RunWorkerCompleted += SelfDestroyMessage_RunWorkerCompleted;
				bgw.RunWorkerAsync(arg);
			}

			MessageTextBox.Text = "";
		}

		#endregion

		#region Getters

		private Label GetLabel(Model.Message message)
		{
			return new Label()
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				//BorderStyle = BorderStyle.FixedSingle,
				Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
				Name = message.ID.ToString(),
				MinimumSize = new Size(0, LabelSizeY),
				Text = message.Text,
				TextAlign = ContentAlignment.MiddleLeft,
				Width = MessagesPanel.GetColumnWidths()[0] - 20
		};
		}

		private Label GetUsername(Model.Message message)
		{
			return new Label()
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Right,
				ForeColor = Properties.Settings.Default.PrimaryColor,
				Font = new Font("Segoe UI Light", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
				Name = message.UserFromID.ToString(),
				MinimumSize = new Size(0, LabelSizeY / 2),
				Margin = new Padding(3, 5, 0, 0),
				Text = message.User.Nickname,
				TextAlign = ContentAlignment.MiddleLeft,
			};
		}

		private PictureBox GetPictureBox(Model.Message message)
		{
			PictureBox pb = new PictureBox()
			{
				BackgroundImageLayout = ImageLayout.Zoom,
				BackgroundImage = ServiceClient.FromBytesToImage(message.Attach),
				Size = ServiceClient.FromBytesToImage(message.Attach).Size,
				MaximumSize = new Size(200, 200),
				Cursor = Cursors.Hand
			};
			pb.Click += (sender, args) =>
						{
							string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
													   "Hummingbird Pictures");

							if (!Directory.Exists(path))
								Directory.CreateDirectory(path);

							path = Path.Combine(path, message.ID + "." + message.AttachName.Split('.').Last());
							if (!File.Exists(path))
								File.WriteAllBytes(path, message.Attach);

							Process.Start(path);
						};

			return pb;
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

			SendMessage();
		}

		private void SendMessageButton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(MessageTextBox.Text) || MessageTextBox.Text == MessageTextBoxPlaceholder)
				return;

			SendMessage();
		}

		private void MessagesPanel_ControlAdded(object sender, ControlEventArgs e)
		{
			//MessagesPanel.ScrollControlIntoView(e.Control);
			MessagesPanel.VerticalScroll.Value = MessagesPanel.VerticalScroll.Maximum;
			MessagesPanel.PerformLayout();

		}

		private void AttachButton_Click(object sender, EventArgs e)
		{
			if (AttachOFD.ShowDialog() == DialogResult.OK)
			{
				// Максимальный размер - 10 мб
				if (new FileInfo(AttachOFD.FileName).Length > 10000000)
				{
					MessageBox.Show("Размер файла не должен превышать 10 МБ");
					return;
				}

				_attachedFile = new Attach()
				{
					Path = AttachOFD.FileName
				};

				string[] imageFormats = new[]
				{
					"jpg", "jpeg", "gif", "bmp", "png"
				};
				if (imageFormats.Contains(AttachOFD.SafeFileName.Split('.').Last().ToLower()))
				{
					_attachedFile.File = ServiceClient.FromImageToBytes(Image.FromFile(AttachOFD.FileName));
					_attachedFile.Type = Message.AttachTypes.Image;
				}
				else
				{
					_attachedFile.File = File.ReadAllBytes(AttachOFD.FileName);
					_attachedFile.Type = Message.AttachTypes.File;
				}

				AttachButton.BackgroundImage = Properties.Resources.attach_active;
			}
		}

		private void RemoveAttachButton_Click(object sender, EventArgs e)
		{
			AttachButton.BackgroundImage = Properties.Resources.attach;
			_attachedFile = new Attach();
		}

		public void RemoveRow(TableLayoutPanel panel, int index)
		{
			if (index >= panel.RowCount)
			{
				return;
			}

			// delete all controls of row that we want to delete
			for (int i = 0; i < panel.ColumnCount; i++)
			{
				var control = panel.GetControlFromPosition(i, index);
				panel.Controls.Remove(control);
			}

			// move up row controls that comes after row we want to remove
			for (int i = index + 1; i < panel.RowCount; i++)
			{
				for (int j = 0; j < panel.ColumnCount; j++)
				{
					var control = panel.GetControlFromPosition(j, i);
					if (control != null)
					{
						panel.SetRow(control, i - 1);
					}
				}
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

			if (KeepUpdating)
				MessageUpdateBGW.RunWorkerAsync();
		}

		private void SelfDestroyMessage_DoWork(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(_chat.TimeToLive * 1000);

			Dictionary<Guid, int> arg = (Dictionary<Guid, int>)e.Argument;

			ServiceClient.DeleteMessage(arg.Keys.ToArray()[0]);

			e.Result = arg.Values.ToArray()[0];
		}

		private void SelfDestroyMessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//RemoveRow(MessagesPanel, (int)e.Result);
		}

		private void MessengerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			KeepUpdating = false;
		}
	}

	internal class Attach
	{
		public byte[] File;
		public string Path;
		public Model.Message.AttachTypes Type;
	}
}
