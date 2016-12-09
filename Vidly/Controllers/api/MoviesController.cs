using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);

        }

        //GET /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
            
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.Genre = _context.Genres.SingleOrDefault(m => m.Id == movieDto.Genre.Id);
            _context.Movies.Add(movie);

            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
            
        }

        [HttpPut]
        public void UpdateMovie(int Id, MovieDto movieDto)
        {

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDB == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDB);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDB == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            _context.Movies.Remove(movieInDB);

            _context.SaveChanges();

        }
    }
}
