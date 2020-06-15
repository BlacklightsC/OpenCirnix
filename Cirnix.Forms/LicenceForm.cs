using Cirnix.Global;
using Cirnix.Memory;
using MetroFramework.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

using static Cirnix.Global.Globals;

namespace Cirnix.Forms
{
    internal sealed partial class LicenceForm : MetroForm
    {
        
        internal LicenceForm()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;

        }


        private void BTN_OK_click(object sender, EventArgs e)
        {
            Close();
        }



        private void LicenceForm_Load(object sender, EventArgs e)
        {
            
        }


            


       

    }
}
