using MVC_Course_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Course_V2.ViewModels
{
    public class CustomerFormView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}