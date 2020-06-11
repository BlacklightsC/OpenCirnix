using CirnoLib.MPQ.Struct;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace Cirnix.Global
{
    public static class Globals
    {
        /*
            다운로드될 InfoData.json에 대한 예시

            {
              "Recommanded_Version": "0.11.7338.2214", // 안정적인 버전
              "Recommanded_URL": "안정적인 버전 다운로드 주소",
              "Latest_Version": "0.11.7338.2214", // 베타 버전
              "Latest_URL": "베타 버전 다운로드 주소",
              "History": "패치 노트 텍스트 파일 주소"
            }
         */
        public static readonly string infoURL = "";


        public static string TargetProcess { get; set; } = "Warcraft III";
        public static readonly string DocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Warcraft III";
        public static readonly string ResourcePath = Environment.GetEnvironmentVariable("APPDATA") + @"\Cirnix";
        public static string[] Code { get; set; }
        public static int[] version { get; set; }
        public static HotkeyList hotkeyList { get; set; }
        public static CommandList commandList { get; set; }
        public static SaveFilePath saveFilePath { get; set; }
        public static string[] Category { get; set; }
        public static bool isOnline { get; set; }
        public static bool isUpdated { get; set; }
        public static CommandTag UserState;
        public static Action ProgramShutDown;
        public static Func<string, int, bool, bool, bool> WarcraftInit; 
        public static Action<int> ListUpdate;
        public static IntPtr GlobalHandle = IntPtr.Zero;
        public static bool ExtendForce = false;
        private static readonly string[] CheatSetPhases = Properties.Resources.CheatSetPhrase.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        public static void InitGlobal(bool IsUpdated)
        {            
            Code = new string[24];
            hotkeyList = new HotkeyList();
            commandList = new CommandList();
            saveFilePath = new SaveFilePath();
            UserState = CommandTag.None;
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            version = new int[4] { ver.Major, ver.Minor, ver.Build, ver.Revision };
            saveFilePath.Read();
            Category = new string[3];
            Category[0] = Settings.MapType;
            Category[1] = Settings.HeroType;
            isOnline = false;
            isUpdated = IsUpdated;
            Theme.LoadTheme();
            ExceptionSender.Init();
            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionSender.Application_ThreadException);
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(ExceptionSender.Application_UnhandledException);
        }
        public static void Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            DateTime AfterWards = ThisMoment.Add(new TimeSpan(0, 0, 0, 0, MS));
            while (AfterWards >= ThisMoment)
            {
                Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
        }
        public static string GetLastest(string directory)
        {
            try
            {
                FileInfo fileInv = null;
                if (Directory.Exists(directory))
                {
                    int result = 0;
                    DirectoryInfo di = new DirectoryInfo(directory);
                    foreach (FileInfo item in di.GetFiles())
                        if (result == 0)
                        {
                            fileInv = item;
                            result = 1;
                        }
                        else
                        {
                            result = DateTime.Compare(fileInv.LastWriteTime, item.LastWriteTime);
                            if (result < 0) fileInv = item;
                            else if (result == 0)
                            {
                                result = DateTime.Compare(fileInv.LastAccessTime, item.LastAccessTime);
                                if (result < 0) fileInv = item;
                                result = 1;
                            }
                        }
                }
                return fileInv?.FullName;
            }
            catch
            {
                return null;
            }
        }
        public static string[] GetDirectoryList(string directory)
        {
            try
            {
                List<string> names = new List<string>();
                if (Directory.Exists(directory))
                {
                    DirectoryInfo di = new DirectoryInfo(directory);
                    foreach (DirectoryInfo item in di.GetDirectories())
                        names.Add(item.Name);
                }
                return names.ToArray();
            }
            catch
            {
                return null;
            }
        }
        public static string[] GetFileList(string directory, bool isOnlyTXT = true)
        {
            try
            {
                List<string> names = new List<string>();
                if (Directory.Exists(directory))
                {
                    DirectoryInfo di = new DirectoryInfo(directory);
                    foreach (FileInfo item in di.GetFiles())
                    {
                        if ((!isOnlyTXT) || item.Extension.ToLower() == ".txt")
                            names.Add(item.Name);
                    }
                }
                return names.ToArray();
            }
            catch
            {
                return null;
            }
        }
        public static string GetCurrentPath(int depth)
        {
            switch (depth)
            {
                case 0:
                    return saveFilePath.GetFullPath(Category[0]);
                case 1:
                    return $"{saveFilePath.GetFullPath(Category[0])}\\{Category[1]}";
                case 2:
                    return $"{saveFilePath.GetFullPath(Category[0])}\\{Category[1]}\\{Category[2]}";
                default:
                    throw new Exception("Unspecified Value.");
            }
        }
        public static string GetFileTime(string Path)
        {
            return new FileInfo(Path).LastAccessTime.ToString("yyyy-MM-dd HH.mm.ss");
        }
        public static void GetCodes()
        {
            if (string.IsNullOrEmpty(Category[0])
             || string.IsNullOrEmpty(Category[1])
             || string.IsNullOrEmpty(Category[2]))
            {
                for (int i = 0; i < 24; i++)
                    Code[i] = string.Empty;
                return;
            }
            List<string> buffer = new List<string>();
            string[] lines = File.ReadAllLines(GetCurrentPath(2));
            bool isFound = false;
            for (int i = 0; true; i++)
            {
                int index;
                if ((index = lines[i].IndexOf("\"Code")) == -1
                 && (index = lines[i].IndexOf("\"저장코드")) == -1)
                    if (isFound) break;
                    else continue;
                isFound = true;
                index += 8;
                buffer.Add(lines[i].Substring(index, lines[i].LastIndexOf(" \" )") - index).Trim());
            }
            for (int i = 0; i < 24; i++)
                Code[i] = i < buffer.Count ? buffer[i] : string.Empty;
            while (true)
            {
                bool isBreak = true;
                for (int i = 0; i < 24; i++)
                {
                    if (string.IsNullOrEmpty(Code[i])) break;
                    if (Code[i][0] == '/')
                    {
                        isBreak = false;
                        for (int j = i; j < 24; j++)
                        {
                            int k = j - 1;
                            if (string.IsNullOrEmpty(Code[j])) break;
                            Code[j] = Code[k][Code[k].Length - 1] + Code[j];
                            Code[k] = Code[k].Substring(0, Code[k].Length - 1);
                        }
                    }
                }
                if (isBreak) return;
            }
        }

        public static void GetCodes2()
        {
            if (string.IsNullOrEmpty(Category[0])
             || string.IsNullOrEmpty(Category[1])
             || string.IsNullOrEmpty(Category[2]))
            {
                for (int i = 0; i < 24; i++)
                    Code[i] = string.Empty;

                return;
            }
            List<string> buffer = new List<string>();
            string[] lines = File.ReadAllLines(GetCurrentPath(2));
            bool isFound = false;
            for (int i = 0; true; i++)
            {
                int index;
                if ((index = lines[i].IndexOf("\"로드 코드")) == -1)
                    if (isFound) break;
                    else continue;
                isFound = true;
                index += 10;
                buffer.Add(lines[i].Substring(index, lines[i].LastIndexOf("\" )") - index).Trim());
            }
            for (int i = 0; i < 24; i++)
                Code[i] = i < buffer.Count ? buffer[i] : string.Empty;
            while (true)
            {
                bool isBreak = true;
                for (int i = 0; i < 24; i++)
                {
                    if (string.IsNullOrEmpty(Code[i])) break;
                    if (Code[i][0] == '/')
                    {
                        isBreak = false;
                        for (int j = i; j < 24; j++)
                        {
                            int k = j - 1;
                            if (string.IsNullOrEmpty(Code[j])) break;
                            Code[j] = Code[k][Code[k].Length - 1] + Code[j];
                            Code[k] = Code[k].Substring(0, Code[k].Length - 1);
                        }
                    }
                }
                if (isBreak) return;
            }
        }

        public static bool IsGrabitiSaveText(string path)
        {
            try
            {
                if (Path.GetExtension(path).ToLower() != ".txt") return false;
                bool isFound = false;
                string[] lines;
                try
                {
                    lines = File.ReadAllLines(path);
                }
                catch
                {
                    Delay(1000);
                    lines = File.ReadAllLines(path);
                }
                for (int i = 0; true; i++)
                {
                    Regex CodePattern = new Regex("^Code[0-9]+: (.+?) $");
                    int index;
                    if ((index = lines[i].IndexOf("\"Code")) == -1
                     && (index = lines[i].IndexOf("\"저장코드")) == -1)
                        if (isFound) break;
                        else continue;
                    isFound = true;
                    index += 8;
                    lines[i].Substring(index, lines[i].LastIndexOf(" \" )") - index);
                }
                return isFound;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsTwrSaveText(string path)
        {
            try
            {
                if (Path.GetExtension(path).ToLower() != ".txt") return false;
                bool isFound = false;
                string[] lines;
                try
                {
                    lines = File.ReadAllLines(path);
                }
                catch
                {
                    Delay(1000);
                    lines = File.ReadAllLines(path);
                }
                for (int i = 0; true; i++)
                {
                    //Regex CodePattern = new Regex("^Code[0-9]+: (.+?) $");
                    int index;
                    if ((index = lines[i].IndexOf("\"로드 코드")) == -1)
                        if (isFound) break;
                        else continue;
                    isFound = true;
                    index += 10;
                    lines[i].Substring(index, lines[i].LastIndexOf("\" )") - index).Trim();
                }
                return isFound;
            }
            catch
            {
                return false;
            }
        }

        public static string GetDataFromServer(string URL)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
                using (Stream stream = client.OpenRead(URL))
                using (StreamReader sReader = new StreamReader(stream))
                    return sReader.ReadToEnd();
            }
        }
        public static byte[] ReadFile(string path)
        {
            byte[] data;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Read bytes from stream and interpret them as ints
                    byte[] buffer = new byte[0x8000000];
                    int count = stream.Read(buffer, 0, buffer.Length);
                    data = new byte[count];
                    // Read from the IO stream fewer times.
                    if (count > 0)
                        for (int i = 0; i < count; i++)
                            data[i] = buffer[i];
                }
            }
            catch
            {
                try
                {
                    Delay(1000);
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        // Read bytes from stream and interpret them as ints
                        byte[] buffer = new byte[0x8000000];
                        int count = stream.Read(buffer, 0, buffer.Length);
                        data = new byte[count];
                        // Read from the IO stream fewer times.
                        if (count > 0)
                            for (int i = 0; i < count; i++)
                                data[i] = buffer[i];
                    }
                }
                catch
                {
                    data = new byte[0];
                }
            }
            return data;
        }
        public static string ConvertSize(double Size)
        {
            bool reversed = false;
            string result;
            if (Size < 0)
            {
                reversed = true;
                Size *= -1;
            }
            if (Size >= 1000000) result = $"{Math.Round(Size / 1048576.0, 1)} MB";
            else if (Size >= 1000) result = $"{Math.Round(Size / 1024.0, 1)} KB";
            else result = $"{Math.Round(Size)} bytes";

            if (reversed) result = '-' + result;

            return result;
        }
        public static string ConvertTick(long Tick)
        {
            StringBuilder TimeText = new StringBuilder();
            long resultTick = Tick;
            bool isFirst = true;
            for (int i = 0; i < 4; i++)
            {
                long t = 1000;
                switch (i)
                {
                    case 0:
                        t = 86400000;
                        break;
                    case 1:
                        t = 3600000;
                        break;
                    case 2:
                        t = 60000;
                        break;
                }
                if (Tick >= t)
                {
                    long temp = resultTick / t;
                    TimeText.AppendFormat("{0}{1}{2}", (temp < 10 && !isFirst) ? "0" : string.Empty, temp, i != 3 ? ":" : string.Empty);
                    resultTick %= t;
                    isFirst = false;
                }
            }
            return TimeText.ToString();
        }
        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
                return false;
            }
            catch (IOException e)
            {
                int errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(e) & ((1 << 16) - 1);
                return errorCode == 32 || errorCode == 33;
            }
        }
        public static string GetDirectorySafeName(string name)
        {
            return name.Replace('\\', ' ').Replace('/', ' ').Replace(':', ' ').Replace('*', ' ').Replace('?', ' ').Replace('\"', ' ').Replace('<', ' ').Replace('>', ' ').Replace('|', ' ');
        }
        /// <summary>
        /// 한국어 받침 체크
        /// </summary>
        /// <param name="name">체크할 문자열</param>
        /// <param name="firstValue">예: 을, 이, 은</param>
        /// <param name="secondValue">예: 를, 가, 는</param>
        /// <returns></returns>
        public static string IsKoreanBlock(string name, string firstValue, string secondValue, bool isNameAdd = true)
        {
            if (name.Length <= 0) return $"{(isNameAdd ? "''" : string.Empty)}{firstValue}";
            char lastName = name[name.Length - 1];
            if (lastName < 0xAC00 || lastName > 0xD7A3) return $"{(isNameAdd ? $"'{name}'" : string.Empty)}({firstValue}){secondValue}";
            string selectedValue = (lastName - 0xAC00) % 28 > 0 ? firstValue : secondValue;
            return $"{(isNameAdd ? $"'{name}'" : string.Empty)}{selectedValue}";
        }

        public static bool IsCheatMap(string path)
        {
            bool result = false;
            using (W3MArchive map = new W3MArchive(path, true))
            {
                MPQFile file = null;
                try
                {
                    file = map.Find(@"scripts\war3map.j");
                    if (file == null) file = map.Find("war3map.j");
                    string JassScript = Encoding.UTF8.GetString(file.File);
                    
                    foreach (string item in CheatSetPhases)
                        if (JassScript.IndexOf(item) != -1)
                        {
                            result = true;
                            break;
                        }
                }
                finally
                {
                    file?.Dispose();
                }
            }
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            return result;
        }
    }
}
