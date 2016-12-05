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

        private decimal amount;
        public decimal Amount
        {
            get
            {
                return this.amount;
            }
        }

        public Employee(string firstName, string lastName, DateTime birthday, string email, string mailAddress, decimal salary)
            : base(firstName, lastName, birthday, email)
        {
            MailAddress = mailAddress;
            Salary = salary;
            amount = 0;
        }

        public void AddAmount(decimal amount)
        {
            this.amount += amount;
        }

        public void RetrieveAmount(decimal amount)
        {
            if (amount > Amount)
            {
                throw new ArgumentOutOfRangeException("You cannot retrieve more than your amount.");
            }
            this.amount -= amount;
        }
    }
}
