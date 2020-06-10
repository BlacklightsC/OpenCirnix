using Cirnix.Global;
using Cirnix.Memory;
using Cirnix.ServerStatus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Reflection.Emit;


using static Cirnix.Global.Globals;
using static Cirnix.Global.Hotkey;
using static Cirnix.Global.TgaReader;
using static Cirnix.Memory.Component;
using static Cirnix.Memory.ControlDelay;
using static Cirnix.Memory.GameDll;
using static Cirnix.Memory.Message;
using static Cirnix.Memory.States;
using static Cirnix.Worker.Actions;
using static Cirnix.Global.NativeMethods;


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
            commandList.Register("tlc", "싳", LoadCode2);
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
            commandList.Register("kr", "키리맵핑", ToggleKeyRemapping);
            commandList.Register("rs", "ㄱㄴ", SearchRoomListRoom);
            commandList.Register("ms", "ㅡㄴ", SearchRoomListMap);
            commandList.Register("test", "ㅅㄷㄴㅅ", LoadCodeSelect);
            commandList.Register("rework", "ㄱㄷ재가", Rework);
            commandList.Register("join", "ㅓㅐㅑㅜ", RoomJoin);
        }
    }

    internal static class Actions
    {
        internal static List<string> args = new List<string>();
        internal static List<string> roomname2 = new List<string>();
        private static string name = string.Empty;
        private static string roomname = string.Empty;
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
            FileName = $"{GetCurrentPath(1)}\\{name}.txt";
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
                SendMsg(true, $"{Category[1]}\\{Category[2]} 로 저장되었습니다.");
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
                SendMsg(true, "기존 맵 세이브가 감지되어 '미지정'으로 저장되었습니다.");
                Category[0] = oldName;
                goto AutoChange;
            }
            else if (IsGrabitiSaveText(e.FullPath)|| IsTwrSaveText(e.FullPath))
            {
                SendMsg(true, "새로운 맵 세이브가 감지되어 자동으로 추가되었습니다.");
                string path = $"\\{Path.GetDirectoryName(e.FullPath).Substring(DocumentPath.Length)}";
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
                string LastReplay = $"{Path.GetDirectoryName(e.FullPath)}\\LastReplay.w3g";
                if (File.Exists(LastReplay) && new FileInfo(LastReplay).Length >= 1024)
                {
                    string FileName;
                    if (IsSaved)
                    {
                        IsSaved = false;
                        string CurrentCategory = $"{DocumentPath}\\Replay\\{Category[0]}\\{Category[1]}";
                        if (!Directory.Exists(CurrentCategory))
                            Directory.CreateDirectory(CurrentCategory);
                        FileName = $"{CurrentCategory}\\{(IsTime ? string.Empty : "_")}{name}.w3g";
                        name = string.Empty;
                        IsTime = false;
                        if (File.Exists(FileName)) File.Delete(FileName);
                        File.Move(LastReplay, FileName);
                    }
                    else if (Settings.NoSavedReplaySave)
                    {
                        if (!Directory.Exists(DocumentPath + @"\Replay\NoSavedReplay"))
                            Directory.CreateDirectory(DocumentPath + @"\Replay\NoSavedReplay");
                        FileName = $"{DocumentPath}\\Replay\\NoSavedReplay\\{GetFileTime(LastReplay)}.w3g";
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
            SaveTo(ReadFile(e.FullPath), $"{Path.GetDirectoryName(e.FullPath)}\\{Path.GetFileNameWithoutExtension(e.FullPath)}", Settings.ConvertExtention);
            if (Settings.IsOriginalRemove) File.Delete(e.FullPath);
        }
        internal static void MapFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            SendMsg(true, $"{Path.GetFileName(e.FullPath)} 맵이 치트맵인지 확인합니다.");
            SendMsg(true, $"판독 결과: 치트맵{(IsCheatMap(e.FullPath) ? " 인것이 확인되었습" : "이 아닙")}니다.");
            MainWorker.MapFileWatcher.EnableRaisingEvents = false;
        }
        internal static void LoadCode()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetFullArgs();
                string path = $"{GetCurrentPath(0)}\\{saveName}";
                if (!Directory.Exists(path))
                {
                    SendMsg(true, $"{IsKoreanBlock(saveName, "은", "는")} 존재하지 않습니다.");
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
            SendMsg(true, $"{Category[1]}\\{Category[2]} 파일을 로드합니다.");
            SendMsg(false, "-load");
            for (int i = 0; i < 24; i++)
            {
                if (string.IsNullOrEmpty(Code[i])) break;
                SendMsg(false, new string[] { Code[i].Substring(0, Code[i].Length >= 127 ? 127 : Code[i].Length) }, Settings.GlobalDelay);
            }
            Delay(200);
            TypeCommands();
            return;
            Error:
            SendMsg(true, "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다.");
        }

        internal static void LoadCode2()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetFullArgs();
                string path = $"{GetCurrentPath(0)}\\{saveName}";
                SendMsg(false, new string[] { path });
                if (!Directory.Exists(path))
                {
                    SendMsg(true, $"{IsKoreanBlock(saveName, "은", "는")} 존재하지 않습니다.");
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
            SendMsg(true, $"{Category[1]}\\{Category[2]} 파일을 로드합니다.");
            for (int i = 0; i < 24; i++)
            {
                if (string.IsNullOrEmpty(Code[i])) break;
                SendMsg(false, new string[] { Code[i].Substring(0, Code[i].Length >= 130 ? 130 : Code[i].Length) }, Settings.GlobalDelay);
            }
            Delay(200);
            TypeCommands();
            return;
        Error:
            SendMsg(true, "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다.");
        }

        internal static void LoadCommands()
        {
            if (string.IsNullOrEmpty(args[1]))
            {
                SendMsg(true, "Error - 프리셋을 지정해주세요. (1 ~ 3)");
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
                    SendMsg(true, "Error - 해당 프리셋이 존재하지 않습니다.");
                    return;
            }
            if (index != -1) SendMsg(true, $"명령어 프리셋 {index}을 입력합니다.");
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
                        builder.Append($"{Theme.MsgTitle} 분류: ");
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
                string path = "{GetCurrentPath(0)}\\{saveName}";
                if (Directory.Exists(path))
                    SendMsg(true, $"{IsKoreanBlock(saveName, "을", "를")} 사용합니다.");
                else
                {
                    SendMsg(true, $"{IsKoreanBlock(saveName, "은", "는")} 존재하지 않으므로, 새로 생성합니다.");
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

                SendMsg(true, $"{IsKoreanBlock(saveName, "과", "와")} 제일 유사한 {IsKoreanBlock(saveFilePath.ConvertName(item.nameEN), "을", "를")} 사용합니다.");
                Settings.MapType = Category[0] = item.nameEN;
                Settings.HeroType = Category[1] = "미지정";
                ListUpdate(2);
                return;
            }
            SendMsg(true, $"{IsKoreanBlock(saveName, "과", "와")} 유사한 이름을 찾지 못했습니다.");
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
            SendMsg(true, $"Delay 값: {(IsHostPlayer ? "<Host>" : string.Empty)}{Settings.GameDelay}ms → {args[1]}ms");
            Settings.GameDelay = delay;
            if (IsInGame) GameDelay = Settings.GameDelay;
            return;
            Error:
            SendMsg(true, "Error - Delay 값 범위: 0 ~ 550");
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
            float startSpeed = Settings.StartSpeed;
            SendMsg(true, $"StartSpeed 값: {(startSpeed <= 0.01 ? 0 : startSpeed)}초 → {args[1]}초");
            if (delay == 0) StartDelay = 0.01f;
            else StartDelay = Convert.ToSingle(delay);
            Settings.StartSpeed = StartDelay;
            return;
            Error:
            SendMsg(true, "Error - StartSpeed 값 범위: 0 ~ 6");
        }
        internal static void SetHPView()
        {
            SendMsg(true, $"HP 최대값 표기가 {(HPView ? "나타납" : "사라집")}니다.");
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
            SendMsg(true, $"주사위에서 {new Random().Next(diceNumber + 1)} (이)가 나왔습니다. ({diceNumber})");
            return;
            Error:
            SendMsg(true, "Error - 주사위 범위: 0 ~ 2,147,483,646");
        }
        internal static void ExecuteRG()
        {
            //if (CurrentGameState == GameState.StartedGame)
            //{
            //    SendMsg(true, "이미 게임을 플레이 하는 중입니다.");
            //    return;
            //}
            if (MainWorker.autoRG.isRunning)
            {
                SendMsg(true, "자동 RG 기능이 종료되었습니다.");
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
            SendMsg(true, $"자동 RG 기능이 시작되었습니다. ▷반복: {args[1]}회");
            MainWorker.autoRG.RunWorkerAsync(value);
            return;
            Error:
            SendMsg(true, "자동 RG 기능이 시작되었습니다. ▷반복: 무제한");
            MainWorker.autoRG.RunWorkerAsync(-1);
        }
        internal static void RpgSave()
        {
            if (!IsInGame) return;
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
            SendMsg(true, $"{Category[1]}\\{Category[2]} 로 저장되었습니다.");
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
            SendMsg(true, $"설정된 시야 값: {args[1]}");
            Settings.CameraDistance = CameraDistance = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, "Error - 시야 범위: 0 ~ 6000");
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
            SendMsg(true, $"설정된 X축 각도 값: {args[1]}");
            Settings.CameraAngleX = CameraAngleX = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, "Error - X축 각도 범위: 0 ~ 360");
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
            SendMsg(true, $"설정된 Y축 각도 값: {args[1]}");
            Settings.CameraAngleY = CameraAngleY = value;
            CameraInit();
            return;
            Error:
            SendMsg(true, "Error - Y축 각도 범위: 0 ~ 360");
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
                else if (CurrentMusicState == MusicState.None)
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
                SendMsg(true, "워크래프트 3 자동 메모리 최적화를 시도합니다.");
                if (CProcess.TrimProcessMemory(TargetProcess,true))
                {
                    MemoryOptimizeElapsed = 0;
                    SendMsg(true, $"결과: {ConvertSize(CProcess.MemoryValue[0])} - {ConvertSize(CProcess.MemoryValue[2])} = {ConvertSize(CProcess.MemoryValue[1])}");
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
                SendMsg(true, "워크래프트 3 메모리 최적화를 시도합니다.");
                if (CProcess.TrimProcessMemory(TargetProcess, true))
                {
                    if (CProcess.MemoryValue[2] < 0)
                    {
                        SendMsg(true, "최적화할 메모리를 찾을 수 없었습니다.");
                    }
                    else SendMsg(true, $"결과: {ConvertSize(CProcess.MemoryValue[0])} - {ConvertSize(CProcess.MemoryValue[2])} = {ConvertSize(CProcess.MemoryValue[1])}");
                }
                else SendMsg(true, "Error - 최적화 중에 예외가 발생했습니다.");
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
                if (!Settings.IsAutoLoad) return;
                Delay(3000);
                LoadCodeSelect();
                
                
                
            }
            else
            {
                if (!WaitLobby && CurrentMusicState == MusicState.BattleNet)
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
                SendMsg(true, "로드된 맵이 없습니다.");
                return;
            }
            SendMsg(true, $"{Path.GetFileName(MapPath)} 맵이 치트맵인지 확인합니다.");
            if (IsCheatMap(MapPath))
                SendMsg(true, "판독 결과: 알려진 치트셋이 사용된 치트맵입니다.");
            else
                SendMsg(true, "판독 결과: 치트맵이 아닌 것 같습니다.");
        }
        internal static void ShowMapPath()
        {
            if (!LoadedFiles.IsLoadedMap(out string MapPath))
            {
                SendMsg(true, "로드된 맵이 없습니다.");
                return;
            }
            SendMsg(true, $"현재 로드된 맵 경로: {MapPath.Substring(MapPath.IndexOf(@"\Warcraft III\Maps\") + 14)}");
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
            SendMsg(true, "단축키 후킹 상태를 재설정하였습니다.");
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
        internal static void SearchRoomListRoom()
        {
            string SearchText = GetFullArgs(true);
            if (string.IsNullOrEmpty(SearchText))
            {
                SendMsg(true, "Error - 검색할 방 제목을 입력해주세요.");
                return;
            }
            SendMsg(true, $"방 제목에 {IsKoreanBlock(SearchText, "이", "가")} 포함된 대기실을 검색하는 중...");
            bool Disconnect = RoomWebDataBase.InitEvent();
            if (Disconnect)
            {
                RoomWebDataBase.EndFirstConnect += () =>
                EndRoomListSearch(RoomWebDataBase.infoList.FindAll(item =>
                    item.flag == "public"
                 && item.status == "open"
                 && item.gname.ToLower().IndexOf(SearchText) != -1), Disconnect);
                RoomWebDataBase.Connect();
            }
            else
                EndRoomListSearch(RoomWebDataBase.infoList.FindAll(item =>
                    item.flag == "public"
                 && item.status == "open"
                 && item.gname.ToLower().IndexOf(SearchText) != -1), Disconnect);
        }
        internal static void SearchRoomListMap()
        {
            string SearchText = GetFullArgs(true);
            if (string.IsNullOrEmpty(SearchText))
            {
                SendMsg(true, "Error - 검색할 맵 파일명을 입력해주세요.");
                return;
            }
            SendMsg(true, $"맵 파일명에 {IsKoreanBlock(SearchText, "이", "가")} 포함된 대기실을 검색하는 중...");
            bool Disconnect = RoomWebDataBase.InitEvent();
            if (Disconnect)
            {
                RoomWebDataBase.EndFirstConnect += () =>
                EndRoomListSearch(RoomWebDataBase.infoList.FindAll(item =>
                    item.flag == "public"
                 && item.status == "open"
                 && item.mapname.ToLower().IndexOf(SearchText) != -1), Disconnect);
                RoomWebDataBase.Connect();
            }
            else
                EndRoomListSearch(RoomWebDataBase.infoList.FindAll(item =>
                    item.flag == "public"
                 && item.status == "open"
                 && item.mapname.ToLower().IndexOf(SearchText) != -1), Disconnect);
        }
        private static void EndRoomListSearch(List<RoomInformation.Field> fields, bool Disconnect)
        {
            if (Disconnect)
            {
                RoomWebDataBase.Disconnect();
                RoomWebDataBase.RemoveAllEvent();
            }
            if (fields.Count == 0)
                SendMsg(true, "조건에 맞는 대기실을 찾을 수 없었습니다.");
            else if (fields.Count <= 2)
                foreach (var item in fields)
                    SendMsg(false, $"{item.gname} [{item.now_players}명] - {item.player0}");
            else
            {
                StringBuilder builder = new StringBuilder();
                SendMsg(true, $"{fields.Count} 개의 대기실을 찾았습니다.");
                fields.Sort((a, b) => (int)(a.now_players - b.now_players));
                foreach (var item in fields)
                    builder.AppendFormat("[{0}명] ", item.now_players);
                SendMsg(false, builder.ToString());
            }
        }

        internal static void LoadCodeSelect()
        {
            string MapPath;
            if (!LoadedFiles.IsLoadedMap(out MapPath))
            {
                SendMsg(true, "로드된 맵이 없습니다.");
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

        internal static void Rework()
        {
            Settings.InstallPath = Path.GetDirectoryName(Warcraft3Info.Process.MainModule.FileName);
            string LastInstallPath = Settings.InstallPath;
            string[] args = GetArguments(Warcraft3Info.ID);
            Warcraft3Info.Process.Kill();
            Delay(2000);
            bool isDebug = false;
            if (File.Exists(Path.Combine(ResourcePath, "JNService", "DEBUG.txt")))
                isDebug = true;
            int windowState = 1;
            if (args.Length != 0)
                switch(args[0].ToLower())
                {
                    case "-windows": windowState = 0; break;
                    case "-nativefullscr": windowState = 2; break;
                }
            WarcraftInit(LastInstallPath, windowState, true, isDebug);
        }

        internal static void RoomJoin()
        {
            StringBuilder arg = new StringBuilder();

            for (int i = 1; i < args.Count - 1; i++)
            {
                arg.Append((args[i]));
                if (i + 1 != args.Count - 1) arg.Append(" ");
            }

            SendMsg(true, $"「{arg}」에 입장합니다.");
            Join.RoomJoin(arg.ToString().Trim());
        }
    }
}
