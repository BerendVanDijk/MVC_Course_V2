using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Course.Models;
using MVC_Course.ViewModels;

namespace MVC_Course.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {

            var customers = new List<Customer>
            { new Customer{Name="Jhon Smith" ,Id=1},
            new Customer{Name="Mary Williams",Id=2 } };
            var viewModel = new CustomerListViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }
        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            { new Customer{Name="Jhin Smith",Id=1  },
            new Customer{Name="Mary Williams",Id=2 } };
            var viewModel = new CustomerListViewModel
            {
                Customers = customers,
                Id = id
            };
            if (id <= 0 || id > customers.Count)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
    }
}