﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private readonly Dictionary<Guid, Bitmap> UserAvatars = new Dictionary<Guid, Bitmap>();

		public MessengerForm(Chat chat)
		{
			InitializeComponent();
			_chat = chat;
			Text = chat.Name.Split('-').First(x => x != Properties.Settings.Default.CurrentUser.Nickname);

			//UserAvatars = _chat.Members.Select(x => new
			//{
			//	x.User.ID,
			//	x.User.Avatar
			//}).ToDictionary(
			//	x => x.ID,
			//	x => (Bitmap)new ImageConverter().ConvertFrom(x.Avatar));
			_chat.Messages = ServiceClient.GetMessages(chat.ID, 0, 20).ToList();
			UpdateAllMessages(_chat.Messages.ToArray());

			//Если поставить якоря при создании контрола, всё сломается
			foreach(Control c in MessagesPanel.Controls)
			{
				if (c.GetType() != typeof(PictureBox))
					continue;

				if (c.Location.X == PictureMargin)
				{
					c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
				}
				else
				{
					c.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				}
			}
		}

		void UpdateAllMessages(Model.Message[] messages)
		{
			Guid lastMessageUserID = new Guid();

			for (int i = 0; i < messages.Length; i++)
			{
				MessagesPanel.Controls.Add(
										GetLabel(
												messages[i].ID.ToString(),
												messages[i].Text,
												LabelSizeY * i,
												messages[i].UserFromID == Properties.Settings.Default.CurrentUser.ID));

				if (lastMessageUserID != messages[i].UserFromID)
				{
					lastMessageUserID = messages[i].UserFromID;

					MessagesPanel.Controls.Add(
											GetPictureBox(
												//UserAvatars[messages[i].UserFromID],
												Properties.Resources.empty_avatar,
												LabelSizeY * i,
												messages[i].UserFromID == Properties.Settings.Default.CurrentUser.ID));
				}
			}
		}

		private Label GetLabel(string name, string text, int locationY, bool right, int sizeY = LabelSizeY)
		{
			return new Label()
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
				Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
				Location = new Point(LabelLocationX, locationY),
				Name = name,
				Size = new Size(ClientRectangle.Width - LabelLocationX * 2, sizeY),
				Text = text,
				TextAlign = right ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft,
				AutoSize = false,
			};
		}

		private PictureBox GetPictureBox(Bitmap image, int locationY, bool right)
		{
			return new PictureBox()
			{
				BackgroundImage = image,
				BackgroundImageLayout = ImageLayout.Zoom,
				Location = right
						 ? new Point(ClientRectangle.Width - PictureMargin - PictureSize, locationY)
						 : new Point(PictureMargin, locationY),
				Size = new Size(PictureSize, PictureSize),
				AutoSize = false,
			};
		}
	}
}
