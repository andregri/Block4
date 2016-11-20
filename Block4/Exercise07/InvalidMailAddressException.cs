using System;

namespace Exercise07
{
    public class InvalidMailAddressException : Exception
    {
        private string email;

        public override string Message
        {
            get
            {
                return email + " is not a valid email address.";
            }
        }

        public InvalidMailAddressException(string email, Exception inner)
            : base(null, inner)
        {
            this.email = email;
        }

        public InvalidMailAddressException(string email)
            : this(email, null) {
        }
    }
}
