using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Course_V2.Models;
using MVC_Course_V2.ViewModels;
using System.Data.Entity;

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
                Customers = _context.Customers.ToList(),
                Id = id
            };
            if (id <= 0 || id > _context.Customers.ToList().Count)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
    }
}