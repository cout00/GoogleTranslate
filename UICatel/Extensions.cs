using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WinForms=System.Drawing;

namespace UICatel
{
    public static class  Extensions
    {
        public struct Hsv
        {
            public double Hue;
            public double Saturation;
            public double Value;
        }


        public static WinForms.Color WpfToGdiColor(this Color self)
        {
            return WinForms.Color.FromArgb(self.A, self.R, self.G, self.B);
        }


        public static Hsv ColorToHsv(this Color self)
        {
            var color = self.WpfToGdiColor();            
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

           var hue = color.GetHue();
      
            var saturation = (max == 0) ? 0 : 1d - (1d * min / max);
           var value = max / 255d;
            return new Hsv() {Hue = hue,Value = value,Saturation = saturation};
        }

        public static Color ColorFromHsv(this Hsv self)
        {
            var hue = self.Hue;
            var value = self.Value;
            var saturation = self.Saturation;
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            byte v = Convert.ToByte(value);
            byte p = Convert.ToByte(value * (1 - saturation));
            byte q = Convert.ToByte(value * (1 - f * saturation));
            byte t = Convert.ToByte(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

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