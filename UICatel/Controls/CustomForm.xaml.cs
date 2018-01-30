using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UICatel.Controls
{
    public partial class CustomForm
    {
        public CustomForm()
        {
            InitializeComponent();
                                    
        }

        public static readonly DependencyProperty NonClienAreaColorProperty = DependencyProperty.Register(
            "NonClienAreaColor", typeof(Brush), typeof(CustomForm), new PropertyMetadata(default(Brush)));

        public Brush NonClienAreaColor
        {
            get { return (Brush) GetValue(NonClienAreaColorProperty); }
            set { SetValue(NonClienAreaColorProperty, value); }
        }       
       
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window window = (sender as DependencyObject).FindVisualParent<Window>();
                if (window.WindowState != WindowState.Minimized)
                {
                    if (CloseButtons.ConsolidateWindow==false)
                    {
                        window.DragMove();
                    }                    
                }
            }
        }

        private void Grid_Initialized(object sender, System.EventArgs e)
        {
            
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            
        }
    }
}
