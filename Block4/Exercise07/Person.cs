﻿using System;
using System.Text.RegularExpressions;

namespace Exercise07
{
    public class Person
    {
        //source english wikipedia
        public static string[] sunSigns = {"Aquarius", "Pisces", "Aries", "Taurus",
            "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn"};
        public static int[] sunSignDays = { 20, 19, 21, 20, 21, 21, 23, 23, 23, 23, 23, 22 };

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

        public bool Adult
        {
            get
            {
                int years = DateTime.Today.Year - Birthday.Year;
                if (years > 18)
                {
                    return true;
                }
                else if (years == 18)
                {
                    if (Birthday.Day.CompareTo(DateTime.Now.Day) >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public String SunSign
        {
            get
            {
                int month = Birthday.Month - 1;
                int day = Birthday.Day;

                if (day >= sunSignDays[month])
                {
                    return sunSigns[month];
                }
                return sunSigns[(12 - month) % 12];
            }
        }
    }
}
