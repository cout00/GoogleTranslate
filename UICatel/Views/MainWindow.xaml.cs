using System.Globalization;
using System.Windows;
using System.Windows.Media;
using UICatel.Blink;

namespace UICatel.Views
{
    public partial class MainWindow
    {
        private readonly Blink.Blink _rb;

        public MainWindow()
        {
            InitializeComponent();            
            //_rb = new LeftBlink(this);
        }

        private void UIMainForm_Loaded(object sender, RoutedEventArgs e)
        {
            //_rb.StartMove();
        }
        
    }
}