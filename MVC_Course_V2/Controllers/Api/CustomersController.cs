using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using MVC_Course_V2.Models;
using MVC_Course_V2.Dtos;
using AutoMapper;
using MVC_Course_V2;
using MVC_Course_V2.App_Start;
using System.Data.Entity;

namespace MVC_Course_V2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/Customers
        public IEnumerable<CustomerDto>GetCustomers()
        {
            return _context.Customers.Include(c=>c.Membershiptype).ToList().Select(mapper.Map<Customer,CustomerDto>);
        }
        //GET/api/Customers/i
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return NotFound();
            }
            else
            {
                return Ok( mapper.Map<Customer,CustomerDto> (customer));
            }
        }
        //POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto) ;
        }
        //PUT/api/customers/i
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            mapper.Map(customerDto,customerInDb);
            
            _context.SaveChanges();


        }
        //DELETE/api/customers/i
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
