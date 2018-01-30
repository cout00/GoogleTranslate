using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blend.CustomControls
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



        public Brush ButtonColor
        {
            get { return (Brush)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }
            
        // Using a DependencyProperty as the backing store for ButtonColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(CloseButtons), new PropertyMetadata(Brushes.Black, OnColorChanged));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = d;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("helloWorld");
        }
    }
}
