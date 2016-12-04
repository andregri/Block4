using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10
{
    public class HourlyWorker : Employee
    {
        private decimal hourlyRate;
        private decimal hoursWorked; // measured in [hours.minute]
         
        public decimal HourlyRate
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

        public decimal HoursWorked
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

        public HourlyWorker(string empName, decimal hourlyRate, decimal hoursWorked) : base(empName)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;            
        }

        public override decimal calcPaidCheck()
        {
            return HourlyRate * HoursWorked;
            
        }
    }
}
