using SuiBotAI.Components.Other.Gemini;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SSC.AI_Integration.CasualChatsElements
{
	public partial class CasualChat_History : UserControl
	{
		private static readonly Regex DATE_TIME_REGEX = new Regex("\\[DATETIME: Local(.+?)\\|\\sUTC\\s(.+?)\\]\\:", RegexOptions.Compiled);

		private GeminiMessage messageToDisplay;
		private DateTime UTC_Time;

		public CasualChat_History()
		{
			InitializeComponent();
		}

		public CasualChat_History(GeminiMessage messageToDisplay)
		{
			InitializeComponent();
			this.messageToDisplay = messageToDisplay;

			switch (messageToDisplay.role)
			{
				case Role.model:
					this.picBox_User.Hide();
					break;
				case Role.user:
					this.picBox_AI.Hide();
					break;
				default:
					this.picBox_User.Hide();
					this.picBox_AI.Hide();
					var el = this.table_Layout.Controls[2];
					break;
			}

			L_Text.Text = PartsToText(this.messageToDisplay.parts);
		}

		private string PartsToText(GeminiResponseMessagePart[] parts)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var part in parts)
			{
				if (part.text != null)
				{
					var text = part.text;
					if (text.StartsWith("[DATETIME:") && DATE_TIME_REGEX.IsMatch(text))
					{
						var groups = DATE_TIME_REGEX.Match(text).Groups;
						if(groups.Count == 3)
						{
							UTC_Time = DateTime.Parse(groups[2].Value.Trim());
							text = text.Substring(groups[0].Length).Trim();
							sb.AppendLine(UTC_Time.ToString());
							sb.AppendLine(text);
						}
					}
					else
						sb.AppendLine(part.text);
				}

				if (part.functionCall != null)
					sb.AppendLine($"~Calls function '{part.functionCall.name}'~");
			}
			return sb.ToString();

		}
	}
}
