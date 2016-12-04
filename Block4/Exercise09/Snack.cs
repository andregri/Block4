using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    public class Snack : MenuItem
    {
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price >= 0)
                    price = value;
                else
                    throw new ArgumentOutOfRangeException("Price can not be negative!");
            }
        }

        public Snack(string name, decimal price) : base (name)
        {
            Price = price;
        }

        public override string printToString()
        {
            return base.printToString() + " - " + string.Format("Price: {0:c}", Price);
        }
    }
}
