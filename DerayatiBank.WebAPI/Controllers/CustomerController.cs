using AutoMapper;
using DerayatiBank.Core.Entities;
using DerayatiBank.Core.Interfaces;
using DerayatiBank.Core.Models;
using DerayatiBank.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DerayatiBank.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService ProductService)
        {
            _customerService = ProductService;

        }
        
        //Add Customer  
        [HttpPost("AddCustomer")]
        public async Task<object> AddCustomer([FromBody] CustomerViewModel customer)
        {
            try
            {
                var resp = await _customerService.AddCustomer(new Customer(customer.FirstName, customer.LastName, customer.DateOfBirth, customer.PhoneNumber, customer.CountryCode, customer.Email));
                return resp.Error == null ? Ok(resp._Customer) : BadRequest(resp.Error);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _customerService.GetAllCustomer();
            return Ok(item);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return (customer.Id == id) ? Ok(customer) : NotFound();
        }
        
        [HttpGet]
        [Route("GetByEmail/{Email}")]
        public ActionResult GetByEmail(String Email)
        {
            var customer = _customerService.GetCustomerByEmail(Email);
            return (customer.Email.Address == Email) ? Ok(customer) : NotFound();
        }
        
        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult Update(Customer customer)
        {
            return Ok(_customerService.UpdateCustomer(customer));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_customerService.DeleteCustomer(id));
        }
    }
}
