using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http.Validation;
using System.Web.Mvc;
using MVC_Course_V2.Models;
using MVC_Course_V2.ViewModels;
using System.Data.Entity;

namespace MVC_Course_V2.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
           
            var viewModel = new MovieListViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList(),

            };


            return View(viewModel);
        }
        public ActionResult Details(int id)
        {

            var viewModel = new MovieListViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList(),
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

            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                

            };
            

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Movie movie)
        {
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };

            if (movie.Id == 0)
            {
                
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;
                
                
            }

            _context.SaveChanges();
            return RedirectToAction("List", "Movie");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };
           
            return View("MovieForm", viewmodel);
        }

    }


}