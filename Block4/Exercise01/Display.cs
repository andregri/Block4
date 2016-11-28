using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            string displayInfo = "Display Size: {1}\nDisplay Colors: {2}\n";
            return string.Format(displayInfo, Size, Colors);
        }

    }
}
