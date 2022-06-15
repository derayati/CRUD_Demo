using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DerayatiBank.Core.Enums;
using DerayatiBank.Core.ValueObjects;

namespace DerayatiBank.Core.Entities
{
    public sealed class Customer
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Phone PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        
        public CustomerStatus Status { get; private set; }

        public Customer()
        { }

        public Customer (Name name,DateTime dateofbirth,Phone phone,Email email)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateofbirth;
            PhoneNumber = phone;
            Email = email;
        }

        public Customer(Guid id,Name name, DateTime dateofbirth, Phone phone, Email email)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateofbirth;
            PhoneNumber = phone;
            Email = email;
        }

        public Customer(string firstname, string lastname, DateTime dateofbirth, string phonenumber,string countrycode, string email)
        {
            Id = Guid.NewGuid();
            Name = new Name(firstname, lastname ) ;
            DateOfBirth = dateofbirth;
            PhoneNumber = new Phone(countrycode, phonenumber) ;
            Email = new Email(email);
        }


    }
}
