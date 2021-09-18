using MVC_Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Course.ViewModels
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public int Id { get; set; }
    }
}