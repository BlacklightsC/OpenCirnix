using Cirnix.JassNative.Runtime.Types;

namespace Cirnix.JassNative.InputAPI
{
    public enum KeyboardKeyState { Down, Up, Char }
	public enum MouseButton { Left, Middle, Right, X1, X2 }
	public enum MouseButtonState { Down, Up }

	public delegate void KeyboardKeyEventHandler(int key, char keyChar, KeyboardKeyState state);
	public delegate void MouseClickEventHandler(MouseButton button, MouseButtonState state, Point2 point);
	public delegate void MouseWheelEventHandler(int delta);
	public delegate void PlayerChatEventHandler(object sender, PlayerChatEventArgs e);
}
