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
    internal sealed partial class SelectProcess : MetroForm
    {

        internal SelectProcess()
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            listView2.View = View.Details;
            listView2.Columns.Add("PID");
            listView2.Columns.Add("War3Name");
            listView2.Columns[0].Width = -2;
            listView2.Columns[1].Width = -2;
            Process[] processesByName = Process.GetProcessesByName(TargetProcess = "Warcraft III");
            if (processesByName.Length == 0)
            {
                processesByName = Process.GetProcessesByName(TargetProcess = "war3");
            }
            try
            {
                listView2.BeginUpdate();
                foreach (Process p in processesByName)

                {
                    string[] row = { Convert.ToString(p.Id), p.ProcessName };
                    ListViewItem newitem = new ListViewItem(row);
                    listView2.Items.Add(newitem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            listView2.EndUpdate();
        }


        private void Select_Click(object sender, EventArgs e)
        {            
            string id = listView2.FocusedItem.SubItems[0].Text;        
            GameModule.SelectWarcraft(Convert.ToInt32(id));
            MessageBox.Show(id + "프로세스 실행");
            Close();                                
        }



        private void SelectProcess_Load(object sender, EventArgs e)
        {

        }


        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
            


       

    }
}
