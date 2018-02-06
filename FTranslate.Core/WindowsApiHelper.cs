using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace FTranslate.Core
{
    public static class WindowsApiHelper
    {
        [System.Runtime.InteropServices.StructLayout(
            System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public readonly Keys key;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x0101;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, ShiftAltCtrlProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys ArrowKeys);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);


        public delegate IntPtr ShiftAltCtrlProc(int nCode, IntPtr wParam, IntPtr lParam);

        static readonly ShiftAltCtrlProc ShiftCallBack;
        static IntPtr _mHHook = IntPtr.Zero;
        public static event EventHandler<KeyPressedArgs> OnKeyPush;

        public static void RemoveKeyBoardHook()
        {
            UnhookWindowsHookEx(_mHHook);
        }

        static WindowsApiHelper()
        {
            ShiftCallBack = LowLevelKeyboardHookProc;
        }

        public static void SetKeyBoardHook()
        {
            _mHHook = SetWindowsHookEx(WH_KEYBOARD_LL, ShiftCallBack, GetModuleHandle(IntPtr.Zero), 0);
        }

        public static Point GetCurMousePos()
        {
            Point lpPoint;
            GetCursorPos(out lpPoint);
            return lpPoint;
        }

        public static void SendGetText()
        {
            InputSimulator isim = new InputSimulator();
            isim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_C);
            Thread.Sleep(50);
        }

        static IntPtr LowLevelKeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN)
            {
                var result = GetAsyncKeyState(Keys.LControlKey);
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT) Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if ((objKeyInfo.key == Keys.Q) && Convert.ToBoolean(result & 1))
                {
                    OnKeyPush?.Invoke(null, new KeyPressedArgs(objKeyInfo.key));
                    return (IntPtr) 1;
                }
            }
            return CallNextHookEx(_mHHook, nCode, wParam, lParam);
        }

        public class KeyPressedArgs : EventArgs
        {
            public Keys PressedKey { get; set; }

            public KeyPressedArgs(Keys altCtrlShiftKey)
            {
                PressedKey = altCtrlShiftKey;
            }
        }
    }
}