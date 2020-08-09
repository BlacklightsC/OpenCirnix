using System;

using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.InputAPI
{
    public class PlayerChatEventArgs : EventArgs
	{
		public PlayerChatEventArgs(int sender, string message, ChatRecipients recipients, float duration)
		{
			Sender = sender;
			Message = message;
			Recipients = recipients;
			Duration = duration;
		}

		public int Sender { get; set; }

		public string Message { get; set; }

		public ChatRecipients Recipients { get; set; }

		public float Duration { get; set; }

		public bool IsBlocked { get; set; }
	}
}
