using Cirnix.Global;

using System;
using System.Threading;
using System.Windows.Forms;

using static Cirnix.Global.Globals;
using static Cirnix.Global.NativeMethods;

namespace Cirnix.Worker
{
    public sealed class AutoMouse
    {
        private System.Threading.Timer LeftTimer = new System.Threading.Timer(state => mouse_event(6, 0, 0, 0, 0));
        private System.Threading.Timer RightTimer = new System.Threading.Timer(state => mouse_event(24, 0, 0, 0, 0));
        private bool _Enabled;
        private Keys _LeftStartKey, _RightStartKey, _EndKey;
        private int _interval;
        public bool Enabled {
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
                    }
                }
                _Enabled = value;
                Save();
            }
        }
        public Keys LeftStartKey {
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
        public Keys RightStartKey {
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
        public Keys EndKey {
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
        public int interval {
            get => _interval;
            set {
                _interval = value;
                Save();
            }
        }
        public bool IsRegistered(Keys key)
            => _LeftStartKey == key || _RightStartKey == key || _EndKey == key;
        internal AutoMouse()
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
        private void Save()
        {
            Settings.AutoMouse = $"{_interval}∫{(int)_LeftStartKey}∫{(int)_RightStartKey}∫{(int)_EndKey}∫{_Enabled}";            
        }
        private void Read()
        {
            string[] Text = Settings.AutoMouse.Split(new string[] { "∫" }, StringSplitOptions.None);
            if(Text.Length != 5)
            {
                _interval = 100;
                _LeftStartKey = _RightStartKey = _EndKey = 0;
                _Enabled = false;
                Save();
                return;
            }
            if (!int.TryParse(Text[0], out _interval)) _interval = 100;
            _LeftStartKey = int.TryParse(Text[1], out int temp) ? (Keys)temp : 0;
            _RightStartKey = int.TryParse(Text[2], out temp) ? (Keys)temp : 0;
            _EndKey = int.TryParse(Text[3], out temp) ? (Keys)temp : 0;
            if (!bool.TryParse(Text[4], out _Enabled)) _Enabled = false;
        }
        private void OnLeft(Keys vk)
        {
            if (!_Enabled) return;
            RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
            LeftTimer.Change(0, _interval);
        }
        private void OnRight(Keys vk)
        {
            if (!_Enabled) return;
            LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
            RightTimer.Change(0, _interval);
        }
        private void Off(Keys vk)
        {
            if (!_Enabled) return;
            LeftTimer.Change(Timeout.Infinite, Timeout.Infinite);
            RightTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
