using System;
using Exercise07;

namespace Exercise08
{
    public class Employee : Person, IPayable
    {
        private decimal salary;
        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary should not be negative.");
                }
                salary = value;
            }
        }

        public string MailAddress
        {
            get;
            private set;
        }

        public string PaymentAddress
        {
            get
            {
                return MailAddress;
            }
        }

        public decimal Amount
        {
            get
            {
                return Salary;
            }
        }

        public Employee(string firstName, string lastName, DateTime birthday, string email, string mailAddress, decimal salary)
            : base(firstName, lastName, birthday, email)
        {
            MailAddress = mailAddress;
            Salary = salary;
        }

        public void AddAmount(decimal amount)
        {
            Salary += amount;
        }
    }
}
