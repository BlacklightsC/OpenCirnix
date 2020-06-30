using Cirnix.Global;
using Cirnix.ServerStatus;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using static Cirnix.ServerStatus.StatusWebDataBase;

namespace Cirnix.Forms.ServerStatus
{
    internal partial class RoomListStatistics : DraggableLabelForm
    {
        private static readonly Font defFont = new Font("맑은 고딕", 8F);
        private const int MaxElement = 18;
        private DataPointCollection DPC;
        internal List<RoomInformation.Field> infoList = null;
        private StatusInformation statusInfo = null;
        private bool closed = false;
        private System.Timers.Timer RefreshTimer;

        internal RoomListStatistics(List<RoomInformation.Field> infoList)
        {
            InitializeComponent();
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            StatisticsChart.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            StatisticsChart.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            StatisticsChart.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            DPC = StatisticsChart.Series[0].Points;
            this.infoList = infoList;
            Responsed += item => Invoke(new GetDataEventHandler(RoomStatisticsResponse), item);

            GetServerStatusAsync();
            RefreshTimer = new System.Timers.Timer(3000);
            RefreshTimer.Elapsed += (sender, e) => GetServerStatusAsync();
            RefreshTimer.Start();
        }
        
        private bool IsMapStandard {
            get => RB_Map.Checked;
            set {
                RB_Map.Checked = value;
                RB_Player.Checked = !value;
            }
        }
        private void RoomStatisticsResponse(StatusInformation i)
        {
            if (closed) return;
            statusInfo = i;
            RoomStatistics();
        }
        private void RoomStatisticsRefresh(object sender, EventArgs e)
        {
            RoomStatistics();
        }
        private void RoomStatistics()
        {
            List<MapStat> stat = new List<MapStat>();
            int TotalPlayer = 0;
            DPC.Clear();
            foreach (var item in infoList)
            {
                int players = 0;
                if (item.player0 != null) players++;
                if (item.player1 != null) players++;
                if (item.player2 != null) players++;
                if (item.player3 != null) players++;
                if (item.player4 != null) players++;
                if (item.player5 != null) players++;
                if (item.player6 != null) players++;
                if (item.player7 != null) players++;
                if (item.player8 != null) players++;
                if (item.player9 != null) players++;
                if (item.player10 != null) players++;
                if (item.player11 != null) players++;
                TotalPlayer += players;
                for (int i = 0; i < stat.Count; i++)
                {
                    if (!item.mapname.Equals(stat[i].name, StringComparison.OrdinalIgnoreCase)) continue;
                    stat[i].count += IsMapStandard ? 1 : players;
                    goto foreachContinue;
                }
                stat.Add(new MapStat(item.mapname, IsMapStandard ? 1 : players));
            foreachContinue:;
            }
            stat.Sort((A, B) =>
            {
                if (A.count > B.count) return -1;
                else if (A.count < B.count) return 1;
                return 0;
            });
            if (CB_IgnoreVersion.Checked)
            {
                for (int i = 0; i < stat.Count; i++)
                {
                    int length = 5;
                    string first = Path.GetFileNameWithoutExtension(stat[i].name);
                    if (first.Length > 2 && first[first.Length - 2] == '~') first = first.Substring(0, first.Length - 2);
                    first = first.Substring(0, first.Length >= length ? length : (length = first.Length));
                    for (int j = i + 1; j < stat.Count;)
                    {
                        string second = Path.GetFileNameWithoutExtension(stat[j].name);
                        if (second.Length > 2 && second[second.Length - 2] == '~') second = second.Substring(0, second.Length - 2);
                        if (second.Length < length)
                        {
                            j++;
                            continue;
                        }
                        if (first.Equals(second.Substring(0, length), StringComparison.OrdinalIgnoreCase))
                        {
                            stat[i].count += stat[j].count;
                            stat.RemoveAt(j);
                            continue;
                        }
                        j++;
                    }
                }
                stat.Sort((A, B) =>
                {
                    if (A.count > B.count) return -1;
                    else if (A.count < B.count) return 1;
                    return 0;
                });
            }
            int otherCount = 0;
            while (stat.Count > MaxElement)
            {
                otherCount += stat[MaxElement].count;
                stat.RemoveAt(MaxElement);
            }          
            if(CB_DisplayAll.Checked)
            {
                if (otherCount > 0)
                {
                    stat.RemoveAt(MaxElement - 1);
                    stat.Add(new MapStat("그 외의 맵", otherCount));
                }
                if (!IsMapStandard)
                {
                    stat.RemoveAt(MaxElement - (otherCount > 0 ? 2 : 1));
                    stat.Add(new MapStat("채널", statusInfo.users - TotalPlayer));
                }
            }

            int Rank = 0, RealRank = 0, PreValue = 0;
            
            foreach (var item in stat)
            {
                DataPoint DP = new DataPoint();
                DP.SetValueY(item.count);
                RealRank++;
                if (PreValue != item.count)
                {
                    PreValue = item.count;
                    Rank = RealRank;
                }
                DP.LegendText = $"{Rank}. {Path.GetFileNameWithoutExtension(item.name)} ({(double)item.count / (IsMapStandard ? infoList.Count : CB_DisplayAll.Checked ? statusInfo.users : TotalPlayer) * 100:0.##}%)";
                DP.Font = defFont;
                DP.IsValueShownAsLabel = true;
                DPC.Add(DP);
            }
            Label_Players.Text = TotalPlayer.ToString();
            Label_TotalRoom.Text = infoList.Count.ToString();
            Label_TotalPlayers.Text = statusInfo.users.ToString();
        }

        private void RoomListStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (RefreshTimer)
            {
                RefreshTimer.Stop();
            }
            closed = true;
            RemoveEventHandler();
        }
    }

    internal sealed class MapStat
    {
        internal string name { get; set; }
        internal int count { get; set; }
        internal MapStat(string name, int count = 1)
        {
            this.name = name;
            this.count = count;
        }
    }
}
