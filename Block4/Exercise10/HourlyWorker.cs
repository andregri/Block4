using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    class HourlyWorker : Employee
    {
        public double hourlyRate;
        public double hoursWorked; // measured in [minute.second]
         
        public double HourlyRate
        {
            get {return hourlyRate; }
            set
            {
                if (value > 0)
                    hourlyRate = value;
                else
                    throw new ArgumentOutOfRangeException("Hourly rate can not be zero or negative");
            }
        }

        public double HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if (value >= 0)
                    hoursWorked = value;
                else
                    throw new ArgumentOutOfRangeException("Hours worked can not be negative");
            }
        }

        public HourlyWorker(string empName, double hourlyRate, double hoursWorked) : base(empName)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;            
        }

        public override double calcPaidCheck()
        {
            return HourlyRate * HoursWorked;
            
        }
    }
}
