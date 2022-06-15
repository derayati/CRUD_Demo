using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }
        public Email() { }
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException();
            if (!address.Contains("@")) throw new ArgumentException("Invalid Email Address");
            Address = address;
        }
    }
}
