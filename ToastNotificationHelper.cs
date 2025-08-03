using System.IO;
using System.Linq;
using Windows.UI.Notifications;

namespace SSC
{
	public static class ToastNotificationHelper
	{
		public const string APP_DISPLAY_NAME = "Sui's Stream Companion App";
		private static readonly ToastNotifier m_Notifier = ToastNotificationManager.CreateToastNotifier(APP_DISPLAY_NAME);

		public static void DisplayNotification(string imagePath, string content, ToastTemplateType notificationType)
		{
			var template = ToastNotificationManager.GetTemplateContent(notificationType);

			var image = template.GetElementsByTagName("image")?[0];
			if(image != null)
			{
				var nodes = image.Attributes.FirstOrDefault(x => x.NodeName == "src");

				if (nodes != null && File.Exists(imagePath))
				{
					nodes.NodeValue = imagePath.Replace('\\', '/');
				}
			}
			var textNode = template.GetElementsByTagName("text")?[0];
			if (textNode != null)
			{
				textNode.InnerText = content;
			}

			m_Notifier.Show(new ToastNotification(template));
		}
	}
}
