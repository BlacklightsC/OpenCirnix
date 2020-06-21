using EasyHook;
using System.IO;
using System.Diagnostics;
using Cirnix.CLRHook.Properties;
using System.Security.Cryptography;
using System;
using System.Linq;

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
                    using (var MD5 = new MD5CryptoServiceProvider())
                    {
                        byte[] source = MD5.ComputeHash(bytes);
                        byte[] dest = MD5.ComputeHash(File.ReadAllBytes(Path));
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
            string CirnixPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            CheckInstall(Path.Combine(CirnixPath, "EasyHook.dll"), Resources.EasyHook);
            CheckInstall(Path.Combine(CirnixPath, "EasyLoad32.dll"), Resources.EasyLoad32);
        }

        public static int Init(string path, int windowState = 0, bool isInstallM16 = true, bool isDebug = false)
        {
            Global.Registry.Warcraft.SetFullQualityGraphics();
            string EXEPath = Path.Combine(path, "Warcraft III.exe");
            if (!(File.Exists(EXEPath) || File.Exists(EXEPath = Path.Combine(path, "war3.exe"))) 
             || FileVersionInfo.GetVersionInfo(EXEPath).FileVersion != "1.28.5.7680")
                return 0;
            CheckDelete(Path.Combine(path, "m16l.mix"));
            if (isInstallM16)
            {
                string M16Mix = Path.Combine(path, "M16.mix");
                string M16Mixnew = $"{M16Mix}_new";
                if (File.Exists(M16Mixnew))
                {
                    CheckDelete(M16Mix);
                    File.Move(M16Mixnew, M16Mix);
                }
                else
                    CheckInstall(M16Mix, Resources.M16);
            }
            string JNServicePath = Path.Combine(Global.Globals.ResourcePath, "JNService");
            string RuntimePath = Path.Combine(JNServicePath, "Cirnix.JassNative.Runtime.dll");
            string JNServicePluginPath = Path.Combine(JNServicePath, "Plugins");
            CheckDirectory(JNServicePath);
            CheckInstall(RuntimePath, Resources.Cirnix_JassNative_Runtime);
            CheckInstall(Path.Combine(JNServicePath, "Cirnix.JassNative.Plugin.dll"), Resources.Cirnix_JassNative_Plugin);
            CheckDirectory(JNServicePluginPath);
            CheckInstall(Path.Combine(JNServicePluginPath, "Cirnix.JassNative.dll"), Resources.Cirnix_JassNative);
            CheckInstall(Path.Combine(JNServicePluginPath, "Cirnix.JassNative.Common.dll"), Resources.Cirnix_JassNative_Common);
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
            RemoteHooking.CreateAndInject(EXEPath, WindowsStateString, 0, RuntimePath, RuntimePath, out int pId, isDebug, JNServicePath, path);
            return pId;
        }
    }
}
