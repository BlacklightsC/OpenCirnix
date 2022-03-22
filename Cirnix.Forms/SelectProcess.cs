using Cirnix.Global;
using Cirnix.Memory;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static Cirnix.Memory.Component;

namespace Cirnix.Forms
{
    internal sealed partial class SelectProcess : MetroForm
    {
        private readonly List<Process> procs = new List<Process>();

        internal SelectProcess()
        {
            InitializeComponent();
            procs.AddRange(Process.GetProcessesByName("Warcraft III"));
            procs.AddRange(Process.GetProcessesByName("war3"));
            try
            {
                ProcessList.BeginUpdate();
                foreach (Process p in procs)
                {
                    string[] row = { p.Id.ToString(), p.ProcessName };
                    ListViewItem newitem = new ListViewItem(row) { Tag = p };
                    ProcessList.Items.Add(newitem);
                }
            }
            finally
            {
                ProcessList.EndUpdate();
            }
        }


        private void Select_Click(object sender, EventArgs e)
        {
            Process proc = ProcessList.FocusedItem.Tag as Process;
            //MetroDialog.OK("지정 완료", $"{proc.ProcessName} ({proc.Id}) 가 지정되었습니다.");
            
            switch (GameModule.InitWarcraft3Info(proc))
            {
                case WarcraftState.OK:
                    Warcraft3Info.Refresh();
                    GameModule.GetOffset();
                    MetroDialog.OK("지정 완료", $"{proc.ProcessName} ({proc.Id}) 가 지정되었습니다.");
                    break;
                case WarcraftState.Closed:
                    MetroDialog.OK("오류", $"{proc.ProcessName} ({proc.Id}) 는 이미 화면이 종료된 상태이므로 강제로 프로세스를 종료합니다.");
                    break;
                case WarcraftState.Error:
                    MetroDialog.OK("오류", "프로세스를 초기화 하는데에 실패했습니다.");
                    break;
            }
            
            procs.Remove(proc);
            Close();                                
        }

        private void SelectProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in procs)
                item.Dispose();
        }
    }
}
