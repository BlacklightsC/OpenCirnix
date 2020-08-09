using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Types;
using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.InputAPI
{
    public static class Input
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr WndProcPrototype(IntPtr hWnd, uint msg, uint wParam, uint lParam);

		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private delegate bool Unknown__UpdateMousePrototype(IntPtr @this, float uiX, float uiY, IntPtr terrainPtr, IntPtr a4);

		[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
		private unsafe delegate IntPtr CGameUI__DisplayChatMessagePrototype(CGameUI* @this, int sender, string message, ChatRecipients recipients, float duration);

		private static WndProcPrototype WndProc;

		private static Unknown__UpdateMousePrototype Unknown__UpdateMouse;

		private static CGameUI__DisplayChatMessagePrototype CGameUI__DisplayChatMessage;

		public static event MouseClickEventHandler MouseClick;

		public static event MouseWheelEventHandler MouseWheel;

		public static event KeyboardKeyEventHandler KeyboardKey;

		public static event PlayerChatEventHandler PlayerChat;

		public static Point2 MouseWindow { get; private set; }

		public static bool IsMouseOverUI { get; private set; }

		public static Vector2 MouseUI { get; private set; }

		public static Vector3 MouseTerrain { get; private set; }

		public static bool BlockChat { get; set; }

		public unsafe static void Initialize()
		{
			if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
				throw new Exception("Attempted to initialize " + typeof(Input).Name + " before 'game.dll' has been loaded.");
			if (!GameAddresses.IsReady)
				throw new Exception($"Attempted to initialize {typeof(Input).Name} before {typeof(GameAddresses).Name} was ready.");
			WndProc = Memory.InstallHook(GameAddresses.WndProc, new WndProcPrototype(WndProcHook), true, false);
			Unknown__UpdateMouse = Memory.InstallHook(GameAddresses.Unknown__UpdateMouse, new Unknown__UpdateMousePrototype(Unknown__UpdateMouseHook), true, false);
			CGameUI__DisplayChatMessage = Memory.InstallHook(GameAddresses.CGameUI__DisplayChatMessage, new CGameUI__DisplayChatMessagePrototype(CGameUI__DisplayChatMessageHook), true, false);
		}

		private static void OnMouseButton(MouseButton button, MouseButtonState state, Point2 point)
		{
			try
			{
                MouseClick?.Invoke(button, state, point);
            }
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalOnPlayerChat!");
				Trace.WriteLine(ex.ToString());
			}
		}

		private static void OnMouseWheel(int delta)
		{
			try
			{
                MouseWheel?.Invoke(delta);
            }
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalOnPlayerChat!");
				Trace.WriteLine(ex.ToString());
			}
		}

		private static void OnKeyboardKey(int key, char keyChar, KeyboardKeyState state)
		{
			try
			{
                KeyboardKey?.Invoke(key, keyChar, state);
            }
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalOnPlayerChat!");
				Trace.WriteLine(ex.ToString());
			}
		}

		private static short LOWORD(uint dword)
		{
			return (short)(dword & 0xFFFFU);
		}

		private static short HIWORD(uint dword)
		{
			return (short)(dword >> 0x10 & 0xFFFFU);
		}

		private static IntPtr WndProcHook(IntPtr hWnd, uint msg, uint wParam, uint lParam)
		{
			try
			{
				switch (msg)
				{
					case 0x100:
						if ((lParam >> 0x1E & 1U) == 0U)
							OnKeyboardKey((int)wParam, (char)wParam, KeyboardKeyState.Down);
						break;
					case 0x101:
						OnKeyboardKey((int)wParam, (char)wParam, KeyboardKeyState.Up);
						break;
					case 0x102:
						OnKeyboardKey((int)wParam, (char)wParam, KeyboardKeyState.Char);
						break;
					default:
						switch (msg)
						{
							case 0x200:
								MouseWindow = new Point2(LOWORD(lParam), HIWORD(lParam));
								break;
							case 0x201:
								OnMouseButton(MouseButton.Left, MouseButtonState.Down, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x202:
								OnMouseButton(MouseButton.Left, MouseButtonState.Up, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x204:
								OnMouseButton(MouseButton.Right, MouseButtonState.Down, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x205:
								OnMouseButton(MouseButton.Right, MouseButtonState.Up, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x207:
								OnMouseButton(MouseButton.Middle, MouseButtonState.Down, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x208:
								OnMouseButton(MouseButton.Middle, MouseButtonState.Up, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x20A:
								OnMouseWheel(HIWORD(wParam));
								break;
							case 0x20B:
								if (HIWORD(wParam) == 1)
									OnMouseButton(MouseButton.X1, MouseButtonState.Down, new Point2(LOWORD(lParam), HIWORD(lParam)));
								if (HIWORD(wParam) == 2)
									OnMouseButton(MouseButton.X2, MouseButtonState.Down, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
							case 0x20C:
								if (HIWORD(wParam) == 1)
									OnMouseButton(MouseButton.X1, MouseButtonState.Up, new Point2(LOWORD(lParam), HIWORD(lParam)));
								if (HIWORD(wParam) == 2)
									OnMouseButton(MouseButton.X2, MouseButtonState.Up, new Point2(LOWORD(lParam), HIWORD(lParam)));
								break;
						}
						break;
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalWndProcHook!");
				Trace.WriteLine(ex.ToString());
			}
			return WndProc(hWnd, msg, wParam, lParam);
		}

		private static bool Unknown__UpdateMouseHook(IntPtr @this, float uiX, float uiY, IntPtr terrainPtr, IntPtr a4)
		{
			bool flag = Unknown__UpdateMouse(@this, uiX, uiY, terrainPtr, a4);
			try
			{
				IsMouseOverUI = !flag;
				MouseUI = new Vector2(uiX, uiY);
				MouseTerrain = Memory.Read<Vector3>(terrainPtr);
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalUnknown__UpdateMouseHook!");
				Trace.WriteLine(ex.ToString());
			}
			return flag;
		}

		private unsafe static IntPtr CGameUI__DisplayChatMessageHook(CGameUI* _this, int sender, string message, ChatRecipients recipients, float duration)
		{
			try
			{
				PlayerChatEventArgs playerChatEventArgs = new PlayerChatEventArgs(sender, message, recipients, duration);
                PlayerChat?.Invoke(null, playerChatEventArgs);
                if (BlockChat || playerChatEventArgs.IsBlocked) return IntPtr.Zero;
				return CGameUI__DisplayChatMessage(_this, playerChatEventArgs.Sender, playerChatEventArgs.Message, playerChatEventArgs.Recipients, playerChatEventArgs.Duration);
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Unhandled Exception in InternalCGameUI__DisplayChatMessageHook!");
				Trace.WriteLine(ex.ToString());
			}
			return BlockChat ? IntPtr.Zero : CGameUI__DisplayChatMessage(_this, sender, message, recipients, duration);
		}
	}
}
