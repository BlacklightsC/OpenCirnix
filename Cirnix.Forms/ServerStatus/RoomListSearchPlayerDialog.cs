using Cirnix.ServerStatus;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cirnix.Forms
{
    internal partial class RoomListSearchPlayerDialog : Global.DraggableLabelForm
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
                if (infoList[i].player0.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player1.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player2.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player3.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player4.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player5.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player6.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player7.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player8.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player9.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player10.Equals(PlayerName, StringComparison.OrdinalIgnoreCase)
                 || infoList[i].player11.Equals(PlayerName, StringComparison.OrdinalIgnoreCase))
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
