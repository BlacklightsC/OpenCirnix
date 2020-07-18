using System;
using System.Threading;
using System.Windows.Forms;

using Cirnix.Global;

using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;

namespace Cirnix.Worker
{
    public static class AutoMouse
    {
        private static System.Threading.Timer LeftTimer = new System.Threading.Timer(state => mouse_event(6, 0, 0, 0, 0));
        private static System.Threading.Timer RightTimer = new System.Threading.Timer(state => mouse_event(24, 0, 0, 0, 0));
        private static bool _Enabled, _IsRunning;
        private static Keys _LeftStartKey, _RightStartKey, _EndKey;
        private static int _Interval;
        public static bool Enabled {
            get {
                return _Enabled;
            }
            set {
                if (_Enabled != value)
                {
                    if (value)
                    {
                        if (_LeftStartKey != 0)
                            hotkeyList.Register(_LeftStartKey, OnLeft, _LeftStartKey);
                        if (_RightStartKey != 0)
                            hotkeyList.Register(_RightStartKey, OnRight, _RightStartKey);
                        hotkeyList.Register(_EndKey, Off, _EndKey);
                    }
                    else
                    {
                        if (hotkeyList.IsRegistered(_LeftStartKey))
                            hotkeyList.UnRegister(_LeftStartKey);
                        if (hotkeyList.IsRegistered(_RightStartKey))
                            hotkeyList.UnRegister(_RightStartKey);
                        hotkeyList.UnRegister(_EndKey);
                        LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        _IsRunning = false;
                    }
                }
                _Enabled = value;
                Save();
            }
        }
        public static Keys LeftStartKey {
            get => _LeftStartKey;
            set {
                if (_Enabled)
                {
                    if (hotkeyList.IsRegistered(_LeftStartKey))
                        hotkeyList.UnRegister(_LeftStartKey);
                    hotkeyList.Register(value, OnLeft, value);
                }
                _LeftStartKey = value;
                Save();
            }
        }
        public static Keys RightStartKey {
            get => _RightStartKey;
            set {
                if (_Enabled)
                {
                    if (hotkeyList.IsRegistered(_RightStartKey))
                        hotkeyList.UnRegister(_RightStartKey);
                    hotkeyList.Register(value, OnRight, value);
                }
                _RightStartKey = value;
                Save();
            }
        }
        public static Keys EndKey {
            get => _EndKey;
            set {
                if(_Enabled)
                {
                    hotkeyList.UnRegister(_EndKey);
                    hotkeyList.Register(value, Off, value);
                }
                _EndKey = value;
                Save();
            }
        }
        public static int Interval {
            get => _Interval;
            set {
                _Interval = value;
                Save();
            }
        }
        public static bool IsRegistered(Keys key)
            => _LeftStartKey == key || _RightStartKey == key || _EndKey == key;
        static AutoMouse()
        {
            Read();
            if(_Enabled)
            {
                if (_LeftStartKey != 0)
                    hotkeyList.Register(_LeftStartKey, OnLeft, _LeftStartKey);
                if (_RightStartKey != 0)
                    hotkeyList.Register(_RightStartKey, OnRight, _RightStartKey);
                hotkeyList.Register(_EndKey, Off, _EndKey);
            }
        }
        private static void Save()
        {
            Settings.AutoMouse = $"{_Interval}∫{(int)_LeftStartKey}∫{(int)_RightStartKey}∫{(int)_EndKey}∫{_Enabled}";            
        }
        private static void Read()
        {
            string[] Text = Settings.AutoMouse.Split(new string[] { "∫" }, StringSplitOptions.None);
            if(Text.Length != 5)
            {
                _Interval = 100;
                _LeftStartKey = _RightStartKey = _EndKey = 0;
                _Enabled = false;
                Save();
                return;
            }
            if (!int.TryParse(Text[0], out _Interval)) _Interval = 100;
            _LeftStartKey = int.TryParse(Text[1], out int temp) ? (Keys)temp : 0;
            _RightStartKey = int.TryParse(Text[2], out temp) ? (Keys)temp : 0;
            _EndKey = int.TryParse(Text[3], out temp) ? (Keys)temp : 0;
            if (!bool.TryParse(Text[4], out _Enabled)) _Enabled = false;
        }
        private static void OnLeft(Keys vk)
        {
            if (!_Enabled) return;
            _IsRunning = true;
            RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
            LeftTimer.Change(0, _Interval);
        }
        private static void OnRight(Keys vk)
        {
            if (!_Enabled) return;
            _IsRunning = true;
            LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
            RightTimer.Change(0, _Interval);
        }
        private static void Off(Keys vk)
        {
            if (!_Enabled) return;
            LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
            RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _IsRunning = false;
        }
        internal static void CheckOff()
        {
            if (_IsRunning)
            {
                LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
                RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
                _IsRunning = false;
            }
        }
    }
}
