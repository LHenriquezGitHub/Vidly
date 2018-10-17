using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers/
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }
        // GET /api/customers/{Id}/
        [HttpGet]
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        // POST /api/customers/
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/{Id}/
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (CustomerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, CustomerInDb);

            return Ok(_context.SaveChanges());
        }

        // DELETE /api/customers/{Id}/
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (CustomerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(CustomerInDb);
            return Ok(_context.SaveChanges());
        }
    }
}