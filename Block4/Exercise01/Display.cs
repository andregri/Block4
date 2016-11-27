using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media; // add PresentationCore.dll

namespace Exercise01
{
    class Display
    {
        private double size;
        private Color colorsRGB;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public Color ColorsRGB
        {
            get { return colorsRGB; }
            set { colorsRGB = value; }
        }

        public Display(double size, Color myrgb)
        {
            Size = size;
            ColorsRGB = myrgb;            
        }

    }
}
