using System;
using System.Text.RegularExpressions;

namespace Exercise07
{
    public class Person
    {
        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w{2,}([-.]\w{2,})*";

                if (Regex.Matches(value, pattern).Count != 1)
                {
                    throw new InvalidMailAddressException(value);
                }
                else
                {
                    email = value;
                }
            }
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                if (value.Year.CompareTo(1900) < 0)
                {
                    throw new TooOldBirthdayException(value);
                }
                else if (value.CompareTo(DateTime.Now) > 0)
                {
                    throw new FutureBirthdayException(value);
                }
                else
                {
                    birthday = value;
                }
            }
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName)
        {
            Email = email;
        }

        public Person(string firstName, string lastName, DateTime birthday)
            : this(firstName, lastName)
        {
            Birthday = birthday;
        }

        public Person(string firstName, string lastName, DateTime birthday, string email)
            : this(firstName, lastName, email)
        {
            Birthday = birthday;
        }
    }
}
