using DerayatiBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DerayatiBank.Core.Models
{
    public class CustomerViewModel
    {
        public Guid? Id { get; set; }
        public String FirstName { get; set; } = string.Empty;
        public String LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public String PhoneNumber { get; set; } = string.Empty;
        public String CountryCode{ get; set; } = string.Empty;
        public String Email { get; set; }

        public CustomerStatus Status { get; set; } = CustomerStatus.UnSpecified;
    }
}
