using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cirnix.Global
{
    internal partial class MessageBoxDialog : DraggableLabelForm
    {
        internal List<Button> Buttons;
        internal int Result = -1;
        internal MessageBoxDialog(string Title, int ButtonCount)
        {
            Init(Title, ButtonCount);

            foreach (var item in Buttons)
                item.Location.Offset(0, -25);
            Size = new Size(Size.Width, Size.Height - 25);
        }

        internal MessageBoxDialog(string Title, string Message, int ButtonCount)
        {
            Init(Title, ButtonCount);
            Label_Message.Visible = true;
            Label_Message.Text = Message;
            Size LabelSize = Label_Message.Size;
            int FixWidth = LabelSize.Width > Size.Width - 20 ? LabelSize.Width + 20 : Size.Width;
            int FixHeight = LabelSize.Height > Size.Height - 75 ? LabelSize.Height + 75 : Size.Height;
            Size = new Size(FixWidth, FixHeight);
        }

        private void Init(string Title, int ButtonCount)
        {
            InitializeComponent();
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Title;
            Icon = Properties.Resources.CirnixIcon;
            if (ButtonCount > 4) ButtonCount = 4;
            Buttons = new List<Button>(ButtonCount);
            for (int i = ButtonCount; i > 0; i--)
                switch (i)
                {
                    case 4: Buttons.Add(BTN_Four); break;
                    case 3: Buttons.Add(BTN_Three); break;
                    case 2: Buttons.Add(BTN_Two); break;
                    case 1: Buttons.Add(BTN_One); break;
                }
            switch (ButtonCount)
            {
                case 3:
                case 4:
                    Size = new Size(Size.Width + 82 * (ButtonCount - 2), Size.Height);
                    break;
            }
            for (int i = 0; i < ButtonCount; i++)
            {
                Buttons[i].Click += (sender, e) =>
                {
                    Result = Buttons.FindIndex(item => item == sender);
                    Close();
                };
                Buttons[i].Visible = true;
            }
        }
    }

    public static class MetroDialog
    {
        public static int Select(string Title, params string[] Buttons)
        {
            using (var dialog = new MessageBoxDialog(Title, Buttons.Length))
            {
                for (int i = 0; i < dialog.Buttons.Count; i++)
                    dialog.Buttons[i].Text = Buttons[i];
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        public static bool YesNo(string Title, string Message)
        {
            using (var dialog = new MessageBoxDialog(Title, Message, 2))
            {
                dialog.Buttons[0].Text = "네";
                dialog.Buttons[1].Text = "아니오";
                dialog.ShowDialog();
                return dialog.Result == 0;
            }
        }

        public static void OK(string Title, string Message)
        {
            using (var dialog = new MessageBoxDialog(Title, Message, 1))
            {
                dialog.Buttons[0].Text = "확인";
                dialog.ShowDialog();
            }
        }
    }
}
