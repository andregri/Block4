using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    interface IPayable
    {
        decimal Amount
        {
            get;
        }

        string PaymentAddress
        {
            get;
        }

        void RetrieveAmount(decimal amount);
        void AddAmount(decimal amount);
    }
}
