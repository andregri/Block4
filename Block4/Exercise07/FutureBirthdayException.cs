using System;

namespace Exercise07
{
    public class FutureBirthdayException : ApplicationException
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
                return "Birth date (" + BirthDate.ToString() + ") couldn't be after current date(" + DateTime.Now.ToString() + ")";
            }
        }

        public FutureBirthdayException(DateTime date, Exception inner)
            : base(null, inner)
        {
            BirthDate = date;
        }

        public FutureBirthdayException(DateTime date)
            : this(date, null) { }
    }
}
