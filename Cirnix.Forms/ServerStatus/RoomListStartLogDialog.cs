using Cirnix.Global;
using System;
using System.Windows.Forms;

namespace Cirnix.Forms.ServerStatus
{
    internal partial class RoomListStartLogDialog : DraggableLabelForm
    {
        internal string MapName = string.Empty;

        internal RoomListStartLogDialog()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            TB_MapName.Focus();
        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            MapName = TB_MapName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RoomListSearchPlayerDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BTN_Search_Click(sender, e);
        }

        private void TB_MapName_TextChanged(object sender, EventArgs e)
        {
            BTN_StartLog.Enabled = TB_MapName.Text.Length > 5;
        }
    }
}
