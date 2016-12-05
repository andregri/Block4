using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public class Call
    {
        private DateTime date;
        private DateTime startTime;
        private double duration;

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            private set { startTime = value; }
        }

        public double CallDuration
        {
            get { return duration; }
            private set { duration = value; }
        }

        public Call(double duration)
        {
            Date = DateTime.Today;
            StartTime = DateTime.Now;
            CallDuration = duration;
        }
    }
}
