using DerayatiBank.Core.DbContexts;
using DerayatiBank.Core.Entities;
using DerayatiBank.Core.Interfaces;
using DerayatiBank.Core.Models;
using DerayatiBank.Core.Repository;
using DerayatiBank.Core.Services;
using DerayatiBank.Core.ValueObjects;
using DerayatiBank.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DerayatiBank.Test.Core.Services
{
    [Collection("Integration Tests")]
    public class CustomerServiceShould
    {
        private DbContextOptionsBuilder<ApplicationDbContext> _builder;
        private ApplicationDbContext _dbContext;
        private CustomerService _service;
        CustomerController _controller;

        public CustomerServiceShould()
        {
            _builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Test_CustomerRepository_Database");
            _dbContext = new ApplicationDbContext(_builder.Options);
            _service = new CustomerService(new CustomerRepository(_dbContext));
            _controller = new CustomerController(_service);
        }

        [Fact]
        public void AddCustomer1_NewRequset_Retune_OK()
        {
            //Arrange
            CustomerViewModel expect = new CustomerViewModel { FirstName = "TEST1",LastName = "Family" , DateOfBirth = DateTime.Now , CountryCode = "98" , PhoneNumber = "9151000000" , Email = "TEST1@EMAIL.COM" , Status = DerayatiBank.Core.Enums.CustomerStatus.InActive };

            //Act
            var actual = _controller.AddCustomer(expect);

            //assert
            Assert.IsType<OkObjectResult>(actual.Result);

            //Act
            var actual2 = _controller.GetAll();

            //assert
            Assert.IsType<OkObjectResult>(actual2.Result);
        }

        [Fact]
        public void AddCustomer2_DuplicateCustomer_Request_Fail()
        {
            //Arrange
            CustomerViewModel expect = new CustomerViewModel { FirstName = "TEST1", LastName = "Family", DateOfBirth = DateTime.Now, CountryCode = "98", PhoneNumber = "9151000000", Email = "TEST1@EMAIL.COM", Status = DerayatiBank.Core.Enums.CustomerStatus.InActive };

            //Act
            var actual = _controller.AddCustomer(expect);

            //assert
            Assert.IsType<BadRequestObjectResult>(actual.Result);
        }

        [Fact]
        public void AddCustomer3_IncorrectEmail_Request_Fail()
        {
            //Arrange
            CustomerViewModel expect = new CustomerViewModel { FirstName = "TEST2", LastName = "Family2", DateOfBirth = DateTime.Now, CountryCode = "98", PhoneNumber = "9152000000", Email = "TEST2.EMAIL.COM", Status = DerayatiBank.Core.Enums.CustomerStatus.InActive };

            //Act
            var actual = _controller.AddCustomer(expect);

            //assert
            Assert.IsType<BadRequestObjectResult>(actual.Result);
        }

        [Fact]
        public void GetCustomers_All_Retrun_Ok()
        {
            // arrange

            // Act
            var actual = _controller.GetAll();

            //assert
            //Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual.Result);
        }

        

        [Fact]
        public void UpdateCustomer_Return_OK()
        {
            //Arrange
            var SampleCustomer = _service.GetCustomerByEmail("TEST1@EMAIL.COM");
            var expect = new Customer(SampleCustomer.Id, SampleCustomer.Name, SampleCustomer.DateOfBirth, new Phone("98" ,"915222222"),SampleCustomer.Email);

            //Act
            var actual = _controller.Update(expect);

            //Assert
            Assert.IsType<OkObjectResult>(actual);
        }



    }
}
