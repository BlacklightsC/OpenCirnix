using Cirnix.Global;
using Cirnix.Worker.InnerWorker;

using System.IO;
using System.Threading;

namespace Cirnix.Worker
{
    public static class MainWorker
    {
        private static Commands commands = null;
        internal static AutoRG autoRG = null;
        internal static ManualResetEvent WorkerReset;
        internal static FileSystemWatcher SaveFileWatcher { get; private set; }
        internal static System.Windows.Forms.Timer SaveWatcherTimer { get; private set; }
        public static FileSystemWatcher ReplayWatcher { get; private set; }
        public static FileSystemWatcher ScreenShotWatcher { get; private set; }
        public static FileSystemWatcher MapFileWatcher { get; private set; }
        public static ChatHotkeyList chatHotkeyList { get; private set; }
        public static AutoMouse autoMouse { get; private set; }
        private static bool isInitialaized = false; 

        private static void CheckPath(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void RunWorkers()
        {
            if (isInitialaized) return;
            isInitialaized = true;
            WorkerReset = new ManualResetEvent(false);
            commands = new Commands();
            autoRG = new AutoRG();
            autoMouse = new AutoMouse();

            string path = $"{Globals.DocumentPath}\\CustomMapData";
            CheckPath(path);
            SaveFileWatcher = new FileSystemWatcher(path, "*.txt");
            SaveFileWatcher.Created += Actions.SaveFileWatcher_Created;
            SaveFileWatcher.IncludeSubdirectories = true;
            SaveFileWatcher.EnableRaisingEvents = false;
            SaveFileWatcher.NotifyFilter = NotifyFilters.FileName;

            SaveWatcherTimer = new System.Windows.Forms.Timer();
            SaveWatcherTimer.Interval = 10000;
            SaveWatcherTimer.Tick += Actions.WatcherTimer_Tick;

            CheckPath(path = $"{Globals.DocumentPath}\\Replay");
            ReplayWatcher = new FileSystemWatcher(path, "*.w3g");
            ReplayWatcher.Created += Actions.ReplayWatcher_Function;
            ReplayWatcher.Changed += Actions.ReplayWatcher_Function;
            ReplayWatcher.IncludeSubdirectories = false;
            ReplayWatcher.EnableRaisingEvents = Settings.IsAutoReplay;

            CheckPath(path = $"{Globals.DocumentPath}\\ScreenShots");
            ScreenShotWatcher = new FileSystemWatcher(path, "*.tga");
            ScreenShotWatcher.Created += Actions.ScreenShotWatcher_Created;
            ScreenShotWatcher.IncludeSubdirectories = false;
            ScreenShotWatcher.EnableRaisingEvents = Settings.IsConvertScreenShot;

            CheckPath(path = $"{Globals.DocumentPath}\\Maps");
            MapFileWatcher = new FileSystemWatcher(path, "*.w3x");
            MapFileWatcher.Created += Actions.MapFileWatcher_Created;
            MapFileWatcher.IncludeSubdirectories = true;
            MapFileWatcher.EnableRaisingEvents = Settings.IsCheatMapCheck;

            chatHotkeyList = new ChatHotkeyList();
            for (int i = 0; i < 10; i++)
                if (chatHotkeyList[i].IsRegisted)
                    chatHotkeyList.Register(i);
        }
    }
}
