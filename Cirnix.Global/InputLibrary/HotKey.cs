using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using static Cirnix.Global.Globals;

using static Cirnix.Global.NativeMethods;

namespace Cirnix.Global
{
    public static class Hotkey
    {
        [Flags]
        private enum MouseFlags : uint
        {
            LBDOWN = 2,
            LBUP = 4,
            RBDOWN = 8,
            RBUP = 0x10,
            MBDOWN = 0x20,
            MBUP = 0x40,
            WHEEL = 0x800
        }

        [Flags]
        public enum SmartKey : int
        {
            None = int.MinValue,
            Q = 1,
            W = 2,
            E = 4,
            R = 8,
            T = 0x10,
            D = 0x20,
            F = 0x40,
            G = 0x80,
            A = 0x100,
            Z = 0x200,
            X = 0x400,
            C = 0x800,
            V = 0x1000
        }

        public static void SetSmartKey(Keys key, bool isUse)
        {
            int flag = (int)ConvertToSmartKey(key);
            if (flag == 0 || !((Settings.SmartKeyFlag & flag) == flag ^ isUse))
                return;
            Settings.SmartKeyFlag += isUse ? flag : -flag;
            if (isKeyReMapped(key))
            {
                if (isUse)
                {
                    Keys TargetKey = 0;
                    if ((Keys)Settings.KeyMap7 == key) TargetKey = Keys.NumPad7;
                    else if ((Keys)Settings.KeyMap8 == key) TargetKey = Keys.NumPad8;
                    else if ((Keys)Settings.KeyMap4 == key) TargetKey = Keys.NumPad4;
                    else if ((Keys)Settings.KeyMap5 == key) TargetKey = Keys.NumPad5;
                    else if ((Keys)Settings.KeyMap1 == key) TargetKey = Keys.NumPad1;
                    else if ((Keys)Settings.KeyMap2 == key) TargetKey = Keys.NumPad2;
                    hotkeyList.UnRegister(key);
                    hotkeyList.Register(key, SmartKeyFunc, TargetKey);
                }
                else
                {
                    if ((Keys)Settings.KeyMap7 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad7);
                    else if ((Keys)Settings.KeyMap8 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad8);
                    else if ((Keys)Settings.KeyMap4 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad4);
                    else if ((Keys)Settings.KeyMap5 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad5);
                    else if ((Keys)Settings.KeyMap1 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad1);
                    else if ((Keys)Settings.KeyMap2 == key)
                        hotkeyList.Register(key, KeyRemapping, Keys.NumPad2);
                }
            }
            else if (hotkeyList.IsRegistered(key) ^ isUse)
            {
                if (isUse) hotkeyList.Register(key, SmartKeyFunc, key);
                else hotkeyList.UnRegister(key);
            }
        }

        public static bool isSmartKey(Keys key)
        {
            int flag = (int)ConvertToSmartKey(key);
            if ((Settings.SmartKeyFlag & flag) == flag && flag != 0)
                return true;
            return false;
        }

        public static SmartKey ConvertToSmartKey(Keys key)
        {
            switch (key)
            {
                case Keys.Q: return SmartKey.Q;
                case Keys.W: return SmartKey.W;
                case Keys.E: return SmartKey.E;
                case Keys.R: return SmartKey.R;
                case Keys.T: return SmartKey.T;
                case Keys.D: return SmartKey.D;
                case Keys.F: return SmartKey.F;
                case Keys.G: return SmartKey.G;
                case Keys.A: return SmartKey.A;
                case Keys.Z: return SmartKey.Z;
                case Keys.X: return SmartKey.X;
                case Keys.C: return SmartKey.C;
                case Keys.V: return SmartKey.V;
                default:     return SmartKey.None;
            }
        }
        public static bool IsCross = false;
        public static void SmartKeyFunc(Keys key)
        {
            if (Settings.SmartKeyPreventionType == 3)
            {
                keybd_event((byte)Keys.ControlKey, 0, 0, 0x21);
                if (IsCross)
                {
                    keybd_event((byte)Keys.D9, 0, 0, 0x21);
                    keybd_event((byte)Keys.D9, 0, 2, 0x21);
                    keybd_event((byte)Keys.D0, 0, 0, 0x21);
                    keybd_event((byte)Keys.D0, 0, 2, 0x21);
                }
                else
                {
                    keybd_event((byte)Keys.D0, 0, 0, 0x21);
                    keybd_event((byte)Keys.D0, 0, 2, 0x21);
                    keybd_event((byte)Keys.D9, 0, 0, 0x21);
                    keybd_event((byte)Keys.D9, 0, 2, 0x21);
                }
                keybd_event((byte)Keys.ControlKey, 0, 2, 0x21);
            }
            keybd_event((byte)key, 0, 0, 0x21);
            keybd_event((byte)key, 0, 2, 0x21);
            Thread.Sleep(1);
            mouse_event((uint)(MouseFlags.LBDOWN | MouseFlags.LBUP), 0, 0, 0, 0);
            Thread.Sleep(1);
            switch(Settings.SmartKeyPreventionType)
            {
                default:
                    return;
                case 1:
                    keybd_event((byte)Keys.Escape, 0, 0, 0x21);
                    keybd_event((byte)Keys.Escape, 0, 2, 0x21);
                    break;
                case 2:
                    keybd_event((byte)Keys.D1, 0, 0, 0x21);
                    keybd_event((byte)Keys.D1, 0, 2, 0x21);
                    break;
                case 3:
                    if(IsCross)
                    {
                        keybd_event((byte)Keys.D9, 0, 0, 0x21);
                        keybd_event((byte)Keys.D9, 0, 2, 0x21);
                    }
                    else
                    {
                        keybd_event((byte)Keys.D0, 0, 0, 0x21);
                        keybd_event((byte)Keys.D0, 0, 2, 0x21);
                    }
                    IsCross = !IsCross;
                    break;
            }
            Thread.Sleep(1);
        }

        public static string GetSendKeyString(Keys key)
        {
            switch(key)
            {
                case Keys.Back:        return "{BACKSPACE}";
                case Keys.Pause:       return "{BREAK}";
                case Keys.CapsLock:    return "{CAPSLOCK}";
                case Keys.Delete:      return "{DELETE}";
                case Keys.Down:        return "{DOWN}";
                case Keys.End:         return "{END}";
                case Keys.Enter:       return "{ENTER}";
                case Keys.Escape:      return "{ESC}";
                case Keys.Help:        return "{HELP}";
                case Keys.Home:        return "{HOME}";
                case Keys.Insert:      return "{INSERT}";
                case Keys.Left:        return "{LEFT}";
                case Keys.NumLock:     return "{NUMLOCK}";
                case Keys.PageDown:    return "{PGDN}";
                case Keys.PageUp:      return "{PGUP}";
                case Keys.PrintScreen: return "{PRTSC}";
                case Keys.Right:       return "{RIGHT}";
                case Keys.Scroll:      return "{SCROLLLOCK}";
                case Keys.Tab:         return "{TAB}";
                case Keys.Up:          return "{UP}";
                case Keys.F1:          return "{F1}";
                case Keys.F2:          return "{F2}";
                case Keys.F3:          return "{F3}";
                case Keys.F4:          return "{F4}";
                case Keys.F5:          return "{F5}";
                case Keys.F6:          return "{F6}";
                case Keys.F7:          return "{F7}";
                case Keys.F8:          return "{F8}";
                case Keys.F9:          return "{F9}";
                case Keys.F10:         return "{F10}";
                case Keys.F11:         return "{F11}";
                case Keys.F12:         return "{F12}";
                case Keys.F13:         return "{F13}";
                case Keys.F14:         return "{F14}";
                case Keys.F15:         return "{F15}";
                case Keys.F16:         return "{F16}";
                case Keys.Add:         return "{ADD}";
                case Keys.Subtract:    return "{SUBTRACT}";
                case Keys.Multiply:    return "{MULTIPLY}";
                case Keys.Divide:      return "{DIVIDE}";
            }
            return Control.IsKeyLocked(Keys.CapsLock) ? key.ToString().ToUpper() : key.ToString().ToLower();
        }

        public static string GetHotkeyString(Keys key)
        {
            switch(key)
            {
                case 0:                    return "없음";
                case Keys.Escape:          return "Esc";
                case Keys.Scroll:          return "Scroll Lock";
                case Keys.Oemtilde:        return "` ~";
                case Keys.D1:              return "1 !";
                case Keys.D2:              return "2 @";
                case Keys.D3:              return "3 #";
                case Keys.D4:              return "4 $";
                case Keys.D5:              return "5 %";
                case Keys.D6:              return "6 ^";
                case Keys.D7:              return "7 &&";
                case Keys.D8:              return "8 *";
                case Keys.D9:              return "9 (";
                case Keys.D0:              return "0 )";
                case Keys.OemMinus:        return "- _";
                case Keys.Oemplus:         return "= +";
                case Keys.Back:            return "Backspace";
                case Keys.NumLock:         return "Num Lock";
                case Keys.Divide:          return "키패드/";
                case Keys.Multiply:        return "키패드*";
                case Keys.Subtract:        return "키패드-";
                case Keys.Add:             return "키패드+";
                case Keys.NumPad1:         return "키패드1";
                case Keys.NumPad2:         return "키패드2";
                case Keys.NumPad3:         return "키패드3";
                case Keys.NumPad4:         return "키패드4";
                case Keys.NumPad5:         return "키패드5";
                case Keys.NumPad6:         return "키패드6";
                case Keys.NumPad7:         return "키패드7";
                case Keys.NumPad8:         return "키패드8";
                case Keys.NumPad9:         return "키패드9";
                case Keys.NumPad0:         return "키패드0";
                case Keys.Decimal:         return "키패드.";
                case Keys.OemOpenBrackets: return "[ {";
                case Keys.Oem6:            return "] }";
                case Keys.Oem5:            return "\\ |";
                case Keys.Oem1:            return "; :";
                case Keys.Oem7:            return "' \"";
                case Keys.Oemcomma:        return ", <";
                case Keys.OemPeriod:       return ". >";
                case Keys.OemQuestion:     return "/ ?";
                case Keys.KanaMode:        return "한/영";
                case Keys.Apps:            return "메뉴";
                case Keys.HanjaMode:       return "한자";
                case Keys.Left:            return "←";
                case Keys.Up:              return "↑";
                case Keys.Right:           return "→";
                case Keys.Down:            return "↓";
                case Keys.Capital:         return "Caps Lock";
            }
            return key.ToString();
        }

        public static bool isKeyReMapped(Keys key)
        {
            int keyInt = (int)key;
            if (keyInt == Settings.KeyMap7
             || keyInt == Settings.KeyMap8
             || keyInt == Settings.KeyMap4
             || keyInt == Settings.KeyMap5
             || keyInt == Settings.KeyMap1
             || keyInt == Settings.KeyMap2)
                return true;
            return false;
        }

        public static bool RegisterReMappedKey(Keys hotkey, Keys key)
        {
            if (hotkeyList.IsRegistered(hotkey)) return false;
            switch (key)
            {
                case Keys.NumPad7: Settings.KeyMap7 = (int)hotkey; break;
                case Keys.NumPad8: Settings.KeyMap8 = (int)hotkey; break;
                case Keys.NumPad4: Settings.KeyMap4 = (int)hotkey; break;
                case Keys.NumPad5: Settings.KeyMap5 = (int)hotkey; break;
                case Keys.NumPad1: Settings.KeyMap1 = (int)hotkey; break;
                case Keys.NumPad2: Settings.KeyMap2 = (int)hotkey; break;
                default: return false;
            }
            hotkeyList.Register(hotkey, KeyRemapping, key);
            return true;
        }

        public static bool UnRegisterReMappedKey(Keys key)
        {
            if (isKeyReMapped(key))
                return hotkeyList.UnRegister(key);

            return hotkeyList.RemoveAll(item => item.fk == key) > 0;
        }

        public static void KeyRemapping(Keys key)
        {
            keybd_event((byte)key, 0, 0, 0x21);
            keybd_event((byte)key, 0, 2, 0x21);
            Thread.Sleep(1);
        }
    }

    public sealed class HotkeyComponent
    {
        public Keys vk { get; private set; }
        public bool recall { get; private set; }
        public bool onlyInGame { get; private set; }
        public Action<Keys> function { get; private set; }
        public Keys fk { get; private set; }
        internal int id { get; private set; }
        internal bool paused { get; set; } = false;

        internal HotkeyComponent(Keys vk, bool recall, bool onlyInGame, Action<Keys> function, Keys fk, int id)
        {
            this.vk = vk;
            this.recall = recall;
            this.onlyInGame = onlyInGame;
            this.function = function;
            this.fk = fk;
            this.id = id;
        }
    }

    public sealed class HotkeyList : List<HotkeyComponent>
    {
        private int seq = 0;
        public void Register(Keys vk, Action<Keys> function, Keys fk, bool recall = false, bool onlyInGame = true)
        {
            Add(new HotkeyComponent(vk, recall, onlyInGame, function, fk, seq));
            //RegisterHotKey(GlobalHandle, seq++, 0, vk);
        }

        public bool IsRegistered(Keys vk) => hotkeyList.FindIndex(item => item.vk == vk) != -1;

        public void Pause(Keys vk)
        {
            foreach (var item in FindAll(item => item.vk == vk && !item.paused))
            {
                UnregisterHotKey(GlobalHandle, item.id);
                item.paused = true;
            }
        }

        public void Resume(Keys vk)
        {
            foreach (var item in FindAll(item => item.vk == vk && item.paused))
            {
                RegisterHotKey(GlobalHandle, item.id, 0, item.vk);
                item.paused = false;
            }
        }


        public bool UnRegister(Keys vk)
        {
            bool ret = false;
            foreach (var item in FindAll(item => item.vk == vk))
            {
                //UnregisterHotKey(GlobalHandle, item.id);
                Remove(item);
                ret = true;
            }
            return ret;
        }
    }
}
