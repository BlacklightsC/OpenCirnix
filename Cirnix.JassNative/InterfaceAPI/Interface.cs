using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.InterfaceAPI
{
    public static class Interface
	{
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private unsafe delegate IntPtr CGameUI__ConstructorPrototype(CGameUI* @this);
		private static CGameUI__ConstructorPrototype CGameUI__Constructor;

		public unsafe static CGameUI* GameUI { get; private set; }

		public unsafe static void Initialize()
		{
			if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
				throw new Exception("Attempted to initialize Interface before 'game.dll' has been loaded.");
			if (!GameAddresses.IsReady)
				throw new Exception("Attempted to initialize Interface before GameAddresses was ready.");
			CGameUI__Constructor = Memory.InstallHook(GameAddresses.CGameUI__Constructor, new CGameUI__ConstructorPrototype(CGameUI__ConstructorHook), true, false);
		}

		private unsafe static IntPtr CGameUI__ConstructorHook(CGameUI* @this)
		{
			IntPtr result = CGameUI__Constructor(@this);
			try
			{
				GameUI = @this;
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in Interface.CGameUI__ConstructorHook!");
				Trace.WriteLine(ex.ToString());
			}
			return result;
		}
	}
}
