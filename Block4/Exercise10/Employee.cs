using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public  abstract class Employee
    {
        public string empName;

        public string Name
        {
            get {return empName; }
            set {empName = value; }
        }

        public Employee(string name)
        {
            Name = empName;
        }

        public abstract int calcPaidCheck();                 
    }
}
