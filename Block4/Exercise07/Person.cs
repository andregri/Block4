using System;
using System.Text.RegularExpressions;

namespace Exercise07
{
    public class Person
    {
        //source english wikipedia
        public static string[] sunSigns = {"Aquarius", "Pisces", "Aries", "Taurus",
            "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn"};

        public static int[] sunSignDays = { 20, 19, 21, 20, 21, 21, 23, 23, 23, 23, 23, 22 };

        public static string[] chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake",
            "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        public string FirstName
        {
            get; private set;
        }

        public string LastName
        {
            get; private set;
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
            Email = ScreenName + "@gmail.com";
        }

        public Person(string firstName, string lastName, DateTime birthday, string email)
        {
            Birthday = birthday;
            Email = email;
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

        public string SunSign
        {
            get
            {
                int month = Birthday.Month;
                int day = Birthday.Day;

                if (day >= sunSignDays[month - 1])
                {
                    return sunSigns[month - 1];
                }
                return sunSigns[12 - month];
            }
        }

        public string ChineseSign
        {
            get
            {
                System.Globalization.EastAsianLunisolarCalendar cc = new System.Globalization.ChineseLunisolarCalendar();
                int sexagenaryYear = cc.GetSexagenaryYear(Birthday);
                int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);
                return chineseSigns[terrestrialBranch - 1];
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (Birthday.CompareTo(DateTime.Today) == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public string ScreenName
        {
            get
            {
                return String.Format("{0}{1}{2:00}{3:00}{4:##}", FirstName.ToLower(), LastName.ToLower(),
                    Birthday.Month, Birthday.Day, Birthday.Year.ToString().Substring(2, 2));
            }
        }
    }
}
