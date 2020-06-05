﻿using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
  [StructLayout(LayoutKind.Sequential, Size = 404)]
  public struct CSimpleMessageFrame
  {
    public unsafe CSimpleMessageFrame.VTable* Methods;
    public IntPtr field0004;
    public IntPtr field0008;
    public IntPtr field000C;
    public IntPtr field0010;
    public IntPtr field0014;
    public IntPtr field0018;
    public IntPtr field001C;
    public IntPtr field0020;
    public IntPtr field0024;
    public IntPtr field0028;
    public IntPtr field002C;
    public IntPtr field0030;
    public IntPtr field0034;
    public IntPtr field0038;
    public IntPtr field003C;
    public IntPtr field0040;
    public IntPtr field0044;
    public IntPtr field0048;
    public IntPtr field004C;
    public IntPtr field0050;
    public IntPtr field0054;
    public IntPtr field0058;
    public IntPtr field005C;
    public IntPtr field0060;
    public IntPtr field0064;
    public IntPtr field0068;
    public IntPtr field006C;
    public IntPtr field0070;
    public IntPtr field0074;
    public IntPtr field0078;
    public IntPtr field007C;
    public IntPtr field0080;
    public IntPtr field0084;
    public IntPtr field0088;
    public IntPtr field008C;
    public IntPtr field0090;
    public IntPtr field0094;
    public IntPtr field0098;
    public IntPtr field009C;
    public IntPtr field00A0;
    public IntPtr field00A4;
    public IntPtr field00A8;
    public IntPtr field00AC;
    public IntPtr field00B0;
    public IntPtr field00B4;
    public IntPtr field00B8;
    public IntPtr field00BC;
    public IntPtr field00C0;
    public IntPtr field00C4;
    public IntPtr field00C8;
    public IntPtr field00CC;
    public IntPtr field00D0;
    public IntPtr field00D4;
    public IntPtr field00D8;
    public IntPtr field00DC;
    public IntPtr field00E0;
    public IntPtr field00E4;
    public IntPtr field00E8;
    public IntPtr field00EC;
    public IntPtr field00F0;
    public IntPtr field00F4;
    public IntPtr field00F8;
    public IntPtr field00FC;
    public IntPtr field0100;
    public IntPtr field0104;
    public IntPtr field0108;
    public IntPtr field010C;
    public IntPtr field0110;
    public IntPtr field0114;
    public IntPtr field0118;
    public IntPtr field011C;
    public IntPtr field0120;
    public IntPtr field0124;
    public IntPtr field0128;
    public IntPtr field012C;
    public IntPtr field0130;
    public IntPtr field0134;
    public IntPtr field0138;
    public IntPtr field013C;
    public IntPtr field0140;
    public IntPtr field0144;
    public IntPtr field0148;
    public IntPtr field014C;
    public IntPtr field0150;
    public IntPtr field0154;
    public IntPtr field0158;
    public IntPtr field015C;
    public IntPtr field0160;
    public IntPtr field0164;
    public IntPtr field0168;
    public IntPtr field016C;
    public IntPtr field0170;
    public IntPtr field0174;
    public IntPtr field0178;
    public IntPtr field017C;
    public IntPtr field0180;
    public IntPtr field0184;
    public IntPtr field0188;
    public IntPtr field018C;
    public IntPtr field0190;

    public unsafe void Method26()
    {
      fixed (CSimpleMessageFrame* @this = &this)
      {
        IntPtr num = this.Methods->Method26(@this);
      }
    }

    public unsafe void WriteLine(string message, Color* color, float duration)
    {
      fixed (CSimpleMessageFrame* @this = &this)
      {
        IntPtr num = this.Methods->WriteLine(@this, message, color, duration);
      }
    }

    public unsafe void WriteLine(string message, Color color, float duration)
    {
      this.WriteLine(message, &color, duration);
    }

    public struct VTable
    {
      public IntPtr Method0;
      public IntPtr Method1;
      public IntPtr Destroy;
      public IntPtr Method3;
      public IntPtr Method4;
      public IntPtr Method5;
      public IntPtr Method6;
      public IntPtr Method7;
      public IntPtr Method8;
      public IntPtr Method9;
      public IntPtr Method10;
      public IntPtr Method11;
      public IntPtr Method12;
      public IntPtr Method13;
      public IntPtr Method14;
      public IntPtr Method15;
      public IntPtr Method16;
      public IntPtr Method17;
      public IntPtr Method18;
      public IntPtr Method19;
      public IntPtr Method20;
      public IntPtr Method21;
      public IntPtr Method22;
      public IntPtr Method23;
      public IntPtr Method24;
      public IntPtr Method25;
      public IntPtr Method26Ptr;
      public IntPtr WriteLinePtr;

      public CSimpleMessageFrame.VTable.Method26Prototype Method26
      {
        get
        {
          return (CSimpleMessageFrame.VTable.Method26Prototype) Marshal.GetDelegateForFunctionPointer(this.Method26Ptr, typeof (CSimpleMessageFrame.VTable.Method26Prototype));
        }
      }

      public CSimpleMessageFrame.VTable.WriteLinePrototype WriteLine
      {
        get
        {
          return (CSimpleMessageFrame.VTable.WriteLinePrototype) Marshal.GetDelegateForFunctionPointer(this.WriteLinePtr, typeof (CSimpleMessageFrame.VTable.WriteLinePrototype));
        }
      }

      [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
      public unsafe delegate IntPtr Method26Prototype(CSimpleMessageFrame* @this);

      [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
      public unsafe delegate IntPtr WriteLinePrototype(CSimpleMessageFrame* @this, string message, Color* color, float duration);
    }
  }
}
