using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public abstract class Employee
    {
        public string name;

        public string Name
        {
            get {return name; }
            set {name = value; }
        }

        public Employee(string name)
        {
            Name = name;
        }

        public abstract decimal calcPaidCheck();
    }
}
