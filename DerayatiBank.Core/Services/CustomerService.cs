using DerayatiBank.Common;
using DerayatiBank.Core.Entities;
using DerayatiBank.Core.Interfaces;
using DerayatiBank.Core.Models;
using DerayatiBank.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customer;

        public CustomerService(IRepository<Customer> customer)
        {
            _customer = customer;
        }
        //Get Customer Details By Customer Id
        public async Task<Customer> GetCustomerById(Guid Id)
        {
            return await _customer.GetByIdAsync(Id);
        }
        //GET All Customer Details 
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
                return await _customer.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Customer by Email
        public virtual Customer GetCustomerByEmail(String email)
        {
            return _customer.GetAll().Where(x => x.Email == new Email(email)).FirstOrDefault();
        }
        //Add Customer
        public async Task<AddCustomerResult> AddCustomer(Customer customer)
        {
            if (!ValidatorHelper.EmailIsValid(customer.Email.Address))
                return new AddCustomerResult
                {
                    Error = Resources.Messages.InvalidEmail
                };

            //if (!ValidatorHelper.AccuntNumberIsValid(customer.BankAccountNumber))
            //    return "Invalid AccountNumber";

            //if (!ValidatorHelper.PhoneNumberIsValid(customer.PhoneNumber.Number,customer.PhoneNumber.CountryCode))
            //    return "Invalid PhoneNumber";

            if (_customer.GetAll().Where(x => x.Email == customer.Email).Any())
                return new AddCustomerResult
                {
                    Error = Resources.Messages.DuplicateEmail
                };

            if (_customer.GetAll().Where(x => x.Name == customer.Name && x.DateOfBirth == customer.DateOfBirth).Any())
                return new AddCustomerResult
                {
                    Error = Resources.Messages.DuplicateCustomer
                };

            var result = await _customer.Create(customer);
            return result != null ? new AddCustomerResult {_Customer = result} : new AddCustomerResult {Error = Resources.Messages.Fail} ;
        }
        //Delete Customer 
        public bool DeleteCustomer(string Email)
        {

            try
            {
                var DataList = _customer.GetAll().Where(x => x.Email.Address == Email).ToList();
                foreach (var item in DataList)
                {
                    _customer.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }

        public bool DeleteCustomer(Guid Id)
        {

            try
            {
                var DataList = _customer.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _customer.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Customer Details
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var DataList = _customer.GetAll().ToList();
                foreach (var item in DataList)
                {
                    _customer.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
