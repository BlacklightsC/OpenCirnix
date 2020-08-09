using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public interface IAgent<T>
    {
        IntPtr AsIntPtr();

        CAgent ToBase();
    }
}