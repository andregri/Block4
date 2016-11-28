using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media; // add PresentationCore.dll

namespace Exercise01
{
    public class Display
    {
        private double size;
        private uint colors;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public uint Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        public Display(double size, uint colors)
        {
            Size = size;
            Colors = colors;            
        }

    }
}
