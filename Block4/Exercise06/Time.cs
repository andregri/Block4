using System;

namespace Exercise06
{
    public struct Time
    {
        private readonly int minutes;

        public Time(int mm)
        {
            minutes = mm;
        }

        public Time(int hh, int mm) : this(60 * hh + mm)
        { }

        public int Hour
        {
            get
            {
                return minutes / 60;
            }
        }

        public int Minute
        {
            get
            {
                return minutes % 60;
            }
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Hour, Minute);
        }

        public static Time operator +(Time time1, Time time2)
        {
            int h = time1.Hour + time2.Hour;
            int m = time1.Minute + time2.Minute;
            return new Time(h, m);
        }

        public static Time operator -(Time time1, Time time2)
        {
            int h = time1.Hour - time2.Hour;
            int m = time1.Minute - time2.Minute;
            return new Time(h, m);
        }

        public static implicit operator Time(int m)
        {
            // since midnight
            return new Time(m % (24 * 60));
        }

        public static explicit operator int(Time t)
        {
            // since midnight
            return t.minutes % (24 * 60);
        }
    }
}
