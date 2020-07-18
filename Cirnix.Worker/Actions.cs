using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cirnix.Global;
using Cirnix.Global.Properties;
using Cirnix.KeyHook;
using Cirnix.Memory;
using Cirnix.ServerStatus;

using static Cirnix.Global.Globals;
using static Cirnix.Global.Hotkey;
using static Cirnix.Global.Locale;
using static Cirnix.Global.NativeMethods;
using static Cirnix.Global.SoundManager;
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
        public static void Init()
        {
            InitHotkey();
            InitCommand();

            //AntiZombieProcessChecker = new HangWatchdog(0, 0, 5);
            //AntiZombieProcessChecker.Condition = () => (Warcraft3Info.Process?.MainWindowHandle == IntPtr.Zero) ?? false;
            //AntiZombieProcessChecker.Actions += () => Warcraft3Info.Close();

            MemoryOptimizeChecker = new HangWatchdog(() => new TimeSpan(0, Settings.MemoryOptimizeCoolDown, 0));
            MemoryOptimizeChecker.Condition = () => Settings.IsMemoryOptimize;
            MemoryOptimizeChecker.Actions += async() => await CProcess.TrimProcessMemory(true);
        }

        internal static void InitHotkey()
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
        internal static void InitCommand()
        {
            commandList.Register("lc", "ㅣㅊ", LoadCode);
            commandList.Register("tlc", "싳", LoadCode2);
            commandList.Register("olc", "ㅐㅣㅊ", LoadCode3);
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
            //commandList.Register("test", "ㅅㄷㄴㅅ", LoadCodeSelect);
            commandList.Register("rework", "ㄱㄷ재가", Rework);
            commandList.Register("j", "ㅓ", RoomJoin);
            commandList.Register("c", "ㅊ", RoomCreate);
            commandList.Register("dbg", "윻", KeyDebug);
            commandList.Register("wa", "ㅈㅁ", BanlistCheck);
            commandList.Register("va", "ㅍㅁ", IpAddrMaching);
            commandList.Register("max", "ㅡㅁㅌ", MaxRoom);
            commandList.Register("min", "ㅡㅑㅜ", MinRoom);
            commandList.Register("as", "ㅁㄴ", AutoStarter);
        }
    }

    internal static class Actions
    {
        internal static List<string> args = new List<string>();
        private static string name = string.Empty;
        private static bool IsSaved = false, IsTime = false, WaitGameStart = false, WaitLobby = false, InitializedWarcraft = false;
        private static bool State=false;
        private static int Max;
        private static int Min;
        internal static string GetSafeFullArgs(bool isLower = false)
        {
            StringBuilder arg = new StringBuilder();
            for (int i = 1; i < args.Count - 1; i++)
            {
                arg.Append(GetDirectorySafeName(args[i]));
                if (i + 1 != args.Count - 1) arg.Append(" ");
            }
            return isLower ? arg.ToString().ToLower() : arg.ToString();
        }
        internal static string GetFullArgs(bool isLower = false)
        {
            StringBuilder arg = new StringBuilder();
            for (int i = 1; i < args.Count - 1; i++)
            {
                arg.Append(args[i]);
                if (i + 1 != args.Count - 1) arg.Append(" ");
            }
            return isLower ? arg.ToString().ToLower() : arg.ToString();
        }
        internal static string GetSafeMixArgs(int start, int end = -1, bool isLower = false)
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
        internal static string GetMixArgs(int start, int end = -1, bool isLower = false)
        {
            StringBuilder arg = new StringBuilder();
            if (end == -1) end = args.Count - 1;
            for (int i = start; i < end; i++)
            {
                arg.Append(args[i]);
                if (i + 1 != end) arg.Append(" ");
            }
            return isLower ? arg.ToString().ToLower() : arg.ToString();
        }
        private static async Task SaveFileMover(string path)
        {
            if (!Directory.Exists(GetCurrentPath(1)))
                Directory.CreateDirectory(GetCurrentPath(1));
            if (string.IsNullOrEmpty(name))
            {
                IsTime = true;
                name = GetFileTime(path);
            }
            string FileName = $"{GetCurrentPath(1)}\\{name}.txt";
            if (File.Exists(FileName)) File.Delete(FileName);
            try
            {
                await Task.Delay(1000);
                File.Move(path, FileName);
            }
            catch
            {
                await Task.Delay(1000);
                File.Move(path, FileName);
            }
        }
        internal static async void SaveFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!IsSaved) return;
            if (e.FullPath.IndexOf(GetCurrentPath(0)) != -1)
            {
                MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = false;
                await SaveFileMover(e.FullPath);
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
            else
            {
                string[] lines = await GetLines(e.FullPath);
                if (IsGrabitiSaveText(lines) || IsTwrSaveText(lines))
                {
                    SendMsg(true, "새로운 맵 세이브가 감지되어 자동으로 추가되었습니다.");
                    string path = $"\\{Path.GetDirectoryName(e.FullPath).Substring(DocumentPath.Length)}";
                    string name = path.Substring(path.LastIndexOf('\\') + 1);
                    saveFilePath.AddPath(path, name);
                    Category[0] = name;
                    goto AutoChange;
                }
            }
            ListUpdate(0);
            return;

        AutoChange:
            Category[1] = "미지정";
            await SaveFileMover(e.FullPath);
            ListUpdate(2);
        }
        internal static void WatcherTimer_Tick(object sender, EventArgs e)
        {
            MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = false;
        }
        internal static async void ReplayWatcher_Function(object sender, FileSystemEventArgs e)
        {
            if (Settings.IsOptimizeAfterEndGame && await CProcess.TrimProcessMemory() && Settings.IsMemoryOptimize)
                MemoryOptimizeChecker.Restart();
            if (!Settings.IsAutoReplay)
            {
                IsTime = IsSaved = false;
                name = string.Empty;
                return;
            }
            try
            {
                await Task.Delay(1000);
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
        internal static async void ScreenShotWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!Path.HasExtension(e.FullPath)) return;
            SaveTo(await ReadFile(e.FullPath), $"{Path.GetDirectoryName(e.FullPath)}\\{Path.GetFileNameWithoutExtension(e.FullPath)}", Settings.ConvertExtention);
            if (Settings.IsOriginalRemove) File.Delete(e.FullPath);
        }
        internal static void MapFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            SendMsg(true, $"{Path.GetFileName(e.FullPath)} 맵이 치트맵인지 확인합니다.");
            SendMsg(true, $"판독 결과: 치트맵{(IsCheatMap(e.FullPath) ? " 인것이 확인되었습" : "이 아닙")}니다.");
            MainWorker.MapFileWatcher.EnableRaisingEvents = false;
        }
        internal static async void LoadCode()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetSafeFullArgs();
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
            await Task.Delay(500);
            TypeCommands();
            return;
        Error:
            SendMsg(true, "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다.");
        }

        internal static async void LoadCode2()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetSafeFullArgs();
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
            await Task.Delay(500);
            TypeCommands();
            return;
        Error:
            SendMsg(true, "Error - 기록된 코드가 없거나, 파일을 읽을 수 없습니다.");
        }
        internal static async void LoadCode3()
        {
            if (args.Count > 1 && !string.IsNullOrEmpty(args[1]))
            {
                string saveName = GetSafeFullArgs();
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
                GetCodes3();
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
            await Task.Delay(500);
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

        private static async void TypeCommands(int index = -1)
        {
            string Command;
            switch (index)
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
            if (index != -1 && string.IsNullOrWhiteSpace(Command))
            {
                SendMsg(true, $"명령어 프리셋 {index}이 비어 있습니다.");
                return;
            }
            int GlobalDelay = Settings.GlobalDelay + 100;
            int line = 0;
            bool UseTitle = false, Silent = false;
            List<string> list = new List<string>(Command.Replace("\r", string.Empty).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
            while (list.Count != 0)
            {
                string item = list[0];
                if (item[0] != '#') break;
                string[] str = item.Substring(1).Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (str[0].ToLower())
                {
                    case "silent": Silent = true; break;
                    default: goto EndPreprocess;
                }
                list.RemoveAt(0);
            }
            EndPreprocess:
            if (index != -1 && !Silent) SendMsg(true, $"명령어 프리셋 {index}을 입력합니다.");
            for (; line < list.Count; line++)
            {
                string item = list[line];
                switch (item[0])
                {
                    case '#':
                    {
                        string[] str = item.Substring(1).Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str.Length < 2) break;
                        switch (str[0].ToLower())
                        {
                            case "delay":
                            {
                                if (int.TryParse(str[1], out int result))
                                    await Task.Delay(result);
                                break;
                            }
                            case "globaldelay":
                            {
                                if (int.TryParse(str[1], out int result))
                                    GlobalDelay = result;
                                break;
                            }
                            case "title":
                            {
                                switch (str[1].ToLower())
                                {
                                    case "on":
                                    case "true":
                                        UseTitle = true;
                                        break;
                                    case "off":
                                    case "false":
                                        UseTitle = false;
                                        break;
                                }
                                break;
                            }
                        }
                        break;
                    }
                    case '%': break;
                    default:
                    {
                        if (GlobalDelay > 0) await Task.Delay(GlobalDelay);
                        SendInstantMsg(UseTitle, item);
                        break;
                    }
                }
            }
        }
        internal static void SetSave()
        {
            string saveName = GetSafeFullArgs();
            if (string.IsNullOrEmpty(saveName))
            {
                List<string> list = new List<string>();
                StringBuilder builder = new StringBuilder();
                bool isFirst = true;
                foreach (var item in new DirectoryInfo(GetCurrentPath(0)).GetDirectories())
                {
                    if (isFirst)
                    {
                        builder.Append($"\x1{Theme.MsgTitle} {Theme.MsgColor}분류: ");
                        isFirst = false;
                    }
                    else
                    {
                        if (builder.Length == 0)
                            builder.Append($"\x1{Theme.MsgColor}");
                        builder.Append(", ");
                    }
                    builder.Append(item.Name);
                    string buffer;
                    if (Encoding.UTF8.GetByteCount(buffer = builder.ToString()) >= 80)
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
                string path = $"{GetCurrentPath(0)}\\{saveName}";
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
            string saveName = GetSafeFullArgs();
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
            if (string.IsNullOrEmpty(args[1])
             || !int.TryParse(args[1], out int delay)
             || delay < 0 || delay > 550)
                goto Error;
            SendMsg(true, $"Delay 값: {(IsHostPlayer ? "<Host> " : string.Empty)}{Settings.GameDelay}ms → {args[1]}ms");
            Settings.GameDelay = delay;
            if (IsInGame) GameDelay = Settings.GameDelay;
            return;
        Error:
            SendMsg(true, "Error - Delay 값 범위: 0 ~ 550");
        }
        internal static void SetStartSpeed()
        {
            if (string.IsNullOrEmpty(args[1])
             || !int.TryParse(args[1], out int delay)
             || delay < 0 || delay > 6)
                goto Error;
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
            bool value = HPView;
            SendMsg(true, $"HP 최대값 표기가 {(value ? "나타납" : "사라집")}니다.");
            HPView = !value;
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
            SendMsg(true, new string[] { $"주사위에서 {new Random().Next(diceNumber + 1)} (이)가 나왔습니다. ({diceNumber})" }, 100, false);
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
            if (AutoRG.IsRunning)
            {
                SendMsg(true, "자동 RG 기능이 종료되었습니다.");
                AutoRG.CancelAsync();
                return;
            }
            if (!int.TryParse(args[1], out int value) || value <= 0) goto Error;
            SendMsg(true, $"자동 RG 기능이 시작되었습니다. ▷반복: {args[1]}회");
            AutoRG.RunWorkerAsync(value);
            return;
        Error:
            SendMsg(true, "자동 RG 기능이 시작되었습니다. ▷반복: 무제한");
            AutoRG.RunWorkerAsync(-1);
        }
        internal static async void RpgSave()
        {
            if (!IsInGame) return;
            IsSaved = true;
            name = GetSafeFullArgs();
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
            await SaveFileMover(FileName[0]);
            Category[2] = Path.GetFileName(GetLastest(GetCurrentPath(1)));
            SendMsg(true, $"{Category[1]}\\{Category[2]} 로 저장되었습니다.");
            ListUpdate(2);
            return;

        Error:
            MainWorker.SaveWatcherTimer.Enabled = MainWorker.SaveFileWatcher.EnableRaisingEvents = true;
        }
        internal static void CamDistance()
        {
            if (string.IsNullOrEmpty(args[1])
             || !float.TryParse(args[1], out float value)
             || value > 6000 || value < 0)
                goto Error;
            SendMsg(true, $"설정된 시야 값: {args[1]}");
            Settings.CameraDistance = CameraDistance = value;
            CameraInit();
            return;
        Error:
            SendMsg(true, "Error - 시야 범위: 0 ~ 6000");
        }
        internal static void CamAngleX()
        {
            if (string.IsNullOrEmpty(args[1])
             || !float.TryParse(args[1], out float value)
             || value > 360 || value < 0)
                goto Error;
            SendMsg(true, $"설정된 X축 각도 값: {args[1]}");
            Settings.CameraAngleX = CameraAngleX = value;
            CameraInit();
            return;
        Error:
            SendMsg(true, "Error - X축 각도 범위: 0 ~ 360");
        }
        internal static void CamAngleY()
        {
            if (string.IsNullOrEmpty(args[1])
             || !float.TryParse(args[1], out float value)
             || value > 360 || value < 0)
                goto Error;
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
            Warcraft3Info.Close();
            //ProgramShutDown();
        }

        internal static HangWatchdog MemoryOptimizeChecker;
        //internal static HangWatchdog AntiZombieProcessChecker;
        internal static async Task<bool> ProcessCheck()
        {
            if (GameModule.InitWarcraft3Info() != WarcraftState.OK
                || !GameModule.WarcraftCheck())
            {
                InitializedWarcraft = false;
                if (AutoRG.IsRunning)
                    AutoRG.CancelAsync();
                AutoMouse.CheckOff();
                // 프로그램을 찾지 못할 경우 검색 간격 증가
                Thread.Sleep(800);

                return true;
            }
            else if (!InitializedWarcraft)
            {
                InitializedWarcraft = true;
                await Task.Delay(2000);
                Warcraft3Info.Refresh();
                GameModule.GetOffset();
                GameDelay = 50;
                RefreshCooldown = 0.01f;
                //ColorfulChat = true;
                name = string.Empty;
                StartDelay = Settings.StartSpeed > 0 ? Settings.StartSpeed : 0.01f;
                CameraDistance = Settings.CameraDistance;
                CameraAngleX = Settings.CameraAngleX;
                CameraAngleY = Settings.CameraAngleY;
            }
            if (Settings.IsAutoHp && !HPView) HPView = true;

            //AntiZombieProcessChecker.Check();
            MemoryOptimizeChecker.Check();

            StatusCheck();
            return false;
        }
        internal static async void MemoryOptimize()
        {
            if (Settings.IsMemoryOptimize) MemoryOptimizeChecker.Restart();
            SendMsg(true, "워크래프트 3 메모리 최적화를 시도합니다.");
            if (await CProcess.TrimProcessMemory(true))
            {
                if (CProcess.MemoryValue[2] < 0)
                {
                    SendMsg(true, "최적화할 메모리를 찾을 수 없었습니다.");
                }
                else SendMsg(true, $"결과: {ConvertSize(CProcess.MemoryValue[0])} - {ConvertSize(CProcess.MemoryValue[2])} = {ConvertSize(CProcess.MemoryValue[1])}");
            }
            else SendMsg(true, "Error - 최적화 중에 예외가 발생했습니다.");
        }
        internal static async void StatusCheck()
        {
            if (WaitGameStart)
            {
                if (!GetSelectedReceiveStatus()) return;
                WaitGameStart = false;
                AutoRG.CancelAsync();
                MainWorker.MapFileWatcher.EnableRaisingEvents = false;
                await Task.Delay(500);
                CameraInit();
                GameDelay = Settings.GameDelay;
                if (Settings.IsAutoLoad)
                {
                    await Task.Delay(3000);
                    LoadCodeSelect();
                }
            }
            else
            {
                if (!WaitLobby && CurrentMusicState == MusicState.BattleNet)
                {
                    GameDelay = 50;
                    WaitLobby = true;
                    Warcraft3Info.Refresh();
                }
                if (!WaitLobby || GameDelay != 100) return;
                GameDelay = 550;
                if (Settings.IsCheatMapCheck && !LoadedFiles.IsLoadedMap(out _))
                    MainWorker.MapFileWatcher.EnableRaisingEvents = true;
                if (File.Exists($"{DocumentPath}\\Replay\\LastReplay.w3g"))
                {
                    try
                    {
                        File.Delete($"{DocumentPath}\\Replay\\CirnixReplay.w3g");
                        File.Move($"{DocumentPath}\\Replay\\LastReplay.w3g", $"{DocumentPath}\\Replay\\CirnixReplay.w3g");
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
            SendMsg(true, $"현재 로드된 맵 경로: {MapPath.Substring(MapPath.IndexOf("\\Warcraft III\\Maps\\") + 14)}");
        }
        private static async void KeyDebugFunc()
        {
            KeyboardHooker.HookEnd();
            await Task.Delay(1);
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

        internal static async void LoadCodeSelect()
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
                await Task.Delay(3000);
                LoadCode2();
            }
            else
            {
                LoadCode();
            }
        }

        internal static async void Rework()
        {
            string LastInstallPath = Path.GetDirectoryName(Warcraft3Info.Process.MainModule.FileName);
            Settings.InstallPath = LastInstallPath;
            string[] args = GetArguments(Warcraft3Info.ID);
            Warcraft3Info.Close();

            await Task.Delay(2000);
            int windowState = 1;
            if (args.Length != 0)
                switch(args[0].ToLower())
                {
                    case "-windows": windowState = 0; break;
                    case "-nativefullscr": windowState = 2; break;
                }
            int pId = WarcraftInit(LastInstallPath, windowState, true, File.Exists(Path.Combine(ResourcePath, "JNService", "DEBUG.txt")));
            if (pId != 0)
            {
                await Task.Delay(5000);
                GameModule.InitWarcraft3Info(pId);
            }
        }

        internal static void RoomJoin()
        {
            string arg = GetFullArgs();
            SendMsg(true, $"'{arg}'에 입장합니다.");
            Join.RoomJoin(arg);
        }

        internal static void RoomCreate()
        {
            string arg = GetFullArgs();
            SendMsg(true, $"'{arg}'방을 생성합니다.");
            Join.RoomCreate(arg);
        }

        internal static void BanlistCheck()
        {
            BanList.CheckBanList();
        }

        internal static void IpAddrMaching()
        {
            BanList.IPAddrMaching();
        }

        internal async static void MaxRoom()
        {
            string arg = GetFullArgs();
            State = true;
            try
            {
                if (arg == "off")
                {
                    SendMsg(true, "알림설정을 취소합니다.");
                    return;
                }
                Max = Convert.ToInt32(arg);
                SendMsg(true, $"'{Max}'명 이상이 될때 알립니다.");
                if (State)
                {
                    do
                    {
                        await Task.Delay(500);
                    }
                    while (Max > PlayerCount);
                    SendMsg(true, $"'{Max}'명 이상이 되었습니다.");
                    Play(Resources.max);
                    State = false;
                    Max = 0;
                }
            }
            catch
            {
                SendMsg(true, "알림설정을 실패하였습니다.");
            }
        }


        internal async static void MinRoom()
        {
            string arg = GetFullArgs();
            State = true;
            try
            {
                if (arg == "off")
                {
                    SendMsg(true, "알림설정을 취소합니다.");
                    return;
                }
                Min = Convert.ToInt32(arg);
                SendMsg(true, $"'{Min}'명 이하가 될때 알립니다.");
                if (State)
                {
                    do
                    {
                        await Task.Delay(500);
                    }
                    while (Min < PlayerCount);
                    SendMsg(true, $"'{Min}'명 이하가 되었습니다.");
                    Play(Resources.max);
                    State = false;
                    Min = 0;
                }
            }
            catch
            {
                SendMsg(true, "알림설정을 실패하였습니다.");
            }
        }

        internal async static void AutoStarter()
        {
            string arg = GetFullArgs();
            try
            {
                if (arg == "off")
                {
                    SendMsg(true," 자동 시작을 취소합니다.");
                    return;
                }
                else
                {
                    Max = Convert.ToInt32(arg);
                    SendMsg(true, $"'{Max}'명 입장시 10초후 시작합니다.");
                    SendMsg(true, "만약 다운로드 유저가 있을시 시작하지 못할 수 있습니다.");
                    do
                    {
                        await Task.Delay(500);
                    }
                    while (Max > PlayerCount);
                    Play(Resources.max);
                    for (int i = 10; i > 0; i--)
                    {
                        if (Max > PlayerCount)
                        {
                            SendMsg(true, "지정된 인원보다 수가 적습니다. 시작을 취소합니다.");
                            return;
                        }
                        SendMsg(true, $"{i}초후 게임을 시작합니다.");
                        await Task.Delay(1000);
                    }
                    PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 18, 0);
                    PostMessage(Warcraft3Info.MainWindowHandle, 0x100, 83, 0);
                    PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 18, 0);
                    PostMessage(Warcraft3Info.MainWindowHandle, 0x101, 83, 0);
                }
                Max = 0;
            }
            catch
            {
                SendMsg(true, "알림설정을 실패하였습니다.");
            }
        }
    }
}
