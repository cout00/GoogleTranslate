using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleTranslate.Core
{
    public class TesHook
    {
        [System.Runtime.InteropServices.StructLayout(
        System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
        }
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x0101;
        private const int WH_CALLWNDPROC = 4;
        private const int WM_INITMENUPOPUP = 0x0117;

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

        public delegate IntPtr ShiftAltCtrlProc(int nCode, IntPtr wParam, IntPtr lParam);

        private ShiftAltCtrlProc shiftCallBack;
        private IntPtr m_hHook = IntPtr.Zero;
        public event EventHandler<KeyPressedArgs> OnKeyPush;

        public void ShiftAndControlUnHook()
        {
            UnhookWindowsHookEx(m_hHook);
        }

        public TesHook()
        {
            shiftCallBack = LowLevelKeyboardHookProc_shift;
        }

        public void ShiftAndControlHook()
        {

            m_hHook = SetWindowsHookEx(WH_CALLWNDPROC, shiftCallBack, GetModuleHandle(IntPtr.Zero), 0);
        }

        public IntPtr LowLevelKeyboardHookProc_shift(
                int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_INITMENUPOPUP)
            {
                var result = GetAsyncKeyState(Keys.LControlKey);
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if ((objKeyInfo.key == Keys.Q) && Convert.ToBoolean(result & 1))
                {
                    OnKeyPush(this, new KeyPressedArgs(objKeyInfo.key));
                }
            }
            return CallNextHookEx(m_hHook, nCode, wParam, lParam);
        }

        public class KeyPressedArgs :EventArgs
        {
            public Keys PressedKey { get; set; }

            public KeyPressedArgs(Keys altCtrlShiftKey)
            {
                PressedKey = altCtrlShiftKey;
            }
        }
    }
}
