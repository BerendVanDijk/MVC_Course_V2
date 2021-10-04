using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Course_V2.Models;
using MVC_Course_V2.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;

namespace MVC_Course_V2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult List()
        {


            var viewModel = new CustomerListViewModel
            {
                Customers = _context.Customers.Include(c => c.Membershiptype).ToList()
            };
            return View(viewModel);
        }
        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id)
        {
           
            var viewModel = new CustomerListViewModel
            {
                Customers = _context.Customers.Include(c => c.Membershiptype).ToList(),
                Id = id
            };
            if (id <= 0 || id > _context.Customers.ToList().Count)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        public ActionResult New()
        {

            var viewModel = new CustomerFormView
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
                
                
            };
            
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var viewModel = new CustomerFormView
            {
                Customer = customer,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            if (!ModelState.IsValid)
            {
                return View("CustomerForm",viewModel);
            }
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;

            }
            
            _context.SaveChanges();
            return RedirectToAction("List","Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            var viewmodel = new CustomerFormView
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
           
            return View("CustomerForm", viewmodel);
        }
    }
}