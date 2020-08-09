using System;
using System.Diagnostics;

using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.Runtime.Windows;

using static Cirnix.JassNative.Common.Component;

namespace Cirnix.JassNative.Common
{
    [Requires(typeof(JassAPIPlugin))]
    public sealed class JassMiscellaneous : IPlugin
    {
        private IntPtr GameDllOffset = IntPtr.Zero;

        private delegate void WriteLogPrototype(JassStringArg str);
        private void WriteLog(JassStringArg str) => Trace.WriteLine(str.ToString());

        private delegate JassStringRet GetLocalDateTimePrototype();
        private JassStringRet GetLocalDateTime() => DateTime.Now.ToString();

        private delegate JassRealRet GetUnitDefensePrototype(JassUnit u);
        private unsafe JassRealRet GetUnitDefense(JassUnit u)
        {
            if (u.Handle == IntPtr.Zero) return 0;
            return u.ToCUnit().AsUnsafe()->Defense;
        }

        private delegate void SetUnitDefensePrototype(JassUnit u, JassRealArg r);
        private unsafe void SetUnitDefense(JassUnit u, JassRealArg r)
        {
            if (u.Handle == IntPtr.Zero) return;
            u.ToCUnit().AsUnsafe()->Defense = r;
        }

        private delegate JassRealRet GetMaxAttackSpeedPrototype();
        private JassRealRet GetMaxAttackSpeed()
        {
            return BitConverter.ToSingle(Bring(GameDllOffset + 0xD33DA4, 4), 0);
        }

        private delegate void SetMaxAttackSpeedPrototype(JassRealArg r);
        private void SetMaxAttackSpeed(JassRealArg r)
        {
            Patch(GameDllOffset + 0xD33DA4, BitConverter.GetBytes(r));
        }


        public void Initialize()
        {
            GameDllOffset = Kernel32.GetModuleHandle("game.dll");
            Natives.Add(new WriteLogPrototype(WriteLog));
            Natives.Add(new GetLocalDateTimePrototype(GetLocalDateTime));
            Natives.Add(new GetUnitDefensePrototype(GetUnitDefense));
            Natives.Add(new SetUnitDefensePrototype(SetUnitDefense));
            Natives.Add(new GetMaxAttackSpeedPrototype(GetMaxAttackSpeed));
            Natives.Add(new SetMaxAttackSpeedPrototype(SetMaxAttackSpeed));
        }

        public void OnGameLoad() { }

        public void OnMapStart()
        {
            Patch(GameDllOffset + 0xD33DA4, BitConverter.GetBytes(5f));
        }

        public void OnMapEnd()
        {
            Patch(GameDllOffset + 0xD33DA4, BitConverter.GetBytes(5f));
        }
    }
}