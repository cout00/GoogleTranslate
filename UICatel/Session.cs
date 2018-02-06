using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UICatel
{
    public static class Session
    {
        public static Brush ThemeBrushLightest;

        public static Brush ThemeBrushLighter;

        public static Brush ThemeBrush;

        public static Brush ThemeBrushDarker;

        public static Brush ThemeBrushDarkest;

        private static Color SetBrightest(double percent, Color inpColor)
        {
            var hsv = inpColor.ColorToHsv();
            hsv.Value *= percent;
            return hsv.ColorFromHsv();
        }

        static Session()
        {
            var startColorRgb = Color.FromRgb(49, 47, 47);
            ThemeBrush = new SolidColorBrush(startColorRgb);
            ThemeBrushDarker = new SolidColorBrush(SetBrightest(0.5, startColorRgb));
            ThemeBrushDarkest = new SolidColorBrush(SetBrightest(0.3, startColorRgb));
            ThemeBrushLighter= new SolidColorBrush(SetBrightest(2, startColorRgb));
            ThemeBrushLightest = new SolidColorBrush(SetBrightest(4, startColorRgb));
        }

    }
}
