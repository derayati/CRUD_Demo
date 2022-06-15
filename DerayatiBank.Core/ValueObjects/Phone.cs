using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.ValueObjects
{
    public class Phone : ValueObject
    {
        public string CountryCode { get; private set; }
        public string Number { get; private set; }

        public Phone() { }
        public Phone(string countrycode , string number) { if (string.IsNullOrEmpty(number)) throw new ArgumentNullException(); CountryCode = countrycode; Number = number; }
    }
}
