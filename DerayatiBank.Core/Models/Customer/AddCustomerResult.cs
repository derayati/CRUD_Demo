using DerayatiBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.Models
{
    public class AddCustomerResult
    {
        public Customer _Customer { get; set; }
        public string Error { get; set; }
    }
}
