using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    public class Beverage : MenuItem
    {
        private decimal small;
        private decimal medium;
        private decimal large;

        public decimal SmallPrice
        {
            get { return small; }
            set
            {
                if (value >= 0)
                    small = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be negative!");                
            }
        }

        public decimal MediumPrice
        {
            get { return medium; }
            set
            {
                if (value > small)
                    medium = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be less than 'small'!");
            }
        }
        public decimal LargePrice
        {
            get { return large; }
            set
            {
                if (value > medium)
                    large = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be less than 'medium'!");
            }
        }

        public Beverage(string name, decimal small, decimal medium, decimal large) : base (name)
        {
            SmallPrice = small;
            MediumPrice = medium;
            LargePrice = large;
        }

        public override string printToString()
        {
            return base.printToString() + " - " + string.Format("Small: {0:c}, Medium: {1:c}, Large: {2:c}", SmallPrice, MediumPrice, LargePrice);
        }
    }
}
