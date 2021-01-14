using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Cirnix.Global;

using static Cirnix.Global.Globals;
using static Cirnix.Memory.Message;

namespace Cirnix.Worker
{
    public sealed class ChatHotkey
    {
        public string ChatMessage { get; set; }
        public Keys Hotkey { get; set; }
        public bool IsRegisted { get; set; }

        internal ChatHotkey()
        {
            ChatMessage = string.Empty;
            Hotkey = 0;
            IsRegisted = false;
        }
    }

    public sealed class ChatHotkeyList : List<ChatHotkey>
    {
        internal ChatHotkeyList()
        {
            Read();
        }
        public void Save()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) builder.Append("∫");
                builder.AppendFormat("{0}∫{1}∫{2}", this[i].ChatMessage, (int)this[i].Hotkey, this[i].IsRegisted);
            }
            Settings.HotkeyChat = builder.ToString();
        }

        private void Read()
        {
            string[] Text = Settings.HotkeyChat.Split(new string[] { "∫" }, StringSplitOptions.None);
            for (int i = 0; i < 10; i++)
            {
                Add(new ChatHotkey());
                this[i].ChatMessage = Text[i * 3];
                this[i].Hotkey = (Keys)int.Parse(Text[i * 3 + 1]);
                this[i].IsRegisted = Convert.ToBoolean(Text[i * 3 + 2]);
            }
        }

        public bool IsKeyRegisted(int index)
        {
            return this[index].Hotkey != 0;
        }

        public bool Register(int index)
        {
            if (hotkeyList.IsRegistered(this[index].Hotkey)) return false;
            hotkeyList.Register(this[index].Hotkey, vk => SendMsg(false, this[index].ChatMessage), this[index].Hotkey, false, false);
            this[index].IsRegisted = true;
            return true;
        }

        public bool UnRegister(int index)
        {
            if (!hotkeyList.IsRegistered(this[index].Hotkey)) return false;
            hotkeyList.UnRegister(this[index].Hotkey);
            this[index].IsRegisted = false;
            return true;
        }
    }
}
