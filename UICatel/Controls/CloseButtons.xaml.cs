using System.Windows;
using System.Windows.Controls;

namespace UICatel.Controls
{
    /// <summary>
    /// Логика взаимодействия для CloseButtons.xaml
    /// </summary>
    public partial class CloseButtons :UserControl
    {
        public CloseButtons()
        {
            InitializeComponent();
            
        }

        public static readonly DependencyProperty ConsolidateWindowProperty = DependencyProperty.Register(
            "ConsolidateWindow", typeof(bool?), typeof(CloseButtons), new PropertyMetadata(false));
        
        public bool? ConsolidateWindow
        {
            get { return (bool?) GetValue(ConsolidateWindowProperty); }
            set { SetValue(ConsolidateWindowProperty, value); }
        }


        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = (sender as DependencyObject).FindVisualParent<Window>();
            if (window.WindowState != WindowState.Maximized)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void ButtonClose_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = (sender as DependencyObject).FindVisualParent<Window>();
            if (window.WindowState != WindowState.Minimized)
            {
                window.Close();
            }
        }
    }
}
