using System;
using System.Diagnostics;
using System.Windows.Forms;

using Cirnix.Global;

namespace Cirnix.Forms
{
    internal partial class DonateForm : DraggableLabelForm
    {
        internal DonateForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Text = "후원 안내";
        }

        private void BTN_Toonation_Click(object sender, EventArgs e)
        {
            Process.Start("https://toon.at/donate/637131255322131449");
        }

        private void BTN_Paypal_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/BlacklightsC");
        }

        private void BTN_Patreon_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.patreon.com/cirnix");
        }
    }
}
