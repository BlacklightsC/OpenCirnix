using System.Windows.Forms;

namespace Cirnix.Forms
{
    partial class OptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.MainTabControl = new MetroFramework.Controls.MetroTabControl();
            this.War3SettingTab = new MetroFramework.Controls.MetroTabPage();
            this.GB_MixFile = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_InstallPath = new System.Windows.Forms.Button();
            this.TB_InstallPath = new MetroFramework.Controls.MetroTextBox();
            this.GB_Manabar = new System.Windows.Forms.GroupBox();
            this.RB_DisableManabar = new System.Windows.Forms.RadioButton();
            this.RB_EnableManabar = new System.Windows.Forms.RadioButton();
            this.GB_SpeenNumberize = new System.Windows.Forms.GroupBox();
            this.RB_DisableSpeedNumberize = new System.Windows.Forms.RadioButton();
            this.RB_EnableSpeedNumberize = new System.Windows.Forms.RadioButton();
            this.BTN_UninstallMix = new System.Windows.Forms.Button();
            this.BTN_InstallMix = new System.Windows.Forms.Button();
            this.Label_CheatMapCheck = new System.Windows.Forms.Label();
            this.Toggle_CheatMapCheck = new MetroFramework.Controls.MetroToggle();
            this.Label_ChannelChatViewer = new System.Windows.Forms.Label();
            this.Toggle_ChannelChatViewer = new MetroFramework.Controls.MetroToggle();
            this.Label_War3FixClipboard = new System.Windows.Forms.Label();
            this.Label_HpCommandAuto = new System.Windows.Forms.Label();
            this.GB_ScreenShot = new System.Windows.Forms.GroupBox();
            this.Combo_ScreenShotExtension = new MetroFramework.Controls.MetroComboBox();
            this.Toggle_AutoConvert = new MetroFramework.Controls.MetroToggle();
            this.Toggle_RemoveOriginal = new MetroFramework.Controls.MetroToggle();
            this.Label_RemoveOriginal = new System.Windows.Forms.Label();
            this.Label_AutoConvert = new System.Windows.Forms.Label();
            this.GB_Host = new System.Windows.Forms.GroupBox();
            this.BTN_HostApply = new System.Windows.Forms.Button();
            this.Num_GameDelay = new System.Windows.Forms.NumericUpDown();
            this.Num_GameStartDelay = new System.Windows.Forms.NumericUpDown();
            this.Label_GameDelay = new System.Windows.Forms.Label();
            this.Label_GameStartDelay = new System.Windows.Forms.Label();
            this.Toggle_War3FixClipboard = new MetroFramework.Controls.MetroToggle();
            this.Toggle_HpCommandAuto = new MetroFramework.Controls.MetroToggle();
            this.GroupBox_MemoryOptimization = new System.Windows.Forms.GroupBox();
            this.TB_MemoryOptimizationDelay = new System.Windows.Forms.TextBox();
            this.Toggle_MemoryOptimizationDelay = new MetroFramework.Controls.MetroToggle();
            this.Toggle_OutGameAutoMemoryOptimization = new MetroFramework.Controls.MetroToggle();
            this.Label_MemoryOptimizationDelay = new System.Windows.Forms.Label();
            this.Label_OutGameAutoMemoryOptimization = new System.Windows.Forms.Label();
            this.GB_Camera = new System.Windows.Forms.GroupBox();
            this.BTN_CameraPresetJurrasic = new System.Windows.Forms.Button();
            this.BTN_CameraReset = new System.Windows.Forms.Button();
            this.BTN_CameraApply = new System.Windows.Forms.Button();
            this.Num_CameraX = new System.Windows.Forms.NumericUpDown();
            this.Num_CameraY = new System.Windows.Forms.NumericUpDown();
            this.Num_CameraDistance = new System.Windows.Forms.NumericUpDown();
            this.CameraImage = new System.Windows.Forms.PictureBox();
            this.RPGTab = new MetroFramework.Controls.MetroTabPage();
            this.CB_AutoLoad = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_CommandPreset = new System.Windows.Forms.Label();
            this.TabControl_CommandPreset = new System.Windows.Forms.TabControl();
            this.TP_CommandPreset1 = new System.Windows.Forms.TabPage();
            this.TB_CommandPreset1 = new System.Windows.Forms.TextBox();
            this.TP_CommandPreset2 = new System.Windows.Forms.TabPage();
            this.TB_CommandPreset2 = new System.Windows.Forms.TextBox();
            this.TP_CommandPreset3 = new System.Windows.Forms.TabPage();
            this.TB_CommandPreset3 = new System.Windows.Forms.TextBox();
            this.CB_NoSavesReplaySave = new System.Windows.Forms.CheckBox();
            this.CB_SavesReplayAutoSave = new System.Windows.Forms.CheckBox();
            this.CB_NewMapSaveFileAuto = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTN_Refresh = new System.Windows.Forms.Button();
            this.Label_HeroList = new System.Windows.Forms.Label();
            this.Label_RPGList = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BTN_HeroFolder = new System.Windows.Forms.Button();
            this.Label_HeroName = new System.Windows.Forms.Label();
            this.BTN_HeroDel = new System.Windows.Forms.Button();
            this.BTN_HeroAddMod = new System.Windows.Forms.Button();
            this.TB_HeroName = new MetroFramework.Controls.MetroTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BTN_RPGSetRegex = new System.Windows.Forms.Button();
            this.BTN_RPGFolder = new System.Windows.Forms.Button();
            this.BTN_RPGDel = new System.Windows.Forms.Button();
            this.BTN_RPGAddMod = new System.Windows.Forms.Button();
            this.BTN_RPGPath = new System.Windows.Forms.Button();
            this.Label_RPGPath = new System.Windows.Forms.Label();
            this.Label_RPGEN = new System.Windows.Forms.Label();
            this.TB_RPGPath = new MetroFramework.Controls.MetroTextBox();
            this.Label_RPGKR = new System.Windows.Forms.Label();
            this.TB_RPGEN = new MetroFramework.Controls.MetroTextBox();
            this.TB_RPGKR = new MetroFramework.Controls.MetroTextBox();
            this.RPGListBox = new System.Windows.Forms.ListBox();
            this.HeroListBox = new System.Windows.Forms.ListBox();
            this.MacroTab = new MetroFramework.Controls.MetroTabPage();
            this.GB_AutoMouse = new System.Windows.Forms.GroupBox();
            this.Label_Border = new System.Windows.Forms.Label();
            this.TrB_AutoMouseDelay = new System.Windows.Forms.TrackBar();
            this.Label_AutoMouseDelay = new System.Windows.Forms.Label();
            this.Label_AutoRightMouseOn = new System.Windows.Forms.Label();
            this.BTN_AutoRightMouseOn = new System.Windows.Forms.Button();
            this.Toggle_AutoMouse = new MetroFramework.Controls.MetroToggle();
            this.Label_AutoMouseOff = new System.Windows.Forms.Label();
            this.BTN_AutoMouseOff = new System.Windows.Forms.Button();
            this.Label_AutoLeftMouseOn = new System.Windows.Forms.Label();
            this.BTN_AutoLeftMouseOn = new System.Windows.Forms.Button();
            this.GB_ChatMacro = new System.Windows.Forms.GroupBox();
            this.Toggle_ChatMacro = new MetroFramework.Controls.MetroToggle();
            this.Label_ChatHotkey = new System.Windows.Forms.Label();
            this.BTN_SetChatHotkey = new System.Windows.Forms.Button();
            this.RB_Chat8 = new System.Windows.Forms.RadioButton();
            this.RB_Chat0 = new System.Windows.Forms.RadioButton();
            this.RB_Chat9 = new System.Windows.Forms.RadioButton();
            this.RB_Chat7 = new System.Windows.Forms.RadioButton();
            this.RB_Chat4 = new System.Windows.Forms.RadioButton();
            this.RB_Chat2 = new System.Windows.Forms.RadioButton();
            this.RB_Chat6 = new System.Windows.Forms.RadioButton();
            this.RB_Chat5 = new System.Windows.Forms.RadioButton();
            this.RB_Chat3 = new System.Windows.Forms.RadioButton();
            this.RB_Chat1 = new System.Windows.Forms.RadioButton();
            this.Label_ChatMacro = new System.Windows.Forms.Label();
            this.TB_ChatMacro = new MetroFramework.Controls.MetroTextBox();
            this.GB_SmartKey = new System.Windows.Forms.GroupBox();
            this.GB_SmartKeyPrevention = new System.Windows.Forms.GroupBox();
            this.RB_Prev4 = new System.Windows.Forms.RadioButton();
            this.RB_Prev2 = new System.Windows.Forms.RadioButton();
            this.Label_ClickPrevention = new System.Windows.Forms.Label();
            this.RB_Prev3 = new System.Windows.Forms.RadioButton();
            this.RB_Prev1 = new System.Windows.Forms.RadioButton();
            this.Qbutton = new MetroFramework.Controls.MetroButton();
            this.Wbutton = new MetroFramework.Controls.MetroButton();
            this.Ebutton = new MetroFramework.Controls.MetroButton();
            this.Rbutton = new MetroFramework.Controls.MetroButton();
            this.Tbutton = new MetroFramework.Controls.MetroButton();
            this.Abutton = new MetroFramework.Controls.MetroButton();
            this.Dbutton = new MetroFramework.Controls.MetroButton();
            this.Fbutton = new MetroFramework.Controls.MetroButton();
            this.Gbutton = new MetroFramework.Controls.MetroButton();
            this.Zbutton = new MetroFramework.Controls.MetroButton();
            this.Xbutton = new MetroFramework.Controls.MetroButton();
            this.Cbutton = new MetroFramework.Controls.MetroButton();
            this.Vbutton = new MetroFramework.Controls.MetroButton();
            this.GB_KeyReMap = new System.Windows.Forms.GroupBox();
            this.Key8Text = new System.Windows.Forms.Label();
            this.Key1Text = new System.Windows.Forms.Label();
            this.Key5Text = new System.Windows.Forms.Label();
            this.Key4Text = new System.Windows.Forms.Label();
            this.Toggle_KeyRemapping = new MetroFramework.Controls.MetroToggle();
            this.Key2Text = new System.Windows.Forms.Label();
            this.Key1 = new MetroFramework.Controls.MetroButton();
            this.Key2 = new MetroFramework.Controls.MetroButton();
            this.Key7Text = new System.Windows.Forms.Label();
            this.Key4 = new MetroFramework.Controls.MetroButton();
            this.Key5 = new MetroFramework.Controls.MetroButton();
            this.Key7 = new MetroFramework.Controls.MetroButton();
            this.Key8 = new MetroFramework.Controls.MetroButton();
            this.BanList = new MetroFramework.Controls.MetroTabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.banlistview = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.사유 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.BTN_HotKeyDebug = new System.Windows.Forms.Button();
            this.GB_ChatFrequency = new System.Windows.Forms.GroupBox();
            this.BTN_DetectFrequency = new System.Windows.Forms.Button();
            this.Number_ChatFrequency = new System.Windows.Forms.NumericUpDown();
            this.Label_ChatFrequency = new System.Windows.Forms.Label();
            this.Label_AutoFrequency = new System.Windows.Forms.Label();
            this.Toggle_AutoFrequency = new MetroFramework.Controls.MetroToggle();
            this.TB_CommandDescription = new System.Windows.Forms.Label();
            this.Label_ParameterInfo = new System.Windows.Forms.Label();
            this.Label_ParameterValue = new System.Windows.Forms.Label();
            this.Label_CommandKR = new System.Windows.Forms.Label();
            this.Label_CommandInfo = new System.Windows.Forms.Label();
            this.Label_CommandEN = new System.Windows.Forms.Label();
            this.Label_CommandTitle = new System.Windows.Forms.Label();
            this.Label_CommandListBox = new System.Windows.Forms.Label();
            this.CommandListBox = new System.Windows.Forms.ListBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.RB_Help8 = new System.Windows.Forms.RadioButton();
            this.RB_Help10 = new System.Windows.Forms.RadioButton();
            this.RB_Help9 = new System.Windows.Forms.RadioButton();
            this.RB_Help7 = new System.Windows.Forms.RadioButton();
            this.RB_Help4 = new System.Windows.Forms.RadioButton();
            this.RB_Help2 = new System.Windows.Forms.RadioButton();
            this.RB_Help6 = new System.Windows.Forms.RadioButton();
            this.RB_Help5 = new System.Windows.Forms.RadioButton();
            this.RB_Help3 = new System.Windows.Forms.RadioButton();
            this.RB_Help1 = new System.Windows.Forms.RadioButton();
            this.TB_Help = new System.Windows.Forms.TextBox();
            this.Toggle_CommandHide = new MetroFramework.Controls.MetroToggle();
            this.Label_Title = new System.Windows.Forms.Label();
            this.CommandHideText = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.War3SettingTab.SuspendLayout();
            this.GB_MixFile.SuspendLayout();
            this.GB_Manabar.SuspendLayout();
            this.GB_SpeenNumberize.SuspendLayout();
            this.GB_ScreenShot.SuspendLayout();
            this.GB_Host.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GameDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GameStartDelay)).BeginInit();
            this.GroupBox_MemoryOptimization.SuspendLayout();
            this.GB_Camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraImage)).BeginInit();
            this.RPGTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabControl_CommandPreset.SuspendLayout();
            this.TP_CommandPreset1.SuspendLayout();
            this.TP_CommandPreset2.SuspendLayout();
            this.TP_CommandPreset3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.MacroTab.SuspendLayout();
            this.GB_AutoMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_AutoMouseDelay)).BeginInit();
            this.GB_ChatMacro.SuspendLayout();
            this.GB_SmartKey.SuspendLayout();
            this.GB_SmartKeyPrevention.SuspendLayout();
            this.GB_KeyReMap.SuspendLayout();
            this.BanList.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.GB_ChatFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Number_ChatFrequency)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.War3SettingTab);
            this.MainTabControl.Controls.Add(this.RPGTab);
            this.MainTabControl.Controls.Add(this.MacroTab);
            this.MainTabControl.Controls.Add(this.BanList);
            this.MainTabControl.Controls.Add(this.metroTabPage1);
            this.MainTabControl.Controls.Add(this.metroTabPage2);
            this.MainTabControl.Location = new System.Drawing.Point(10, 30);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 5;
            this.MainTabControl.Size = new System.Drawing.Size(640, 275);
            this.MainTabControl.TabIndex = 6;
            this.MainTabControl.UseSelectable = true;
            // 
            // War3SettingTab
            // 
            this.War3SettingTab.Controls.Add(this.GB_MixFile);
            this.War3SettingTab.Controls.Add(this.Label_CheatMapCheck);
            this.War3SettingTab.Controls.Add(this.Toggle_CheatMapCheck);
            this.War3SettingTab.Controls.Add(this.Label_ChannelChatViewer);
            this.War3SettingTab.Controls.Add(this.Toggle_ChannelChatViewer);
            this.War3SettingTab.Controls.Add(this.Label_War3FixClipboard);
            this.War3SettingTab.Controls.Add(this.Label_HpCommandAuto);
            this.War3SettingTab.Controls.Add(this.GB_ScreenShot);
            this.War3SettingTab.Controls.Add(this.GB_Host);
            this.War3SettingTab.Controls.Add(this.Toggle_War3FixClipboard);
            this.War3SettingTab.Controls.Add(this.Toggle_HpCommandAuto);
            this.War3SettingTab.Controls.Add(this.GroupBox_MemoryOptimization);
            this.War3SettingTab.Controls.Add(this.GB_Camera);
            this.War3SettingTab.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.War3SettingTab.HorizontalScrollbarBarColor = true;
            this.War3SettingTab.HorizontalScrollbarHighlightOnWheel = false;
            this.War3SettingTab.HorizontalScrollbarSize = 10;
            this.War3SettingTab.Location = new System.Drawing.Point(4, 36);
            this.War3SettingTab.Name = "War3SettingTab";
            this.War3SettingTab.Size = new System.Drawing.Size(632, 235);
            this.War3SettingTab.TabIndex = 2;
            this.War3SettingTab.Text = "워크래프트";
            this.War3SettingTab.VerticalScrollbarBarColor = true;
            this.War3SettingTab.VerticalScrollbarHighlightOnWheel = false;
            this.War3SettingTab.VerticalScrollbarSize = 10;
            // 
            // GB_MixFile
            // 
            this.GB_MixFile.BackColor = System.Drawing.Color.White;
            this.GB_MixFile.Controls.Add(this.label1);
            this.GB_MixFile.Controls.Add(this.BTN_InstallPath);
            this.GB_MixFile.Controls.Add(this.TB_InstallPath);
            this.GB_MixFile.Controls.Add(this.GB_Manabar);
            this.GB_MixFile.Controls.Add(this.GB_SpeenNumberize);
            this.GB_MixFile.Controls.Add(this.BTN_UninstallMix);
            this.GB_MixFile.Controls.Add(this.BTN_InstallMix);
            this.GB_MixFile.Location = new System.Drawing.Point(467, 3);
            this.GB_MixFile.Name = "GB_MixFile";
            this.GB_MixFile.Size = new System.Drawing.Size(165, 225);
            this.GB_MixFile.TabIndex = 72;
            this.GB_MixFile.TabStop = false;
            this.GB_MixFile.Text = "Mix 파일";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.label1.Location = new System.Drawing.Point(5, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 52);
            this.label1.TabIndex = 80;
            this.label1.Text = "Mix 파일의 설정 변경은\r\n워크래프트가 실행 중인\r\n상태에서는 워크래프트가\r\n꺼진 뒤, 설정이 적용됩니다.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_InstallPath
            // 
            this.BTN_InstallPath.Font = new System.Drawing.Font("굴림", 8F);
            this.BTN_InstallPath.Location = new System.Drawing.Point(136, 43);
            this.BTN_InstallPath.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_InstallPath.Name = "BTN_InstallPath";
            this.BTN_InstallPath.Size = new System.Drawing.Size(22, 22);
            this.BTN_InstallPath.TabIndex = 79;
            this.BTN_InstallPath.Text = "...";
            this.BTN_InstallPath.UseVisualStyleBackColor = true;
            this.BTN_InstallPath.Click += new System.EventHandler(this.BTN_InstallPath_Click);
            // 
            // TB_InstallPath
            // 
            // 
            // 
            // 
            this.TB_InstallPath.CustomButton.Image = null;
            this.TB_InstallPath.CustomButton.Location = new System.Drawing.Point(111, 2);
            this.TB_InstallPath.CustomButton.Name = "";
            this.TB_InstallPath.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_InstallPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_InstallPath.CustomButton.TabIndex = 1;
            this.TB_InstallPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_InstallPath.CustomButton.UseSelectable = true;
            this.TB_InstallPath.CustomButton.Visible = false;
            this.TB_InstallPath.Lines = new string[0];
            this.TB_InstallPath.Location = new System.Drawing.Point(8, 44);
            this.TB_InstallPath.Margin = new System.Windows.Forms.Padding(1);
            this.TB_InstallPath.MaxLength = 260;
            this.TB_InstallPath.Name = "TB_InstallPath";
            this.TB_InstallPath.PasswordChar = '\0';
            this.TB_InstallPath.ReadOnly = true;
            this.TB_InstallPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_InstallPath.SelectedText = "";
            this.TB_InstallPath.SelectionLength = 0;
            this.TB_InstallPath.SelectionStart = 0;
            this.TB_InstallPath.ShortcutsEnabled = true;
            this.TB_InstallPath.Size = new System.Drawing.Size(129, 20);
            this.TB_InstallPath.TabIndex = 78;
            this.TB_InstallPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_InstallPath.UseSelectable = true;
            this.TB_InstallPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_InstallPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // GB_Manabar
            // 
            this.GB_Manabar.BackColor = System.Drawing.Color.White;
            this.GB_Manabar.Controls.Add(this.RB_DisableManabar);
            this.GB_Manabar.Controls.Add(this.RB_EnableManabar);
            this.GB_Manabar.Enabled = false;
            this.GB_Manabar.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.GB_Manabar.Location = new System.Drawing.Point(5, 118);
            this.GB_Manabar.Name = "GB_Manabar";
            this.GB_Manabar.Size = new System.Drawing.Size(155, 45);
            this.GB_Manabar.TabIndex = 76;
            this.GB_Manabar.TabStop = false;
            this.GB_Manabar.Text = "마나바";
            // 
            // RB_DisableManabar
            // 
            this.RB_DisableManabar.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_DisableManabar.Checked = true;
            this.RB_DisableManabar.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_DisableManabar.Location = new System.Drawing.Point(78, 15);
            this.RB_DisableManabar.Name = "RB_DisableManabar";
            this.RB_DisableManabar.Size = new System.Drawing.Size(73, 25);
            this.RB_DisableManabar.TabIndex = 80;
            this.RB_DisableManabar.TabStop = true;
            this.RB_DisableManabar.Text = "꺼짐";
            this.RB_DisableManabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_DisableManabar.UseVisualStyleBackColor = true;
            // 
            // RB_EnableManabar
            // 
            this.RB_EnableManabar.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_EnableManabar.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_EnableManabar.Location = new System.Drawing.Point(4, 15);
            this.RB_EnableManabar.Name = "RB_EnableManabar";
            this.RB_EnableManabar.Size = new System.Drawing.Size(73, 25);
            this.RB_EnableManabar.TabIndex = 79;
            this.RB_EnableManabar.Text = "켜짐";
            this.RB_EnableManabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_EnableManabar.UseVisualStyleBackColor = true;
            this.RB_EnableManabar.CheckedChanged += new System.EventHandler(this.RB_EnableManabar_CheckedChanged);
            // 
            // GB_SpeenNumberize
            // 
            this.GB_SpeenNumberize.BackColor = System.Drawing.Color.White;
            this.GB_SpeenNumberize.Controls.Add(this.RB_DisableSpeedNumberize);
            this.GB_SpeenNumberize.Controls.Add(this.RB_EnableSpeedNumberize);
            this.GB_SpeenNumberize.Enabled = false;
            this.GB_SpeenNumberize.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.GB_SpeenNumberize.Location = new System.Drawing.Point(5, 70);
            this.GB_SpeenNumberize.Name = "GB_SpeenNumberize";
            this.GB_SpeenNumberize.Size = new System.Drawing.Size(155, 45);
            this.GB_SpeenNumberize.TabIndex = 75;
            this.GB_SpeenNumberize.TabStop = false;
            this.GB_SpeenNumberize.Text = "속도 수치를 숫자로 변경";
            // 
            // RB_DisableSpeedNumberize
            // 
            this.RB_DisableSpeedNumberize.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_DisableSpeedNumberize.Checked = true;
            this.RB_DisableSpeedNumberize.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_DisableSpeedNumberize.Location = new System.Drawing.Point(78, 15);
            this.RB_DisableSpeedNumberize.Name = "RB_DisableSpeedNumberize";
            this.RB_DisableSpeedNumberize.Size = new System.Drawing.Size(73, 25);
            this.RB_DisableSpeedNumberize.TabIndex = 78;
            this.RB_DisableSpeedNumberize.TabStop = true;
            this.RB_DisableSpeedNumberize.Text = "꺼짐";
            this.RB_DisableSpeedNumberize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_DisableSpeedNumberize.UseVisualStyleBackColor = true;
            // 
            // RB_EnableSpeedNumberize
            // 
            this.RB_EnableSpeedNumberize.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_EnableSpeedNumberize.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_EnableSpeedNumberize.Location = new System.Drawing.Point(4, 15);
            this.RB_EnableSpeedNumberize.Name = "RB_EnableSpeedNumberize";
            this.RB_EnableSpeedNumberize.Size = new System.Drawing.Size(73, 25);
            this.RB_EnableSpeedNumberize.TabIndex = 77;
            this.RB_EnableSpeedNumberize.Text = "켜짐";
            this.RB_EnableSpeedNumberize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_EnableSpeedNumberize.UseVisualStyleBackColor = true;
            this.RB_EnableSpeedNumberize.CheckedChanged += new System.EventHandler(this.RB_EnableSpeedNumberize_CheckedChanged);
            // 
            // BTN_UninstallMix
            // 
            this.BTN_UninstallMix.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_UninstallMix.Location = new System.Drawing.Point(83, 17);
            this.BTN_UninstallMix.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_UninstallMix.Name = "BTN_UninstallMix";
            this.BTN_UninstallMix.Size = new System.Drawing.Size(75, 25);
            this.BTN_UninstallMix.TabIndex = 74;
            this.BTN_UninstallMix.Text = "제거";
            this.BTN_UninstallMix.UseVisualStyleBackColor = true;
            this.BTN_UninstallMix.Click += new System.EventHandler(this.BTN_UninstallMix_Click);
            // 
            // BTN_InstallMix
            // 
            this.BTN_InstallMix.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_InstallMix.Location = new System.Drawing.Point(7, 17);
            this.BTN_InstallMix.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_InstallMix.Name = "BTN_InstallMix";
            this.BTN_InstallMix.Size = new System.Drawing.Size(75, 25);
            this.BTN_InstallMix.TabIndex = 73;
            this.BTN_InstallMix.Text = "설치";
            this.BTN_InstallMix.UseVisualStyleBackColor = true;
            this.BTN_InstallMix.Click += new System.EventHandler(this.BTN_InstallMix_Click);
            // 
            // Label_CheatMapCheck
            // 
            this.Label_CheatMapCheck.BackColor = System.Drawing.Color.Transparent;
            this.Label_CheatMapCheck.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_CheatMapCheck.Location = new System.Drawing.Point(0, 213);
            this.Label_CheatMapCheck.Name = "Label_CheatMapCheck";
            this.Label_CheatMapCheck.Size = new System.Drawing.Size(151, 17);
            this.Label_CheatMapCheck.TabIndex = 71;
            this.Label_CheatMapCheck.Text = "맵 다운로드시 치트맵 체크";
            this.Label_CheatMapCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Toggle_CheatMapCheck
            // 
            this.Toggle_CheatMapCheck.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_CheatMapCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_CheatMapCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_CheatMapCheck.Location = new System.Drawing.Point(147, 213);
            this.Toggle_CheatMapCheck.Name = "Toggle_CheatMapCheck";
            this.Toggle_CheatMapCheck.Size = new System.Drawing.Size(70, 15);
            this.Toggle_CheatMapCheck.TabIndex = 70;
            this.Toggle_CheatMapCheck.Text = "Off";
            this.Toggle_CheatMapCheck.UseSelectable = true;
            this.Toggle_CheatMapCheck.CheckedChanged += new System.EventHandler(this.Toggle_CheatMapCheck_CheckedChanged);
            // 
            // Label_ChannelChatViewer
            // 
            this.Label_ChannelChatViewer.BackColor = System.Drawing.Color.Transparent;
            this.Label_ChannelChatViewer.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_ChannelChatViewer.Location = new System.Drawing.Point(226, 213);
            this.Label_ChannelChatViewer.Name = "Label_ChannelChatViewer";
            this.Label_ChannelChatViewer.Size = new System.Drawing.Size(167, 15);
            this.Label_ChannelChatViewer.TabIndex = 69;
            this.Label_ChannelChatViewer.Text = "방 리스트에서 채널 채팅 표시";
            this.Label_ChannelChatViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Toggle_ChannelChatViewer
            // 
            this.Toggle_ChannelChatViewer.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_ChannelChatViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_ChannelChatViewer.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_ChannelChatViewer.Location = new System.Drawing.Point(391, 213);
            this.Toggle_ChannelChatViewer.Name = "Toggle_ChannelChatViewer";
            this.Toggle_ChannelChatViewer.Size = new System.Drawing.Size(70, 15);
            this.Toggle_ChannelChatViewer.TabIndex = 68;
            this.Toggle_ChannelChatViewer.Text = "Off";
            this.Toggle_ChannelChatViewer.UseSelectable = true;
            this.Toggle_ChannelChatViewer.CheckedChanged += new System.EventHandler(this.Toggle_ChannelChatViewer_CheckedChanged);
            // 
            // Label_War3FixClipboard
            // 
            this.Label_War3FixClipboard.BackColor = System.Drawing.Color.Transparent;
            this.Label_War3FixClipboard.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_War3FixClipboard.Location = new System.Drawing.Point(0, 195);
            this.Label_War3FixClipboard.Name = "Label_War3FixClipboard";
            this.Label_War3FixClipboard.Size = new System.Drawing.Size(148, 15);
            this.Label_War3FixClipboard.TabIndex = 67;
            this.Label_War3FixClipboard.Text = "워크 클립보드 오류 수정";
            this.Label_War3FixClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HpCommandAuto
            // 
            this.Label_HpCommandAuto.BackColor = System.Drawing.Color.Transparent;
            this.Label_HpCommandAuto.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_HpCommandAuto.Location = new System.Drawing.Point(0, 66);
            this.Label_HpCommandAuto.Name = "Label_HpCommandAuto";
            this.Label_HpCommandAuto.Size = new System.Drawing.Size(151, 15);
            this.Label_HpCommandAuto.TabIndex = 62;
            this.Label_HpCommandAuto.Text = "!Hp 명령어 자동";
            this.Label_HpCommandAuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GB_ScreenShot
            // 
            this.GB_ScreenShot.BackColor = System.Drawing.Color.Transparent;
            this.GB_ScreenShot.Controls.Add(this.Combo_ScreenShotExtension);
            this.GB_ScreenShot.Controls.Add(this.Toggle_AutoConvert);
            this.GB_ScreenShot.Controls.Add(this.Toggle_RemoveOriginal);
            this.GB_ScreenShot.Controls.Add(this.Label_RemoveOriginal);
            this.GB_ScreenShot.Controls.Add(this.Label_AutoConvert);
            this.GB_ScreenShot.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GB_ScreenShot.Location = new System.Drawing.Point(0, 140);
            this.GB_ScreenShot.Name = "GB_ScreenShot";
            this.GB_ScreenShot.Size = new System.Drawing.Size(219, 52);
            this.GB_ScreenShot.TabIndex = 54;
            this.GB_ScreenShot.TabStop = false;
            this.GB_ScreenShot.Text = "스크린샷";
            // 
            // Combo_ScreenShotExtension
            // 
            this.Combo_ScreenShotExtension.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Combo_ScreenShotExtension.FormattingEnabled = true;
            this.Combo_ScreenShotExtension.ItemHeight = 23;
            this.Combo_ScreenShotExtension.Items.AddRange(new object[] {
            "PNG",
            "JPG",
            "GIF",
            "BMP"});
            this.Combo_ScreenShotExtension.Location = new System.Drawing.Point(4, 16);
            this.Combo_ScreenShotExtension.Name = "Combo_ScreenShotExtension";
            this.Combo_ScreenShotExtension.Size = new System.Drawing.Size(60, 29);
            this.Combo_ScreenShotExtension.TabIndex = 19;
            this.Combo_ScreenShotExtension.UseSelectable = true;
            this.Combo_ScreenShotExtension.TextChanged += new System.EventHandler(this.ScreenShotFileNameExtensionList_TextChanged);
            // 
            // Toggle_AutoConvert
            // 
            this.Toggle_AutoConvert.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_AutoConvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_AutoConvert.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_AutoConvert.Location = new System.Drawing.Point(147, 14);
            this.Toggle_AutoConvert.Name = "Toggle_AutoConvert";
            this.Toggle_AutoConvert.Size = new System.Drawing.Size(70, 15);
            this.Toggle_AutoConvert.TabIndex = 34;
            this.Toggle_AutoConvert.Text = "Off";
            this.Toggle_AutoConvert.UseSelectable = true;
            this.Toggle_AutoConvert.CheckedChanged += new System.EventHandler(this.TgaAutoConvertToggle_CheckedChanged);
            // 
            // Toggle_RemoveOriginal
            // 
            this.Toggle_RemoveOriginal.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_RemoveOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_RemoveOriginal.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_RemoveOriginal.Location = new System.Drawing.Point(147, 32);
            this.Toggle_RemoveOriginal.Name = "Toggle_RemoveOriginal";
            this.Toggle_RemoveOriginal.Size = new System.Drawing.Size(70, 15);
            this.Toggle_RemoveOriginal.TabIndex = 35;
            this.Toggle_RemoveOriginal.Text = "Off";
            this.Toggle_RemoveOriginal.UseSelectable = true;
            this.Toggle_RemoveOriginal.CheckedChanged += new System.EventHandler(this.TgaOriginallyDeleteToggle_CheckedChanged);
            // 
            // Label_RemoveOriginal
            // 
            this.Label_RemoveOriginal.BackColor = System.Drawing.Color.Transparent;
            this.Label_RemoveOriginal.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_RemoveOriginal.Location = new System.Drawing.Point(65, 32);
            this.Label_RemoveOriginal.Name = "Label_RemoveOriginal";
            this.Label_RemoveOriginal.Size = new System.Drawing.Size(83, 15);
            this.Label_RemoveOriginal.TabIndex = 66;
            this.Label_RemoveOriginal.Text = "원본 삭제";
            this.Label_RemoveOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_AutoConvert
            // 
            this.Label_AutoConvert.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoConvert.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_AutoConvert.Location = new System.Drawing.Point(65, 14);
            this.Label_AutoConvert.Name = "Label_AutoConvert";
            this.Label_AutoConvert.Size = new System.Drawing.Size(83, 15);
            this.Label_AutoConvert.TabIndex = 65;
            this.Label_AutoConvert.Text = "자동 변환";
            this.Label_AutoConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GB_Host
            // 
            this.GB_Host.BackColor = System.Drawing.Color.Transparent;
            this.GB_Host.Controls.Add(this.BTN_HostApply);
            this.GB_Host.Controls.Add(this.Num_GameDelay);
            this.GB_Host.Controls.Add(this.Num_GameStartDelay);
            this.GB_Host.Controls.Add(this.Label_GameDelay);
            this.GB_Host.Controls.Add(this.Label_GameStartDelay);
            this.GB_Host.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GB_Host.Location = new System.Drawing.Point(0, 3);
            this.GB_Host.Name = "GB_Host";
            this.GB_Host.Size = new System.Drawing.Size(219, 60);
            this.GB_Host.TabIndex = 52;
            this.GB_Host.TabStop = false;
            this.GB_Host.Text = "호스트";
            // 
            // BTN_HostApply
            // 
            this.BTN_HostApply.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_HostApply.Location = new System.Drawing.Point(180, 10);
            this.BTN_HostApply.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_HostApply.Name = "BTN_HostApply";
            this.BTN_HostApply.Size = new System.Drawing.Size(37, 47);
            this.BTN_HostApply.TabIndex = 72;
            this.BTN_HostApply.Text = "적용";
            this.BTN_HostApply.UseVisualStyleBackColor = true;
            this.BTN_HostApply.Click += new System.EventHandler(this.DelayApplyBTN_Click);
            // 
            // Num_GameDelay
            // 
            this.Num_GameDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Num_GameDelay.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Num_GameDelay.Location = new System.Drawing.Point(142, 11);
            this.Num_GameDelay.Maximum = new decimal(new int[] {
            550,
            0,
            0,
            0});
            this.Num_GameDelay.Name = "Num_GameDelay";
            this.Num_GameDelay.Size = new System.Drawing.Size(38, 22);
            this.Num_GameDelay.TabIndex = 59;
            this.Num_GameDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Num_GameStartDelay
            // 
            this.Num_GameStartDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Num_GameStartDelay.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Num_GameStartDelay.Location = new System.Drawing.Point(142, 34);
            this.Num_GameStartDelay.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Num_GameStartDelay.Name = "Num_GameStartDelay";
            this.Num_GameStartDelay.Size = new System.Drawing.Size(38, 22);
            this.Num_GameStartDelay.TabIndex = 60;
            this.Num_GameStartDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_GameDelay
            // 
            this.Label_GameDelay.BackColor = System.Drawing.Color.Transparent;
            this.Label_GameDelay.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_GameDelay.Location = new System.Drawing.Point(1, 11);
            this.Label_GameDelay.Name = "Label_GameDelay";
            this.Label_GameDelay.Size = new System.Drawing.Size(140, 22);
            this.Label_GameDelay.TabIndex = 59;
            this.Label_GameDelay.Text = "반응 지연시간";
            this.Label_GameDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_GameStartDelay
            // 
            this.Label_GameStartDelay.BackColor = System.Drawing.Color.Transparent;
            this.Label_GameStartDelay.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_GameStartDelay.Location = new System.Drawing.Point(1, 34);
            this.Label_GameStartDelay.Name = "Label_GameStartDelay";
            this.Label_GameStartDelay.Size = new System.Drawing.Size(140, 22);
            this.Label_GameStartDelay.TabIndex = 61;
            this.Label_GameStartDelay.Text = "시작 대기시간";
            this.Label_GameStartDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Toggle_War3FixClipboard
            // 
            this.Toggle_War3FixClipboard.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_War3FixClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_War3FixClipboard.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_War3FixClipboard.Location = new System.Drawing.Point(147, 195);
            this.Toggle_War3FixClipboard.Name = "Toggle_War3FixClipboard";
            this.Toggle_War3FixClipboard.Size = new System.Drawing.Size(70, 15);
            this.Toggle_War3FixClipboard.TabIndex = 23;
            this.Toggle_War3FixClipboard.Text = "Off";
            this.Toggle_War3FixClipboard.UseSelectable = true;
            this.Toggle_War3FixClipboard.CheckedChanged += new System.EventHandler(this.War3AutoKillToggle_CheckedChanged);
            // 
            // Toggle_HpCommandAuto
            // 
            this.Toggle_HpCommandAuto.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_HpCommandAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_HpCommandAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_HpCommandAuto.Location = new System.Drawing.Point(147, 66);
            this.Toggle_HpCommandAuto.Name = "Toggle_HpCommandAuto";
            this.Toggle_HpCommandAuto.Size = new System.Drawing.Size(70, 15);
            this.Toggle_HpCommandAuto.TabIndex = 27;
            this.Toggle_HpCommandAuto.Text = "Off";
            this.Toggle_HpCommandAuto.UseSelectable = true;
            this.Toggle_HpCommandAuto.CheckedChanged += new System.EventHandler(this.HpCommandAutoToggle_CheckedChanged);
            // 
            // GroupBox_MemoryOptimization
            // 
            this.GroupBox_MemoryOptimization.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox_MemoryOptimization.Controls.Add(this.TB_MemoryOptimizationDelay);
            this.GroupBox_MemoryOptimization.Controls.Add(this.Toggle_MemoryOptimizationDelay);
            this.GroupBox_MemoryOptimization.Controls.Add(this.Toggle_OutGameAutoMemoryOptimization);
            this.GroupBox_MemoryOptimization.Controls.Add(this.Label_MemoryOptimizationDelay);
            this.GroupBox_MemoryOptimization.Controls.Add(this.Label_OutGameAutoMemoryOptimization);
            this.GroupBox_MemoryOptimization.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GroupBox_MemoryOptimization.Location = new System.Drawing.Point(0, 84);
            this.GroupBox_MemoryOptimization.Name = "GroupBox_MemoryOptimization";
            this.GroupBox_MemoryOptimization.Size = new System.Drawing.Size(219, 53);
            this.GroupBox_MemoryOptimization.TabIndex = 51;
            this.GroupBox_MemoryOptimization.TabStop = false;
            this.GroupBox_MemoryOptimization.Text = "메모리 최적화";
            // 
            // TB_MemoryOptimizationDelay
            // 
            this.TB_MemoryOptimizationDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_MemoryOptimizationDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_MemoryOptimizationDelay.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.TB_MemoryOptimizationDelay.Location = new System.Drawing.Point(4, 15);
            this.TB_MemoryOptimizationDelay.MaxLength = 3;
            this.TB_MemoryOptimizationDelay.Name = "TB_MemoryOptimizationDelay";
            this.TB_MemoryOptimizationDelay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TB_MemoryOptimizationDelay.Size = new System.Drawing.Size(24, 16);
            this.TB_MemoryOptimizationDelay.TabIndex = 69;
            this.TB_MemoryOptimizationDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_MemoryOptimizationDelay.Leave += new System.EventHandler(this.MemoryOptimizationEdit_Leave);
            // 
            // Toggle_MemoryOptimizationDelay
            // 
            this.Toggle_MemoryOptimizationDelay.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_MemoryOptimizationDelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_MemoryOptimizationDelay.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_MemoryOptimizationDelay.Location = new System.Drawing.Point(147, 15);
            this.Toggle_MemoryOptimizationDelay.Name = "Toggle_MemoryOptimizationDelay";
            this.Toggle_MemoryOptimizationDelay.Size = new System.Drawing.Size(70, 15);
            this.Toggle_MemoryOptimizationDelay.TabIndex = 33;
            this.Toggle_MemoryOptimizationDelay.Text = "Off";
            this.Toggle_MemoryOptimizationDelay.UseSelectable = true;
            this.Toggle_MemoryOptimizationDelay.CheckedChanged += new System.EventHandler(this.MemoryOptimizationToggle_CheckedChanged);
            // 
            // Toggle_OutGameAutoMemoryOptimization
            // 
            this.Toggle_OutGameAutoMemoryOptimization.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_OutGameAutoMemoryOptimization.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_OutGameAutoMemoryOptimization.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_OutGameAutoMemoryOptimization.Location = new System.Drawing.Point(147, 33);
            this.Toggle_OutGameAutoMemoryOptimization.Name = "Toggle_OutGameAutoMemoryOptimization";
            this.Toggle_OutGameAutoMemoryOptimization.Size = new System.Drawing.Size(70, 15);
            this.Toggle_OutGameAutoMemoryOptimization.TabIndex = 44;
            this.Toggle_OutGameAutoMemoryOptimization.Text = "Off";
            this.Toggle_OutGameAutoMemoryOptimization.UseSelectable = true;
            this.Toggle_OutGameAutoMemoryOptimization.CheckedChanged += new System.EventHandler(this.OutGameAutoMemoryOptimizationToggle_CheckedChanged);
            // 
            // Label_MemoryOptimizationDelay
            // 
            this.Label_MemoryOptimizationDelay.BackColor = System.Drawing.Color.Transparent;
            this.Label_MemoryOptimizationDelay.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_MemoryOptimizationDelay.Location = new System.Drawing.Point(26, 15);
            this.Label_MemoryOptimizationDelay.Name = "Label_MemoryOptimizationDelay";
            this.Label_MemoryOptimizationDelay.Size = new System.Drawing.Size(122, 15);
            this.Label_MemoryOptimizationDelay.TabIndex = 63;
            this.Label_MemoryOptimizationDelay.Text = "분 마다 최적화";
            this.Label_MemoryOptimizationDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_OutGameAutoMemoryOptimization
            // 
            this.Label_OutGameAutoMemoryOptimization.BackColor = System.Drawing.Color.Transparent;
            this.Label_OutGameAutoMemoryOptimization.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_OutGameAutoMemoryOptimization.Location = new System.Drawing.Point(2, 33);
            this.Label_OutGameAutoMemoryOptimization.Name = "Label_OutGameAutoMemoryOptimization";
            this.Label_OutGameAutoMemoryOptimization.Size = new System.Drawing.Size(146, 15);
            this.Label_OutGameAutoMemoryOptimization.TabIndex = 64;
            this.Label_OutGameAutoMemoryOptimization.Text = "게임 끝난후 최적화";
            this.Label_OutGameAutoMemoryOptimization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GB_Camera
            // 
            this.GB_Camera.BackColor = System.Drawing.Color.Transparent;
            this.GB_Camera.Controls.Add(this.BTN_CameraPresetJurrasic);
            this.GB_Camera.Controls.Add(this.BTN_CameraReset);
            this.GB_Camera.Controls.Add(this.BTN_CameraApply);
            this.GB_Camera.Controls.Add(this.Num_CameraX);
            this.GB_Camera.Controls.Add(this.Num_CameraY);
            this.GB_Camera.Controls.Add(this.Num_CameraDistance);
            this.GB_Camera.Controls.Add(this.CameraImage);
            this.GB_Camera.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GB_Camera.Location = new System.Drawing.Point(220, 3);
            this.GB_Camera.Name = "GB_Camera";
            this.GB_Camera.Size = new System.Drawing.Size(241, 202);
            this.GB_Camera.TabIndex = 58;
            this.GB_Camera.TabStop = false;
            this.GB_Camera.Text = "카메라";
            // 
            // BTN_CameraPresetJurrasic
            // 
            this.BTN_CameraPresetJurrasic.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_CameraPresetJurrasic.Location = new System.Drawing.Point(191, 11);
            this.BTN_CameraPresetJurrasic.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_CameraPresetJurrasic.Name = "BTN_CameraPresetJurrasic";
            this.BTN_CameraPresetJurrasic.Size = new System.Drawing.Size(48, 22);
            this.BTN_CameraPresetJurrasic.TabIndex = 72;
            this.BTN_CameraPresetJurrasic.Text = "프리셋";
            this.BTN_CameraPresetJurrasic.UseVisualStyleBackColor = true;
            this.BTN_CameraPresetJurrasic.Click += new System.EventHandler(this.BTN_CameraPresetJurrasic_Click);
            // 
            // BTN_CameraReset
            // 
            this.BTN_CameraReset.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_CameraReset.Location = new System.Drawing.Point(191, 154);
            this.BTN_CameraReset.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_CameraReset.Name = "BTN_CameraReset";
            this.BTN_CameraReset.Size = new System.Drawing.Size(48, 22);
            this.BTN_CameraReset.TabIndex = 70;
            this.BTN_CameraReset.Text = "초기화";
            this.BTN_CameraReset.UseVisualStyleBackColor = true;
            this.BTN_CameraReset.Click += new System.EventHandler(this.CameraResetBTN_Click);
            // 
            // BTN_CameraApply
            // 
            this.BTN_CameraApply.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_CameraApply.Location = new System.Drawing.Point(191, 177);
            this.BTN_CameraApply.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_CameraApply.Name = "BTN_CameraApply";
            this.BTN_CameraApply.Size = new System.Drawing.Size(48, 22);
            this.BTN_CameraApply.TabIndex = 71;
            this.BTN_CameraApply.Text = "적용";
            this.BTN_CameraApply.UseVisualStyleBackColor = true;
            this.BTN_CameraApply.Click += new System.EventHandler(this.CameraApplyBTN_Click);
            // 
            // Num_CameraX
            // 
            this.Num_CameraX.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Num_CameraX.Location = new System.Drawing.Point(192, 126);
            this.Num_CameraX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Num_CameraX.Name = "Num_CameraX";
            this.Num_CameraX.Size = new System.Drawing.Size(46, 22);
            this.Num_CameraX.TabIndex = 57;
            this.Num_CameraX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Num_CameraY
            // 
            this.Num_CameraY.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Num_CameraY.Location = new System.Drawing.Point(192, 97);
            this.Num_CameraY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Num_CameraY.Name = "Num_CameraY";
            this.Num_CameraY.Size = new System.Drawing.Size(46, 22);
            this.Num_CameraY.TabIndex = 56;
            this.Num_CameraY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Num_CameraDistance
            // 
            this.Num_CameraDistance.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Num_CameraDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Num_CameraDistance.Location = new System.Drawing.Point(192, 67);
            this.Num_CameraDistance.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.Num_CameraDistance.Name = "Num_CameraDistance";
            this.Num_CameraDistance.Size = new System.Drawing.Size(46, 22);
            this.Num_CameraDistance.TabIndex = 55;
            this.Num_CameraDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CameraImage
            // 
            this.CameraImage.BackColor = System.Drawing.Color.Transparent;
            this.CameraImage.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Camera;
            this.CameraImage.Location = new System.Drawing.Point(3, 11);
            this.CameraImage.Name = "CameraImage";
            this.CameraImage.Size = new System.Drawing.Size(187, 187);
            this.CameraImage.TabIndex = 53;
            this.CameraImage.TabStop = false;
            // 
            // RPGTab
            // 
            this.RPGTab.BackColor = System.Drawing.Color.Transparent;
            this.RPGTab.Controls.Add(this.CB_AutoLoad);
            this.RPGTab.Controls.Add(this.groupBox1);
            this.RPGTab.Controls.Add(this.CB_NoSavesReplaySave);
            this.RPGTab.Controls.Add(this.CB_SavesReplayAutoSave);
            this.RPGTab.Controls.Add(this.CB_NewMapSaveFileAuto);
            this.RPGTab.Controls.Add(this.groupBox2);
            this.RPGTab.HorizontalScrollbar = true;
            this.RPGTab.HorizontalScrollbarBarColor = true;
            this.RPGTab.HorizontalScrollbarHighlightOnWheel = false;
            this.RPGTab.HorizontalScrollbarSize = 10;
            this.RPGTab.Location = new System.Drawing.Point(4, 36);
            this.RPGTab.Name = "RPGTab";
            this.RPGTab.Size = new System.Drawing.Size(632, 235);
            this.RPGTab.TabIndex = 0;
            this.RPGTab.Text = "세이브";
            this.RPGTab.VerticalScrollbar = true;
            this.RPGTab.VerticalScrollbarBarColor = true;
            this.RPGTab.VerticalScrollbarHighlightOnWheel = false;
            this.RPGTab.VerticalScrollbarSize = 10;
            // 
            // CB_AutoLoad
            // 
            this.CB_AutoLoad.AutoSize = true;
            this.CB_AutoLoad.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CB_AutoLoad.Location = new System.Drawing.Point(435, 8);
            this.CB_AutoLoad.Margin = new System.Windows.Forms.Padding(0);
            this.CB_AutoLoad.Name = "CB_AutoLoad";
            this.CB_AutoLoad.Size = new System.Drawing.Size(182, 19);
            this.CB_AutoLoad.TabIndex = 47;
            this.CB_AutoLoad.Text = "게임 시작시에 자동으로 로드";
            this.CB_AutoLoad.UseVisualStyleBackColor = true;
            this.CB_AutoLoad.CheckedChanged += new System.EventHandler(this.CB_AutoLoad_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_CommandPreset);
            this.groupBox1.Controls.Add(this.TabControl_CommandPreset);
            this.groupBox1.Location = new System.Drawing.Point(432, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 149);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // Label_CommandPreset
            // 
            this.Label_CommandPreset.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_CommandPreset.Location = new System.Drawing.Point(48, 10);
            this.Label_CommandPreset.Name = "Label_CommandPreset";
            this.Label_CommandPreset.Size = new System.Drawing.Size(104, 20);
            this.Label_CommandPreset.TabIndex = 46;
            this.Label_CommandPreset.Text = "명령어 프리셋";
            this.Label_CommandPreset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabControl_CommandPreset
            // 
            this.TabControl_CommandPreset.Controls.Add(this.TP_CommandPreset1);
            this.TabControl_CommandPreset.Controls.Add(this.TP_CommandPreset2);
            this.TabControl_CommandPreset.Controls.Add(this.TP_CommandPreset3);
            this.TabControl_CommandPreset.Location = new System.Drawing.Point(3, 30);
            this.TabControl_CommandPreset.Name = "TabControl_CommandPreset";
            this.TabControl_CommandPreset.Padding = new System.Drawing.Point(0, 0);
            this.TabControl_CommandPreset.SelectedIndex = 0;
            this.TabControl_CommandPreset.Size = new System.Drawing.Size(196, 116);
            this.TabControl_CommandPreset.TabIndex = 45;
            this.TabControl_CommandPreset.SelectedIndexChanged += new System.EventHandler(this.TabControl_CommandPreset_SelectedIndexChanged);
            // 
            // TP_CommandPreset1
            // 
            this.TP_CommandPreset1.Controls.Add(this.TB_CommandPreset1);
            this.TP_CommandPreset1.Location = new System.Drawing.Point(4, 22);
            this.TP_CommandPreset1.Name = "TP_CommandPreset1";
            this.TP_CommandPreset1.Padding = new System.Windows.Forms.Padding(3);
            this.TP_CommandPreset1.Size = new System.Drawing.Size(188, 90);
            this.TP_CommandPreset1.TabIndex = 0;
            this.TP_CommandPreset1.Text = "프리셋 1";
            this.TP_CommandPreset1.UseVisualStyleBackColor = true;
            // 
            // TB_CommandPreset1
            // 
            this.TB_CommandPreset1.Location = new System.Drawing.Point(0, 0);
            this.TB_CommandPreset1.Multiline = true;
            this.TB_CommandPreset1.Name = "TB_CommandPreset1";
            this.TB_CommandPreset1.Size = new System.Drawing.Size(188, 90);
            this.TB_CommandPreset1.TabIndex = 0;
            this.TB_CommandPreset1.TextChanged += new System.EventHandler(this.TB_CommandPreset1_TextChanged);
            // 
            // TP_CommandPreset2
            // 
            this.TP_CommandPreset2.Controls.Add(this.TB_CommandPreset2);
            this.TP_CommandPreset2.Location = new System.Drawing.Point(4, 22);
            this.TP_CommandPreset2.Name = "TP_CommandPreset2";
            this.TP_CommandPreset2.Padding = new System.Windows.Forms.Padding(3);
            this.TP_CommandPreset2.Size = new System.Drawing.Size(188, 90);
            this.TP_CommandPreset2.TabIndex = 1;
            this.TP_CommandPreset2.Text = "프리셋 2";
            this.TP_CommandPreset2.UseVisualStyleBackColor = true;
            // 
            // TB_CommandPreset2
            // 
            this.TB_CommandPreset2.Location = new System.Drawing.Point(0, 0);
            this.TB_CommandPreset2.Multiline = true;
            this.TB_CommandPreset2.Name = "TB_CommandPreset2";
            this.TB_CommandPreset2.Size = new System.Drawing.Size(188, 90);
            this.TB_CommandPreset2.TabIndex = 1;
            this.TB_CommandPreset2.TextChanged += new System.EventHandler(this.TB_CommandPreset2_TextChanged);
            // 
            // TP_CommandPreset3
            // 
            this.TP_CommandPreset3.Controls.Add(this.TB_CommandPreset3);
            this.TP_CommandPreset3.Location = new System.Drawing.Point(4, 22);
            this.TP_CommandPreset3.Name = "TP_CommandPreset3";
            this.TP_CommandPreset3.Padding = new System.Windows.Forms.Padding(3);
            this.TP_CommandPreset3.Size = new System.Drawing.Size(188, 90);
            this.TP_CommandPreset3.TabIndex = 2;
            this.TP_CommandPreset3.Text = "프리셋 3";
            this.TP_CommandPreset3.UseVisualStyleBackColor = true;
            // 
            // TB_CommandPreset3
            // 
            this.TB_CommandPreset3.Location = new System.Drawing.Point(0, 0);
            this.TB_CommandPreset3.Multiline = true;
            this.TB_CommandPreset3.Name = "TB_CommandPreset3";
            this.TB_CommandPreset3.Size = new System.Drawing.Size(188, 90);
            this.TB_CommandPreset3.TabIndex = 1;
            this.TB_CommandPreset3.TextChanged += new System.EventHandler(this.TB_CommandPreset3_TextChanged);
            // 
            // CB_NoSavesReplaySave
            // 
            this.CB_NoSavesReplaySave.AutoSize = true;
            this.CB_NoSavesReplaySave.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CB_NoSavesReplaySave.Location = new System.Drawing.Point(435, 65);
            this.CB_NoSavesReplaySave.Margin = new System.Windows.Forms.Padding(0);
            this.CB_NoSavesReplaySave.Name = "CB_NoSavesReplaySave";
            this.CB_NoSavesReplaySave.Size = new System.Drawing.Size(194, 19);
            this.CB_NoSavesReplaySave.TabIndex = 44;
            this.CB_NoSavesReplaySave.Text = "저장하지 않은 리플레이도 저장";
            this.CB_NoSavesReplaySave.UseVisualStyleBackColor = true;
            this.CB_NoSavesReplaySave.CheckedChanged += new System.EventHandler(this.NoSavesReplaySave_CheckedChanged);
            // 
            // CB_SavesReplayAutoSave
            // 
            this.CB_SavesReplayAutoSave.AutoSize = true;
            this.CB_SavesReplayAutoSave.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CB_SavesReplayAutoSave.Location = new System.Drawing.Point(435, 46);
            this.CB_SavesReplayAutoSave.Margin = new System.Windows.Forms.Padding(0);
            this.CB_SavesReplayAutoSave.Name = "CB_SavesReplayAutoSave";
            this.CB_SavesReplayAutoSave.Size = new System.Drawing.Size(197, 19);
            this.CB_SavesReplayAutoSave.TabIndex = 43;
            this.CB_SavesReplayAutoSave.Text = "세이브시, 리플레이도 자동 저장";
            this.CB_SavesReplayAutoSave.UseVisualStyleBackColor = true;
            this.CB_SavesReplayAutoSave.CheckedChanged += new System.EventHandler(this.SavesReplayAutoSave_CheckedChanged);
            // 
            // CB_NewMapSaveFileAuto
            // 
            this.CB_NewMapSaveFileAuto.AutoSize = true;
            this.CB_NewMapSaveFileAuto.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CB_NewMapSaveFileAuto.Location = new System.Drawing.Point(435, 27);
            this.CB_NewMapSaveFileAuto.Margin = new System.Windows.Forms.Padding(0);
            this.CB_NewMapSaveFileAuto.Name = "CB_NewMapSaveFileAuto";
            this.CB_NewMapSaveFileAuto.Size = new System.Drawing.Size(190, 19);
            this.CB_NewMapSaveFileAuto.TabIndex = 42;
            this.CB_NewMapSaveFileAuto.Text = "신규 맵 세이브 파일 자동 감지";
            this.CB_NewMapSaveFileAuto.UseVisualStyleBackColor = true;
            this.CB_NewMapSaveFileAuto.CheckedChanged += new System.EventHandler(this.NewMapSaveFileAutoSense_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BTN_Refresh);
            this.groupBox2.Controls.Add(this.Label_HeroList);
            this.groupBox2.Controls.Add(this.Label_RPGList);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.RPGListBox);
            this.groupBox2.Controls.Add(this.HeroListBox);
            this.groupBox2.Location = new System.Drawing.Point(0, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 230);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // BTN_Refresh
            // 
            this.BTN_Refresh.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_Refresh.Location = new System.Drawing.Point(3, 196);
            this.BTN_Refresh.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_Refresh.Name = "BTN_Refresh";
            this.BTN_Refresh.Size = new System.Drawing.Size(122, 29);
            this.BTN_Refresh.TabIndex = 59;
            this.BTN_Refresh.Text = "새로고침";
            this.BTN_Refresh.UseVisualStyleBackColor = true;
            this.BTN_Refresh.Click += new System.EventHandler(this.BTN_Refresh_Click);
            // 
            // Label_HeroList
            // 
            this.Label_HeroList.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_HeroList.Location = new System.Drawing.Point(126, 10);
            this.Label_HeroList.Name = "Label_HeroList";
            this.Label_HeroList.Size = new System.Drawing.Size(120, 30);
            this.Label_HeroList.TabIndex = 42;
            this.Label_HeroList.Text = "저장 분류 리스트";
            this.Label_HeroList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_RPGList
            // 
            this.Label_RPGList.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_RPGList.Location = new System.Drawing.Point(4, 10);
            this.Label_RPGList.Name = "Label_RPGList";
            this.Label_RPGList.Size = new System.Drawing.Size(120, 30);
            this.Label_RPGList.TabIndex = 42;
            this.Label_RPGList.Text = "RPG 리스트";
            this.Label_RPGList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BTN_HeroFolder);
            this.groupBox4.Controls.Add(this.Label_HeroName);
            this.groupBox4.Controls.Add(this.BTN_HeroDel);
            this.groupBox4.Controls.Add(this.BTN_HeroAddMod);
            this.groupBox4.Controls.Add(this.TB_HeroName);
            this.groupBox4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupBox4.Location = new System.Drawing.Point(249, 155);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 70);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "저장 분류 설정";
            // 
            // BTN_HeroFolder
            // 
            this.BTN_HeroFolder.Enabled = false;
            this.BTN_HeroFolder.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_HeroFolder.Location = new System.Drawing.Point(98, 40);
            this.BTN_HeroFolder.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_HeroFolder.Name = "BTN_HeroFolder";
            this.BTN_HeroFolder.Size = new System.Drawing.Size(74, 25);
            this.BTN_HeroFolder.TabIndex = 60;
            this.BTN_HeroFolder.Text = "폴더 열기";
            this.BTN_HeroFolder.UseVisualStyleBackColor = true;
            this.BTN_HeroFolder.Click += new System.EventHandler(this.BTN_HeroFolder_Click);
            // 
            // Label_HeroName
            // 
            this.Label_HeroName.AutoSize = true;
            this.Label_HeroName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_HeroName.Location = new System.Drawing.Point(4, 17);
            this.Label_HeroName.Name = "Label_HeroName";
            this.Label_HeroName.Size = new System.Drawing.Size(37, 19);
            this.Label_HeroName.TabIndex = 45;
            this.Label_HeroName.Text = "이름";
            // 
            // BTN_HeroDel
            // 
            this.BTN_HeroDel.Enabled = false;
            this.BTN_HeroDel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_HeroDel.Location = new System.Drawing.Point(51, 40);
            this.BTN_HeroDel.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_HeroDel.Name = "BTN_HeroDel";
            this.BTN_HeroDel.Size = new System.Drawing.Size(47, 25);
            this.BTN_HeroDel.TabIndex = 59;
            this.BTN_HeroDel.Text = "삭제";
            this.BTN_HeroDel.UseVisualStyleBackColor = true;
            this.BTN_HeroDel.Click += new System.EventHandler(this.BTN_HeroDel_Click);
            // 
            // BTN_HeroAddMod
            // 
            this.BTN_HeroAddMod.Enabled = false;
            this.BTN_HeroAddMod.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_HeroAddMod.Location = new System.Drawing.Point(4, 40);
            this.BTN_HeroAddMod.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_HeroAddMod.Name = "BTN_HeroAddMod";
            this.BTN_HeroAddMod.Size = new System.Drawing.Size(47, 25);
            this.BTN_HeroAddMod.TabIndex = 58;
            this.BTN_HeroAddMod.Text = "추가";
            this.BTN_HeroAddMod.UseVisualStyleBackColor = true;
            this.BTN_HeroAddMod.Click += new System.EventHandler(this.BTN_HeroAddMod_Click);
            // 
            // TB_HeroName
            // 
            // 
            // 
            // 
            this.TB_HeroName.CustomButton.Image = null;
            this.TB_HeroName.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TB_HeroName.CustomButton.Name = "";
            this.TB_HeroName.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_HeroName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_HeroName.CustomButton.TabIndex = 1;
            this.TB_HeroName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_HeroName.CustomButton.UseSelectable = true;
            this.TB_HeroName.CustomButton.Visible = false;
            this.TB_HeroName.Lines = new string[0];
            this.TB_HeroName.Location = new System.Drawing.Point(42, 16);
            this.TB_HeroName.Margin = new System.Windows.Forms.Padding(1);
            this.TB_HeroName.MaxLength = 100;
            this.TB_HeroName.Name = "TB_HeroName";
            this.TB_HeroName.PasswordChar = '\0';
            this.TB_HeroName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_HeroName.SelectedText = "";
            this.TB_HeroName.SelectionLength = 0;
            this.TB_HeroName.SelectionStart = 0;
            this.TB_HeroName.ShortcutsEnabled = true;
            this.TB_HeroName.Size = new System.Drawing.Size(130, 20);
            this.TB_HeroName.TabIndex = 43;
            this.TB_HeroName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_HeroName.UseSelectable = true;
            this.TB_HeroName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_HeroName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TB_HeroName.TextChanged += new System.EventHandler(this.TB_HeroName_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BTN_RPGSetRegex);
            this.groupBox3.Controls.Add(this.BTN_RPGFolder);
            this.groupBox3.Controls.Add(this.BTN_RPGDel);
            this.groupBox3.Controls.Add(this.BTN_RPGAddMod);
            this.groupBox3.Controls.Add(this.BTN_RPGPath);
            this.groupBox3.Controls.Add(this.Label_RPGPath);
            this.groupBox3.Controls.Add(this.Label_RPGEN);
            this.groupBox3.Controls.Add(this.TB_RPGPath);
            this.groupBox3.Controls.Add(this.Label_RPGKR);
            this.groupBox3.Controls.Add(this.TB_RPGEN);
            this.groupBox3.Controls.Add(this.TB_RPGKR);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupBox3.Location = new System.Drawing.Point(249, 9);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 141);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RPG 설정";
            // 
            // BTN_RPGSetRegex
            // 
            this.BTN_RPGSetRegex.Enabled = false;
            this.BTN_RPGSetRegex.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_RPGSetRegex.Location = new System.Drawing.Point(4, 111);
            this.BTN_RPGSetRegex.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RPGSetRegex.Name = "BTN_RPGSetRegex";
            this.BTN_RPGSetRegex.Size = new System.Drawing.Size(168, 25);
            this.BTN_RPGSetRegex.TabIndex = 60;
            this.BTN_RPGSetRegex.Text = "세이브 불러오기 형식 수정";
            this.BTN_RPGSetRegex.UseVisualStyleBackColor = true;
            this.BTN_RPGSetRegex.Click += new System.EventHandler(this.BTN_RPGSetRegex_Click);
            // 
            // BTN_RPGFolder
            // 
            this.BTN_RPGFolder.Enabled = false;
            this.BTN_RPGFolder.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_RPGFolder.Location = new System.Drawing.Point(98, 86);
            this.BTN_RPGFolder.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RPGFolder.Name = "BTN_RPGFolder";
            this.BTN_RPGFolder.Size = new System.Drawing.Size(74, 25);
            this.BTN_RPGFolder.TabIndex = 57;
            this.BTN_RPGFolder.Text = "폴더 열기";
            this.BTN_RPGFolder.UseVisualStyleBackColor = true;
            this.BTN_RPGFolder.Click += new System.EventHandler(this.BTN_RPGFolder_Click);
            // 
            // BTN_RPGDel
            // 
            this.BTN_RPGDel.Enabled = false;
            this.BTN_RPGDel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_RPGDel.Location = new System.Drawing.Point(51, 86);
            this.BTN_RPGDel.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RPGDel.Name = "BTN_RPGDel";
            this.BTN_RPGDel.Size = new System.Drawing.Size(47, 25);
            this.BTN_RPGDel.TabIndex = 56;
            this.BTN_RPGDel.Text = "제거";
            this.BTN_RPGDel.UseVisualStyleBackColor = true;
            this.BTN_RPGDel.Click += new System.EventHandler(this.BTN_RPGDel_Click);
            // 
            // BTN_RPGAddMod
            // 
            this.BTN_RPGAddMod.Enabled = false;
            this.BTN_RPGAddMod.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_RPGAddMod.Location = new System.Drawing.Point(4, 86);
            this.BTN_RPGAddMod.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RPGAddMod.Name = "BTN_RPGAddMod";
            this.BTN_RPGAddMod.Size = new System.Drawing.Size(47, 25);
            this.BTN_RPGAddMod.TabIndex = 55;
            this.BTN_RPGAddMod.Text = "추가";
            this.BTN_RPGAddMod.UseVisualStyleBackColor = true;
            this.BTN_RPGAddMod.Click += new System.EventHandler(this.BTN_RPGAddMod_Click);
            // 
            // BTN_RPGPath
            // 
            this.BTN_RPGPath.Enabled = false;
            this.BTN_RPGPath.Font = new System.Drawing.Font("굴림", 8F);
            this.BTN_RPGPath.Location = new System.Drawing.Point(150, 61);
            this.BTN_RPGPath.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_RPGPath.Name = "BTN_RPGPath";
            this.BTN_RPGPath.Size = new System.Drawing.Size(22, 22);
            this.BTN_RPGPath.TabIndex = 54;
            this.BTN_RPGPath.Text = "...";
            this.BTN_RPGPath.UseVisualStyleBackColor = true;
            this.BTN_RPGPath.Click += new System.EventHandler(this.BTN_RPGPath_Click);
            // 
            // Label_RPGPath
            // 
            this.Label_RPGPath.AutoSize = true;
            this.Label_RPGPath.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_RPGPath.Location = new System.Drawing.Point(4, 62);
            this.Label_RPGPath.Name = "Label_RPGPath";
            this.Label_RPGPath.Size = new System.Drawing.Size(37, 19);
            this.Label_RPGPath.TabIndex = 44;
            this.Label_RPGPath.Text = "경로";
            // 
            // Label_RPGEN
            // 
            this.Label_RPGEN.AutoSize = true;
            this.Label_RPGEN.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_RPGEN.Location = new System.Drawing.Point(4, 39);
            this.Label_RPGEN.Name = "Label_RPGEN";
            this.Label_RPGEN.Size = new System.Drawing.Size(37, 19);
            this.Label_RPGEN.TabIndex = 43;
            this.Label_RPGEN.Text = "영문";
            // 
            // TB_RPGPath
            // 
            // 
            // 
            // 
            this.TB_RPGPath.CustomButton.Image = null;
            this.TB_RPGPath.CustomButton.Location = new System.Drawing.Point(91, 2);
            this.TB_RPGPath.CustomButton.Name = "";
            this.TB_RPGPath.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_RPGPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_RPGPath.CustomButton.TabIndex = 1;
            this.TB_RPGPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_RPGPath.CustomButton.UseSelectable = true;
            this.TB_RPGPath.CustomButton.Visible = false;
            this.TB_RPGPath.Enabled = false;
            this.TB_RPGPath.Lines = new string[0];
            this.TB_RPGPath.Location = new System.Drawing.Point(42, 62);
            this.TB_RPGPath.Margin = new System.Windows.Forms.Padding(1);
            this.TB_RPGPath.MaxLength = 260;
            this.TB_RPGPath.Name = "TB_RPGPath";
            this.TB_RPGPath.PasswordChar = '\0';
            this.TB_RPGPath.ReadOnly = true;
            this.TB_RPGPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_RPGPath.SelectedText = "";
            this.TB_RPGPath.SelectionLength = 0;
            this.TB_RPGPath.SelectionStart = 0;
            this.TB_RPGPath.ShortcutsEnabled = true;
            this.TB_RPGPath.Size = new System.Drawing.Size(109, 20);
            this.TB_RPGPath.TabIndex = 52;
            this.TB_RPGPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_RPGPath.UseSelectable = true;
            this.TB_RPGPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_RPGPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Label_RPGKR
            // 
            this.Label_RPGKR.AutoSize = true;
            this.Label_RPGKR.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_RPGKR.Location = new System.Drawing.Point(4, 16);
            this.Label_RPGKR.Name = "Label_RPGKR";
            this.Label_RPGKR.Size = new System.Drawing.Size(37, 19);
            this.Label_RPGKR.TabIndex = 42;
            this.Label_RPGKR.Text = "한글";
            // 
            // TB_RPGEN
            // 
            // 
            // 
            // 
            this.TB_RPGEN.CustomButton.Image = null;
            this.TB_RPGEN.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TB_RPGEN.CustomButton.Name = "";
            this.TB_RPGEN.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_RPGEN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_RPGEN.CustomButton.TabIndex = 1;
            this.TB_RPGEN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_RPGEN.CustomButton.UseSelectable = true;
            this.TB_RPGEN.CustomButton.Visible = false;
            this.TB_RPGEN.Enabled = false;
            this.TB_RPGEN.Lines = new string[0];
            this.TB_RPGEN.Location = new System.Drawing.Point(42, 39);
            this.TB_RPGEN.Margin = new System.Windows.Forms.Padding(1);
            this.TB_RPGEN.MaxLength = 100;
            this.TB_RPGEN.Name = "TB_RPGEN";
            this.TB_RPGEN.PasswordChar = '\0';
            this.TB_RPGEN.ReadOnly = true;
            this.TB_RPGEN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_RPGEN.SelectedText = "";
            this.TB_RPGEN.SelectionLength = 0;
            this.TB_RPGEN.SelectionStart = 0;
            this.TB_RPGEN.ShortcutsEnabled = true;
            this.TB_RPGEN.Size = new System.Drawing.Size(130, 20);
            this.TB_RPGEN.TabIndex = 50;
            this.TB_RPGEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_RPGEN.UseSelectable = true;
            this.TB_RPGEN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_RPGEN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TB_RPGKR
            // 
            // 
            // 
            // 
            this.TB_RPGKR.CustomButton.Image = null;
            this.TB_RPGKR.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TB_RPGKR.CustomButton.Name = "";
            this.TB_RPGKR.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_RPGKR.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_RPGKR.CustomButton.TabIndex = 1;
            this.TB_RPGKR.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_RPGKR.CustomButton.UseSelectable = true;
            this.TB_RPGKR.CustomButton.Visible = false;
            this.TB_RPGKR.Enabled = false;
            this.TB_RPGKR.Lines = new string[0];
            this.TB_RPGKR.Location = new System.Drawing.Point(42, 16);
            this.TB_RPGKR.Margin = new System.Windows.Forms.Padding(1);
            this.TB_RPGKR.MaxLength = 100;
            this.TB_RPGKR.Name = "TB_RPGKR";
            this.TB_RPGKR.PasswordChar = '\0';
            this.TB_RPGKR.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_RPGKR.SelectedText = "";
            this.TB_RPGKR.SelectionLength = 0;
            this.TB_RPGKR.SelectionStart = 0;
            this.TB_RPGKR.ShortcutsEnabled = true;
            this.TB_RPGKR.Size = new System.Drawing.Size(130, 20);
            this.TB_RPGKR.TabIndex = 48;
            this.TB_RPGKR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_RPGKR.UseSelectable = true;
            this.TB_RPGKR.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_RPGKR.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // RPGListBox
            // 
            this.RPGListBox.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RPGListBox.ItemHeight = 15;
            this.RPGListBox.Location = new System.Drawing.Point(4, 40);
            this.RPGListBox.Margin = new System.Windows.Forms.Padding(1);
            this.RPGListBox.Name = "RPGListBox";
            this.RPGListBox.Size = new System.Drawing.Size(120, 154);
            this.RPGListBox.Sorted = true;
            this.RPGListBox.TabIndex = 38;
            this.RPGListBox.SelectedIndexChanged += new System.EventHandler(this.RPGListBox_SelectedIndexChanged);
            // 
            // HeroListBox
            // 
            this.HeroListBox.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.HeroListBox.ItemHeight = 15;
            this.HeroListBox.Location = new System.Drawing.Point(126, 40);
            this.HeroListBox.Margin = new System.Windows.Forms.Padding(1);
            this.HeroListBox.Name = "HeroListBox";
            this.HeroListBox.Size = new System.Drawing.Size(120, 184);
            this.HeroListBox.Sorted = true;
            this.HeroListBox.TabIndex = 39;
            this.HeroListBox.SelectedIndexChanged += new System.EventHandler(this.HeroListBox_SelectedIndexChanged);
            // 
            // MacroTab
            // 
            this.MacroTab.Controls.Add(this.GB_AutoMouse);
            this.MacroTab.Controls.Add(this.GB_ChatMacro);
            this.MacroTab.Controls.Add(this.GB_SmartKey);
            this.MacroTab.Controls.Add(this.GB_KeyReMap);
            this.MacroTab.HorizontalScrollbarBarColor = true;
            this.MacroTab.HorizontalScrollbarHighlightOnWheel = false;
            this.MacroTab.HorizontalScrollbarSize = 10;
            this.MacroTab.Location = new System.Drawing.Point(4, 36);
            this.MacroTab.Name = "MacroTab";
            this.MacroTab.Size = new System.Drawing.Size(632, 235);
            this.MacroTab.TabIndex = 1;
            this.MacroTab.Text = "매크로";
            this.MacroTab.VerticalScrollbarBarColor = true;
            this.MacroTab.VerticalScrollbarHighlightOnWheel = false;
            this.MacroTab.VerticalScrollbarSize = 10;
            // 
            // GB_AutoMouse
            // 
            this.GB_AutoMouse.BackColor = System.Drawing.Color.White;
            this.GB_AutoMouse.Controls.Add(this.Label_Border);
            this.GB_AutoMouse.Controls.Add(this.TrB_AutoMouseDelay);
            this.GB_AutoMouse.Controls.Add(this.Label_AutoMouseDelay);
            this.GB_AutoMouse.Controls.Add(this.Label_AutoRightMouseOn);
            this.GB_AutoMouse.Controls.Add(this.BTN_AutoRightMouseOn);
            this.GB_AutoMouse.Controls.Add(this.Toggle_AutoMouse);
            this.GB_AutoMouse.Controls.Add(this.Label_AutoMouseOff);
            this.GB_AutoMouse.Controls.Add(this.BTN_AutoMouseOff);
            this.GB_AutoMouse.Controls.Add(this.Label_AutoLeftMouseOn);
            this.GB_AutoMouse.Controls.Add(this.BTN_AutoLeftMouseOn);
            this.GB_AutoMouse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GB_AutoMouse.Location = new System.Drawing.Point(442, 153);
            this.GB_AutoMouse.Name = "GB_AutoMouse";
            this.GB_AutoMouse.Size = new System.Drawing.Size(190, 80);
            this.GB_AutoMouse.TabIndex = 35;
            this.GB_AutoMouse.TabStop = false;
            this.GB_AutoMouse.Text = "오토마우스";
            // 
            // Label_Border
            // 
            this.Label_Border.BackColor = System.Drawing.Color.Silver;
            this.Label_Border.Location = new System.Drawing.Point(95, 12);
            this.Label_Border.Name = "Label_Border";
            this.Label_Border.Size = new System.Drawing.Size(1, 26);
            this.Label_Border.TabIndex = 100;
            // 
            // TrB_AutoMouseDelay
            // 
            this.TrB_AutoMouseDelay.AutoSize = false;
            this.TrB_AutoMouseDelay.LargeChange = 100;
            this.TrB_AutoMouseDelay.Location = new System.Drawing.Point(1, 54);
            this.TrB_AutoMouseDelay.Maximum = 1000;
            this.TrB_AutoMouseDelay.Minimum = 1;
            this.TrB_AutoMouseDelay.Name = "TrB_AutoMouseDelay";
            this.TrB_AutoMouseDelay.Size = new System.Drawing.Size(188, 23);
            this.TrB_AutoMouseDelay.SmallChange = 10;
            this.TrB_AutoMouseDelay.TabIndex = 0;
            this.TrB_AutoMouseDelay.TickFrequency = 100;
            this.TrB_AutoMouseDelay.Value = 10;
            this.TrB_AutoMouseDelay.ValueChanged += new System.EventHandler(this.TrB_AutoMouseDelay_ValueChanged);
            // 
            // Label_AutoMouseDelay
            // 
            this.Label_AutoMouseDelay.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoMouseDelay.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.Label_AutoMouseDelay.Location = new System.Drawing.Point(126, 40);
            this.Label_AutoMouseDelay.Name = "Label_AutoMouseDelay";
            this.Label_AutoMouseDelay.Size = new System.Drawing.Size(60, 16);
            this.Label_AutoMouseDelay.TabIndex = 99;
            this.Label_AutoMouseDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_AutoRightMouseOn
            // 
            this.Label_AutoRightMouseOn.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoRightMouseOn.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.Label_AutoRightMouseOn.Location = new System.Drawing.Point(97, 17);
            this.Label_AutoRightMouseOn.Name = "Label_AutoRightMouseOn";
            this.Label_AutoRightMouseOn.Size = new System.Drawing.Size(50, 16);
            this.Label_AutoRightMouseOn.TabIndex = 98;
            this.Label_AutoRightMouseOn.Text = "없음";
            this.Label_AutoRightMouseOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BTN_AutoRightMouseOn
            // 
            this.BTN_AutoRightMouseOn.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_AutoRightMouseOn.Location = new System.Drawing.Point(147, 15);
            this.BTN_AutoRightMouseOn.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_AutoRightMouseOn.Name = "BTN_AutoRightMouseOn";
            this.BTN_AutoRightMouseOn.Size = new System.Drawing.Size(40, 20);
            this.BTN_AutoRightMouseOn.TabIndex = 97;
            this.BTN_AutoRightMouseOn.Text = "우클";
            this.BTN_AutoRightMouseOn.UseVisualStyleBackColor = true;
            this.BTN_AutoRightMouseOn.Click += new System.EventHandler(this.BTN_AutoRightMouseOn_Click);
            this.BTN_AutoRightMouseOn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AutoMouse_PreviewKeyDown);
            // 
            // Toggle_AutoMouse
            // 
            this.Toggle_AutoMouse.Location = new System.Drawing.Point(120, 0);
            this.Toggle_AutoMouse.Name = "Toggle_AutoMouse";
            this.Toggle_AutoMouse.Size = new System.Drawing.Size(70, 15);
            this.Toggle_AutoMouse.TabIndex = 39;
            this.Toggle_AutoMouse.Text = "Off";
            this.Toggle_AutoMouse.UseSelectable = true;
            this.Toggle_AutoMouse.CheckedChanged += new System.EventHandler(this.Toggle_AutoMouse_CheckedChanged);
            // 
            // Label_AutoMouseOff
            // 
            this.Label_AutoMouseOff.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoMouseOff.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.Label_AutoMouseOff.Location = new System.Drawing.Point(43, 36);
            this.Label_AutoMouseOff.Name = "Label_AutoMouseOff";
            this.Label_AutoMouseOff.Size = new System.Drawing.Size(50, 16);
            this.Label_AutoMouseOff.TabIndex = 96;
            this.Label_AutoMouseOff.Text = "없음";
            this.Label_AutoMouseOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BTN_AutoMouseOff
            // 
            this.BTN_AutoMouseOff.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_AutoMouseOff.Location = new System.Drawing.Point(3, 34);
            this.BTN_AutoMouseOff.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_AutoMouseOff.Name = "BTN_AutoMouseOff";
            this.BTN_AutoMouseOff.Size = new System.Drawing.Size(40, 20);
            this.BTN_AutoMouseOff.TabIndex = 95;
            this.BTN_AutoMouseOff.Text = "종료";
            this.BTN_AutoMouseOff.UseVisualStyleBackColor = true;
            this.BTN_AutoMouseOff.Click += new System.EventHandler(this.BTN_AutoMouseOff_Click);
            this.BTN_AutoMouseOff.Leave += new System.EventHandler(this.BTN_AutoMouse_Leave);
            this.BTN_AutoMouseOff.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AutoMouse_PreviewKeyDown);
            // 
            // Label_AutoLeftMouseOn
            // 
            this.Label_AutoLeftMouseOn.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoLeftMouseOn.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.Label_AutoLeftMouseOn.Location = new System.Drawing.Point(43, 17);
            this.Label_AutoLeftMouseOn.Name = "Label_AutoLeftMouseOn";
            this.Label_AutoLeftMouseOn.Size = new System.Drawing.Size(50, 16);
            this.Label_AutoLeftMouseOn.TabIndex = 94;
            this.Label_AutoLeftMouseOn.Text = "없음";
            this.Label_AutoLeftMouseOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BTN_AutoLeftMouseOn
            // 
            this.BTN_AutoLeftMouseOn.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_AutoLeftMouseOn.Location = new System.Drawing.Point(3, 15);
            this.BTN_AutoLeftMouseOn.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_AutoLeftMouseOn.Name = "BTN_AutoLeftMouseOn";
            this.BTN_AutoLeftMouseOn.Size = new System.Drawing.Size(40, 20);
            this.BTN_AutoLeftMouseOn.TabIndex = 93;
            this.BTN_AutoLeftMouseOn.Text = "좌클";
            this.BTN_AutoLeftMouseOn.UseVisualStyleBackColor = true;
            this.BTN_AutoLeftMouseOn.Click += new System.EventHandler(this.BTN_AutoLeftMouseOn_Click);
            this.BTN_AutoLeftMouseOn.Leave += new System.EventHandler(this.BTN_AutoMouse_Leave);
            this.BTN_AutoLeftMouseOn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AutoMouse_PreviewKeyDown);
            // 
            // GB_ChatMacro
            // 
            this.GB_ChatMacro.BackColor = System.Drawing.Color.White;
            this.GB_ChatMacro.Controls.Add(this.Toggle_ChatMacro);
            this.GB_ChatMacro.Controls.Add(this.Label_ChatHotkey);
            this.GB_ChatMacro.Controls.Add(this.BTN_SetChatHotkey);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat8);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat0);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat9);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat7);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat4);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat2);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat6);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat5);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat3);
            this.GB_ChatMacro.Controls.Add(this.RB_Chat1);
            this.GB_ChatMacro.Controls.Add(this.Label_ChatMacro);
            this.GB_ChatMacro.Controls.Add(this.TB_ChatMacro);
            this.GB_ChatMacro.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GB_ChatMacro.Location = new System.Drawing.Point(0, 153);
            this.GB_ChatMacro.Name = "GB_ChatMacro";
            this.GB_ChatMacro.Size = new System.Drawing.Size(435, 80);
            this.GB_ChatMacro.TabIndex = 34;
            this.GB_ChatMacro.TabStop = false;
            this.GB_ChatMacro.Text = "채팅 단축키";
            // 
            // Toggle_ChatMacro
            // 
            this.Toggle_ChatMacro.Location = new System.Drawing.Point(365, 0);
            this.Toggle_ChatMacro.Name = "Toggle_ChatMacro";
            this.Toggle_ChatMacro.Size = new System.Drawing.Size(70, 15);
            this.Toggle_ChatMacro.TabIndex = 93;
            this.Toggle_ChatMacro.Text = "Off";
            this.Toggle_ChatMacro.UseSelectable = true;
            this.Toggle_ChatMacro.CheckedChanged += new System.EventHandler(this.Toggle_ChatMacro_CheckedChanged);
            // 
            // Label_ChatHotkey
            // 
            this.Label_ChatHotkey.BackColor = System.Drawing.Color.Transparent;
            this.Label_ChatHotkey.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Label_ChatHotkey.Location = new System.Drawing.Point(274, 23);
            this.Label_ChatHotkey.Name = "Label_ChatHotkey";
            this.Label_ChatHotkey.Size = new System.Drawing.Size(70, 17);
            this.Label_ChatHotkey.TabIndex = 92;
            this.Label_ChatHotkey.Text = "없음";
            this.Label_ChatHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BTN_SetChatHotkey
            // 
            this.BTN_SetChatHotkey.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BTN_SetChatHotkey.Location = new System.Drawing.Point(344, 20);
            this.BTN_SetChatHotkey.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_SetChatHotkey.Name = "BTN_SetChatHotkey";
            this.BTN_SetChatHotkey.Size = new System.Drawing.Size(87, 23);
            this.BTN_SetChatHotkey.TabIndex = 91;
            this.BTN_SetChatHotkey.Text = "단축키 지정";
            this.BTN_SetChatHotkey.UseVisualStyleBackColor = true;
            this.BTN_SetChatHotkey.Click += new System.EventHandler(this.BTN_SetChatHotkey_Click);
            this.BTN_SetChatHotkey.Leave += new System.EventHandler(this.BTN_SetChatHotkey_Leave);
            this.BTN_SetChatHotkey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BTN_SetChatHotkey_PreviewKeyDown);
            // 
            // RB_Chat8
            // 
            this.RB_Chat8.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat8.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat8.Location = new System.Drawing.Point(189, 19);
            this.RB_Chat8.Name = "RB_Chat8";
            this.RB_Chat8.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat8.TabIndex = 88;
            this.RB_Chat8.Text = "8";
            this.RB_Chat8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat8.UseVisualStyleBackColor = true;
            this.RB_Chat8.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat0
            // 
            this.RB_Chat0.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat0.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat0.Location = new System.Drawing.Point(241, 19);
            this.RB_Chat0.Name = "RB_Chat0";
            this.RB_Chat0.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat0.TabIndex = 87;
            this.RB_Chat0.Text = "0";
            this.RB_Chat0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat0.UseVisualStyleBackColor = true;
            this.RB_Chat0.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat9
            // 
            this.RB_Chat9.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat9.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat9.Location = new System.Drawing.Point(215, 19);
            this.RB_Chat9.Name = "RB_Chat9";
            this.RB_Chat9.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat9.TabIndex = 86;
            this.RB_Chat9.Text = "9";
            this.RB_Chat9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat9.UseVisualStyleBackColor = true;
            this.RB_Chat9.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat7
            // 
            this.RB_Chat7.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat7.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat7.Location = new System.Drawing.Point(163, 19);
            this.RB_Chat7.Name = "RB_Chat7";
            this.RB_Chat7.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat7.TabIndex = 85;
            this.RB_Chat7.Text = "7";
            this.RB_Chat7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat7.UseVisualStyleBackColor = true;
            this.RB_Chat7.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat4
            // 
            this.RB_Chat4.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat4.Location = new System.Drawing.Point(85, 19);
            this.RB_Chat4.Name = "RB_Chat4";
            this.RB_Chat4.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat4.TabIndex = 84;
            this.RB_Chat4.Text = "4";
            this.RB_Chat4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat4.UseVisualStyleBackColor = true;
            this.RB_Chat4.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat2
            // 
            this.RB_Chat2.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat2.Location = new System.Drawing.Point(32, 19);
            this.RB_Chat2.Name = "RB_Chat2";
            this.RB_Chat2.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat2.TabIndex = 83;
            this.RB_Chat2.Text = "2";
            this.RB_Chat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat2.UseVisualStyleBackColor = true;
            this.RB_Chat2.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat6
            // 
            this.RB_Chat6.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat6.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat6.Location = new System.Drawing.Point(137, 19);
            this.RB_Chat6.Name = "RB_Chat6";
            this.RB_Chat6.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat6.TabIndex = 82;
            this.RB_Chat6.Text = "6";
            this.RB_Chat6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat6.UseVisualStyleBackColor = true;
            this.RB_Chat6.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat5
            // 
            this.RB_Chat5.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat5.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat5.Location = new System.Drawing.Point(111, 19);
            this.RB_Chat5.Name = "RB_Chat5";
            this.RB_Chat5.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat5.TabIndex = 81;
            this.RB_Chat5.Text = "5";
            this.RB_Chat5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat5.UseVisualStyleBackColor = true;
            this.RB_Chat5.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat3
            // 
            this.RB_Chat3.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat3.Location = new System.Drawing.Point(59, 19);
            this.RB_Chat3.Name = "RB_Chat3";
            this.RB_Chat3.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat3.TabIndex = 80;
            this.RB_Chat3.Text = "3";
            this.RB_Chat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat3.UseVisualStyleBackColor = true;
            this.RB_Chat3.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // RB_Chat1
            // 
            this.RB_Chat1.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Chat1.Checked = true;
            this.RB_Chat1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Chat1.Location = new System.Drawing.Point(6, 19);
            this.RB_Chat1.Name = "RB_Chat1";
            this.RB_Chat1.Size = new System.Drawing.Size(25, 25);
            this.RB_Chat1.TabIndex = 79;
            this.RB_Chat1.TabStop = true;
            this.RB_Chat1.Text = "1";
            this.RB_Chat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Chat1.UseVisualStyleBackColor = true;
            this.RB_Chat1.CheckedChanged += new System.EventHandler(this.RB_Chat_CheckedChanged);
            // 
            // Label_ChatMacro
            // 
            this.Label_ChatMacro.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_ChatMacro.Location = new System.Drawing.Point(3, 53);
            this.Label_ChatMacro.Name = "Label_ChatMacro";
            this.Label_ChatMacro.Size = new System.Drawing.Size(37, 20);
            this.Label_ChatMacro.TabIndex = 49;
            this.Label_ChatMacro.Text = "채팅";
            this.Label_ChatMacro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_ChatMacro
            // 
            // 
            // 
            // 
            this.TB_ChatMacro.CustomButton.Image = null;
            this.TB_ChatMacro.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.TB_ChatMacro.CustomButton.Name = "";
            this.TB_ChatMacro.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.TB_ChatMacro.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TB_ChatMacro.CustomButton.TabIndex = 1;
            this.TB_ChatMacro.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TB_ChatMacro.CustomButton.UseSelectable = true;
            this.TB_ChatMacro.CustomButton.Visible = false;
            this.TB_ChatMacro.Lines = new string[0];
            this.TB_ChatMacro.Location = new System.Drawing.Point(41, 53);
            this.TB_ChatMacro.Margin = new System.Windows.Forms.Padding(1);
            this.TB_ChatMacro.MaxLength = 127;
            this.TB_ChatMacro.Name = "TB_ChatMacro";
            this.TB_ChatMacro.PasswordChar = '\0';
            this.TB_ChatMacro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TB_ChatMacro.SelectedText = "";
            this.TB_ChatMacro.SelectionLength = 0;
            this.TB_ChatMacro.SelectionStart = 0;
            this.TB_ChatMacro.ShortcutsEnabled = true;
            this.TB_ChatMacro.Size = new System.Drawing.Size(390, 20);
            this.TB_ChatMacro.TabIndex = 50;
            this.TB_ChatMacro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_ChatMacro.UseSelectable = true;
            this.TB_ChatMacro.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TB_ChatMacro.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TB_ChatMacro.TextChanged += new System.EventHandler(this.TB_ChatMacro_TextChanged);
            // 
            // GB_SmartKey
            // 
            this.GB_SmartKey.BackColor = System.Drawing.Color.Transparent;
            this.GB_SmartKey.Controls.Add(this.GB_SmartKeyPrevention);
            this.GB_SmartKey.Controls.Add(this.Qbutton);
            this.GB_SmartKey.Controls.Add(this.Wbutton);
            this.GB_SmartKey.Controls.Add(this.Ebutton);
            this.GB_SmartKey.Controls.Add(this.Rbutton);
            this.GB_SmartKey.Controls.Add(this.Tbutton);
            this.GB_SmartKey.Controls.Add(this.Abutton);
            this.GB_SmartKey.Controls.Add(this.Dbutton);
            this.GB_SmartKey.Controls.Add(this.Fbutton);
            this.GB_SmartKey.Controls.Add(this.Gbutton);
            this.GB_SmartKey.Controls.Add(this.Zbutton);
            this.GB_SmartKey.Controls.Add(this.Xbutton);
            this.GB_SmartKey.Controls.Add(this.Cbutton);
            this.GB_SmartKey.Controls.Add(this.Vbutton);
            this.GB_SmartKey.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GB_SmartKey.Location = new System.Drawing.Point(285, 3);
            this.GB_SmartKey.Name = "GB_SmartKey";
            this.GB_SmartKey.Size = new System.Drawing.Size(347, 142);
            this.GB_SmartKey.TabIndex = 32;
            this.GB_SmartKey.TabStop = false;
            this.GB_SmartKey.Text = "스마트키";
            // 
            // GB_SmartKeyPrevention
            // 
            this.GB_SmartKeyPrevention.Controls.Add(this.RB_Prev4);
            this.GB_SmartKeyPrevention.Controls.Add(this.RB_Prev2);
            this.GB_SmartKeyPrevention.Controls.Add(this.Label_ClickPrevention);
            this.GB_SmartKeyPrevention.Controls.Add(this.RB_Prev3);
            this.GB_SmartKeyPrevention.Controls.Add(this.RB_Prev1);
            this.GB_SmartKeyPrevention.Location = new System.Drawing.Point(217, 0);
            this.GB_SmartKeyPrevention.Name = "GB_SmartKeyPrevention";
            this.GB_SmartKeyPrevention.Size = new System.Drawing.Size(130, 142);
            this.GB_SmartKeyPrevention.TabIndex = 47;
            this.GB_SmartKeyPrevention.TabStop = false;
            // 
            // RB_Prev4
            // 
            this.RB_Prev4.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Prev4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Prev4.Location = new System.Drawing.Point(5, 111);
            this.RB_Prev4.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Prev4.Name = "RB_Prev4";
            this.RB_Prev4.Size = new System.Drawing.Size(120, 25);
            this.RB_Prev4.TabIndex = 87;
            this.RB_Prev4.Text = "9,0번키를 사용 함";
            this.RB_Prev4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Prev4.UseVisualStyleBackColor = true;
            this.RB_Prev4.CheckedChanged += new System.EventHandler(this.RB_Prev_CheckedChanged);
            // 
            // RB_Prev2
            // 
            this.RB_Prev2.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Prev2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Prev2.Location = new System.Drawing.Point(5, 49);
            this.RB_Prev2.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Prev2.Name = "RB_Prev2";
            this.RB_Prev2.Size = new System.Drawing.Size(120, 25);
            this.RB_Prev2.TabIndex = 86;
            this.RB_Prev2.Text = "ESC키 누름";
            this.RB_Prev2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Prev2.UseVisualStyleBackColor = true;
            this.RB_Prev2.CheckedChanged += new System.EventHandler(this.RB_Prev_CheckedChanged);
            // 
            // Label_ClickPrevention
            // 
            this.Label_ClickPrevention.BackColor = System.Drawing.Color.White;
            this.Label_ClickPrevention.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_ClickPrevention.Location = new System.Drawing.Point(7, 0);
            this.Label_ClickPrevention.Name = "Label_ClickPrevention";
            this.Label_ClickPrevention.Size = new System.Drawing.Size(71, 15);
            this.Label_ClickPrevention.TabIndex = 46;
            this.Label_ClickPrevention.Text = "오클릭 방지";
            this.Label_ClickPrevention.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RB_Prev3
            // 
            this.RB_Prev3.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Prev3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Prev3.Location = new System.Drawing.Point(5, 80);
            this.RB_Prev3.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Prev3.Name = "RB_Prev3";
            this.RB_Prev3.Size = new System.Drawing.Size(120, 25);
            this.RB_Prev3.TabIndex = 85;
            this.RB_Prev3.Text = "부대지정 1키 누름";
            this.RB_Prev3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Prev3.UseVisualStyleBackColor = true;
            this.RB_Prev3.CheckedChanged += new System.EventHandler(this.RB_Prev_CheckedChanged);
            // 
            // RB_Prev1
            // 
            this.RB_Prev1.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Prev1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RB_Prev1.Location = new System.Drawing.Point(5, 18);
            this.RB_Prev1.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Prev1.Name = "RB_Prev1";
            this.RB_Prev1.Size = new System.Drawing.Size(120, 25);
            this.RB_Prev1.TabIndex = 84;
            this.RB_Prev1.Text = "사용 안 함";
            this.RB_Prev1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Prev1.UseVisualStyleBackColor = true;
            this.RB_Prev1.CheckedChanged += new System.EventHandler(this.RB_Prev_CheckedChanged);
            // 
            // Qbutton
            // 
            this.Qbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Qbutton;
            this.Qbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Qbutton.Location = new System.Drawing.Point(2, 17);
            this.Qbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Qbutton.Name = "Qbutton";
            this.Qbutton.Size = new System.Drawing.Size(40, 40);
            this.Qbutton.TabIndex = 8;
            this.Qbutton.UseSelectable = true;
            this.Qbutton.Click += new System.EventHandler(this.Qbutton_Click);
            // 
            // Wbutton
            // 
            this.Wbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Wbutton;
            this.Wbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Wbutton.Location = new System.Drawing.Point(43, 17);
            this.Wbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Wbutton.Name = "Wbutton";
            this.Wbutton.Size = new System.Drawing.Size(40, 40);
            this.Wbutton.TabIndex = 14;
            this.Wbutton.UseSelectable = true;
            this.Wbutton.Click += new System.EventHandler(this.Wbutton_Click);
            // 
            // Ebutton
            // 
            this.Ebutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Ebutton;
            this.Ebutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Ebutton.Location = new System.Drawing.Point(84, 17);
            this.Ebutton.Margin = new System.Windows.Forms.Padding(1);
            this.Ebutton.Name = "Ebutton";
            this.Ebutton.Size = new System.Drawing.Size(40, 40);
            this.Ebutton.TabIndex = 15;
            this.Ebutton.UseSelectable = true;
            this.Ebutton.Click += new System.EventHandler(this.Ebutton_Click);
            // 
            // Rbutton
            // 
            this.Rbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Rbutton;
            this.Rbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Rbutton.Location = new System.Drawing.Point(125, 17);
            this.Rbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Rbutton.Name = "Rbutton";
            this.Rbutton.Size = new System.Drawing.Size(40, 40);
            this.Rbutton.TabIndex = 16;
            this.Rbutton.UseSelectable = true;
            this.Rbutton.Click += new System.EventHandler(this.Rbutton_Click);
            // 
            // Tbutton
            // 
            this.Tbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Tbutton;
            this.Tbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Tbutton.Location = new System.Drawing.Point(166, 17);
            this.Tbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Tbutton.Name = "Tbutton";
            this.Tbutton.Size = new System.Drawing.Size(40, 40);
            this.Tbutton.TabIndex = 18;
            this.Tbutton.UseSelectable = true;
            this.Tbutton.Click += new System.EventHandler(this.Tbutton_Click);
            // 
            // Abutton
            // 
            this.Abutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Abutton;
            this.Abutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Abutton.Location = new System.Drawing.Point(12, 58);
            this.Abutton.Margin = new System.Windows.Forms.Padding(1);
            this.Abutton.Name = "Abutton";
            this.Abutton.Size = new System.Drawing.Size(40, 40);
            this.Abutton.TabIndex = 17;
            this.Abutton.UseSelectable = true;
            this.Abutton.Click += new System.EventHandler(this.Abutton_Click);
            // 
            // Dbutton
            // 
            this.Dbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Dbutton;
            this.Dbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Dbutton.Location = new System.Drawing.Point(94, 58);
            this.Dbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Dbutton.Name = "Dbutton";
            this.Dbutton.Size = new System.Drawing.Size(40, 40);
            this.Dbutton.TabIndex = 19;
            this.Dbutton.UseSelectable = true;
            this.Dbutton.Click += new System.EventHandler(this.Dbutton_Click);
            // 
            // Fbutton
            // 
            this.Fbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Fbutton;
            this.Fbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Fbutton.Location = new System.Drawing.Point(135, 58);
            this.Fbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Fbutton.Name = "Fbutton";
            this.Fbutton.Size = new System.Drawing.Size(40, 40);
            this.Fbutton.TabIndex = 20;
            this.Fbutton.UseSelectable = true;
            this.Fbutton.Click += new System.EventHandler(this.Fbutton_Click);
            // 
            // Gbutton
            // 
            this.Gbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Gbutton;
            this.Gbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Gbutton.Location = new System.Drawing.Point(176, 58);
            this.Gbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Gbutton.Name = "Gbutton";
            this.Gbutton.Size = new System.Drawing.Size(40, 40);
            this.Gbutton.TabIndex = 21;
            this.Gbutton.UseSelectable = true;
            this.Gbutton.Click += new System.EventHandler(this.Gbutton_Click);
            // 
            // Zbutton
            // 
            this.Zbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Zbutton;
            this.Zbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Zbutton.Location = new System.Drawing.Point(32, 99);
            this.Zbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Zbutton.Name = "Zbutton";
            this.Zbutton.Size = new System.Drawing.Size(40, 40);
            this.Zbutton.TabIndex = 22;
            this.Zbutton.UseSelectable = true;
            this.Zbutton.Click += new System.EventHandler(this.Zbutton_Click);
            // 
            // Xbutton
            // 
            this.Xbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Xbutton;
            this.Xbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Xbutton.Location = new System.Drawing.Point(73, 99);
            this.Xbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Xbutton.Name = "Xbutton";
            this.Xbutton.Size = new System.Drawing.Size(40, 40);
            this.Xbutton.TabIndex = 23;
            this.Xbutton.UseSelectable = true;
            this.Xbutton.Click += new System.EventHandler(this.Xbutton_Click);
            // 
            // Cbutton
            // 
            this.Cbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Cbutton;
            this.Cbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Cbutton.Location = new System.Drawing.Point(114, 99);
            this.Cbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Cbutton.Name = "Cbutton";
            this.Cbutton.Size = new System.Drawing.Size(40, 40);
            this.Cbutton.TabIndex = 24;
            this.Cbutton.UseSelectable = true;
            this.Cbutton.Click += new System.EventHandler(this.Cbutton_Click);
            // 
            // Vbutton
            // 
            this.Vbutton.BackgroundImage = global::Cirnix.Forms.Properties.Resources.Vbutton;
            this.Vbutton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Vbutton.Location = new System.Drawing.Point(155, 99);
            this.Vbutton.Margin = new System.Windows.Forms.Padding(1);
            this.Vbutton.Name = "Vbutton";
            this.Vbutton.Size = new System.Drawing.Size(40, 40);
            this.Vbutton.TabIndex = 25;
            this.Vbutton.UseSelectable = true;
            this.Vbutton.Click += new System.EventHandler(this.Vbutton_Click);
            // 
            // GB_KeyReMap
            // 
            this.GB_KeyReMap.BackColor = System.Drawing.Color.Transparent;
            this.GB_KeyReMap.Controls.Add(this.Key8Text);
            this.GB_KeyReMap.Controls.Add(this.Key1Text);
            this.GB_KeyReMap.Controls.Add(this.Key5Text);
            this.GB_KeyReMap.Controls.Add(this.Key4Text);
            this.GB_KeyReMap.Controls.Add(this.Toggle_KeyRemapping);
            this.GB_KeyReMap.Controls.Add(this.Key2Text);
            this.GB_KeyReMap.Controls.Add(this.Key1);
            this.GB_KeyReMap.Controls.Add(this.Key2);
            this.GB_KeyReMap.Controls.Add(this.Key7Text);
            this.GB_KeyReMap.Controls.Add(this.Key4);
            this.GB_KeyReMap.Controls.Add(this.Key5);
            this.GB_KeyReMap.Controls.Add(this.Key7);
            this.GB_KeyReMap.Controls.Add(this.Key8);
            this.GB_KeyReMap.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GB_KeyReMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GB_KeyReMap.Location = new System.Drawing.Point(0, 3);
            this.GB_KeyReMap.Name = "GB_KeyReMap";
            this.GB_KeyReMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GB_KeyReMap.Size = new System.Drawing.Size(266, 142);
            this.GB_KeyReMap.TabIndex = 33;
            this.GB_KeyReMap.TabStop = false;
            this.GB_KeyReMap.Text = "키리맵핑";
            this.GB_KeyReMap.Leave += new System.EventHandler(this.KeyReMap_Leave);
            // 
            // Key8Text
            // 
            this.Key8Text.BackColor = System.Drawing.Color.Transparent;
            this.Key8Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key8Text.Location = new System.Drawing.Point(173, 27);
            this.Key8Text.Name = "Key8Text";
            this.Key8Text.Size = new System.Drawing.Size(90, 18);
            this.Key8Text.TabIndex = 38;
            this.Key8Text.Text = "키패드8";
            this.Key8Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Key1Text
            // 
            this.Key1Text.BackColor = System.Drawing.Color.Transparent;
            this.Key1Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key1Text.Location = new System.Drawing.Point(3, 109);
            this.Key1Text.Name = "Key1Text";
            this.Key1Text.Size = new System.Drawing.Size(90, 18);
            this.Key1Text.TabIndex = 35;
            this.Key1Text.Text = "키패드1";
            this.Key1Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Key5Text
            // 
            this.Key5Text.BackColor = System.Drawing.Color.Transparent;
            this.Key5Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key5Text.Location = new System.Drawing.Point(173, 68);
            this.Key5Text.Name = "Key5Text";
            this.Key5Text.Size = new System.Drawing.Size(90, 18);
            this.Key5Text.TabIndex = 37;
            this.Key5Text.Text = "키패드5";
            this.Key5Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Key4Text
            // 
            this.Key4Text.BackColor = System.Drawing.Color.Transparent;
            this.Key4Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key4Text.Location = new System.Drawing.Point(3, 68);
            this.Key4Text.Name = "Key4Text";
            this.Key4Text.Size = new System.Drawing.Size(90, 18);
            this.Key4Text.TabIndex = 36;
            this.Key4Text.Text = "키패드4";
            this.Key4Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Toggle_KeyRemapping
            // 
            this.Toggle_KeyRemapping.Location = new System.Drawing.Point(196, 0);
            this.Toggle_KeyRemapping.Name = "Toggle_KeyRemapping";
            this.Toggle_KeyRemapping.Size = new System.Drawing.Size(70, 15);
            this.Toggle_KeyRemapping.TabIndex = 13;
            this.Toggle_KeyRemapping.Text = "Off";
            this.Toggle_KeyRemapping.UseSelectable = true;
            this.Toggle_KeyRemapping.CheckedChanged += new System.EventHandler(this.Toggle_KeyRemapping_CheckedChanged);
            // 
            // Key2Text
            // 
            this.Key2Text.BackColor = System.Drawing.Color.Transparent;
            this.Key2Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key2Text.Location = new System.Drawing.Point(173, 109);
            this.Key2Text.Name = "Key2Text";
            this.Key2Text.Size = new System.Drawing.Size(90, 18);
            this.Key2Text.TabIndex = 36;
            this.Key2Text.Text = "키패드2";
            this.Key2Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Key1
            // 
            this.Key1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key1.Location = new System.Drawing.Point(93, 97);
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(39, 39);
            this.Key1.TabIndex = 4;
            this.Key1.Text = "1";
            this.Key1.UseMnemonic = false;
            this.Key1.UseSelectable = true;
            this.Key1.Click += new System.EventHandler(this.Key1_Click);
            this.Key1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // Key2
            // 
            this.Key2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key2.Location = new System.Drawing.Point(134, 97);
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(39, 39);
            this.Key2.TabIndex = 7;
            this.Key2.Text = "2";
            this.Key2.UseMnemonic = false;
            this.Key2.UseSelectable = true;
            this.Key2.Click += new System.EventHandler(this.Key2_Click);
            this.Key2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // Key7Text
            // 
            this.Key7Text.BackColor = System.Drawing.Color.Transparent;
            this.Key7Text.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.Key7Text.Location = new System.Drawing.Point(3, 27);
            this.Key7Text.Name = "Key7Text";
            this.Key7Text.Size = new System.Drawing.Size(90, 18);
            this.Key7Text.TabIndex = 34;
            this.Key7Text.Text = "키패드7";
            this.Key7Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Key4
            // 
            this.Key4.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key4.Location = new System.Drawing.Point(93, 56);
            this.Key4.Name = "Key4";
            this.Key4.Size = new System.Drawing.Size(39, 39);
            this.Key4.TabIndex = 3;
            this.Key4.Text = "4";
            this.Key4.UseMnemonic = false;
            this.Key4.UseSelectable = true;
            this.Key4.Click += new System.EventHandler(this.Key4_Click);
            this.Key4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // Key5
            // 
            this.Key5.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key5.Location = new System.Drawing.Point(134, 56);
            this.Key5.Name = "Key5";
            this.Key5.Size = new System.Drawing.Size(39, 39);
            this.Key5.TabIndex = 6;
            this.Key5.Text = "5";
            this.Key5.UseMnemonic = false;
            this.Key5.UseSelectable = true;
            this.Key5.Click += new System.EventHandler(this.Key5_Click);
            this.Key5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // Key7
            // 
            this.Key7.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key7.Location = new System.Drawing.Point(93, 15);
            this.Key7.Name = "Key7";
            this.Key7.Size = new System.Drawing.Size(39, 39);
            this.Key7.TabIndex = 2;
            this.Key7.Text = "7";
            this.Key7.UseMnemonic = false;
            this.Key7.UseSelectable = true;
            this.Key7.Click += new System.EventHandler(this.Key7_Click);
            this.Key7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // Key8
            // 
            this.Key8.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.Key8.Location = new System.Drawing.Point(134, 15);
            this.Key8.Name = "Key8";
            this.Key8.Size = new System.Drawing.Size(39, 39);
            this.Key8.TabIndex = 5;
            this.Key8.Text = "8";
            this.Key8.UseMnemonic = false;
            this.Key8.UseSelectable = true;
            this.Key8.Click += new System.EventHandler(this.Key8_Click);
            this.Key8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyReMapping_PreviewKeyDown);
            // 
            // BanList
            // 
            this.BanList.Controls.Add(this.button2);
            this.BanList.Controls.Add(this.label4);
            this.BanList.Controls.Add(this.label3);
            this.BanList.Controls.Add(this.label2);
            this.BanList.Controls.Add(this.ReasonTextBox);
            this.BanList.Controls.Add(this.IPTextBox);
            this.BanList.Controls.Add(this.IdTextBox);
            this.BanList.Controls.Add(this.button1);
            this.BanList.Controls.Add(this.banlistview);
            this.BanList.HorizontalScrollbarBarColor = true;
            this.BanList.HorizontalScrollbarHighlightOnWheel = false;
            this.BanList.HorizontalScrollbarSize = 10;
            this.BanList.Location = new System.Drawing.Point(4, 36);
            this.BanList.Name = "BanList";
            this.BanList.Size = new System.Drawing.Size(632, 235);
            this.BanList.TabIndex = 5;
            this.BanList.Text = "밴리스트";
            this.BanList.VerticalScrollbarBarColor = true;
            this.BanList.VerticalScrollbarHighlightOnWheel = false;
            this.BanList.VerticalScrollbarSize = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(483, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "사유";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(483, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(483, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // ReasonTextBox
            // 
            this.ReasonTextBox.Location = new System.Drawing.Point(527, 91);
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(100, 21);
            this.ReasonTextBox.TabIndex = 7;
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(527, 54);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(100, 21);
            this.IPTextBox.TabIndex = 6;
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(527, 15);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 21);
            this.IdTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(551, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // banlistview
            // 
            this.banlistview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.IP,
            this.사유});
            this.banlistview.FullRowSelect = true;
            this.banlistview.GridLines = true;
            this.banlistview.HideSelection = false;
            this.banlistview.Location = new System.Drawing.Point(3, 5);
            this.banlistview.Name = "banlistview";
            this.banlistview.Size = new System.Drawing.Size(445, 227);
            this.banlistview.TabIndex = 2;
            this.banlistview.UseCompatibleStateImageBehavior = false;
            this.banlistview.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 112;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 115;
            // 
            // 사유
            // 
            this.사유.Text = "사유";
            this.사유.Width = 213;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.BTN_HotKeyDebug);
            this.metroTabPage1.Controls.Add(this.GB_ChatFrequency);
            this.metroTabPage1.Controls.Add(this.TB_CommandDescription);
            this.metroTabPage1.Controls.Add(this.Label_ParameterInfo);
            this.metroTabPage1.Controls.Add(this.Label_ParameterValue);
            this.metroTabPage1.Controls.Add(this.Label_CommandKR);
            this.metroTabPage1.Controls.Add(this.Label_CommandInfo);
            this.metroTabPage1.Controls.Add(this.Label_CommandEN);
            this.metroTabPage1.Controls.Add(this.Label_CommandTitle);
            this.metroTabPage1.Controls.Add(this.Label_CommandListBox);
            this.metroTabPage1.Controls.Add(this.CommandListBox);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(632, 233);
            this.metroTabPage1.TabIndex = 3;
            this.metroTabPage1.Text = "명령어";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // BTN_HotKeyDebug
            // 
            this.BTN_HotKeyDebug.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_HotKeyDebug.Location = new System.Drawing.Point(512, 92);
            this.BTN_HotKeyDebug.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_HotKeyDebug.Name = "BTN_HotKeyDebug";
            this.BTN_HotKeyDebug.Size = new System.Drawing.Size(110, 23);
            this.BTN_HotKeyDebug.TabIndex = 93;
            this.BTN_HotKeyDebug.Text = "단축키 디버깅";
            this.BTN_HotKeyDebug.UseVisualStyleBackColor = true;
            this.BTN_HotKeyDebug.Click += new System.EventHandler(this.BTN_HotKeyDebug_Click);
            // 
            // GB_ChatFrequency
            // 
            this.GB_ChatFrequency.BackColor = System.Drawing.Color.White;
            this.GB_ChatFrequency.Controls.Add(this.BTN_DetectFrequency);
            this.GB_ChatFrequency.Controls.Add(this.Number_ChatFrequency);
            this.GB_ChatFrequency.Controls.Add(this.Label_ChatFrequency);
            this.GB_ChatFrequency.Controls.Add(this.Label_AutoFrequency);
            this.GB_ChatFrequency.Controls.Add(this.Toggle_AutoFrequency);
            this.GB_ChatFrequency.Location = new System.Drawing.Point(507, 3);
            this.GB_ChatFrequency.Name = "GB_ChatFrequency";
            this.GB_ChatFrequency.Size = new System.Drawing.Size(120, 85);
            this.GB_ChatFrequency.TabIndex = 13;
            this.GB_ChatFrequency.TabStop = false;
            this.GB_ChatFrequency.Text = "채팅 주파수";
            // 
            // BTN_DetectFrequency
            // 
            this.BTN_DetectFrequency.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.BTN_DetectFrequency.Location = new System.Drawing.Point(5, 57);
            this.BTN_DetectFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.BTN_DetectFrequency.Name = "BTN_DetectFrequency";
            this.BTN_DetectFrequency.Size = new System.Drawing.Size(110, 23);
            this.BTN_DetectFrequency.TabIndex = 92;
            this.BTN_DetectFrequency.Text = "채팅 주파수 검색";
            this.BTN_DetectFrequency.UseVisualStyleBackColor = true;
            this.BTN_DetectFrequency.Click += new System.EventHandler(this.BTN_DetectFrequency_Click);
            // 
            // Number_ChatFrequency
            // 
            this.Number_ChatFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Number_ChatFrequency.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Number_ChatFrequency.Location = new System.Drawing.Point(75, 33);
            this.Number_ChatFrequency.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Number_ChatFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Number_ChatFrequency.Name = "Number_ChatFrequency";
            this.Number_ChatFrequency.Size = new System.Drawing.Size(39, 22);
            this.Number_ChatFrequency.TabIndex = 65;
            this.Number_ChatFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Number_ChatFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Number_ChatFrequency.ValueChanged += new System.EventHandler(this.Number_ChatFrequency_ValueChanged);
            // 
            // Label_ChatFrequency
            // 
            this.Label_ChatFrequency.BackColor = System.Drawing.Color.Transparent;
            this.Label_ChatFrequency.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_ChatFrequency.Location = new System.Drawing.Point(4, 33);
            this.Label_ChatFrequency.Name = "Label_ChatFrequency";
            this.Label_ChatFrequency.Size = new System.Drawing.Size(69, 22);
            this.Label_ChatFrequency.TabIndex = 66;
            this.Label_ChatFrequency.Text = "채널 번호";
            this.Label_ChatFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_AutoFrequency
            // 
            this.Label_AutoFrequency.BackColor = System.Drawing.Color.Transparent;
            this.Label_AutoFrequency.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_AutoFrequency.Location = new System.Drawing.Point(4, 15);
            this.Label_AutoFrequency.Name = "Label_AutoFrequency";
            this.Label_AutoFrequency.Size = new System.Drawing.Size(41, 15);
            this.Label_AutoFrequency.TabIndex = 64;
            this.Label_AutoFrequency.Text = "자동";
            this.Label_AutoFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Toggle_AutoFrequency
            // 
            this.Toggle_AutoFrequency.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_AutoFrequency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_AutoFrequency.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_AutoFrequency.Location = new System.Drawing.Point(44, 15);
            this.Toggle_AutoFrequency.Name = "Toggle_AutoFrequency";
            this.Toggle_AutoFrequency.Size = new System.Drawing.Size(70, 15);
            this.Toggle_AutoFrequency.TabIndex = 63;
            this.Toggle_AutoFrequency.Text = "Off";
            this.Toggle_AutoFrequency.UseSelectable = true;
            this.Toggle_AutoFrequency.CheckedChanged += new System.EventHandler(this.Toggle_AutoFrequency_CheckedChanged);
            // 
            // TB_CommandDescription
            // 
            this.TB_CommandDescription.BackColor = System.Drawing.SystemColors.Control;
            this.TB_CommandDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_CommandDescription.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.TB_CommandDescription.Location = new System.Drawing.Point(141, 92);
            this.TB_CommandDescription.Name = "TB_CommandDescription";
            this.TB_CommandDescription.Size = new System.Drawing.Size(350, 140);
            this.TB_CommandDescription.TabIndex = 12;
            this.TB_CommandDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_ParameterInfo
            // 
            this.Label_ParameterInfo.BackColor = System.Drawing.Color.Transparent;
            this.Label_ParameterInfo.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.Label_ParameterInfo.Location = new System.Drawing.Point(141, 65);
            this.Label_ParameterInfo.Name = "Label_ParameterInfo";
            this.Label_ParameterInfo.Size = new System.Drawing.Size(115, 20);
            this.Label_ParameterInfo.TabIndex = 11;
            this.Label_ParameterInfo.Text = "매개 변수 :";
            this.Label_ParameterInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_ParameterValue
            // 
            this.Label_ParameterValue.BackColor = System.Drawing.Color.Transparent;
            this.Label_ParameterValue.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_ParameterValue.Location = new System.Drawing.Point(256, 65);
            this.Label_ParameterValue.Name = "Label_ParameterValue";
            this.Label_ParameterValue.Size = new System.Drawing.Size(140, 20);
            this.Label_ParameterValue.TabIndex = 10;
            this.Label_ParameterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_CommandKR
            // 
            this.Label_CommandKR.BackColor = System.Drawing.Color.Transparent;
            this.Label_CommandKR.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_CommandKR.Location = new System.Drawing.Point(346, 40);
            this.Label_CommandKR.Name = "Label_CommandKR";
            this.Label_CommandKR.Size = new System.Drawing.Size(75, 20);
            this.Label_CommandKR.TabIndex = 8;
            this.Label_CommandKR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_CommandInfo
            // 
            this.Label_CommandInfo.BackColor = System.Drawing.Color.Transparent;
            this.Label_CommandInfo.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.Label_CommandInfo.Location = new System.Drawing.Point(141, 40);
            this.Label_CommandInfo.Name = "Label_CommandInfo";
            this.Label_CommandInfo.Size = new System.Drawing.Size(115, 20);
            this.Label_CommandInfo.TabIndex = 7;
            this.Label_CommandInfo.Text = "입력 명령어 :";
            this.Label_CommandInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_CommandEN
            // 
            this.Label_CommandEN.BackColor = System.Drawing.Color.Transparent;
            this.Label_CommandEN.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Label_CommandEN.Location = new System.Drawing.Point(266, 40);
            this.Label_CommandEN.Name = "Label_CommandEN";
            this.Label_CommandEN.Size = new System.Drawing.Size(63, 20);
            this.Label_CommandEN.TabIndex = 6;
            this.Label_CommandEN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_CommandTitle
            // 
            this.Label_CommandTitle.BackColor = System.Drawing.Color.Transparent;
            this.Label_CommandTitle.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.Label_CommandTitle.Location = new System.Drawing.Point(216, 3);
            this.Label_CommandTitle.Name = "Label_CommandTitle";
            this.Label_CommandTitle.Size = new System.Drawing.Size(200, 25);
            this.Label_CommandTitle.TabIndex = 5;
            this.Label_CommandTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_CommandListBox
            // 
            this.Label_CommandListBox.BackColor = System.Drawing.Color.Transparent;
            this.Label_CommandListBox.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.Label_CommandListBox.Location = new System.Drawing.Point(11, 3);
            this.Label_CommandListBox.Name = "Label_CommandListBox";
            this.Label_CommandListBox.Size = new System.Drawing.Size(67, 15);
            this.Label_CommandListBox.TabIndex = 3;
            this.Label_CommandListBox.Text = "리스트";
            this.Label_CommandListBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommandListBox
            // 
            this.CommandListBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CommandListBox.FormattingEnabled = true;
            this.CommandListBox.ItemHeight = 15;
            this.CommandListBox.Items.AddRange(new object[] {
            "dr",
            "ss",
            "rg",
            "set",
            "lc",
            "tlc",
            "olc",
            "cmd",
            "cam",
            "camx",
            "camy",
            "hp",
            "dice",
            "mo",
            "chk",
            "rework",
            "j",
            "c",
            "wa",
            "va",
            "max",
            "min",
            "as",
            "exit"});
            this.CommandListBox.Location = new System.Drawing.Point(6, 18);
            this.CommandListBox.Name = "CommandListBox";
            this.CommandListBox.Size = new System.Drawing.Size(72, 214);
            this.CommandListBox.TabIndex = 2;
            this.CommandListBox.SelectedIndexChanged += new System.EventHandler(this.CommandListBox_SelectedIndexChanged);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.RB_Help8);
            this.metroTabPage2.Controls.Add(this.RB_Help10);
            this.metroTabPage2.Controls.Add(this.RB_Help9);
            this.metroTabPage2.Controls.Add(this.RB_Help7);
            this.metroTabPage2.Controls.Add(this.RB_Help4);
            this.metroTabPage2.Controls.Add(this.RB_Help2);
            this.metroTabPage2.Controls.Add(this.RB_Help6);
            this.metroTabPage2.Controls.Add(this.RB_Help5);
            this.metroTabPage2.Controls.Add(this.RB_Help3);
            this.metroTabPage2.Controls.Add(this.RB_Help1);
            this.metroTabPage2.Controls.Add(this.TB_Help);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(632, 233);
            this.metroTabPage2.TabIndex = 4;
            this.metroTabPage2.Text = "도움말";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // RB_Help8
            // 
            this.RB_Help8.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help8.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help8.Location = new System.Drawing.Point(3, 164);
            this.RB_Help8.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help8.Name = "RB_Help8";
            this.RB_Help8.Size = new System.Drawing.Size(90, 23);
            this.RB_Help8.TabIndex = 98;
            this.RB_Help8.Text = "키 리맵핑";
            this.RB_Help8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help8.UseVisualStyleBackColor = true;
            this.RB_Help8.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help10
            // 
            this.RB_Help10.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help10.Checked = true;
            this.RB_Help10.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help10.Location = new System.Drawing.Point(3, 210);
            this.RB_Help10.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help10.Name = "RB_Help10";
            this.RB_Help10.Size = new System.Drawing.Size(90, 23);
            this.RB_Help10.TabIndex = 97;
            this.RB_Help10.TabStop = true;
            this.RB_Help10.Text = "기타";
            this.RB_Help10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help10.UseVisualStyleBackColor = true;
            this.RB_Help10.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help9
            // 
            this.RB_Help9.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help9.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help9.Location = new System.Drawing.Point(3, 187);
            this.RB_Help9.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help9.Name = "RB_Help9";
            this.RB_Help9.Size = new System.Drawing.Size(90, 23);
            this.RB_Help9.TabIndex = 96;
            this.RB_Help9.Text = "채팅 주파수";
            this.RB_Help9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help9.UseVisualStyleBackColor = true;
            this.RB_Help9.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help7
            // 
            this.RB_Help7.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help7.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help7.Location = new System.Drawing.Point(3, 141);
            this.RB_Help7.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help7.Name = "RB_Help7";
            this.RB_Help7.Size = new System.Drawing.Size(90, 23);
            this.RB_Help7.TabIndex = 95;
            this.RB_Help7.Text = "스마트키";
            this.RB_Help7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help7.UseVisualStyleBackColor = true;
            this.RB_Help7.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help4
            // 
            this.RB_Help4.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help4.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help4.Location = new System.Drawing.Point(3, 72);
            this.RB_Help4.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help4.Name = "RB_Help4";
            this.RB_Help4.Size = new System.Drawing.Size(90, 23);
            this.RB_Help4.TabIndex = 94;
            this.RB_Help4.Text = "프로세스 감지";
            this.RB_Help4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help4.UseVisualStyleBackColor = true;
            this.RB_Help4.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help2
            // 
            this.RB_Help2.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help2.Location = new System.Drawing.Point(3, 26);
            this.RB_Help2.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help2.Name = "RB_Help2";
            this.RB_Help2.Size = new System.Drawing.Size(90, 23);
            this.RB_Help2.TabIndex = 93;
            this.RB_Help2.Text = "메모리 최적화";
            this.RB_Help2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help2.UseVisualStyleBackColor = true;
            this.RB_Help2.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help6
            // 
            this.RB_Help6.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help6.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help6.Location = new System.Drawing.Point(3, 118);
            this.RB_Help6.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help6.Name = "RB_Help6";
            this.RB_Help6.Size = new System.Drawing.Size(90, 23);
            this.RB_Help6.TabIndex = 92;
            this.RB_Help6.Text = "리플레이 저장";
            this.RB_Help6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help6.UseVisualStyleBackColor = true;
            this.RB_Help6.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help5
            // 
            this.RB_Help5.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help5.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help5.Location = new System.Drawing.Point(3, 95);
            this.RB_Help5.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help5.Name = "RB_Help5";
            this.RB_Help5.Size = new System.Drawing.Size(90, 23);
            this.RB_Help5.TabIndex = 91;
            this.RB_Help5.Text = "세이브 분류";
            this.RB_Help5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help5.UseVisualStyleBackColor = true;
            this.RB_Help5.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help3
            // 
            this.RB_Help3.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help3.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help3.Location = new System.Drawing.Point(3, 49);
            this.RB_Help3.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help3.Name = "RB_Help3";
            this.RB_Help3.Size = new System.Drawing.Size(90, 23);
            this.RB_Help3.TabIndex = 90;
            this.RB_Help3.Text = "치트맵 체크";
            this.RB_Help3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help3.UseVisualStyleBackColor = true;
            this.RB_Help3.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // RB_Help1
            // 
            this.RB_Help1.Appearance = System.Windows.Forms.Appearance.Button;
            this.RB_Help1.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.RB_Help1.Location = new System.Drawing.Point(3, 3);
            this.RB_Help1.Margin = new System.Windows.Forms.Padding(0);
            this.RB_Help1.Name = "RB_Help1";
            this.RB_Help1.Size = new System.Drawing.Size(90, 23);
            this.RB_Help1.TabIndex = 89;
            this.RB_Help1.Text = "호스트 설정";
            this.RB_Help1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_Help1.UseVisualStyleBackColor = true;
            this.RB_Help1.CheckedChanged += new System.EventHandler(this.RB_Help_CheckedChanged);
            // 
            // TB_Help
            // 
            this.TB_Help.BackColor = System.Drawing.Color.White;
            this.TB_Help.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Help.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.TB_Help.Location = new System.Drawing.Point(97, 1);
            this.TB_Help.Multiline = true;
            this.TB_Help.Name = "TB_Help";
            this.TB_Help.ReadOnly = true;
            this.TB_Help.Size = new System.Drawing.Size(530, 232);
            this.TB_Help.TabIndex = 3;
            this.TB_Help.Text = @"- 개발 기간: 2017-07-16 ~ ...

해당 프로그램은 Cirnix의 오픈소스 프로젝트인 OpenCirnix입니다.
https://github.com/BlacklightsC/OpenCirnix


---------- 후원 안내 ----------

농협중앙회 302-0627-1751-31 박성현
카카오뱅크 3333-09-4274361 박성현
투네이션: https://toon.at/donate/637131255322131449
페이팔(해외): https://www.paypal.me/BlacklightsC
Patreon(해외 정기후원): https://www.patreon.com/cirnix";
            // 
            // Toggle_CommandHide
            // 
            this.Toggle_CommandHide.BackColor = System.Drawing.SystemColors.ControlText;
            this.Toggle_CommandHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toggle_CommandHide.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Toggle_CommandHide.Location = new System.Drawing.Point(565, 41);
            this.Toggle_CommandHide.Name = "Toggle_CommandHide";
            this.Toggle_CommandHide.Size = new System.Drawing.Size(80, 17);
            this.Toggle_CommandHide.TabIndex = 26;
            this.Toggle_CommandHide.Text = "Off";
            this.Toggle_CommandHide.UseSelectable = true;
            this.Toggle_CommandHide.CheckedChanged += new System.EventHandler(this.CommandHideToggle_CheckedChanged);
            // 
            // Label_Title
            // 
            this.Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Label_Title.Location = new System.Drawing.Point(255, 10);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(260, 0, 260, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(160, 20);
            this.Label_Title.TabIndex = 6;
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommandHideText
            // 
            this.CommandHideText.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CommandHideText.Location = new System.Drawing.Point(425, 40);
            this.CommandHideText.Name = "CommandHideText";
            this.CommandHideText.Size = new System.Drawing.Size(142, 19);
            this.CommandHideText.TabIndex = 45;
            this.CommandHideText.Text = "명령어 숨기기";
            this.CommandHideText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(660, 315);
            this.Controls.Add(this.CommandHideText);
            this.Controls.Add(this.Toggle_CommandHide);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.MainTabControl);
            this.DisplayHeader = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "OptionForm";
            this.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Activated += new System.EventHandler(this.OptionForm_Activated);
            this.MainTabControl.ResumeLayout(false);
            this.War3SettingTab.ResumeLayout(false);
            this.GB_MixFile.ResumeLayout(false);
            this.GB_Manabar.ResumeLayout(false);
            this.GB_SpeenNumberize.ResumeLayout(false);
            this.GB_ScreenShot.ResumeLayout(false);
            this.GB_Host.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Num_GameDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GameStartDelay)).EndInit();
            this.GroupBox_MemoryOptimization.ResumeLayout(false);
            this.GroupBox_MemoryOptimization.PerformLayout();
            this.GB_Camera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CameraDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraImage)).EndInit();
            this.RPGTab.ResumeLayout(false);
            this.RPGTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.TabControl_CommandPreset.ResumeLayout(false);
            this.TP_CommandPreset1.ResumeLayout(false);
            this.TP_CommandPreset1.PerformLayout();
            this.TP_CommandPreset2.ResumeLayout(false);
            this.TP_CommandPreset2.PerformLayout();
            this.TP_CommandPreset3.ResumeLayout(false);
            this.TP_CommandPreset3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.MacroTab.ResumeLayout(false);
            this.GB_AutoMouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrB_AutoMouseDelay)).EndInit();
            this.GB_ChatMacro.ResumeLayout(false);
            this.GB_SmartKey.ResumeLayout(false);
            this.GB_SmartKeyPrevention.ResumeLayout(false);
            this.GB_KeyReMap.ResumeLayout(false);
            this.BanList.ResumeLayout(false);
            this.BanList.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            this.GB_ChatFrequency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Number_ChatFrequency)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private MetroFramework.Controls.MetroTabControl MainTabControl;
        private MetroFramework.Controls.MetroTabPage RPGTab;
        private MetroFramework.Controls.MetroTabPage MacroTab;
        private System.Windows.Forms.GroupBox GB_SmartKey;
        private MetroFramework.Controls.MetroTabPage War3SettingTab;
        private MetroFramework.Controls.MetroButton Key4;
        private MetroFramework.Controls.MetroButton Key7;
        private MetroFramework.Controls.MetroToggle Toggle_KeyRemapping;
        private MetroFramework.Controls.MetroButton Qbutton;
        private MetroFramework.Controls.MetroButton Key2;
        private MetroFramework.Controls.MetroButton Key5;
        private MetroFramework.Controls.MetroButton Key8;
        private MetroFramework.Controls.MetroButton Key1;
        private MetroFramework.Controls.MetroButton Wbutton;
        private MetroFramework.Controls.MetroButton Vbutton;
        private MetroFramework.Controls.MetroButton Cbutton;
        private MetroFramework.Controls.MetroButton Xbutton;
        private MetroFramework.Controls.MetroButton Zbutton;
        private MetroFramework.Controls.MetroButton Gbutton;
        private MetroFramework.Controls.MetroButton Fbutton;
        private MetroFramework.Controls.MetroButton Dbutton;
        private MetroFramework.Controls.MetroButton Tbutton;
        private MetroFramework.Controls.MetroButton Abutton;
        private MetroFramework.Controls.MetroButton Rbutton;
        private MetroFramework.Controls.MetroButton Ebutton;
        private GroupBox GB_KeyReMap;
        private MetroFramework.Controls.MetroComboBox Combo_ScreenShotExtension;
        private Label Label_Title;
        private MetroFramework.Controls.MetroToggle Toggle_War3FixClipboard;
        private MetroFramework.Controls.MetroToggle Toggle_HpCommandAuto;
        private MetroFramework.Controls.MetroToggle Toggle_CommandHide;
        private MetroFramework.Controls.MetroToggle Toggle_RemoveOriginal;
        private MetroFramework.Controls.MetroToggle Toggle_AutoConvert;
        private MetroFramework.Controls.MetroToggle Toggle_MemoryOptimizationDelay;
        private MetroFramework.Controls.MetroToggle Toggle_OutGameAutoMemoryOptimization;
        private GroupBox GB_Host;
        private GroupBox GroupBox_MemoryOptimization;
        private PictureBox CameraImage;
        private NumericUpDown Num_CameraX;
        private NumericUpDown Num_CameraY;
        private NumericUpDown Num_CameraDistance;
        private GroupBox GB_ScreenShot;
        private GroupBox GB_Camera;
        private NumericUpDown Num_GameDelay;
        private NumericUpDown Num_GameStartDelay;
        private ListBox RPGListBox;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private ListBox HeroListBox;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private MetroFramework.Controls.MetroTextBox TB_HeroName;
        private MetroFramework.Controls.MetroTextBox TB_RPGEN;
        private Button BTN_RPGPath;
        private MetroFramework.Controls.MetroTextBox TB_RPGPath;
        private Label Label_War3FixClipboard;
        private Label Label_HpCommandAuto;
        private Label Label_RemoveOriginal;
        private Label Label_AutoConvert;
        private Label Label_GameDelay;
        private Label Label_GameStartDelay;
        private Label Label_MemoryOptimizationDelay;
        private Label Label_OutGameAutoMemoryOptimization;
        private Label Label_HeroList;
        private Label Label_RPGList;
        private Label Label_HeroName;
        private Label Label_RPGPath;
        private Label Label_RPGEN;
        private Label Label_RPGKR;
        private CheckBox CB_NoSavesReplaySave;
        private CheckBox CB_SavesReplayAutoSave;
        private CheckBox CB_NewMapSaveFileAuto;
        private Label CommandHideText;
        private Label Key8Text;
        private Label Key1Text;
        private Label Key5Text;
        private Label Key4Text;
        private Label Key2Text;
        private TextBox TB_MemoryOptimizationDelay;
        private Label Label_ChannelChatViewer;
        private MetroFramework.Controls.MetroToggle Toggle_ChannelChatViewer;
        private MetroFramework.Controls.MetroTextBox TB_RPGKR;
        private TabControl TabControl_CommandPreset;
        private TabPage TP_CommandPreset1;
        private TextBox TB_CommandPreset1;
        private TabPage TP_CommandPreset2;
        private TextBox TB_CommandPreset2;
        private TabPage TP_CommandPreset3;
        private TextBox TB_CommandPreset3;
        private GroupBox groupBox1;
        private Label Label_CommandPreset;
        private Button BTN_Refresh;
        private Button BTN_HeroFolder;
        private Button BTN_HeroDel;
        private Button BTN_HeroAddMod;
        private Button BTN_RPGFolder;
        private Button BTN_RPGDel;
        private Button BTN_RPGAddMod;
        private Button BTN_HostApply;
        private Button BTN_CameraReset;
        private Button BTN_CameraApply;
        private Label Label_ClickPrevention;
        private Label Label_CheatMapCheck;
        private MetroFramework.Controls.MetroToggle Toggle_CheatMapCheck;
        private ListBox CommandListBox;
        private Label Label_CommandListBox;
        private Label Label_CommandEN;
        private Label Label_CommandTitle;
        private Label Label_CommandInfo;
        private Label Label_CommandKR;
        private Label Label_ParameterInfo;
        private Label Label_ParameterValue;
        private Label TB_CommandDescription;
        private GroupBox GB_ChatMacro;
        private CheckBox CB_AutoLoad;
        private GroupBox GB_MixFile;
        private Button BTN_UninstallMix;
        private Button BTN_InstallMix;
        private GroupBox GB_Manabar;
        private RadioButton RB_DisableManabar;
        private RadioButton RB_EnableManabar;
        private GroupBox GB_SpeenNumberize;
        private RadioButton RB_DisableSpeedNumberize;
        private RadioButton RB_EnableSpeedNumberize;
        private Button BTN_InstallPath;
        private MetroFramework.Controls.MetroTextBox TB_InstallPath;
        private Label label1;
        private RadioButton RB_Chat8;
        private RadioButton RB_Chat0;
        private RadioButton RB_Chat9;
        private RadioButton RB_Chat7;
        private RadioButton RB_Chat4;
        private RadioButton RB_Chat2;
        private RadioButton RB_Chat6;
        private RadioButton RB_Chat5;
        private RadioButton RB_Chat3;
        private Label Label_ChatMacro;
        private MetroFramework.Controls.MetroTextBox TB_ChatMacro;
        private Label Key7Text;
        private Button BTN_SetChatHotkey;
        private MetroFramework.Controls.MetroToggle Toggle_ChatMacro;
        private Label Label_ChatHotkey;
        private RadioButton RB_Chat1;
        private Button BTN_CameraPresetJurrasic;
        private TextBox TB_Help;
        private RadioButton RB_Help8;
        private RadioButton RB_Help10;
        private RadioButton RB_Help9;
        private RadioButton RB_Help7;
        private RadioButton RB_Help4;
        private RadioButton RB_Help2;
        private RadioButton RB_Help6;
        private RadioButton RB_Help5;
        private RadioButton RB_Help3;
        private RadioButton RB_Help1;
        private GroupBox GB_ChatFrequency;
        private NumericUpDown Number_ChatFrequency;
        private Label Label_ChatFrequency;
        private Label Label_AutoFrequency;
        private MetroFramework.Controls.MetroToggle Toggle_AutoFrequency;
        private Button BTN_DetectFrequency;
        private GroupBox GB_SmartKeyPrevention;
        private RadioButton RB_Prev2;
        private RadioButton RB_Prev3;
        private RadioButton RB_Prev1;
        private RadioButton RB_Prev4;
        private GroupBox GB_AutoMouse;
        private TrackBar TrB_AutoMouseDelay;
        private Label Label_AutoMouseOff;
        private Button BTN_AutoMouseOff;
        private Label Label_AutoLeftMouseOn;
        private Button BTN_AutoLeftMouseOn;
        private MetroFramework.Controls.MetroToggle Toggle_AutoMouse;
        private Button BTN_HotKeyDebug;
        private Button BTN_RPGSetRegex;
        private Label Label_AutoRightMouseOn;
        private Button BTN_AutoRightMouseOn;
        private Label Label_AutoMouseDelay;
        private Label Label_Border;
        private MetroFramework.Controls.MetroTabPage BanList;
        private ListView banlistview;
        private ColumnHeader ID;
        private ColumnHeader IP;
        private ColumnHeader 사유;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox ReasonTextBox;
        private TextBox IPTextBox;
        private TextBox IdTextBox;
        private Button button1;
        private Button button2;
    }
}