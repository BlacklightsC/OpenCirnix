using Cirnix.Global;
using Cirnix.ServerStatus;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cirnix.Forms.ServerStatus
{
    internal partial class RoomListSearchPlayerDialog : DraggableLabelForm
    {
        internal List<RoomInformation.Field> infoList = null;
        internal int ResultIndex = -1;
        internal string PlayerName = string.Empty;

        internal RoomListSearchPlayerDialog()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            TB_ID.Focus();
        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            PlayerName = TB_ID.Text;
            for (int i = 0; i < infoList.Count; i++)
            {
                if (PlayerName.Equals(infoList[i].player0, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player1, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player2, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player3, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player4, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player5, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player6, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player7, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player8, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player9, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player10, StringComparison.OrdinalIgnoreCase)
                 || PlayerName.Equals(infoList[i].player11, StringComparison.OrdinalIgnoreCase))
                {
                    ResultIndex = i;
                    break;
                }
            }
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
    }
}
