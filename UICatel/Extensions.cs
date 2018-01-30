using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UICatel
{
    public static class  Extensions
    {
        public static T FindVisualParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            if (parentObject is T)
            {
                return parentObject as T;
            }
            else
            {
                return FindVisualParent<T>(parentObject);
            }
        }
    }
}