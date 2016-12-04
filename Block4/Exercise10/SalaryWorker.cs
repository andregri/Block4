using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public class SalaryWorker : Employee
    {
        private decimal annualSalary;

        public decimal Salary
        {
            get { return annualSalary; }
            set
            {
                if (value >= 0)
                    annualSalary = value;
                else
                    throw new ArgumentOutOfRangeException("Salary can not be negative!");            
            }
        }

        public SalaryWorker(string empName, decimal annualSalary) : base (empName)
        {
            Salary = annualSalary;
        }

        public override decimal calcPaidCheck()
        {
            return (annualSalary / 12);
        }
    }
}
