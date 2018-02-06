using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using UICatel.Blink;

namespace UICatel.Views
{
    internal enum AccentState
    {
        ACCENT_DISABLED = 1,
        ACCENT_ENABLE_GRADIENT = 0,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_INVALID_STATE = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AccentPolicy
    {
        public AccentState AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    internal enum WindowCompositionAttribute
    {
        // ...
        WCA_ACCENT_POLICY = 19
        // ...
    }
    public partial class MainWindow
    {
        private NotifyIcon _notifyIcon;

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
        private readonly Blink.Blink _rb;

        public MainWindow()
        {
            InitializeComponent();
            _notifyIcon = new NotifyIcon();

            _notifyIcon.Icon = new Icon(
                @"C:\Users\aizik\Source\Repos\GoogleTranslate\UICatel\Images\icon.ico");
            _notifyIcon.MouseDoubleClick += NotifyIconOnMouseDoubleClick;
            _notifyIcon.Visible = true;
            Loaded += MainWindow_Loaded;
            _rb = new RightBlink(this);
        }

        private void NotifyIconOnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {
            _rb.State = _rb.State == State.Minimazed ? State.Maximazed : State.Minimazed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }

    }
}