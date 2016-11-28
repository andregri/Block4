using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    public class Beverage : MenuItem
    {
        private double small;
        private double medium;
        private double large;

        public double SmallPrice
        {
            get { return small; }
            set
            {
                if (small >= 0)
                    small = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be negative!");                
            }
        }

        public double MediumPrice
        {
            get { return medium; }
            set
            {
                if (medium > small)
                    medium = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be less than 'small'!");
            }
        }
        public double LargePrice
        {
            get { return large; }
            set
            {
                if (large > medium)
                    large = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be less than 'medium'!");
            }
        }

        public Beverage(string name, double small, double medium, double large) : base (name)
        {
            SmallPrice = small;
            MediumPrice = medium;
            LargePrice = large;
        }

        public override string printToString()
        {
            return base.printToString() + " - " + string.Format("Small: {0:c}, Medium: {1:c}, Large: {2:c}", SmallPrice, MediumPrice,LargePrice);
        }
    }
}
