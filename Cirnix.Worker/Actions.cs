using Cirnix.Global;
using Cirnix.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

using static Cirnix.Global.Globals;
using static Cirnix.Global.Hotkey;
using static Cirnix.Global.TgaReader;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.ControlDelay;
using static Cirnix.Memory.GameDll;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.States;
using static Cirnix.Worker.Actions;

namespace Cirnix.Worker
{
    public static class InitFunction
    {
        public static void InitHotkey()
        {
            SmartKey SKey = (SmartKey)Settings.SmartKeyFlag;
            Keys[] SmartKeyList = new Keys[] { Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.A, Keys.D, Keys.F, Keys.G, Keys.Z, Keys.X, Keys.C, Keys.V };

            foreach (var key in SmartKeyList)
                if (SKey.HasFlag(ConvertToSmartKey(key)))
                {
                    if ((Keys)Settings.KeyMap7 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad7);
                    else if ((Keys)Settings.KeyMap8 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad8);
                    else if ((Keys)Settings.KeyMap4 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad4);
                    else if ((Keys)Settings.KeyMap5 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad5);
                    else if ((Keys)Settings.KeyMap1 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad1);
                    else if ((Keys)Settings.KeyMap2 == key)
                        hotkeyList.Register(key, SmartKeyFunc, Keys.NumPad2);
                    else
                        hotkeyList.Register(key, SmartKeyFunc, key);
                }
            if (!Settings.IsKeyRemapped) return;
            if (Settings.KeyMap7 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap7)))
                hotkeyList.Register((Keys)Settings.KeyMap7, KeyRemapping, Keys.NumPad7);
            if (Settings.KeyMap8 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap8)))
                hotkeyList.Register((Keys)Settings.KeyMap8, KeyRemapping, Keys.NumPad8);
            if (Settings.KeyMap4 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap4)))
                hotkeyList.Register((Keys)Settings.KeyMap4, KeyRemapping, Keys.NumPad4);
            if (Settings.KeyMap5 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap5)))
                hotkeyList.Register((Keys)Settings.KeyMap5, KeyRemapping, Keys.NumPad5);
            if (Settings.KeyMap1 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap1)))
                hotkeyList.Register((Keys)Settings.KeyMap1, KeyRemapping, Keys.NumPad1);
            if (Settings.KeyMap2 != 0 && !SKey.HasFlag(ConvertToSmartKey((Keys)Settings.KeyMap2)))
                hotkeyList.Register((Keys)Settings.KeyMap2, KeyRemapping, Keys.NumPad2);
        }
        public static void InitCommand()
        {
            commandList.Register("lc", "ㅣㅊ", LoadCode);
            commandList.Register("tlc", "ㅅㅣㅊ", LoadCode2);
            commandList.Register("dr", "ㅇㄱ", SetGameDelay);
            commandList.Register("ss", "ㄴㄴ", SetStartSpeed);
            commandList.Register("hp", "ㅗㅔ", SetHPView);
            commandList.Register("dice", "주사위", RollDice);
            commandList.Register("rg", "ㄱㅎ", ExecuteRG);
            commandList.Register("save", string.Empty, RpgSave, CommandTag.Chat);
            commandList.Register("cam", "시야", CamDistance);
            commandList.Register("camx", "ㅊ믙", CamAngleX);
            commandList.Register("camy", "ㅊ므ㅛ", CamAngleY);
            commandList.Register("mo", "ㅡㅐ", MemoryOptimize);
            commandList.Register("exit", "종료", ProgramExit);
            commandList.Register("cmd", "층", LoadCommands);
            commandList.Register("set", "ㄴㄷㅅ", SetSave);
            commandList.Register("chk", "체크", CheatCheck);
            commandList.Register("map", "맵", ShowMapPath);
            commandList.Register("mset", "ㅡㄴㄷㅅ", SetMap);
            commandList.Register("dbg", "키", KeyDebug);
            commandList.Register("kr", "키리맵핑", ToggleKeyRemapping);
            commandList.Register("ex", "ㄷㅌ", ExtendForce);
            commandList.Register("test", "ㅅㄷㄴㅅ", LoadCodeSelect);
        }
    }

    internal static class Actions
    {
        internal static List<string> args = new List<string>();
        private static string name = string.Empty;
        private static bool IsSaved = false, IsTime = false, WaitGameStart = false, WaitLobby = false, InitializedWarcraft = false, ignoreDetect = false;
        private static int ZombieCount = 0, MemoryOptimizeElapsed = 0;

        internal static string GetFullArgs(bool isLower = false)
        {
            StringBuilder arg = new StringBuilder();
            for (int i = 1; i < args.Count - 1; i++)
            {
                arg.Append(GetDirectorySafeName(args[i]));
                if (i + 1 != args.Count - 1) arg.Append(" ");
            }
            return isLower ? arg.ToString().ToLower() : arg.ToString();
        }
        internal static string GetMixArgs(int start, int end = -1, bool isLower = false)
        {
            StringBuilder arg = new StringBuilder();
            if (end == -1) end = args.Count - 1;
            for (int i = start; i < end; i++)
            {
                arg.Append(GetDirectorySafeName(args[i]));
                if (i + 1 != end) arg.Append(" ");
            }
            return isLower ? arg.ToString().ToLower() : arg.ToString();
        }
        private static void SaveFileMover(string path)
        {
            string FileName;
            if (!Directory.Exists(GetCurrentPath(1)))
                Directory.CreateDirectory(GetCurrentPath(1));
            if (string.IsNullOrEmpty(name))
            {
                IsTime = true;
                name = GetFileTime(path);
            }
            FileName = string.Format("{0}\\{1}.txt", GetCurrentPath(1), name);
            if (File.Exists(FileName)) File.Delete(FileName);
            try
            {
                File.Move(path, FileName);
            }
            catch
            {
                Delay(1000);
                File.Move(path, FileName);
            }
        }
        internal static void SaveFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!IsSaved) return;
            if (e.FullPath.IndexOf(GetCurrentPath(0)) != -1)
            {
                MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = false;
                SaveFileMover(e.FullPath);
                Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
                SendMsg(true, new string[] { string.Format("{0}\\{1} 로 저장되었습니다.", Category[1], Category[2]) });
                ListUpdate(2);
                return;
            }
            if (!Settings.IsGrabitiSaveAutoAdd) return;
            bool isExist = false;
            string oldName = string.Empty;
            foreach (SavePath item in saveFilePath)
                if (e.FullPath.IndexOf(item.path) != -1)
                {
                    isExist = true;
                    oldName = item.nameEN;
                    break;
                }
            MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = false;
            if (isExist)
            {
                SendMsg(true, new string[] { "기존 맵 세이브가 감지되어 '미지정'으로 저장되었습니다." });
                Category[0] = oldName;
                goto AutoChange;
            }
            else if (IsGrabitiSaveText(e.FullPath)|| IsTwrSaveText(e.FullPath))
            {
                SendMsg(true, new string[] { "새로운 맵 세이브가 감지되어 자동으로 추가되었습니다." });
                string path = string.Format("\\{0}", Path.GetDirectoryName(e.FullPath).Substring(DocumentPath.Length));
                string name = path.Substring(path.LastIndexOf('\\') + 1);
                saveFilePath.AddPath(path, name);
                Category[0] = name;
                goto AutoChange;
            }
            ListUpdate(0);
            return;

            AutoChange:
            Category[1] = "미지정";
            SaveFileMover(e.FullPath);
            ListUpdate(2);
        }
        internal static void WatcherTimer_Tick(object sender, EventArgs e)
        {
            MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = false;
        }
        internal static void ReplayWatcher_Function(object sender, FileSystemEventArgs e)
        {
            if (Settings.IsOptimizeAfterEndGame && CProcess.TrimProcessMemory(TargetProcess))
                MemoryOptimizeElapsed = 0;
            if (!Settings.IsAutoReplay)
            {
                IsTime = IsSaved = false;
                name = string.Empty;
                return;
            }
            try
            {
                Delay(1000);
                MainWorker.ReplayWatcher.EnableRaisingEvents = false;
                string LastReplay = string.Format(@"{0}\LastReplay.w3g", Path.GetDirectoryName(e.FullPath));
                if (File.Exists(LastReplay) && new FileInfo(LastReplay).Length >= 1024)
                {
                    string FileName;
                    if (IsSaved)
                    {
                        IsSaved = false;
                        string CurrentCategory = string.Format(@"{0}\Replay\{1}\{2}", DocumentPath, Category[0], Category[1]);
                        if (!Directory.Exists(CurrentCategory))
                            Directory.CreateDirectory(CurrentCategory);
                        FileName = string.Format("{0}\\{1}{2}.w3g", CurrentCategory, IsTime ? string.Empty : "_", name);
                        name = string.Empty;
                        IsTime = false;
                        if (File.Exists(FileName)) File.Delete(FileName);
                        File.Move(LastReplay, FileName);
                    }
                    else if (Settings.NoSavedReplaySave)
                    {
                        if (!Directory.Exists(DocumentPath + @"\Replay\NoSavedReplay"))
                            Directory.CreateDirectory(DocumentPath + @"\Replay\NoSavedReplay");
                        FileName = string.Format(@"{0}\Replay\NoSavedReplay\{1}.w3g", DocumentPath, GetFileTime(LastReplay));
                        if (File.Exists(FileName)) File.Delete(FileName);
                        File.Move(LastReplay, FileName);
                    }
                }
            }
            catch { }
            MainWorker.ReplayWatcher.EnableRaisingEvents = true;
        }
        internal static void ScreenShotWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!Path.HasExtension(e.FullPath)) return;
            SaveTo(ReadFile(e.FullPath), string.Format("{0}\\{1}", Path.GetDirectoryName(e.FullPath), Path.GetFileNameWithoutExtension(e.FullPath)), Settings.ConvertExtention);
            if (Settings.IsOriginalRemove) File.Delete(e.FullPath);
        }
        internal static void MapFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            SendMsg(true, new string[] { string.Format("{0} 맵이 치트맵인지 확인합니다.", Path.GetFileName(e.FullPath)) });
            SendMsg(true, new string[] { string.Format("판독 결과: 치트맵{0}니다.", IsCheatMap(e.FullPath) ? " 인것이 확인되었습" : "이 아닙") });
            MainWorker.MapFileWatcher.EnableRaisingEvents = false;
        }
        internal static void LoadCode()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetFullArgs();
                string path =  string.Format("{0}\\{1}", GetCurrentPath(0), saveName);
                if (!Directory.Exists(path))
                {
                    SendMsg(true, new string[] { string.Format("{0} 존재하지 않습니다.", IsKoreanBlock(saveName, "은", "는")) });
                    return;
                }
                Settings.HeroType = Category[1] = saveName;
                Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
                ListUpdate(2);
            }
            try
            {
                GetCodes();
            }
            catch
            {
                goto Error;
            }
            if (string.IsNullOrEmpty(Code[0])) goto Error;
            SendMsg(true, new string[] { string.Format("{0}\\{1} 파일을 로드합니다.", Category[1], Category[2]) });
            SendMsg(false, new string[] { "-load" });
            for (int i = 0; i < 24; i++)
            {
                if (string.IsNullOrEmpty(Code[i])) break;
                SendMsg(false, new string[] { Code[i].Substring(0, Code[i].Length >= 127 ? 127 : Code[i].Length) }, Settings.GlobalDelay);
            }
            Delay(200);
            TypeCommands();
            return;
            Error:
            SendMsg(true, new string[] { "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다." });
        }

        internal static void LoadCode2()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetFullArgs();
                string path = string.Format("{0}\\{1}", GetCurrentPath(0), saveName);
                SendMsg(false, new string[] { path });
                if (!Directory.Exists(path))
                {
                    SendMsg(true, new string[] { string.Format("{0} 존재하지 않습니다.", IsKoreanBlock(saveName, "은", "는")) });
                    return;
                }
                Settings.HeroType = Category[1] = saveName;
                Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
                ListUpdate(2);
            }
            try
            {
                GetCodes2();
            }
            catch
            {
                goto Error;
            }
            if (string.IsNullOrEmpty(Code[0])) goto Error;
            SendMsg(true, new string[] { string.Format("{0}\\{1} 파일을 로드합니다.", Category[1], Category[2]) });
            for (int i = 0; i < 24; i++)
            {
                if (string.IsNullOrEmpty(Code[i])) break;
                SendMsg(false, new string[] { Code[i].Substring(0, Code[i].Length >= 130 ? 130 : Code[i].Length) }, Settings.GlobalDelay);
            }
            Delay(200);
            TypeCommands();
            return;
        Error:
            SendMsg(true, new string[] { "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다." });
        }

        internal static void LoadCommands()
        {
            if (string.IsNullOrEmpty(args[1]))
            {
                SendMsg(true, new string[] { "Error - 프리셋을 지정해주세요. (1 ~ 3)" });
                return;
            }
            TypeCommands(int.Parse(args[1]));
        }

        private static void TypeCommands(int index = -1)
        {
            string Command;
            switch(index)
            {
                case -1:
                    switch (Settings.SelectedCommand)
                    {
                        case 1:
                            Command = Settings.CommandPreset1;
                            break;
                        case 2:
                            Command = Settings.CommandPreset2;
                            break;
                        case 3:
                            Command = Settings.CommandPreset3;
                            break;
                        default:
                            return;
                    }
                    break;
                case 1:
                    Command = Settings.CommandPreset1;
                    break;
                case 2:
                    Command = Settings.CommandPreset2;
                    break;
                case 3:
                    Command = Settings.CommandPreset3;
                    break;
                default:
                    SendMsg(true, new string[] { "Error - 해당 프리셋이 존재하지 않습니다." });
                    return;
            }
            if (index != -1) SendMsg(true, new string[] { string.Format("명령어 프리셋 {0}을 입력합니다.", index) });
            if (string.IsNullOrEmpty(Command)) return;
            SendMsg(false, Command.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries), Settings.GlobalDelay + 100);
        }
        internal static void SetSave()
        {
            string saveName = GetFullArgs();
            if (string.IsNullOrEmpty(saveName))
            {
                List<string> list = new List<string>();
                StringBuilder builder = new StringBuilder();
                bool isFirst = true;
                foreach (var item in new DirectoryInfo(GetCurrentPath(0)).GetDirectories())
                {
                    if (isFirst)
                    {
                        builder.Append($"{Theme.Title} 분류: ");
                        isFirst = false;
                    }
                    else
                        builder.Append(", ");
                    builder.Append(item.Name);
                    string buffer;
                    if (Encoding.UTF8.GetByteCount(buffer = builder.ToString()) >= 100)
                    {
                        list.Add(buffer);
                        builder.Clear();
                    }
                }
                if (builder.Length > 0) list.Add(builder.ToString());
                SendMsg(false, list.ToArray());
            }
            else
            {
                string path = string.Format("{0}\\{1}", GetCurrentPath(0), saveName);
                if (Directory.Exists(path))
                    SendMsg(true, new string[] { string.Format("{0} 사용합니다.", IsKoreanBlock(saveName, "을", "를")) });
                else
                {
                    SendMsg(true, new string[] { string.Format("{0} 존재하지 않으므로, 새로 생성합니다.", IsKoreanBlock(saveName, "은", "는")) });
                    Directory.CreateDirectory(path);
                }
                Settings.HeroType = Category[1] = saveName;
                ListUpdate(2);
            }
        }
        internal static void SetMap()
        {
            string saveName = GetFullArgs();
            foreach (var item in saveFilePath)
            {
                if (item.nameEN.ToLower().IndexOf(saveName) == -1
                 && item.nameKR.ToLower().IndexOf(saveName) == -1)
                    continue;

                SendMsg(true, new string[] { string.Format("{0} 제일 유사한 {1} 사용합니다.", IsKoreanBlock(saveName, "과", "와"), IsKoreanBlock(saveFilePath.ConvertName(item.nameEN),"을","를")) });
                Settings.MapType = Category[0] = item.nameEN;
                Settings.HeroType = Category[1] = "미지정";
                ListUpdate(2);
                return;
            }
            SendMsg(true, new string[] { string.Format("{0} 유사한 이름을 찾지 못했습니다.", IsKoreanBlock(saveName, "과", "와")) });
        }
        internal static void SetGameDelay()
        {
            if (string.IsNullOrEmpty(args[1])) goto Error;
            int delay;
            try
            {
                delay = int.Parse(args[1]);
            }
            catch
            {
                goto Error;
            }
            if (delay < 0 || delay > 550) goto Error;
            SendMsg(true, new string[] { string.Format("Delay 값: {0}{1}ms → {2}ms", IsHostPlayer ? "<Host> " : string.Empty, Settings.GameDelay, args[1]) });
            Settings.GameDelay = delay;
            if (CurrentGameState == GameState.StartedGame
                || CurrentGameState == GameState.InGame)
                GameDelay = Settings.GameDelay;
            return;
            Error:
            SendMsg(true, new string[] { "Error - Delay 값 범위: 0 ~ 550" });
        }
        internal static void SetStartSpeed()
        {
            if (string.IsNullOrEmpty(args[1])) goto Error;
            int delay;
            try
            {
                delay = int.Parse(args[1]);
            }
            catch
            {
                goto Error;
            }
            if (delay < 0 || delay > 6) goto Error;
            SendMsg(true, new string[] { string.Format("StartSpeed 값: {0}초 → {1}초", Settings.StartSpeed <= 0.01 ? 0 : Settings.StartSpeed, args[1]) });
            if (delay == 0) StartDelay = 0.01f;
            else StartDelay = Convert.ToSingle(delay);
            Settings.StartSpeed = StartDelay;
            return;
            Error:
            SendMsg(true, new string[] { "Error - StartSpeed 값 범위: 0 ~ 6" });
        }
        internal static void SetHPView()
        {
            SendMsg(true, new string[] { string.Format("HP 최대값 표기가 {0}니다.", HPView ? "나타납" : "사라집") });
            HPView = !HPView;
        }
        internal static void RollDice()
        {
            int diceNumber;
            if (string.IsNullOrEmpty(args[1])) diceNumber = 100;
            else
            {
                try
                {
                    diceNumber = int.Parse(args[1]);
                    if (diceNumber < 0) goto Error;
                }
                catch
                {
                    goto Error;
                }
            }
            SendMsg(true, new string[] { string.Format("주사위에서 {0} (이)가 나왔습니다. ({1})", new Random().Next(diceNumber + 1), diceNumber) });
            return;
            Error:
            SendMsg(true, new string[] { "Error - 주사위 범위: 0 ~ 2,147,483,646" });
        }
        internal static void ExecuteRG()
        {
            //if (CurrentGameState == GameState.StartedGame)
            //{
            //    SendMsg(true, new string[] { "이미 게임을 플레이 하는 중입니다." });
            //    return;
            //}
            if (MainWorker.autoRG.isRunning)
            {
                SendMsg(true, new string[] { "자동 RG 기능이 종료되었습니다." });
                MainWorker.autoRG.CancelAsync();
                return;
            }
            int value;
            try
            {
                value = int.Parse(args[1]);
                if (value <= 0) goto Error;
            }
            catch
            {
                goto Error;
            }
            SendMsg(true, new string[] { string.Format("자동 RG 기능이 시작되었습니다. ▷반복: {0}회", args[1]) });
            MainWorker.autoRG.RunWorkerAsync(value);
            return;
            Error:
            SendMsg(true, new string[] { "자동 RG 기능이 시작되었습니다. ▷반복: 무제한" });
            MainWorker.autoRG.RunWorkerAsync(-1);
        }
        internal static void RpgSave()
        {
            if (CurrentGameState != GameState.StartedGame
             && CurrentGameState != GameState.InGame)
                return;
            IsSaved = true;
            name = GetFullArgs();
            string[] FileName;
            try
            {
                FileName = Directory.GetFiles(GetCurrentPath(0));
            }
            catch
            {
                goto Error;
            }
            if (FileName.Length == 0) goto Error;
            SaveFileMover(FileName[0]);
            Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
            SendMsg(true, new string[] { string.Format("{0}\\{1} 로 저장되었습니다.", Category[1], Category[2]) });
            ListUpdate(2);
            return;

            Error:
            MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = true;
        }
        internal static void CamDistance()
        {
            if (string.IsNullOrEmpty(args[1])) goto Error;
            float value;
            try
            {
                value = float.Parse(args[1]);
            }
            catch
            {
                goto Error;
            }
            if (value > 6000 || value < 0) goto Error;
            SendMsg(true, new string[] { string.Format("설정된 시야 값: {0}", args[1]) });
            Settings.CameraDistance = CameraDistance = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, new string[] { "Error - 시야 범위: 0 ~ 6000" });
        }
        internal static void CamAngleX()
        {
            if (string.IsNullOrEmpty(args[1])) goto Error;
            float value;
            try
            {
                value = float.Parse(args[1]);
            }
            catch
            {
                goto Error;
            }
            if (value > 360 || value < 0) goto Error;
            SendMsg(true, new string[] { string.Format("설정된 X축 각도 값: {0}", args[1]) });
            Settings.CameraAngleX = CameraAngleX = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, new string[] { "Error - X축 각도 범위: 0 ~ 360" });
        }
        internal static void CamAngleY()
        {
            if (string.IsNullOrEmpty(args[1])) goto Error;
            float value;
            try
            {
                value = float.Parse(args[1]);
            }
            catch
            {
                goto Error;
            }
            if (value > 360 || value < 0) goto Error;
            SendMsg(true, new string[] { string.Format("설정된 Y축 각도 값: {0}", args[1]) });
            Settings.CameraAngleY = CameraAngleY = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, new string[] { "Error - Y축 각도 범위: 0 ~ 360" });
        }

        internal static void ProgramExit()
        {
            //SendMsg(true, new string[] { "프로그램을 종료합니다." });
            Warcraft3Info.Process.Kill();
            //ProgramShutDown();
        }
        internal static bool ProcessCheck()
        {
            if (GameModule.WarcraftDetect() != WarcraftState.OK
                || !GameModule.WarcraftCheck())
            {
                InitializedWarcraft = ignoreDetect = false;
                return true;
            }
            if (!InitializedWarcraft)
            {
                InitializedWarcraft = true;
                Delay(2000);
                GameDll.GetOffset();
                GameDelay = 50;
                RefreshCooldown = 0.01f;
                name = string.Empty;
                StartDelay = Settings.StartSpeed > 0 ? Settings.StartSpeed : 0.01f;
                CameraDistance = Settings.CameraDistance;
                CameraAngleX = Settings.CameraAngleX;
                CameraAngleY = Settings.CameraAngleY;
            }
            if (Settings.IsAutoHp && !HPView) HPView = true;
            
            if (Settings.IsAntiZombieProcess)
            {
                if (ignoreDetect && ++ZombieCount > 9000)
                {
                    ignoreDetect = false;
                    ZombieCount = 0;
                }
                else if (CurrentGameState == GameState.Unknown)
                {
                    if (++ZombieCount > 22)
                    {
                        try
                        {
                            PerformanceCounter CPUCounter = new PerformanceCounter("Process", "% Processor Time", TargetProcess);
                            CPUCounter.NextValue();
                            for (int i = 0; i < 5; i++)
                            {
                                Delay(1100);
                                if (CPUCounter.NextValue() >= 0.01f)
                                {
                                    ZombieCount = 0;
                                    break;
                                }
                                if (i != 4) continue;
                                if (MessageBox.Show("워크래프트가 정상적으로 종료되지 않은 것 같습니다.\n강제로 종료하시겠습니까?", "강제 종료 알림", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        Warcraft3Info.Process.Kill();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("워크래프트를 강제로 종료할 수 없었습니다.\n이미 종료되었거나, 백신에 의해 차단된 것 같습니다.", "강제 종료 실패", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                    }
                                }
                                else ignoreDetect = true;
                            }
                        }
                        catch
                        {
                            ZombieCount = 0;
                        }
                    }
                    return true;
                }
                else ZombieCount = 0;
            }

            if (Settings.IsMemoryOptimize
             && MemoryOptimizeElapsed++ >= Settings.MemoryOptimizeCoolDown * 6000)
            {
                SendMsg(true, new string[] { "워크래프트 3 자동 메모리 최적화를 시도합니다." });
                if (CProcess.TrimProcessMemory(TargetProcess,true))
                {
                    MemoryOptimizeElapsed = 0;
                    SendMsg(true, new string[] { $"결과: {ConvertSize(CProcess.MemoryValue[0])} - {ConvertSize(CProcess.MemoryValue[2])} = {ConvertSize(CProcess.MemoryValue[1])}" });
                }
                else
                {
                    MemoryOptimizeElapsed = Settings.MemoryOptimizeCoolDown / 2;
                }
            }
            StatusCheck();
            return false;
        }
        internal static void MemoryOptimize()
        {
            MemoryOptimizeElapsed = 0;
            new System.Threading.Thread(() => {
                SendMsg(true, new string[] { "워크래프트 3 메모리 최적화를 시도합니다." });
                if (CProcess.TrimProcessMemory(TargetProcess, true))
                {
                    if (CProcess.MemoryValue[2] < 0)
                    {
                        SendMsg(true, new string[] { "최적화할 메모리를 찾을 수 없었습니다." });
                    }
                    else SendMsg(true, new string[] { $"결과: {ConvertSize(CProcess.MemoryValue[0])} - {ConvertSize(CProcess.MemoryValue[2])} = {ConvertSize(CProcess.MemoryValue[1])}" });
                }
                else SendMsg(true, new string[] { "Error - 최적화 중에 예외가 발생했습니다." });
            }).Start();
        }
        internal static void StatusCheck() 
        {
            if (WaitGameStart)
            {
                if (!GetReceiveStatus()) return;
                WaitGameStart = false;
                MainWorker.autoRG.CancelAsync();
                MainWorker.MapFileWatcher.EnableRaisingEvents = false;
                Delay(500);
                CameraInit();
                GameDelay = Settings.GameDelay;
                KeyDebugFunc();
                if (!Settings.IsAutoLoad) return;
                Delay(3000);
                LoadCodeSelect();
                
                
                
            }
            else
            {
                if (!WaitLobby && CurrentGameState == GameState.BattleNet)
                {
                    GameDelay = 50;
                    WaitLobby = true;
                    Globals.ExtendForce = false;
                }
                if (!WaitLobby || GameDelay != 100) return;
                GameDelay = 550;
                if (Settings.IsCheatMapCheck && !LoadedFiles.IsLoadedMap(out _))
                    MainWorker.MapFileWatcher.EnableRaisingEvents = true;
                if (File.Exists(DocumentPath + @"\Replay\LastReplay.w3g"))
                {
                    try
                    {
                        File.Delete(DocumentPath + @"\Replay\CirnixReplay.w3g");
                        File.Move(DocumentPath + @"\Replay\LastReplay.w3g", DocumentPath + @"\Replay\CirnixReplay.w3g");
                    }
                    catch
                    {
                        // Delete : CirnixReplay.w3g 경로에 대한 액세스가 거부되었습니다.
                        // 백신때문으로 유추
                    }
                }
                WaitLobby = false;
                WaitGameStart = true;
            }
        }
        internal static void CheatCheck()
        {
            if (!LoadedFiles.IsLoadedMap(out string MapPath))
            {
                SendMsg(true, new string[] { "로드된 맵이 없습니다." });
                return;
            }
            SendMsg(true, new string[] { string.Format("{0} 맵이 치트맵인지 확인합니다.", Path.GetFileName(MapPath)) });
            if (IsCheatMap(MapPath))
                SendMsg(true, new string[] { "판독 결과: 알려진 치트셋이 사용된 치트맵입니다." });
            else
                SendMsg(true, new string[] { "판독 결과: 치트맵이 아닌 것 같습니다." });
        }
        internal static void ShowMapPath()
        {
            string MapPath;
            if (!LoadedFiles.IsLoadedMap(out MapPath))
            {
                SendMsg(true, new string[] { "로드된 맵이 없습니다." });
                return;
            }
            MapPath = MapPath.Substring(MapPath.IndexOf(@"\Warcraft III\Maps\") + 14);
            SendMsg(true, new string[] { string.Format("현재 로드된 맵 경로: {0}", MapPath) });
        }
        private static void KeyDebugFunc()
        {
            KeyboardHooker.HookEnd();
            Delay(1);
            KeyboardHooker.HookStart();
        }
        internal static void KeyDebug()
        {
            KeyDebugFunc();
            SendMsg(true, new string[] { "단축키 후킹 상태를 재설정하였습니다." });
        }
        internal static void ToggleKeyRemapping()
        {
            if (!Settings.IsKeyRemapped
             && (hotkeyList.IsRegistered((Keys)Settings.KeyMap7)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap8)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap4)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap5)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap1)
             || hotkeyList.IsRegistered((Keys)Settings.KeyMap2)))
            {
                SendMsg(true, "겹치는 단축키가 발견되어 작동하지 않습니다.");
                return;
            }
            if (Settings.IsKeyRemapped = !Settings.IsKeyRemapped)
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
                SendMsg(true, "키 리맵핑을 사용합니다.");
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
                SendMsg(true, "키 리맵핑을 사용하지 않습니다.");
            }
        }

        internal static void ExtendForce()
        {
            SendMsg(true, "강제 모드 " + ((Globals.ExtendForce = !Globals.ExtendForce) ? "켜짐" : "꺼짐"));
        }


        internal static void LoadCodeSelect()
        {
            string MapPath;
            if (!LoadedFiles.IsLoadedMap(out MapPath))
            {
                SendMsg(true, new string[] { "로드된 맵이 없습니다." });
                return;
            }
            MapPath = MapPath.Substring(MapPath.IndexOf(@"\Warcraft III\Maps\") + 14);

            if (MapPath.Contains("twrpg"))
            {
                Delay(3000);
                LoadCode2();
            }
            else
            {
                LoadCode();
            }
            

            
            

            
        }
    }
}
