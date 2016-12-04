using System;

namespace Exercise07
{
    public class TooOldBirthdayException : ApplicationException
    {
        public DateTime BirthDate
        {
            get;
            set;
        }

        public override string Message
        {
            get
            {
                return "The oldest person in the world is born after 1900. " + BirthDate.ToString() + " is not valid";
            }
        }

        public TooOldBirthdayException(DateTime date, Exception inner)
            : base(null, inner)
        {
            BirthDate = date;
        }

        public TooOldBirthdayException(DateTime date)
            : this(date, null) { }
    }
}
