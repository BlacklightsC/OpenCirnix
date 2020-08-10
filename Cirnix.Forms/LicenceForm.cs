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
            Label_Licence.Text = "Copyright (c) 2017 - 2020 BlacklightsC\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\n of this software and associated documentation files(the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\n to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell\r\n copies of the Software, and to permit persons to whom the Software is\r\n furnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.";

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
