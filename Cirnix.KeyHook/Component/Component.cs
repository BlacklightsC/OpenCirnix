using System;

namespace Cirnix.KeyHook
{
    public static class Component
    {
        internal delegate IntPtr HookProc
        (
            int nCode,
            int wParam,
            ref KeyData lParam
        );

        internal struct KeyData
        {
            internal int vkCode;
            internal int scanCode;
            internal int flags;
            internal int time;
            internal int dwExtraInfo;
        }
    }
}
