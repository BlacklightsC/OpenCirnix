using System;
using System.Windows.Forms;

namespace Cirnix.Forms
{
    internal partial class HistoryForm : Global.DraggableLabelForm
    {
        private readonly string URL;
        internal HistoryForm(string URL)
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Text = $"{Global.Theme.Title} 패치 노트";
            this.URL = URL;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            TB_History.Text = Global.Globals.GetStringFromServer(URL);
        }
    }
}
