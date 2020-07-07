using System;
using Cirnix.Global;
using System.Drawing;
using System.Windows.Forms;
using static Cirnix.Forms.Component;
using static Cirnix.Memory.ChannelChat;

namespace Cirnix.Forms
{
    internal partial class ChannelChatForm : Global.DraggableLabelForm
    {
        private int AutoCloseElapsed = 0;
        private bool isPassed = false;
        internal ChannelChatForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            richTextBox.BackColor = Color.FromArgb(Settings.ChannelChatBGColor);
        }

        private void ChannelChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing
             && e.CloseReason != CloseReason.None ) return;
            e.Cancel = true;
            Hide();
            isPassed = true;
        }

        private void ChannelChatForm_VisibleChanged(object sender, EventArgs e)
        {
            Text = Title.Text = "접속 중 - " + GetChannelName();
            richTextBox.Clear();
            AutoCloseElapsed = 0;
            WindowsCloseTimer.Enabled = false;
            ChatTimer.Interval = Visible ? 200 : 2000;
        }

        private void ChatTimer_Tick(object sender, EventArgs e)
        {
            string ChatLog;
            if (string.IsNullOrEmpty(ChatLog = GetChannelChat()))
            {
                isPassed = false;
                if (AutoClose.Checked)
                    WindowsCloseTimer.Enabled = true;
                return;
            }
            if (isPassed
             || string.IsNullOrEmpty(ChatLog)
             || ChatLog == "\0")
                return;

            if (!Visible) Visible = true;
            string[] lines = ChatLog.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) return;
            string TimeLine = $"|CFFFFFFFF({DateTime.Now:hh:mm:ss})|R ";
            ChatLog = string.Empty;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i != 0) ChatLog += '\n';
                ChatLog += TimeLine + lines[i];
            }
            SetRTBText(ref richTextBox, ChatLog);
            richTextBox.AppendText("\n");
            if (WindowsCloseTimer.Enabled)
            {
                WindowsCloseTimer.Enabled = false;
                Text = Title.Text = "접속 중 - " + GetChannelName();
            }
        }

        private void WindowsCloseTimer_Tick(object sender, EventArgs e)
        {
            if (AutoCloseElapsed == 5) Hide();
            Text = Title.Text = (5 - AutoCloseElapsed++) + "초 뒤에 창이 닫힙니다...";
        }

        private void AutoClose_CheckedChanged(object sender, EventArgs e)
        {
            AutoCloseElapsed = 0;
            if (!AutoClose.Checked)
            {
                Text = Title.Text = "접속 중 - " + GetChannelName();
                WindowsCloseTimer.Enabled = false;
            }
        }

        private void ColorChange_Click(object sender, EventArgs e)
        {
            using (ColorDialog ColorPicker = new ColorDialog())
            {
                ColorPicker.AnyColor = true;
                ColorPicker.Color = Color.FromArgb(Settings.ChannelChatBGColor);
                ColorPicker.FullOpen = true;
                if (ColorPicker.ShowDialog() != DialogResult.OK) return;
                Settings.ChannelChatBGColor = ColorPicker.Color.ToArgb();
                richTextBox.BackColor = ColorPicker.Color;
            }
        }

        private void ClearScreen_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
    }
}
