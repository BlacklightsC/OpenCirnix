using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI
{
    public static class Game
    {
        private static Unknown__SetStatePrototype Unknown__SetState;

        public static event Action EngineStart;

        public static event Action EngineEnd;

        public static event Action MapStart;

        public static event Action MapEnd;

        public static bool IsEngineRunning { get; private set; }

        public static bool IsInMap { get; private set; }

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception("Attempted to initialize " + typeof(Game).Name + " before 'game.dll' has been loaded.");
            if (!GameAddresses.IsReady)
                throw new Exception("Attempted to initialize " + typeof(Game).Name + " before " + typeof(GameAddresses).Name + " was ready.");
            Unknown__SetState = Memory.InstallHook(GameAddresses.Unknown__SetState, new Unknown__SetStatePrototype(Unknown__SetStateHook), true, false);
        }

        private static void OnEngineStart()
        {
            try
            {
                EngineStart?.Invoke();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unhandled Exception in " + typeof(Game).Name + ".OnEngineStart!");
                Trace.WriteLine(ex.ToString());
            }
        }

        private static void OnEngineEnd()
        {
            try
            {
                EngineEnd?.Invoke();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unhandled Exception in " + typeof(Game).Name + ".OnEngineEnd!");
                Trace.WriteLine(ex.ToString());
            }
        }

        private static void OnMapStart()
        {
            try
            {
                MapStart?.Invoke();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unhandled Exception in " + typeof(Game).Name + ".OnMapStart!");
                Trace.WriteLine(ex.ToString());
            }
        }

        private static void OnMapEnd()
        {
            try
            {
                MapEnd?.Invoke();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unhandled Exception in " + typeof(Game).Name + ".OnMapEnd!");
                Trace.WriteLine(ex.ToString());
            }
        }

        private static int Unknown__SetStateHook(IntPtr @this, bool endMap, bool endEngine)
        {
            try
            {
                if (endEngine)
                {
                    if (IsInMap)
                    {
                        IsInMap = false;
                        OnMapEnd();
                    }
                    if (IsEngineRunning)
                    {
                        IsEngineRunning = false;
                        OnEngineEnd();
                    }
                }
                else if (endMap)
                {
                    if (IsInMap)
                    {
                        IsInMap = false;
                        OnMapEnd();
                    }
                }
                else
                {
                    if (!IsEngineRunning)
                    {
                        OnEngineStart();
                        IsEngineRunning = true;
                    }
                    if (IsInMap)
                        OnMapEnd();
                    OnMapStart();
                    IsInMap = true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Unhandled Exception in {nameof(Game)}.{nameof(Unknown__SetStateHook)}!");
                Trace.WriteLine(ex.ToString());
            }
            return Unknown__SetState(@this, endMap, endEngine);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int Unknown__SetStatePrototype(IntPtr _this, bool endMap, bool endEngine);
    }
}
