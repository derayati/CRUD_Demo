using DerayatiBank.Core.Entities;
using DerayatiBank.Core.Interfaces;
using DerayatiBank.Core.Services;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace DerayatiBank.TestUnit
{
    public class UnitTest1
    {
        private readonly IRepository<Customer> _Customer;
        private CustomerService _customerService;

        [OneTimeSetUp]
        public void Setup()
        {
            _customerService = new CustomerService(_Customer);
        }

        [Test]
        public void TestMethod1()
        {
            var testiii = string.Empty;
            Assert.IsNull(testiii);
        }

        [Test]
        public async void GetCustomers_Ok()
        {
            // Act
            var actualCustomers = await _customerService.GetAllCustomer();

            //assert
            Assert.NotNull(actualCustomers);
        }
    }
}
