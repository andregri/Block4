using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public class SalaryWorker : Employee
    {
        private double annualSalary;

        public double Salary
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

        public SalaryWorker(string empName, double annualSalary) : base (empName)
        {
            Salary = annualSalary;
        }

        public override double calcPaidCheck()
        {
            return (annualSalary / 12);
        }
    }
}
