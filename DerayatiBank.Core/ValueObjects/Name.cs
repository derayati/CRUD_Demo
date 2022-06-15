using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get;private set; }
        public string LastName { get; private set; }

        public Name() { }
        public Name(string firstname,string lastname)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
                throw new ArgumentException("Value Is Null");

            FirstName = firstname;
            LastName = lastname;
        }
    }
}
