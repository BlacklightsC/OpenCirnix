using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cirnix.Forms
{
    public static class Component
    {
        public static void SetRTBText(ref RichTextBox RTB, string Text, bool IsNew = false, bool IsNegative = false, bool IsMiddleSort = false)
        {
            if (IsNew) RTB.Text = string.Empty;
            List<int> Pos = new List<int>();
            List<int> ColorCode = new List<int>();
            for (int i = 0; i < Text.Length;)
            {
                int idx = Text.IndexOf('|', i);
                if (idx == -1) break;
                else
                {
                    try
                    {
                        switch (Text[idx + 1])
                        {
                            case 'C':
                            case 'c':
                                ColorCode.Add(Convert.ToInt32(Text.Substring(idx + 2, 8), 16));
                                Text = Text.Remove(idx, 10);
                                break;
                            case 'R':
                            case 'r':
                                ColorCode.Add(IsNegative ? 0x000000 : 0xFFFFFF);
                                Text = Text.Remove(idx, 2);
                                break;
                            case 'n':
                                Text = Text.Remove(idx, 2).Insert(idx, "\n");
                                i = idx - 1;
                                continue;
                            default: i = idx + 1; continue;
                        }
                        Pos.Add(idx + (IsNew ? 0 : RTB.Text.Length));
                    }
                    catch
                    {
                        i = idx + 1;
                    }
                }
            }
            if (IsMiddleSort) RTB.SelectionAlignment = HorizontalAlignment.Center;
            RTB.AppendText(Text);
            for (int i = 0; i < Pos.Count; i++)
            {
                RTB.Select(Pos[i], i + 1 < Pos.Count ? Pos[i + 1] : RTB.Text.Length - Pos[i]);
                RTB.SelectionColor = Color.FromArgb(ColorCode[i]);
                RTB.DeselectAll();
                RTB.SelectionColor = IsNegative ? Color.Black : Color.White;
            }
            RTB.ScrollToCaret();
        }
    }
}
