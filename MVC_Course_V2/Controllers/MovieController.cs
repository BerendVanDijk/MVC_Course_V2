using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http.Validation;
using System.Web.Mvc;
using MVC_Course.Models;
using MVC_Course.ViewModels;

namespace MVC_Course.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            { new Customer{Name="Customer 1" },
            new Customer{Name="Customer2" } };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model;

            return View(viewModel);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrEmpty(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year,int month)
        //{
        //    return Content(year+"/"+month);
        //}
        public ActionResult List()
        {
            var movies = new List<Movie>
            { new Movie{Name="Sherek" },
            new Movie{Name="Wall-e" } };
            var viewModel = new MovieListViewModel
            {
                Movies = movies,

            };


            return View(viewModel);
        }

    }


}