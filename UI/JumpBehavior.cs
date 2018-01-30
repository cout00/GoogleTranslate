using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace UI
{
    public class JumpBehavior:Behavior<Window>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var fade = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            AssociatedObject.BeginAnimation(UIElement.OpacityProperty, fade);
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

    }
}
