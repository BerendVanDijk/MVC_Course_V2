using MVC_Course_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Course_V2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres{ get; set; }
        public Movie Movie { get; set; }
    }
}