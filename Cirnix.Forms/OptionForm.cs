using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cirnix.Global;
using Cirnix.KeyHook;
using Cirnix.Memory;
using Cirnix.Worker;

using ModernFolderBrowserDialog;

using static Cirnix.Forms.NativeMethods;
using static Cirnix.Global.Globals;
using static Cirnix.Global.Hotkey;
using static Cirnix.Global.Locale;
using static Cirnix.Worker.MainWorker;

namespace Cirnix.Forms
{
    internal partial class OptionForm : DraggableLabelForm
    {
        internal Action<bool> ChannelChatState;
        private enum SelectedKeypadType
        {
            Key7 = 7,
            Key8 = 8,
            Key4 = 4,
            Key5 = 5,
            Key1 = 1,
            Key2 = 2,
            None = 0
        }
        private enum SelectedAutoMouseType { Off, Left, Right }
        private SelectedKeypadType TargetKey;
        private SelectedAutoMouseType TargetMouse;
        private bool IsRemapKeyInput = false, IsChatHotkeyInput = false, IsAutoMouseInput = false, IsUpdating = false;
        private int CurrentChatIndex = 0;

        internal OptionForm()
        {
            InitializeComponent();
            IsUpdating = true;
            Icon = Global.Properties.Resources.CirnixIcon;
            Label_Title.MouseDown += new MouseEventHandler(Label_Title_MouseDown);
            Label_Title.MouseMove += new MouseEventHandler(Label_Title_MouseMove);
            Label_Title.MouseUp += new MouseEventHandler(Label_Title_MouseUp);
            Label_Title.Text = Text = $"{Global.Theme.Title} 설정 및 도움말";
            Toggle_CommandHide.Checked = Settings.IsCommandHide;
            #region [    Warcraft Tab Initialize    ]
            Num_GameDelay.Value = Settings.GameDelay;
            Num_GameStartDelay.Value = Math.Abs(Convert.ToInt32(Settings.StartSpeed));
            Toggle_HpCommandAuto.Checked = Settings.IsAutoHp;
            TB_MemoryOptimizationDelay.Text = Settings.MemoryOptimizeCoolDown.ToString();
            Toggle_MemoryOptimizationDelay.Checked = Settings.IsMemoryOptimize;
            Toggle_OutGameAutoMemoryOptimization.Checked = Settings.IsOptimizeAfterEndGame;
            Toggle_CheatMapCheck.Checked = Settings.IsCheatMapCheck;
            Combo_ScreenShotExtension.Text = Settings.ConvertExtention;
            Toggle_AutoConvert.Checked = Settings.IsConvertScreenShot;
            Toggle_RemoveOriginal.Checked = Settings.IsOriginalRemove;
            Toggle_War3FixClipboard.Checked = Settings.IsFixClipboard;
            Num_CameraDistance.Value = Convert.ToInt32(Settings.CameraDistance);
            Num_CameraX.Value = Convert.ToInt32(Settings.CameraAngleX);
            Num_CameraY.Value = Convert.ToInt32(Settings.CameraAngleY);
            Toggle_ChannelChatViewer.Checked = Settings.IsChannelChatDetect;
            TB_InstallPath.Text = Settings.InstallPath;
            #endregion
            #region [    RPG Tab Initialize    ]
            RPGListBox.BeginUpdate();
            RPGListBox.Items.Clear();
            RPGListBox.Items.Add("(새로 만들기)");
            if(saveFilePath.Count > 0)
                foreach (SavePath item in saveFilePath)
                    RPGListBox.Items.Add(saveFilePath.ConvertName(item.nameEN));
            RPGListBox.EndUpdate();
            CB_AutoLoad.Checked = Settings.IsAutoLoad;
            CB_NewMapSaveFileAuto.Checked = Settings.IsGrabitiSaveAutoAdd;
            CB_SavesReplayAutoSave.Checked = CB_NoSavesReplaySave.Enabled = Settings.IsAutoReplay;
            CB_NoSavesReplaySave.Checked = Settings.NoSavedReplaySave;
            TabControl_CommandPreset.SelectedIndex = Settings.SelectedCommand - 1;
            TB_CommandPreset1.Text = Settings.CommandPreset1.Replace("\n\n", "\n").Replace("\n", "\r\n");
            TB_CommandPreset2.Text = Settings.CommandPreset2.Replace("\n\n", "\n").Replace("\n", "\r\n");
            TB_CommandPreset3.Text = Settings.CommandPreset3.Replace("\n\n", "\n").Replace("\n", "\r\n");
            #endregion
            #region [    Macro Tab Initialize    ]
            #region [    Smart Key Showing Status Initialize    ]
            if (isSmartKey(Keys.Q))
                Qbutton.BackgroundImage = Properties.Resources.Q1button;
            if (isSmartKey(Keys.W))
                Wbutton.BackgroundImage = Properties.Resources.W1button;
            if (isSmartKey(Keys.E))
                Ebutton.BackgroundImage = Properties.Resources.E1button;
            if (isSmartKey(Keys.R))
                Rbutton.BackgroundImage = Properties.Resources.R1button;
            if (isSmartKey(Keys.T))
                Tbutton.BackgroundImage = Properties.Resources.T1button;
            if (isSmartKey(Keys.A))
                Abutton.BackgroundImage = Properties.Resources.A1button;
            if (isSmartKey(Keys.D))
                Dbutton.BackgroundImage = Properties.Resources.D1button;
            if (isSmartKey(Keys.F))
                Fbutton.BackgroundImage = Properties.Resources.F1button;
            if (isSmartKey(Keys.G))
                Gbutton.BackgroundImage = Properties.Resources.G1button;
            if (isSmartKey(Keys.Z))
                Zbutton.BackgroundImage = Properties.Resources.Z1button;
            if (isSmartKey(Keys.X))
                Xbutton.BackgroundImage = Properties.Resources.X1button;
            if (isSmartKey(Keys.C))
                Cbutton.BackgroundImage = Properties.Resources.C1button;
            if (isSmartKey(Keys.V))
                Vbutton.BackgroundImage = Properties.Resources.V1button;
            SmartKeyPreventionType = Settings.SmartKeyPreventionType;
            #endregion
            #region [    Key Remapping Showing Status Initialize    ]
            if (Settings.KeyMap7 != 0)
            {
                Key7Text.Text = GetHotkeyString(((Keys)Settings.KeyMap7));
                Key7.Text = "X";
            }
            if (Settings.KeyMap8 != 0)
            {
                Key8Text.Text = GetHotkeyString(((Keys)Settings.KeyMap8));
                Key8.Text = "X";
            }
            if (Settings.KeyMap4 != 0)
            {
                Key4Text.Text = GetHotkeyString(((Keys)Settings.KeyMap4));
                Key4.Text = "X";
            }
            if (Settings.KeyMap5 != 0)
            {
                Key5Text.Text = GetHotkeyString(((Keys)Settings.KeyMap5));
                Key5.Text = "X";
            }
            if (Settings.KeyMap1 != 0)
            {
                Key1Text.Text = GetHotkeyString(((Keys)Settings.KeyMap1));
                Key1.Text = "X";
            }
            if (Settings.KeyMap2 != 0)
            {
                Key2Text.Text = GetHotkeyString(((Keys)Settings.KeyMap2));
                Key2.Text = "X";
            }
            Toggle_KeyRemapping.Checked = Settings.IsKeyRemapped;
            #endregion
            #region [    Text Macro Showing Status Initialize   ]
            TB_ChatMacro.Text = chatHotkeyList[CurrentChatIndex].ChatMessage;
            Label_ChatHotkey.Text = GetHotkeyString(chatHotkeyList[CurrentChatIndex].Hotkey);
            BTN_SetChatHotkey.Text = chatHotkeyList.IsKeyRegisted(CurrentChatIndex) ? "단축키 해제" : "단축키 지정";
            Toggle_ChatMacro.Checked = chatHotkeyList[CurrentChatIndex].IsRegisted;
            for (; CurrentChatIndex < 10; CurrentChatIndex++)
            {
                if (chatHotkeyList.IsKeyRegisted(CurrentChatIndex))
                    RB_Chat_SetCurrentFont(0, true);
                if (chatHotkeyList[CurrentChatIndex].IsRegisted)
                    RB_Chat_SetCurrentFont(1, true);
            }
            CurrentChatIndex = 0;
            #endregion
            #region [    Auto Mouse Showing Status Initialize    ]
            Toggle_AutoMouse.Checked = AutoMouse.Enabled;
            BTN_AutoLeftMouseOn.Text = AutoMouse.LeftStartKey == 0 ? "좌클" : "해제";
            BTN_AutoRightMouseOn.Text = AutoMouse.RightStartKey == 0 ? "우클" : "해제";
            BTN_AutoMouseOff.Text = AutoMouse.EndKey == 0 ? "종료" : "해제";
            Label_AutoLeftMouseOn.Text = GetHotkeyString(AutoMouse.LeftStartKey);
            Label_AutoRightMouseOn.Text = GetHotkeyString(AutoMouse.RightStartKey);
            Label_AutoMouseOff.Text = GetHotkeyString(AutoMouse.EndKey);
            Label_AutoMouseDelay.Text = $"{AutoMouse.Interval} ms";
            TrB_AutoMouseDelay.Value = AutoMouse.Interval;
            #endregion
            #endregion
            Toggle_AutoFrequency.Checked = Settings.IsAutoFrequency;
            Number_ChatFrequency.Enabled = BTN_DetectFrequency.Enabled = !Settings.IsAutoFrequency;
            Number_ChatFrequency.Value = Settings.ChatFrequency + 1;
            Banlistload();
            IsUpdating = false;
        }
        private void OptionForm_Activated(object sender, EventArgs e)
        {
            IsUpdating = true;
            #region [    RPG Tab Update    ]
            HeroListBox_Update();
            #endregion
            #region [    Warcraft Tab Update    ]
            Num_GameDelay.Value = Settings.GameDelay;
            Num_GameStartDelay.Value = Settings.StartSpeed >= 1 ? (int)Settings.StartSpeed : 0;
            Num_CameraDistance.Value = Settings.CameraDistance > 6000 ? 6000 : (int)Settings.CameraDistance;
            Num_CameraY.Value = ((int)Settings.CameraAngleY) % 360;
            Num_CameraX.Value = ((int)Settings.CameraAngleX) % 360;
            IsMixFIleFormEnabled = IsMixFileInstalled;
            GetMixFileStates();
            #endregion
            Toggle_KeyRemapping.Checked = Settings.IsKeyRemapped;
            IsUpdating = false;
        }
        #region [    Warcraft Tab Setting    ]
        private void DelayApplyBTN_Click(object sender, EventArgs e)
        {
            Settings.GameDelay = ControlDelay.GameDelay = Convert.ToInt32(Num_GameDelay.Value);
            Settings.StartSpeed = GameDll.StartDelay = Convert.ToInt32(Num_GameStartDelay.Value) <= 0.01 ? 0.01f : Convert.ToInt32(Num_GameStartDelay.Value);
        }
        private void HpCommandAutoToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsAutoHp = Toggle_HpCommandAuto.Checked;
        }
        private void MemoryOptimizationEdit_Leave(object sender, EventArgs e)
        {
            try
            {
                Settings.MemoryOptimizeCoolDown = int.Parse(TB_MemoryOptimizationDelay.Text);
            }
            catch
            {
                TB_MemoryOptimizationDelay.Text = Settings.MemoryOptimizeCoolDown.ToString();
            }
        }
        private void MemoryOptimizationToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsMemoryOptimize = Toggle_MemoryOptimizationDelay.Checked;
        }
        private void OutGameAutoMemoryOptimizationToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsOptimizeAfterEndGame = Toggle_OutGameAutoMemoryOptimization.Checked;
        }
        private void Toggle_CheatMapCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsCheatMapCheck = Toggle_CheatMapCheck.Checked;
        }
        private void BTN_CameraPresetJurrasic_Click(object sender, EventArgs e)
        {
            Num_CameraDistance.Value = 3318;
            GameDll.CameraDistance = Settings.CameraDistance = 3318.4f;
            Num_CameraY.Value = 283;
            GameDll.CameraAngleY = Settings.CameraAngleY = 283.4f;
            Num_CameraX.Value = 101;
            GameDll.CameraAngleX = Settings.CameraAngleX = 100.7f;
            GameDll.CameraInit();
        }
        private void CameraResetBTN_Click(object sender, EventArgs e)
        {
            Num_CameraDistance.Value = 1650;
            GameDll.CameraDistance = Settings.CameraDistance = 1650.0f;
            Num_CameraY.Value = 304;
            GameDll.CameraAngleY = Settings.CameraAngleY = 304.0f;
            Num_CameraX.Value = 90;
            GameDll.CameraAngleX = Settings.CameraAngleX = 90.0f;
            GameDll.CameraInit();
        }
        private void CameraApplyBTN_Click(object sender, EventArgs e)
        {
            GameDll.CameraDistance = Settings.CameraDistance = Convert.ToInt32(Num_CameraDistance.Value);
            GameDll.CameraAngleY = Settings.CameraAngleY = Convert.ToInt32(Num_CameraY.Value);
            GameDll.CameraAngleX = Settings.CameraAngleX = Convert.ToInt32(Num_CameraX.Value);
            GameDll.CameraInit();
        }
        private void ScreenShotFileNameExtensionList_TextChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.ConvertExtention = Combo_ScreenShotExtension.Text;
        }
        private void TgaAutoConvertToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            ScreenShotWatcher.EnableRaisingEvents = Settings.IsConvertScreenShot = Toggle_AutoConvert.Checked;
        }
        private void TgaOriginallyDeleteToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsOriginalRemove = Toggle_RemoveOriginal.Checked;
        }
        private void War3AutoKillToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsFixClipboard = Toggle_War3FixClipboard.Checked;
            if (Toggle_War3FixClipboard.Checked)
                ClipboardConverter.FixStart();
            else
                ClipboardConverter.FixEnd();
        }
        private void CommandHideToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsCommandHide = Toggle_CommandHide.Checked;
        }
        private void Toggle_ChannelChatViewer_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            ChannelChatState(Settings.IsChannelChatDetect = Toggle_ChannelChatViewer.Checked);
        }
        #region [    Mix File Setting    ]
        private void GetMixFileStates()
        {
            Manabar = GetPrivateProfileInt("Cirnix", "Mana Bar", 0, Settings.InstallPath + @"\Cirnix.ini") == 1;
            SpeedNumberize = GetPrivateProfileInt("Cirnix", "Show AS & MS in Number", 0, Settings.InstallPath + @"\Cirnix.ini") == 1;
        }
        private bool IsMixFileInstalled {
            get {
                if (string.IsNullOrEmpty(Settings.InstallPath)) return false;
                return File.Exists($"{Settings.InstallPath}\\Cirnix.mix");
            }
            set {
                if (string.IsNullOrEmpty(Settings.InstallPath))
                {
                    MetroDialog.OK("경로 오류", "경로가 비어있습니다.\n경로를 입력하세요.");
                    return;
                }
                string path = $"{Settings.InstallPath}\\Cirnix";
                if (value)
                {
                    if (!File.Exists(path + ".mix"))
                    {
                        File.WriteAllBytes(path + ".mix", Global.Properties.Resources.Cirnix);
                        WritePrivateProfileString("Cirnix", "Mana Bar", "0", path + ".ini");
                        WritePrivateProfileString("Cirnix", "Show AS & MS in Number", "0", path + ".ini");
                    }
                    return;
                }
                try
                {
                    File.Delete(path + ".mix");
                    File.Delete(path + ".ini");
                }
                catch
                {
                    MetroDialog.OK("파일 접근 오류", "워크래프트 실행 중에는 파일을 제거할 수 없습니다.\n먼저 워크래프트를 종료하세요.");
                }
            }
        }
        private bool IsMixFIleFormEnabled {
            get => BTN_UninstallMix.Enabled;
            set {
                GB_SpeenNumberize.Enabled =
                BTN_UninstallMix.Enabled =
                GB_Manabar.Enabled = value;
                BTN_InstallMix.Enabled = !value;
            }
        }
        private bool SpeedNumberize {
            get => RB_EnableSpeedNumberize.Checked;
            set {
                RB_EnableSpeedNumberize.Checked = value;
                RB_DisableSpeedNumberize.Checked = !value;
            }
        }
        private bool Manabar {
            get => RB_EnableManabar.Checked;
            set {
                RB_EnableManabar.Checked = value;
                RB_DisableManabar.Checked = !value;
            }
        }
        private void BTN_InstallMix_Click(object sender, EventArgs e)
        {
            IsMixFileInstalled = true;
            IsMixFIleFormEnabled = IsMixFileInstalled;
        }
        private void BTN_UninstallMix_Click(object sender, EventArgs e)
        {
            IsMixFileInstalled = false;
            IsMixFIleFormEnabled = IsMixFileInstalled;
            GetMixFileStates();
        }
        private void BTN_InstallPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog FDialog = new OpenFileDialog())
            {
                FDialog.Title = "워크래프트 실행 파일을 선택하세요.";
                FDialog.Filter = "워크래프트 EXE파일|Warcraft III.exe";
                if (FDialog.ShowDialog() != DialogResult.OK) return;
                Settings.InstallPath = TB_InstallPath.Text = Path.GetDirectoryName(FDialog.FileName);
            }
            IsMixFIleFormEnabled = IsMixFileInstalled;
        }
        private void RB_EnableSpeedNumberize_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            WritePrivateProfileString("Cirnix", "Show AS & MS in Number", RB_EnableSpeedNumberize.Checked ? "1" : "0", Settings.InstallPath + @"\Cirnix.ini");
        }
        private void RB_EnableManabar_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            WritePrivateProfileString("Cirnix", "Mana Bar", RB_EnableManabar.Checked ? "1" : "0", Settings.InstallPath + @"\Cirnix.ini");
        }
        #endregion
        #endregion
        #region [    RPG Tab Setting    ]
        #region [    SaveList Setting    ]
        private void RPGListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_RPGKR.Text = TB_RPGEN.Text = TB_RPGPath.Text = string.Empty;
            BTN_RPGDel.Enabled = BTN_RPGFolder.Enabled = false;
            HeroListBox_Update();
            if (RPGListBox.SelectedIndex == -1)
            {
                TB_RPGKR.Enabled = TB_RPGEN.Enabled = TB_RPGPath.Enabled = BTN_RPGPath.Enabled = BTN_RPGAddMod.Enabled = false;
                BTN_RPGAddMod.Text = "추가";
                return;
            }
            TB_RPGKR.Enabled = TB_RPGEN.Enabled = TB_RPGPath.Enabled = BTN_RPGPath.Enabled = BTN_RPGAddMod.Enabled = true;
            string SelectedName = RPGListBox.SelectedItem.ToString();
            if (SelectedName == "(새로 만들기)")
            {
                BTN_RPGAddMod.Text = "추가";
                return;
            }
            BTN_RPGDel.Enabled = BTN_RPGFolder.Enabled = true;
            BTN_RPGAddMod.Text = "변경";
            string NameEN = saveFilePath.ConvertName(SelectedName, true);
            if (SelectedName != NameEN) TB_RPGKR.Text = SelectedName;
            TB_RPGEN.Text = NameEN;
            TB_RPGPath.Text = saveFilePath.GetFullPath(SelectedName);
        }
        private void HeroListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_HeroName.Text = string.Empty;
            BTN_HeroDel.Enabled = BTN_HeroFolder.Enabled = false;
            if (HeroListBox.SelectedIndex == -1)
            {
                TB_HeroName.Enabled = BTN_HeroAddMod.Enabled = false;
                BTN_HeroAddMod.Text = "추가";
                return;
            }
            TB_HeroName.Enabled = BTN_HeroAddMod.Enabled = true;
            string SelectedName = HeroListBox.SelectedItem.ToString();
            if (SelectedName == "(새로 만들기)")
            {
                BTN_HeroAddMod.Text = "추가";
                return;
            }
            BTN_HeroDel.Enabled = BTN_HeroFolder.Enabled = true;
            BTN_HeroAddMod.Text = "변경";
            TB_HeroName.Text = SelectedName;
        }
        private void HeroListBox_Update()
        {
            HeroListBox.Items.Clear();
            TB_HeroName.Text = string.Empty;
            TB_HeroName.Enabled = BTN_HeroAddMod.Enabled = BTN_HeroDel.Enabled = BTN_HeroFolder.Enabled = false;
            BTN_HeroAddMod.Text = "추가";
            if (RPGListBox.SelectedIndex == -1) return;
            string SelectedName = RPGListBox.SelectedItem.ToString();
            if (SelectedName != "(새로 만들기)")
            {
                HeroListBox.Items.Add("(새로 만들기)");
                foreach (string item in GetDirectoryList(saveFilePath.GetFullPath(SelectedName)))
                    HeroListBox.Items.Add(item);
            }
        }
        #region [    RPG Setting    ]
        private void BTN_RPGPath_Click(object sender, EventArgs e)
        {
            FolderBrowser FDialog = new FolderBrowser();
            FDialog.UseDescriptionForTitle = true;
            FDialog.Description = "세이브 파일이 저장되는 폴더를 선택하세요.";
            if (FDialog.ShowDialog() != DialogResult.OK) return;
            string DirectoryName = FDialog.SelectedPath;
            if (DirectoryName.IndexOf("CustomMapData") == -1)
            {
                MetroDialog.OK("올바르지 않은 경로", "올바른 경로가 아닌 것 같습니다.\nCustomMapData폴더가 경로에 포함되어 있어야 합니다.");
                return;
            }
            TB_RPGPath.Text = DirectoryName;
            TB_RPGEN.Text = Path.GetFileNameWithoutExtension(DirectoryName);
        }
        private void BTN_RPGAddMod_Click(object sender, EventArgs e)
        {
            int pathIndex;
            if ((pathIndex = TB_RPGPath.Text.IndexOf("CustomMapData")) == -1)
            {
                MetroDialog.OK("올바르지 않은 경로", "경로가 올바르지 않은 것같습니다.\n경로를 다시 확인해주세요.");
                return;
            }
            switch (BTN_RPGAddMod.Text)
            {
                case "추가":
                    saveFilePath.AddPath(TB_RPGPath.Text, TB_RPGEN.Text, TB_RPGKR.Text);
                    break;
                case "변경":
                    SavePath item = saveFilePath.GetSavePath(RPGListBox.SelectedItem.ToString());
                    item.nameEN = TB_RPGEN.Text;
                    item.nameKR = TB_RPGKR.Text;
                    item.path = TB_RPGPath.Text.Substring(pathIndex + 13);
                    break;
                default:
                    return;
            }
            saveFilePath.Save();
            ListUpdate(0);
            BTN_Refresh_Click(sender, e);
        }
        private void BTN_RPGDel_Click(object sender, EventArgs e)
        {
            if (RPGListBox.Items.Count <= 2)
            {
                MetroDialog.OK("제거 실패", "1개 이상의 항목이 남아 있어야 합니다.");
                return;
            }
            string name = RPGListBox.SelectedItem.ToString();
            if (!MetroDialog.YesNo("제거 여부 확인", $"리스트에서만 제거됩니다.\n정말 {IsKoreanBlock(name, "을", "를")} 제거하시겠습니까?")) return;
            saveFilePath.RemovePath(name);
            ListUpdate(0);
            BTN_Refresh_Click(sender, e);
        }
        private void BTN_RPGFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(saveFilePath.GetFullPath(RPGListBox.SelectedItem.ToString()));
        }
        private void BTN_RPGSetRegex_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region [    Hero Setting    ]
        private void TB_HeroName_TextChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            if (HeroListBox.SelectedIndex < 0)
            {
                BTN_HeroAddMod.Enabled = false;
                return;
            }
            BTN_HeroAddMod.Enabled = !GetDirectorySafeName(TB_HeroName.Text).Equals(HeroListBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        private void BTN_HeroAddMod_Click(object sender, EventArgs e)
        {
            TB_HeroName.Text = GetDirectorySafeName(TB_HeroName.Text);
            string RPG = saveFilePath.GetFullPath(RPGListBox.SelectedItem.ToString());
            if (Directory.Exists(RPG + @"\" + TB_HeroName.Text))
            {
                MetroDialog.OK("이미 존재하는 이름", $"{IsKoreanBlock(TB_HeroName.Text, "은", "는")} 이미 존재하는 이름입니다.\n다른 이름을 사용하시기 바랍니다.");
                return;
            }
            switch (BTN_HeroAddMod.Text)
            {
                case "추가":
                    Directory.CreateDirectory(saveFilePath.GetFullPath(RPGListBox.SelectedItem.ToString()) + @"\" + TB_HeroName.Text);
                    break;
                case "변경":
                    string Hero = HeroListBox.SelectedItem.ToString();
                    try
                    {
                        Directory.Move(RPG + @"\" + Hero, RPG + @"\" + TB_HeroName.Text);
                    }
                    catch
                    {
                        MetroDialog.OK("변경 실패", "다른 프로세서가 파일을 사용 중 이므로, 변경할 수 없습니다.");
                        return;
                    }
                    break;
                default:
                    return;
            }
            ListUpdate(1);
            HeroListBox_Update();
        }
        private void BTN_HeroDel_Click(object sender, EventArgs e)
        {
            if (HeroListBox.Items.Count <= 2)
            {
                MetroDialog.OK("삭제 실패", "1개 이상의 항목이 남아 있어야 합니다.");
                return;
            }
            string name = HeroListBox.SelectedItem.ToString();
            if (!MetroDialog.YesNo("제거 여부 확인", $"분류에 포함된 모든 세이브 파일이 삭제됩니다.\n정말 {IsKoreanBlock(name, "을", "를")} 삭제하시겠습니까?")) return;
            string path = saveFilePath.GetFullPath(RPGListBox.SelectedItem.ToString()) + @"\" + name;
            foreach (FileInfo file in new DirectoryInfo(path).GetFiles("*.*", SearchOption.AllDirectories))
                file.Attributes = FileAttributes.Normal;
            try
            {
                Directory.Delete(path, true);
            }
            catch
            {
                MetroDialog.OK("삭제 실패", "다른 프로세서가 파일을 사용 중 이므로, 삭제할 수 없습니다.");
                return;
            }
            ListUpdate(1);
            HeroListBox_Update();
        }
        private void BTN_HeroFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(saveFilePath.GetFullPath(RPGListBox.SelectedItem.ToString()) + @"\" + TB_HeroName.Text);
        }
        #endregion
        private void BTN_Refresh_Click(object sender, EventArgs e)
        {
            RPGListBox.Items.Clear();
            RPGListBox.Items.Add("(새로 만들기)");
            foreach (SavePath item in saveFilePath)
                RPGListBox.Items.Add(saveFilePath.ConvertName(item.nameEN));
            RPGListBox.SelectedIndex = -1;
            RPGListBox_SelectedIndexChanged(sender, e);
        }
        #endregion
        private void CB_AutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsAutoLoad = CB_AutoLoad.Checked;
        }
        private void NewMapSaveFileAutoSense_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsGrabitiSaveAutoAdd = CB_NewMapSaveFileAuto.Checked;
        }
        private void SavesReplayAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            ReplayWatcher.EnableRaisingEvents = CB_NoSavesReplaySave.Enabled = Settings.IsAutoReplay = CB_SavesReplayAutoSave.Checked;
        }
        private void NoSavesReplaySave_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.NoSavedReplaySave = CB_NoSavesReplaySave.Checked;
        }
        #region [    Command Preset Setting    ]
        private void TabControl_CommandPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.SelectedCommand = TabControl_CommandPreset.SelectedIndex + 1;
        }
        private void TB_CommandPreset1_TextChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.CommandPreset1 = TB_CommandPreset1.Text.Replace("\n\n", "\n").Replace("\r\n", "\n");
        }
        private void TB_CommandPreset2_TextChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.CommandPreset2 = TB_CommandPreset2.Text.Replace("\n\n", "\n").Replace("\r\n", "\n");
        }
        private void TB_CommandPreset3_TextChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.CommandPreset3 = TB_CommandPreset3.Text.Replace("\n\n", "\n").Replace("\r\n", "\n");
        }
        #endregion
        #endregion
        #region [    Macro Tab Setting    ]
        #region [    Smart Key Setting    ]
        private void Qbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.Q))
            {
                // 사용 안함
                Qbutton.BackgroundImage = Properties.Resources.Qbutton;
                SetSmartKey(Keys.Q, false);
            }
            else
            {
                if (hotkeyCheck(Keys.Q)) return;
                // 사용함
                Qbutton.BackgroundImage = Properties.Resources.Q1button;
                SetSmartKey(Keys.Q, true);
            }
        }
        private void Wbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.W))
            {
                // 사용 안함
                Wbutton.BackgroundImage = Properties.Resources.Wbutton;
                SetSmartKey(Keys.W, false);
            }
            else
            {
                if (hotkeyCheck(Keys.W)) return;
                // 사용함
                Wbutton.BackgroundImage = Properties.Resources.W1button;
                SetSmartKey(Keys.W, true);
            }
        }
        private void Ebutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.E))
            {
                // 사용 안함
                Ebutton.BackgroundImage = Properties.Resources.Ebutton;
                SetSmartKey(Keys.E, false);
            }
            else
            {
                if (hotkeyCheck(Keys.E)) return;
                // 사용함
                Ebutton.BackgroundImage = Properties.Resources.E1button;
                SetSmartKey(Keys.E, true);
            }
        }
        private void Rbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.R))
            {
                // 사용 안함
                Rbutton.BackgroundImage = Properties.Resources.Rbutton;
                SetSmartKey(Keys.R, false);
            }
            else
            {
                if (hotkeyCheck(Keys.R)) return;
                // 사용함
                Rbutton.BackgroundImage = Properties.Resources.R1button;
                SetSmartKey(Keys.R, true);
            }
        }
        private void Tbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.T))
            {
                // 사용 안함
                Tbutton.BackgroundImage = Properties.Resources.Tbutton;
                SetSmartKey(Keys.T, false);
            }
            else
            {
                if (hotkeyCheck(Keys.T)) return;
                // 사용함
                Tbutton.BackgroundImage = Properties.Resources.T1button;
                SetSmartKey(Keys.T, true);
            }
        }
        private void Abutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.A))
            {
                // 사용 안함
                Abutton.BackgroundImage = Properties.Resources.Abutton;
                SetSmartKey(Keys.A, false);
            }
            else
            {
                if (hotkeyCheck(Keys.A)) return;
                // 사용함
                Abutton.BackgroundImage = Properties.Resources.A1button;
                SetSmartKey(Keys.A, true);
            }
        }
        private void Dbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.D))
            {
                // 사용 안함
                Dbutton.BackgroundImage = Properties.Resources.Dbutton;
                SetSmartKey(Keys.D, false);
            }
            else
            {
                if (hotkeyCheck(Keys.D)) return;
                // 사용함
                Dbutton.BackgroundImage = Properties.Resources.D1button;
                SetSmartKey(Keys.D, true);
            }
        }
        private void Fbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.F))
            {
                // 사용 안함
                Fbutton.BackgroundImage = Properties.Resources.Fbutton;
                SetSmartKey(Keys.F, false);
            }
            else
            {
                if (hotkeyCheck(Keys.F)) return;
                // 사용함
                Fbutton.BackgroundImage = Properties.Resources.F1button;
                SetSmartKey(Keys.F, true);
            }
        }
        private void Gbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.G))
            {
                // 사용 안함
                Gbutton.BackgroundImage = Properties.Resources.Gbutton;
                SetSmartKey(Keys.G, false);
            }
            else
            {
                if (hotkeyCheck(Keys.G)) return;
                // 사용함
                Gbutton.BackgroundImage = Properties.Resources.G1button;
                SetSmartKey(Keys.G, true);
            }
        }
        private void Zbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.Z))
            {
                // 사용 안함
                Zbutton.BackgroundImage = Properties.Resources.Zbutton;
                SetSmartKey(Keys.Z, false);
            }
            else
            {
                if (hotkeyCheck(Keys.Z)) return;
                // 사용함
                Zbutton.BackgroundImage = Properties.Resources.Z1button;
                SetSmartKey(Keys.Z, true);
            }
        }
        private void Xbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.X))
            {
                // 사용 안함
                Xbutton.BackgroundImage = Properties.Resources.Xbutton;
                SetSmartKey(Keys.X, false);
            }
            else
            {
                if (hotkeyCheck(Keys.X)) return;
                // 사용함
                Xbutton.BackgroundImage = Properties.Resources.X1button;
                SetSmartKey(Keys.X, true);
            }
        }
        private void Cbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.C))
            {
                // 사용 안함
                Cbutton.BackgroundImage = Properties.Resources.Cbutton;
                SetSmartKey(Keys.C, false);
            }
            else
            {
                if (hotkeyCheck(Keys.C)) return;
                // 사용함
                Cbutton.BackgroundImage = Properties.Resources.C1button;
                SetSmartKey(Keys.C, true);
            }
        }
        private void Vbutton_Click(object sender, EventArgs e)
        {
            if (isSmartKey(Keys.V))
            {
                // 사용 안함
                Vbutton.BackgroundImage = Properties.Resources.Vbutton;
                SetSmartKey(Keys.V, false);
            }
            else
            {
                if (hotkeyCheck(Keys.V)) return;
                // 사용함
                Vbutton.BackgroundImage = Properties.Resources.V1button;
                SetSmartKey(Keys.V, true);
            }
        }
        private void RB_Prev_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SmartKeyPreventionType = SmartKeyPreventionType;
        }
        private int SmartKeyPreventionType {
            get {
                if (RB_Prev2.Checked) return 1;
                if (RB_Prev3.Checked) return 2;
                if (RB_Prev4.Checked) return 3;
                return 0;
            }
            set {
                switch (value)
                {
                    case 0:
                        RB_Prev1.Checked = true;
                        RB_Prev2.Checked =
                        RB_Prev3.Checked =
                        RB_Prev4.Checked = false;
                        break;
                    case 1:
                        RB_Prev2.Checked = true;
                        RB_Prev1.Checked =
                        RB_Prev3.Checked =
                        RB_Prev4.Checked = false;
                        break;
                    case 2:
                        RB_Prev3.Checked = true;
                        RB_Prev1.Checked =
                        RB_Prev2.Checked =
                        RB_Prev4.Checked = false;
                        break;
                    case 3:
                        RB_Prev4.Checked = true;
                        RB_Prev1.Checked =
                        RB_Prev2.Checked =
                        RB_Prev3.Checked = false;
                        break;
                }
            }
        }
        private bool hotkeyCheck(Keys key)
        {
            if (hotkeyList.IsRegistered(key) && !isKeyReMapped(key))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                return true;
            }
            return false;
        }
        #endregion
        #region [    Key Remapping Setting    ]
        private void Key7_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key7.Text)
            {
                case "7":
                    Key7.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key7;
                    break;
                case "...":
                    Key7.Text = "7";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap7)) break;
                    Key7.Text = "7";
                    Key7Text.Text = "키패드7";
                    UnRegisterReMappedKey(Keys.NumPad7);
                    Settings.KeyMap7 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Key8_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key8.Text)
            {
                case "8":
                    Key8.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key8;
                    break;
                case "...":
                    Key8.Text = "8";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap8)) break;
                    Key8.Text = "8";
                    Key8Text.Text = "키패드8";
                    UnRegisterReMappedKey(Keys.NumPad8);
                    Settings.KeyMap8 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Key4_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key4.Text)
            {
                case "4":
                    Key4.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key4;
                    break;
                case "...":
                    Key4.Text = "4";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap4)) break;
                    Key4.Text = "4";
                    Key4Text.Text = "키패드4";
                    UnRegisterReMappedKey(Keys.NumPad4);
                    Settings.KeyMap4 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Key5_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key5.Text)
            {
                case "5":
                    Key5.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key5;
                    break;
                case "...":
                    Key5.Text = "5";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap5)) break;
                    Key5.Text = "5";
                    Key5Text.Text = "키패드5";
                    UnRegisterReMappedKey(Keys.NumPad5);
                    Settings.KeyMap5 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Key1_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key1.Text)
            {
                case "1":
                    Key1.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key1;
                    break;
                case "...":
                    Key1.Text = "1";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap1)) break;
                    Key1.Text = "1";
                    Key1Text.Text = "키패드1";
                    UnRegisterReMappedKey(Keys.NumPad1);
                    Settings.KeyMap1 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Key2_Click(object sender, EventArgs e)
        {
            KeyReMapDefault();
            switch (Key2.Text)
            {
                case "2":
                    Key2.Text = "...";
                    IsRemapKeyInput = true;
                    TargetKey = SelectedKeypadType.Key2;
                    break;
                case "...":
                    Key2.Text = "2";
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
                case "X":
                    if (isRemappedSmartkey((Keys)Settings.KeyMap2)) break;
                    Key2.Text = "2";
                    Key2Text.Text = "키패드2";
                    UnRegisterReMappedKey(Keys.NumPad2);
                    Settings.KeyMap2 = 0;
                    IsRemapKeyInput = false;
                    TargetKey = SelectedKeypadType.None;
                    break;
            }
        }
        private void Toggle_KeyRemapping_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            KeyReMapDefault();
            if (Toggle_KeyRemapping.Checked
             &&(hotkeyList.IsRegistered((Keys)Settings.KeyMap7)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap8)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap4)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap5)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap1)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap2)))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n스마트키나 키리맵핑, 채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                IsUpdating = true;
                Toggle_KeyRemapping.Checked = false;
                IsUpdating = false;
                return;
            }
            Settings.IsKeyRemapped = Toggle_KeyRemapping.Checked;
            if (Toggle_KeyRemapping.Checked)
            {
                if (Settings.KeyMap7 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap7, KeyRemapping, Keys.NumPad7);
                if (Settings.KeyMap8 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap8, KeyRemapping, Keys.NumPad8);
                if (Settings.KeyMap4 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap4, KeyRemapping, Keys.NumPad4);
                if (Settings.KeyMap5 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap5, KeyRemapping, Keys.NumPad5);
                if (Settings.KeyMap1 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap1, KeyRemapping, Keys.NumPad1);
                if (Settings.KeyMap2 != 0)
                    hotkeyList.Register((Keys)Settings.KeyMap2, KeyRemapping, Keys.NumPad2);
            }
            else
            {
                if (Settings.KeyMap7 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap7);
                if (Settings.KeyMap8 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap8);
                if (Settings.KeyMap4 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap4);
                if (Settings.KeyMap5 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap5);
                if (Settings.KeyMap1 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap1);
                if (Settings.KeyMap2 != 0)
                    hotkeyList.UnRegister((Keys)Settings.KeyMap2);
            }
        }
        private void KeyReMapDefault()
        {
            if (!IsRemapKeyInput) return;
            switch (TargetKey)
            {
                case SelectedKeypadType.Key7:
                    Key7.Text = "7";
                    Settings.KeyMap7 = 0;
                    break;
                case SelectedKeypadType.Key8:
                    Key8.Text = "8";
                    Settings.KeyMap8 = 0;
                    break;
                case SelectedKeypadType.Key4:
                    Key4.Text = "4";
                    Settings.KeyMap4 = 0;
                    break;
                case SelectedKeypadType.Key5:
                    Key5.Text = "5";
                    Settings.KeyMap5 = 0;
                    break;
                case SelectedKeypadType.Key1:
                    Key1.Text = "1";
                    Settings.KeyMap1 = 0;
                    break;
                case SelectedKeypadType.Key2:
                    Key2.Text = "2";
                    Settings.KeyMap2 = 0;
                    break;
            }
            TargetKey = SelectedKeypadType.None;
            IsRemapKeyInput = false;
        }
        private bool isRemappedSmartkey(Keys key)
        {
            if (isSmartKey(key))
            {
                MetroDialog.OK("이미 교차 활성화된 단축키", "해당 키는 스마트키가 활성화되어 있습니다.\n스마트키를 먼저 해제해주시기 바랍니다.");
                return true;
            }
            return false;
        }
        private void KeyReMapping_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!IsRemapKeyInput) return;
            Keys key, hotkey = e.KeyCode;
            string KeyText = GetHotkeyString(hotkey);
            foreach (string item in new string[] { "Control", "Alt", "Shift", "Menu" })
                if (KeyText.IndexOf(item) != -1)
                    return;

            if (hotkeyList.IsRegistered(hotkey)
             || isKeyReMapped(hotkey))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n스마트키나 키리맵핑, 채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                KeyReMapDefault();
                return;
            }
            GB_KeyReMap.Focus();
            switch (TargetKey)
            {
                case SelectedKeypadType.Key7:
                    key = Keys.NumPad7;
                    Settings.KeyMap7 = (int)hotkey;
                    Key7Text.Text = KeyText;
                    Key7.Text = "X";
                    break;
                case SelectedKeypadType.Key8:
                    key = Keys.NumPad8;
                    Settings.KeyMap8 = (int)hotkey;
                    Key8Text.Text = KeyText;
                    Key8.Text = "X";
                    break;
                case SelectedKeypadType.Key4:
                    key = Keys.NumPad4;
                    Settings.KeyMap4 = (int)hotkey;
                    Key4Text.Text = KeyText;
                    Key4.Text = "X";
                    break;
                case SelectedKeypadType.Key5:
                    key = Keys.NumPad5;
                    Settings.KeyMap5 = (int)hotkey;
                    Key5Text.Text = KeyText;
                    Key5.Text = "X";
                    break;
                case SelectedKeypadType.Key1:
                    key = Keys.NumPad1;
                    Settings.KeyMap1 = (int)hotkey;
                    Key1Text.Text = KeyText;
                    Key1.Text = "X";
                    break;
                case SelectedKeypadType.Key2:
                    key = Keys.NumPad2;
                    Settings.KeyMap2 = (int)hotkey;
                    Key2Text.Text = KeyText;
                    Key2.Text = "X";
                    break;
                default:
                    TargetKey = SelectedKeypadType.None;
                    IsRemapKeyInput = false;
                    return;
            }
            if (Toggle_KeyRemapping.Checked) RegisterReMappedKey(hotkey, key);
            TargetKey = SelectedKeypadType.None;
            IsRemapKeyInput = false;
        }
        private void KeyReMap_Leave(object sender, EventArgs e)
        {
            KeyReMapDefault();
        }
        #endregion
        #region [    Text Macro Setting    ]
        private void RB_Chat_SetCurrentFont(int type, bool state)
        {
            switch (CurrentChatIndex)
            {
                case 0:
                    switch (type)
                    {
                        case 0:
                            RB_Chat1.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat1.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 1:
                    switch (type)
                    {
                        case 0:
                            RB_Chat2.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat2.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 2:
                    switch (type)
                    {
                        case 0:
                            RB_Chat3.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat3.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 3:
                    switch (type)
                    {
                        case 0:
                            RB_Chat4.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat4.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 4:
                    switch (type)
                    {
                        case 0:
                            RB_Chat5.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat5.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 5:
                    switch (type)
                    {
                        case 0:
                            RB_Chat6.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat6.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 6:
                    switch (type)
                    {
                        case 0:
                            RB_Chat7.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat7.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 7:
                    switch (type)
                    {
                        case 0:
                            RB_Chat8.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat8.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 8:
                    switch (type)
                    {
                        case 0:
                            RB_Chat9.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat9.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
                case 9:
                    switch (type)
                    {
                        case 0:
                            RB_Chat0.Font = state ? new Font("맑은 고딕", 9F, FontStyle.Bold) : new Font("맑은 고딕", 9F);
                            return;
                        case 1:
                            RB_Chat0.ForeColor = state ? Color.Red : SystemColors.ControlText;
                            return;
                    }
                    return;
            }
        }
        private void RB_Chat_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Chat1.Checked) CurrentChatIndex = 0;
            else if (RB_Chat2.Checked) CurrentChatIndex = 1;
            else if (RB_Chat3.Checked) CurrentChatIndex = 2;
            else if (RB_Chat4.Checked) CurrentChatIndex = 3;
            else if (RB_Chat5.Checked) CurrentChatIndex = 4;
            else if (RB_Chat6.Checked) CurrentChatIndex = 5;
            else if (RB_Chat7.Checked) CurrentChatIndex = 6;
            else if (RB_Chat8.Checked) CurrentChatIndex = 7;
            else if (RB_Chat9.Checked) CurrentChatIndex = 8;
            else if (RB_Chat0.Checked) CurrentChatIndex = 9;
            IsUpdating = true;
            TB_ChatMacro.Text = chatHotkeyList[CurrentChatIndex].ChatMessage;
            Label_ChatHotkey.Text = GetHotkeyString(chatHotkeyList[CurrentChatIndex].Hotkey);
            BTN_SetChatHotkey.Text = chatHotkeyList.IsKeyRegisted(CurrentChatIndex) ? "단축키 해제" : "단축키 지정";
            Toggle_ChatMacro.Checked = chatHotkeyList[CurrentChatIndex].IsRegisted;
            IsUpdating = false;
        }
        private void BTN_SetChatHotkey_Click(object sender, EventArgs e)
        {
            switch (BTN_SetChatHotkey.Text)
            {
                case "단축키 지정":
                    BTN_SetChatHotkey.Text = "...";
                    IsChatHotkeyInput = true;
                    break;
                case "...":
                    BTN_SetChatHotkey.Text = "단축키 지정";
                    IsChatHotkeyInput = false;
                    break;
                case "단축키 해제":
                    if (chatHotkeyList[CurrentChatIndex].IsRegisted)
                    {
                        IsUpdating = true;
                        Toggle_ChatMacro.Checked = false;
                        chatHotkeyList.UnRegister(CurrentChatIndex);
                        RB_Chat_SetCurrentFont(1, false);
                        IsUpdating = false;
                    }
                    BTN_SetChatHotkey.Text = "단축키 지정";
                    Label_ChatHotkey.Text = "없음";
                    chatHotkeyList[CurrentChatIndex].Hotkey = 0;
                    IsChatHotkeyInput = false;
                    RB_Chat_SetCurrentFont(0, false);
                    chatHotkeyList.Save();
                    break;
            }
        }
        private void TB_ChatMacro_TextChanged(object sender, EventArgs e)
        {
            chatHotkeyList[CurrentChatIndex].ChatMessage = TB_ChatMacro.Text;
            chatHotkeyList.Save();
        }
        private void BTN_SetChatHotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!IsChatHotkeyInput) return;
            Keys hotkey = e.KeyCode;
            string KeyText = GetHotkeyString(hotkey);
            foreach (string item in new string[] { "Control", "Alt", "Shift", "Menu" })
                if (KeyText.IndexOf(item) != -1)
                    return;
            if (hotkeyList.IsRegistered(hotkey)
             || isKeyReMapped(hotkey))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n스마트키나 키리맵핑, 채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                BTN_SetChatHotkey.Text = "단축키 지정";
                Label_ChatHotkey.Text = "없음";
                chatHotkeyList[CurrentChatIndex].Hotkey = 0;
                IsChatHotkeyInput = false;
                return;
            }
            GB_ChatMacro.Focus();
            chatHotkeyList[CurrentChatIndex].Hotkey = hotkey;
            Label_ChatHotkey.Text = KeyText;
            BTN_SetChatHotkey.Text = "단축키 해제";
            RB_Chat_SetCurrentFont(0, true);
        }
        private void BTN_SetChatHotkey_Leave(object sender, EventArgs e)
        {
            if (!IsChatHotkeyInput) return;
            BTN_SetChatHotkey.Text = "단축키 지정";
            Label_ChatHotkey.Text = "없음";
            IsChatHotkeyInput = false;
        }
        private void Toggle_ChatMacro_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            if (!chatHotkeyList.IsKeyRegisted(CurrentChatIndex))
            {
                MetroDialog.OK("단축키가 지정되지 않음", "단축키가 설정되어 있지 않습니다.\n우선, 단축키를 지정해주시기 바랍니다.");
                goto UnCheck;
            }
            if (!Toggle_ChatMacro.Checked)
            {
                chatHotkeyList.UnRegister(CurrentChatIndex);
                RB_Chat_SetCurrentFont(1, false);
                chatHotkeyList.Save();
                return;
            }
            if (hotkeyList.IsRegistered(chatHotkeyList[CurrentChatIndex].Hotkey))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n스마트키나 키리맵핑, 채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                goto UnCheck;
            }
            chatHotkeyList.Register(CurrentChatIndex);
            RB_Chat_SetCurrentFont(1, true);
            chatHotkeyList.Save();
            return;
        UnCheck:
            IsUpdating = true;
            Toggle_ChatMacro.Checked = false;
            IsUpdating = false;
        }
        #endregion
        #region [    Auto Mouse Setting    ]
        private void Toggle_AutoMouse_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            if ((AutoMouse.LeftStartKey != 0
             || AutoMouse.RightStartKey != 0)
             && AutoMouse.EndKey != 0)
            {
                AutoMouse.Enabled = Toggle_AutoMouse.Checked;
                return;
            }
            MetroDialog.OK("미지정 단축키 발견", "지정되지 않은 단축키가 있습니다.\n최소한 한쪽 시작 단축키는 지정해주세요.");
            IsUpdating = true;
            Toggle_AutoMouse.Checked = false;
            IsUpdating = false;
        }
        private void BTN_AutoLeftMouseOn_Click(object sender, EventArgs e)
        {
            if (AutoMouse.Enabled && AutoMouse.RightStartKey == 0)
                AutoMouse.Enabled = Toggle_AutoMouse.Checked = false;
            if (IsAutoMouseInput || AutoMouse.LeftStartKey != 0)
            {
                Label_AutoLeftMouseOn.Text = "없음";
                BTN_AutoLeftMouseOn.Text = "좌클";
                AutoMouse.LeftStartKey = 0;
                return;
            }
            TargetMouse = SelectedAutoMouseType.Left;
            IsAutoMouseInput = true;
            BTN_AutoLeftMouseOn.Text = "...";
        }
        private void BTN_AutoRightMouseOn_Click(object sender, EventArgs e)
        {
            if (AutoMouse.Enabled && AutoMouse.LeftStartKey == 0)
                AutoMouse.Enabled = Toggle_AutoMouse.Checked = false;
            if (IsAutoMouseInput || AutoMouse.RightStartKey != 0)
            {
                Label_AutoRightMouseOn.Text = "없음";
                BTN_AutoRightMouseOn.Text = "우클";
                AutoMouse.RightStartKey = 0;
                return;
            }
            TargetMouse = SelectedAutoMouseType.Right;
            IsAutoMouseInput = true;
            BTN_AutoRightMouseOn.Text = "...";
        }
        private void BTN_AutoMouseOff_Click(object sender, EventArgs e)
        {
            if (AutoMouse.Enabled)
                AutoMouse.Enabled = Toggle_AutoMouse.Checked = false;
            if (IsAutoMouseInput || AutoMouse.EndKey != 0)
            {
                Label_AutoMouseOff.Text = "없음";
                BTN_AutoMouseOff.Text = "종료";
                AutoMouse.EndKey = 0;
                return;
            }
            TargetMouse = SelectedAutoMouseType.Off;
            IsAutoMouseInput = true;
            BTN_AutoMouseOff.Text = "...";
        }
        private void TrB_AutoMouseDelay_ValueChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Label_AutoMouseDelay.Text = $"{TrB_AutoMouseDelay.Value} ms";
            AutoMouse.Interval = TrB_AutoMouseDelay.Value;
        }
        private void AutoMouse_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!IsAutoMouseInput) return;
            Keys hotkey = e.KeyCode;
            string KeyText = GetHotkeyString(hotkey);
            foreach (string item in new string[] { "Control", "Alt", "Shift", "Menu" })
                if (KeyText.IndexOf(item) != -1)
                    return;
            if (hotkeyList.IsRegistered(hotkey) || isKeyReMapped(hotkey) || AutoMouse.IsRegistered(hotkey))
            {
                MetroDialog.OK("이미 등록된 단축키", "해당 키가 이미 단축키로 등록되어 있습니다.\n스마트키나 키리맵핑, 채팅 단축키에서 먼저 해제해주시기 바랍니다.");
                switch (TargetMouse)
                {
                    case SelectedAutoMouseType.Off:
                        Label_AutoMouseOff.Text = "없음";
                        BTN_AutoMouseOff.Text = "종료";
                        AutoMouse.EndKey = 0;
                        break;
                    case SelectedAutoMouseType.Left:
                        Label_AutoLeftMouseOn.Text = "없음";
                        BTN_AutoLeftMouseOn.Text = "좌클";
                        AutoMouse.LeftStartKey = 0;
                        break;
                    case SelectedAutoMouseType.Right:
                        Label_AutoRightMouseOn.Text = "없음";
                        BTN_AutoRightMouseOn.Text = "우클";
                        AutoMouse.RightStartKey = 0;
                        break;
                }
            }
            else
            {
                GB_AutoMouse.Focus();
                switch (TargetMouse)
                {
                    case SelectedAutoMouseType.Off:
                        Label_AutoMouseOff.Text = KeyText;
                        BTN_AutoMouseOff.Text = "해제";
                        AutoMouse.EndKey = hotkey;
                        break;
                    case SelectedAutoMouseType.Left:
                        Label_AutoLeftMouseOn.Text = KeyText;
                        BTN_AutoLeftMouseOn.Text = "해제";
                        AutoMouse.LeftStartKey = hotkey;
                        break;
                    case SelectedAutoMouseType.Right:
                        Label_AutoRightMouseOn.Text = KeyText;
                        BTN_AutoRightMouseOn.Text = "해제";
                        AutoMouse.RightStartKey = hotkey;
                        break;
                }
            }
            IsAutoMouseInput = false;
        }
        private void BTN_AutoMouse_Leave(object sender, EventArgs e)
        {
            if (!IsAutoMouseInput) return;
            switch (TargetMouse)
            {
                case SelectedAutoMouseType.Off:
                    Label_AutoMouseOff.Text = "없음";
                    BTN_AutoMouseOff.Text = "종료";
                    AutoMouse.EndKey = 0;
                    break;
                case SelectedAutoMouseType.Left:
                    Label_AutoLeftMouseOn.Text = "없음";
                    BTN_AutoLeftMouseOn.Text = "좌클";
                    AutoMouse.LeftStartKey = 0;
                    break;
                case SelectedAutoMouseType.Right:
                    Label_AutoRightMouseOn.Text = "없음";
                    BTN_AutoRightMouseOn.Text = "우클";
                    AutoMouse.RightStartKey = 0;
                    break;
            }
            IsAutoMouseInput = false;
        }
        #endregion
        #endregion
        private void CommandListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = CommandListBox.SelectedItem.ToString();
            switch (value)
            {
                case "dr":
                    Label_CommandTitle.Text = "반응 지연시간 설정";
                    Label_CommandKR.Text = "ㅇㄱ";
                    Label_ParameterValue.Text = "0 ~ 550";
                    TB_CommandDescription.Text = "워크래프트의 컨트롤 지연시간을 설정합니다.\r\n다른 툴과 다르게, 워크래프트와 프로그램 동시 실행시에 자동으로 지정된 수치로 적용됩니다.\r\n일반적으로 15~45의 수치가 가장 보편적으로 사용됩니다.\n일부 맵에서 시작 한정으로 550의 수치를 사용하나, Cirnix의 경우, 자동으로 해당 기능이 적용되므로 사용할 필요가 없습니다.";
                    break;
                case "ss":
                    Label_CommandTitle.Text = "시작 대기시간 설정";
                    Label_CommandKR.Text = "ㄴㄴ";
                    Label_ParameterValue.Text = "0 ~ 6";
                    TB_CommandDescription.Text = "대기실에서 게임 시작을 누를시 발생하는 대기시간을 조정합니다.\r\n다른 툴과 다르게, 워크래프트와 프로그램 동시 실행시에 자동으로 지정된 수치로 적용됩니다.";
                    break;
                case "rg":
                    Label_CommandTitle.Text = "자동 대기실 새로고침";
                    Label_CommandKR.Text = "ㄱㅎ";
                    Label_ParameterValue.Text = "(선택) 1 ~ 2147483647";
                    TB_CommandDescription.Text = "서버에서 지원하는 /rg 명령어를 11초 간격으로 자동으로 입력해줍니다.\r\n매개변수를 입력하지 않을 시, 횟수 제한없이 동작하며, 다시 입력시, 작동을 중지합니다.\r\n다른 툴과 다르게, 게임이 시작될 경우에 한해서, 자동으로 해당 기능이 중지됩니다.";
                    break;
                case "set":
                    Label_CommandTitle.Text = "세이브 분류 선택";
                    Label_CommandKR.Text = "ㄴㄷㅅ";
                    Label_ParameterValue.Text = "분류 이름";
                    TB_CommandDescription.Text = "세이브 분류를 지정합니다.\r\n입력한 분류가 존재하지 않을 경우, 즉시 해당 분류를 생성 후 지정합니다.";
                    break;
                case "lc":
                    Label_CommandTitle.Text = "세이브 코드 로드";
                    Label_CommandKR.Text = "ㅣㅊ";
                    Label_ParameterValue.Text = "(선택) 분류 이름";
                    TB_CommandDescription.Text = "현재 지정된 세이브를 즉시 로드합니다.\r\nGrabiti's RPG Creator로 제작된 맵만 지원하며, 로드 직후 설정된 명령어 프리셋을 입력합니다.\r\n분류 이름을 입력할 경우, 해당 분류의 최신 세이브를 로드하며, 현재 로드 지정 대상도 즉시 변경합니다.";
                    break;
                case "tlc":
                    Label_CommandTitle.Text = "TWR세이브 코드 로드";
                    Label_CommandKR.Text = "싳";
                    Label_ParameterValue.Text = "(선택) 분류 이름";
                    TB_CommandDescription.Text = "현재 지정된 세이브를 즉시 로드합니다.\r\nTWRPG맵만 지원하며, 로드 직후 설정된 명령어 프리셋을 입력합니다.\r\n분류 이름을 입력할 경우, 해당 분류의 최신 세이브를 로드하며, 현재 로드 지정 대상도 즉시 변경합니다.";
                    break;
                case "olc":
                    Label_CommandTitle.Text = "원피스 랜던 디펜스 세이브 코드 로드";
                    Label_CommandKR.Text = "ㅐㅣㅊ";
                    Label_ParameterValue.Text = "(선택) 분류 이름";
                    TB_CommandDescription.Text = "현재 지정된 세이브를 즉시 로드합니다.\r\n원피스 랜덤 디펜스맵만 지원하며, 로드 직후 설정된 명령어 프리셋을 입력합니다.\r\n분류 이름을 입력할 경우, 해당 분류의 최신 세이브를 로드하며, 현재 로드 지정 대상도 즉시 변경합니다.";
                    break;
                case "cmd":
                    Label_CommandTitle.Text = "명령어 프리셋 로드";
                    Label_CommandKR.Text = "층";
                    Label_ParameterValue.Text = "1 ~ 3";
                    TB_CommandDescription.Text = "지정된 명령어 프리셋을 입력하여 줍니다.";
                    break;
                case "cam":
                    Label_CommandTitle.Text = "카메라 시야 거리 설정";
                    Label_CommandKR.Text = "시야";
                    Label_ParameterValue.Text = "0 ~ 6000";
                    TB_CommandDescription.Text = "카메라의 시야를 조절합니다.\r\n워크래프트의 기본 시야는 1650이며, 일반적인 RPG맵의 '-시야 100'은 1700, '-시야 150'은 2550의 시야를 가집니다.\r\n추천 시야 거리는 3550가량이며, 권장 최대 시야는 4050입니다.";
                    break;
                case "camy":
                    Label_CommandTitle.Text = "카메라 Y축 각도 설정";
                    Label_CommandKR.Text = "ㅊ므ㅛ";
                    Label_ParameterValue.Text = "0 ~ 360";
                    TB_CommandDescription.Text = "카메라의 수직 각도를 조절합니다.\r\n워크래프트의 기본 수직 각도는 304이며, 화면을 수직으로 내려보는 각도는 270입니다.\r\n수치가 크면 클수록 아래로 내려가며, 낮으면 낮을수록 위로 올라갑니다.";
                    break;
                case "camx":
                    Label_CommandTitle.Text = "카메라 X축 각도 설정";
                    Label_CommandKR.Text = "ㅊ믙";
                    Label_ParameterValue.Text = "0 ~ 360";
                    TB_CommandDescription.Text = "카메라의 수평 각도를 조절합니다.\r\n워크래프트의 기본 수평 각도는 90이며, 수치가 크면 클수록 우측으로 회전하고, 낮으면 낮을수록 좌측으로 회전합니다.";
                    break;
                case "hp":
                    Label_CommandTitle.Text = "최대 체력수치 제거";
                    Label_CommandKR.Text = "ㅗㅔ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "상태 창에 표기되는 최대 체력수치를 제거하여 체력수치가 사라지는 증상을 완화합니다.\r\n사용 시, 현재 체력의 수치만 확인할 수 있으며, 다시 입력시, 해당 기능을 사용하지 않습니다.";
                    break;
                case "dice":
                    Label_CommandTitle.Text = "주사위 굴리기";
                    Label_CommandKR.Text = "주사위";
                    Label_ParameterValue.Text = "(선택) 0 ~ 2147483646";
                    TB_CommandDescription.Text = "매개변수를 최대값으로 랜덤한 정수를 출력합니다.\r\n매개변수를 입력하지 않을 시, 최대값이 100으로 설정됩니다.";
                    break;
                case "mo":
                    Label_CommandTitle.Text = "메모리 최적화";
                    Label_CommandKR.Text = "ㅡㅐ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "워크래프트가 사용 중인 메모리를 최적화합니다.\r\n메모리를 최적화함으로써, 페이탈로 인한 워크래프트 강제 종료 현상을 최소화 할 수 있지만, 컴퓨터 사양이 낮은 유저의 경우, 인 게임 최적화를 사용시에 잔렉이 발생할 수 있습니다.\r\n명령어 사용 직후, 5초간 메모리의 변화량을 체크하여 알려줍니다.";
                    break;
                case "chk":
                    Label_CommandTitle.Text = "치트맵 판독";
                    Label_CommandKR.Text = "체크";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "프로그램에 사전에 등록된 구문을 이용하여, 해당 맵에 치트셋이 삽입되어 있는지 확인합니다.\r\n현재 지원하는 치트셋은 '갯힝', '소울상디' 치트셋이며, 제보해주시는대로 추가 지원도 고려하고 있습니다.";
                    break;
                case "rework":
                    Label_CommandTitle.Text = "리워크";
                    Label_CommandKR.Text = "ㄱㄷ재가";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "워크래프트의 리워크 기능입니다.";
                    break;
                case "j":
                    Label_CommandTitle.Text = "방 입장";
                    Label_CommandKR.Text = "ㅓ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "워크래프트의 지정된 방으로 입장합니다.";
                    break;
                case "c":
                    Label_CommandTitle.Text = "방 생성";
                    Label_CommandKR.Text = "ㅊ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "워크래프트의 방을 생성합니다.\r\n 생성할때 이전에 만들었던 방의 맵으로 생성됩니다.";
                    break;
                case "wa":
                    Label_CommandTitle.Text = "밴 리스트";
                    Label_CommandKR.Text = "ㅈㅁ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "밴리스트에 저장된 IP 및 ID를 방에 접속된 인원의\r\n IP 및 ID와 매칭하여 조건에 맞을 경우 출력합니다.\r\n\r\nID 및 IP의 일부를 입력해주세요. \r\n\r\n1.2를 입력할 경우 1.2.3.4 IP를 검색합니다.\r\n1.2.3.4를 입력할 경우 무조건 같은 IP를 검색합니다.";
                    break;
                case "va":
                    Label_CommandTitle.Text = "IP 매칭";
                    Label_CommandKR.Text = "ㅍㅁ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "방에 접속된 인원의 IP 및 ID를 출력합니다.";
                    break;
                case "max":
                    Label_CommandTitle.Text = "방 유저 카운트 알람(MAX)";
                    Label_CommandKR.Text = "ㅡㅁㅌ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "방의 유저 설정된 수 이상이되면 알립니다.\r\n\r\n 한번더 !max 명령어를 입력하면 중단합니다.";
                    break;
                case "min":
                    Label_CommandTitle.Text = "방 유저 카운트 알람(MIN)";
                    Label_CommandKR.Text = "ㅡㅑㅜ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "방의 유저 설정된 수 이하가되면 알립니다.\r\n\r\n 한번더 !min 명령어를 입력하면 중단합니다.";
                    break;
                case "as":
                    Label_CommandTitle.Text = "자동시작";
                    Label_CommandKR.Text = "ㅁㄴ";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "지정 이상의 인원이되면 10초 후 자동으로 시작합니다.\r\n\r\n 한번더 !as 명령어를 입력하면 중단합니다.\r\n이미 10초 카운트다운을 하고있다면 중단이 불가능합니다.";
                    break;
                case "exit":
                    Label_CommandTitle.Text = "워크래프트 종료";
                    Label_CommandKR.Text = "종료";
                    Label_ParameterValue.Text = "없음";
                    TB_CommandDescription.Text = "워크래프트를 종료합니다.";
                    break;
                default:
                    return;
            }
            Label_CommandEN.Text = value;
        }


        private void Banlistload()
        {
            List<BanlistModel> list = SaveBanlistUsers.Load();
            if (list == null)
            {
                return;
            }
            banlistview.Items.Clear();
            Memory.BanList.Clear();
            try
            {
                banlistview.BeginUpdate();
                foreach (BanlistModel banlistModel in list)
                {
                    string[] row = { banlistModel.ID, banlistModel.IP, banlistModel.Reason };
                    ListViewItem newitem = new ListViewItem(row) { Tag = banlistModel };
                    banlistview.Items.Add(newitem);
                    Memory.BanList.Add(banlistModel);
                }
            }
            finally
            {
                banlistview.EndUpdate();
            }
        }

        private void AddSave(BanlistModel data)
        {
            List<BanlistModel> list = new List<BanlistModel>();
            foreach (object obj in banlistview.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                list.Add((BanlistModel)listViewItem.Tag);
            }
            list.Add(data);
            SaveBanlistUsers.Save(list);
            Banlistload();
        }

        private void DelSave(BanlistModel data)
        {
            List<BanlistModel> list = new List<BanlistModel>();
            foreach (object obj in banlistview.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                list.Add((BanlistModel)listViewItem.Tag);
            }
            list.Remove(data);
            SaveBanlistUsers.Save(list);
            Banlistload();
        }

        private async void BTN_HotKeyDebug_Click(object sender, EventArgs e)
        {
            KeyboardHooker.HookEnd();
            await Task.Delay(1);
            KeyboardHooker.HookStart();
            MetroDialog.OK("후킹 재설정 완료", "단축키 후킹 상태를 재설정하였습니다.");
        }

        private void Toggle_AutoFrequency_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.IsAutoFrequency = Toggle_AutoFrequency.Checked;
            Number_ChatFrequency.Enabled = BTN_DetectFrequency.Enabled = !Toggle_AutoFrequency.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BanlistModel banlistModel = new BanlistModel();
            banlistModel.ID = IdTextBox.Text;
            banlistModel.IP = IPTextBox.Text;
            banlistModel.Reason = ReasonTextBox.Text;
            IdTextBox.Text = "";
            IPTextBox.Text = "";
            ReasonTextBox.Text = "";
            this.AddSave(banlistModel);
            Banlistload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (banlistview.SelectedItems.Count <= 0) return;
            this.DelSave((BanlistModel)this.banlistview.SelectedItems[0].Tag);
        }

        private void Number_ChatFrequency_ValueChanged(object sender, EventArgs e)
        {
            if (IsUpdating) return;
            Settings.ChatFrequency = Convert.ToInt32(Number_ChatFrequency.Value) - 1;
        }
        private async void BTN_DetectFrequency_Click(object sender, EventArgs e)
        {
            await Memory.Message.DetectChatFrequency();
            IsUpdating = true;
            Number_ChatFrequency.Value = Settings.ChatFrequency + 1;
            IsUpdating = false;
        }
        private void RB_Help_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Help1.Checked)
            {
                TB_Help.Text = "호스트 플레이어가 설정시에 효과를 보는 설정입니다.\r\n\r\n반응 지연시간: 플레이어가 어떠한 행동을 했을 경우에 발생하는 지연시간을 의미합니다. 지연시간이 낮으면 낮을수록 반응속도가 빨라지는 효과가 있습니다.\r\n\r\n시작 대기시간: 게임 시작을 누를시에 발생하는 대기시간을 의미합니다. 대기시간은 사용자가 원하는대로 설정할 수 있으나, 트롤링 방지를 위하여 7초 이상의 시간은 설정할 수 없습니다.\r\n\r\n위 항목은 프로그램 내에 저장되며, 매번 딜 체크를 해줘야 하는 타 프로그램과 달리, 한번 수치를 지정하면, 그 이후는 자동으로 워크래프트에 지속적으로 적용이 됩니다.";
                return;
            }
            if (RB_Help2.Checked)
            {
                TB_Help.Text = "메모리 최적화는 운영체제에서 워크래프트에 할당된 메모리를 해제합니다.\r\n\r\n이는 일시적으로 해제되는 것이며, 워크래프트에서 필요한 데이터의 경우, 워크래프트상에서 다시 파일을 로드합니다.\r\n\r\n이때, 컴퓨터의 사양이 좋지 않는 플레이어의 경우, 렉 현상이 발생할 가능성이 있으므로, 게임 도중에 사용하는 것은 추천드리지 않습니다.\r\n(컴퓨터 사양이 좋은 플레이어의 경우는 상관 없습니다.)\r\n\r\n워크래프트의 경우, 불특정 다수의 이유로 인해 메모리에 지속적으로 누수가 발생합니다. 이는 1.28.5업데이트 이후 좀 더 자주 발생하며, 이 메모리 누수로 인해 페이탈 에러가 발생하게 됩니다. 이 기능을 이용함으로써 해제되고 있지 않은 누수를 해결하여 워크래프트가 팅기는 현상을 완화할 수 있습니다.";
                return;
            }
            if (RB_Help3.Checked)
            {
                TB_Help.Text = "현재 가진 맵을 즉시 분석하여, 치트맵인지 아닌지 확인합니다.\r\n\r\n워크래프트에는 Jass라는 문법을 가진 스크립트가 존재하며, 해당 스크립트를 통해 모든 트리거가 발생합니다. 치트의 경우도 스크립트로 작성이 되며, 해당 기능은 스크립트로 작성된 치트를 검색합니다.\r\n\r\n주 목적은 범용 치트셋을 판독하기 위함이며, 제보에 따라서 추가적인 치트셋의 지원도 고려하고 있습니다.";
                return;
            }
            if (RB_Help4.Checked)
            {
                TB_Help.Text = "매 0.2초마다 Warcraft III.exe가 실행되어 있는지를 확인하여 동작합니다.\r\n\r\n1.28.5 업데이트 이후, 간헐적으로 워크래프트 종료시에 프로세스가 완전히 종료되지 않아, 작업 관리자를 통해서 수동으로 종료해야하는 불편함이 있었습니다.\r\n\r\n워크래프트가 최소 10초간 완전히 종료되고 있지 않을경우, 프로그램에서 안내 메세지를 표시하여 종료를 도와줍니다.\r\n\r\n일부 메세지 창이 뜨면 안되는 특정 상황에서 해당 메세지 창이 발생하는 버그가 있습니다.\r\n\r\n한번 '아니오'를 누를 경우, 30분간 해당 메세지가 나타나지 않습니다.";
                return;
            }
            if (RB_Help5.Checked)
            {
                TB_Help.Text = "개인 컴퓨터에 저장된 세이브 파일을 폴더별로 저장하고 관리합니다.\r\n\r\n다수의 캐릭터를 키울수 있는 RPG의 특성상, 여러 RPG맵과 여러 캐릭터를 키울 수 있지만, 정작 해당 세이브 파일의 분류는 너무나도 귀찮은 작업입니다. Cirnix는 세이브 파일을 분류할 폴더를 생성할 수 있으며, 세이브 파일 별로 분류에 저장하는 기능을 제공합니다.\r\n\r\n-save 명령어 입력시에, 현재 지정된 RPG맵의 분류 폴더에 현재 시간으로 이름이 지정되며, -save 명령어 뒤에 수식어를 붙일 경우, 파일 이름이 '수식어.txt' 로 변경됩니다.";
                return;
            }
            if (RB_Help6.Checked)
            {
                TB_Help.Text = "워크래프트의 리플레이 파일을 자동으로 저장합니다.\r\n단, 이때 한글명칭을 사용할 수 있습니다.\r\n\r\nRPG맵을 플레이하고 인증하기 위해서는 리플레이가 필수적으로 필요합니다. 이를 매번 저장해서, 맞는 세이브 파일을 찾는 것은 여간 귀찮은 일이 아닙니다.\r\n\r\nCirnix는 -save 명령어를 사용하고 나간 게임에 한정하여, 자동으로 리플레이를 현재 시간으로 이름을 지정하며, -save 명령어 뒤에 수식어를 붙일 경우, 파일 이름이 '_수식어.w3g' 로 변경되어 저장됩니다.\r\n\r\n1.28.5 업데이트 이후부터 워크래프트에서 한글 명칭으로 리플레이를 저장하려할 경우, 인코딩이 박살나서 출력되는 문제점이 있습니다만, Cirnix의 리플레이 세이브 기능은 외부 도구를 사용하므로, 한글 명칭을 사용할 수 있는 것이 특징입니다.";
                return;
            }
            if (RB_Help7.Checked)
            {
                TB_Help.Text = "스마트키가 켜진 키에 한해서, 키를 입력시에 마우스 지점에 즉시 클릭을 합니다.\r\n\r\n오클릭 방지는 스마트키 동작 시에, 마우스 클릭 후 작동합니다.";
                return;
            }
            if (RB_Help8.Checked)
            {
                TB_Help.Text = "인벤토리 단축키를 원하는 키로 변경할 수 있습니다.\r\n\r\n채팅창이 열려 있거나, 워크래프트 창이 메인 화면이 아닐 경우에는 동작하지 않습니다.\r\n\r\n또한, 단축키들은 과도하게 빠른 속도로 연타시에 문제가 발생될 수 있는 점에 유의하시기 바랍니다.";
                return;
            }
            if (RB_Help9.Checked)
            {
                TB_Help.Text = "채팅을 입력받고 출력하는 주파수를 조정할 수 있습니다.\r\n\r\n워크래프트는 메모리에 채팅 입력 메세지를 저장한 뒤에 전송합니다.\r\n일반적인 상황에서는 프로그램이 자동적으로 해당 주파수를 검색하여 사용하나, 불특정 상황에서 주파수 검색에 실패하는 경우가 존재합니다.\r\n\r\n이러한 상황에서는 수동으로 주파수를 조정하여 해당 문제를 해결할 수 있습니다.\r\n\r\n자동으로 검색할 여러 알고리즘을 모색해보았으나, 일부 사용자가 지속적으로 발생하는 문제로 인해 추가된 기능이니, 채팅을 쳐도 아무런 반응이 없다고 판단되는 분만 해당 기능을 사용하시기 바랍니다.";
                return;
            }
            if (RB_Help10.Checked)
            {
                TB_Help.Text = " - 개발 기간: 2017-07-16 ~ ...\r\n\r\n해당 프로그램은 Cirnix의 오픈소스 프로젝트인 OpenCirnix입니다.\r\nhttps://github.com/BlacklightsC/OpenCirnix\r\n\r\n\r\n---------- 후원 안내 ----------\r\n\r\n농협중앙회 302-0627-1751-31 박성현\r\n카카오뱅크 3333-09-4274361 박성현\r\n투네이션: https://toon.at/donate/637131255322131449\r\n페이팔(해외): https://www.paypal.me/BlacklightsC\r\nPatreon(해외 정기후원): https://www.patreon.com/cirnix";
                return;
            }
        }
    }
}