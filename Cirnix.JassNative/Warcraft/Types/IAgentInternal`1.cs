using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public interface IAgentInternal<T>
  {
    IntPtr AsIntPtr();

    unsafe CAgentInternal* ToBase();
  }
}
