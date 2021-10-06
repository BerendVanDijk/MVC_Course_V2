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

namespace MVC_Course_V2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        private Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET/api/Movies
        public IEnumerable<MovieDto>GetMovies()
        {
            return _context.Movies.ToList().Select(mapper.Map<Movie,MovieDto>);
        }
            

        //GET/api/Movies/i
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id==id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(mapper.Map<Movie, MovieDto>(movie));
            }
        }

        //POST/api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT/api/Movies/i
        [HttpPut]
        public void UpdateMovie(int id,MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        //DELETE/api/Movies/i
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.ToList().SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
