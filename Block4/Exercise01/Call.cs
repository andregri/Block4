using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    class Call
    {
        private DateTime date;
        private DateTime startTime;
        private double duration;
        private List<Call> history;

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

        public List<Call> CallHistory
        {
            get { return history; }
            private set { history = value; }
        }

        public Call(double duration)
        {
            Date = DateTime.Today;
            StartTime = DateTime.Now;
            CallDuration = duration;

            CallHistory = new List<Call>();
        }
    }
}
