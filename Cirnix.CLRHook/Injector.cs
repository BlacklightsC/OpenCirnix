using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

using Cirnix.CLRHook.Properties;
using Cirnix.Global;

using EasyHook;

namespace Cirnix.CLRHook
{
    public static class Injector
    {
        private static void ForceInstall(string Path, byte[] bytes)
        {
            try
            {
                if (CheckDelete(Path))
                    File.WriteAllBytes(Path, bytes);
            }
            catch { }
        }

        private static void CheckDirectory(string Path)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        private static bool CheckInstall(string Path, byte[] bytes)
        {
            try
            {
                if (!File.Exists(Path))
                    File.WriteAllBytes(Path, bytes);
                else
                    using (var SHA256 = new SHA256CryptoServiceProvider())
                    {
                        byte[] source = SHA256.ComputeHash(bytes);
                        byte[] dest = SHA256.ComputeHash(File.ReadAllBytes(Path));
                        if (!source.SequenceEqual(dest))
                            File.WriteAllBytes(Path, bytes);
                        else return false;
                    }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool CheckDelete(string Path)
        {
            try
            {
                if (File.Exists(Path)) 
                    File.Delete(Path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void InstallHookLib()
        {
            string CirnixPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string FilePath = $"{CirnixPath}\\EasyHook.dll";
            if (CheckInstall(FilePath, Resources.EasyHook))
                File.SetAttributes(FilePath, FileAttributes.Hidden);
            if (CheckInstall(FilePath = $"{CirnixPath}\\EasyLoad32.dll", Resources.EasyLoad32))
                File.SetAttributes(FilePath, FileAttributes.Hidden);
        }

        public static void InstallM16Mix(string path)
        {
            string M16Mix = $"{path}\\M16.mix";
            if (File.Exists(M16Mix))
            {
                string ServerMD5 = Globals.GetStringFromServer("http://3d83b79312a03679207d5dbd06de14fe.fx.fo/hash").Trim('\n');
                using (var MD5 = new MD5CryptoServiceProvider())
                {
                    StringBuilder builder = new StringBuilder();
                    byte[] dest = MD5.ComputeHash(File.ReadAllBytes(M16Mix));
                    for (int i = 0; i < dest.Length; i++)
                        builder.Append(dest[i].ToString("x2"));
                    if (ServerMD5 == builder.ToString()) return;
                }
            }
            ForceInstall(M16Mix, Globals.GetDataFromServer("http://3d83b79312a03679207d5dbd06de14fe.fx.fo/M16.mix"));
        }

        public static void InstallYDWE(string JNServicePath)
        {
            string YDWEPath = $"{JNServicePath}\\YDWE";
            string SHA256Path = $"{YDWEPath}\\sha256";
            byte[] LatestSHA256 = null;
            if (Directory.Exists(YDWEPath))
            {
                if (File.Exists(SHA256Path))
                {
                    byte[] sha256 = File.ReadAllBytes(SHA256Path);
                    using (var SHA256 = new SHA256CryptoServiceProvider())
                        LatestSHA256 = SHA256.ComputeHash(Resources.YDWE);
                    if (sha256.SequenceEqual(LatestSHA256)) return;
                }
            }
            else
                Directory.CreateDirectory(YDWEPath);

            using (MemoryStream ms = new MemoryStream(Resources.YDWE))
            using (ZipArchive zipArchive = new ZipArchive(ms))
                foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                    try
                    {
                        string filePath = Path.Combine(YDWEPath, zipArchiveEntry.FullName);
                        string folderPath = Path.GetDirectoryName(filePath);
                        CheckDirectory(folderPath);
                        if (!string.IsNullOrEmpty(Path.GetFileName(filePath)) && CheckDelete(filePath))
                            zipArchiveEntry.ExtractToFile(filePath);
                    }
                    catch (PathTooLongException) { }

            if (LatestSHA256 == null)
                using (var SHA256 = new SHA256CryptoServiceProvider())
                    File.WriteAllBytes(SHA256Path, SHA256.ComputeHash(Resources.YDWE));
            else
                File.WriteAllBytes(SHA256Path, LatestSHA256);
        }

        public static int Init(string path, int windowState = 0, bool isInstallM16 = true, bool isDebug = false)
        {
            Global.Registry.Warcraft.SetFullQualityGraphics();
            string EXEPath = $"{path}\\Warcraft III.exe";
            if (!(File.Exists(EXEPath) || File.Exists(EXEPath = $"{path}\\war3.exe")) 
             || FileVersionInfo.GetVersionInfo(EXEPath).FileVersion != "1.28.5.7680")
                return 0;
            if (!isDebug)
            {
                CheckDelete($"{path}\\m16l.mix");
                if (isInstallM16) InstallM16Mix(path);
            }
            string CirnixPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (!CirnixPath.Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                CheckDelete($"{path}\\EasyHook.dll");
                CheckDelete($"{path}\\EasyLoad32.dll");
            }
            string JNServicePath = $"{Globals.ResourcePath}\\JNService";
            string RuntimePath = $"{JNServicePath}\\Cirnix.JassNative.Runtime.dll";
            string JNServicePluginPath = $"{JNServicePath}\\Plugins";
            CheckDirectory(JNServicePath);
            try
            {
                FileInfo DebugLog = new FileInfo($"{JNServicePath}\\debug.log");
                if (DebugLog.Exists && DebugLog.Length > 0x100000)
                    DebugLog.Delete();
            }
            catch { }
            CheckInstall(RuntimePath, Resources.Cirnix_JassNative_Runtime);
            CheckInstall($"{JNServicePath}\\Cirnix.JassNative.Plugin.dll", Resources.Cirnix_JassNative_Plugin);
            CheckDirectory(JNServicePluginPath);
            CheckInstall($"{JNServicePluginPath}\\Cirnix.JassNative.dll", Resources.Cirnix_JassNative);
            CheckInstall($"{JNServicePluginPath}\\Cirnix.JassNative.Common.dll", Resources.Cirnix_JassNative_Common);
            CheckInstall($"{JNServicePluginPath}\\Cirnix.JassNative.YDWE.dll", Resources.Cirnix_JassNative_YDWE);
            InstallYDWE(JNServicePath);
            //Global.LogManager.Write($"InEXEPath = {EXEPath}\n"
            //                      + $"InCommandLine = {((windowState == 0) ? "-window" : ((windowState == 1) ? "-nativefullscr" : ""))}\n"
            //                      + $"InProcessCreationFlags = 0\n"
            //                      + $"InLibraryPath_x86 = {RuntimePath}\n"
            //                      + $"InLibraryPath_x64 = {RuntimePath}\n"
            //                      + $"OutProcessId = \n"
            //                      + $"InPassThruArgs[0] = {isDebug}\n"
            //                      + $"InPassThruArgs[1] = {CurrentPath}\n"
            //                      + $"InPassThruArgs[2] = {path}");
            //Config.HelperLibraryLocation = CurrentPath;
            string WindowsStateString;
            switch (windowState)
            {
                case 0: WindowsStateString = "-windows"; break;
                case 1: WindowsStateString = string.Empty; break;
                case 2: WindowsStateString = "-nativefullscr"; break;
                default: return 0;
            }
            try
            {
                RemoteHooking.CreateAndInject(EXEPath, WindowsStateString, 0, RuntimePath, RuntimePath, out int pId, isDebug, JNServicePath, path);
                return pId;
            }
            catch (ArgumentException ex)
            {
                MetroDialog.OK("오류", "Warcraft III를 실행하지 못했습니다.\nCirnix를 다시 실행시켜주세요.");
                ExceptionSender.ExceptionSendAsync(ex);
                return 0;
            }
        }
    }
}
