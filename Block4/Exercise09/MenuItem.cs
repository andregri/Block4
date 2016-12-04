using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise09
{
    public class MenuItem
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MenuItem(string name)
        {
            Name = name;
        }

        public virtual string printToString()
        {
            return name;
        }
      
    }
}
