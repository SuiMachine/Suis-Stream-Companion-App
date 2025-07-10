using SuiBotAI.Components.Other.Gemini;
using System;
using System.Text;
using System.Windows.Forms;

namespace SSC.AI_Integration.CasualChatsElements
{
	public partial class CasualChat_History : UserControl
	{
		private GeminiMessage messageToDisplay;

		public CasualChat_History()
		{
			InitializeComponent();
		}

		public CasualChat_History(GeminiMessage messageToDisplay)
		{
			InitializeComponent();
			this.messageToDisplay = messageToDisplay;

			switch(messageToDisplay.role)
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
					break;
			}

			L_Text.Text = PartsToText(this.messageToDisplay.parts);
		}

		private string PartsToText(GeminiResponseMessagePart[] parts)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var part in parts)
			{
				if(part.text != null)
					sb.AppendLine(part.text);

				if (part.functionCall != null)
					sb.AppendLine("FUNCTION CALL:" + part.functionCall.name);
			}
			return sb.ToString();

		}
	}
}
