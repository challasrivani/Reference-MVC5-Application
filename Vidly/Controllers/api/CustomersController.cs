using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList().Select(Mapper.Map<Customers, CustomerDto>);
            
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if(customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomerDto>(customer));

        }

        // POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customers>(customerDto);

            customer.MembershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == customer.MembershipType.Id);
            _context.Customers.Add(customer);
             _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

        }

        // PUT /api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (ModelState.IsValid == false)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            
            var customerInDB = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customers>(customerDto, customerInDB);
            
            _context.SaveChanges();
            
        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public void DeleteCustomer( byte Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            
        }


    }
}
