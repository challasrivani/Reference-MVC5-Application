using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        [Route("Movie/Random")]
        public ActionResult Random()
        {
            //var viewModel = new RandomMoviesViewModel();
            //viewModel.Movies = _context.Movies.Include(c=>c.Genre).ToList();
            return View();
        }

        public ActionResult New()
        {
            var newMovie = new Movie() { };
            var viewModel = new NewMovieViewModel()
            {
                Movie = _context.Movies.Add(newMovie),
                Genres = _context.Genres.ToList()
            };
            
            return View(viewModel);
        }

        public ActionResult Create(Movie movie)
        {
            if(ModelState.IsValid == false)
            {
                var viewModel = new NewMovieViewModel()
                {
                    Movie = _context.Movies.SingleOrDefault(m => m.Id == movie.Id),
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            movie.Genre = _context.Genres.SingleOrDefault(m => m.Id == movie.Genre.Id);
            if (movie.Genre == null)
                return Content("New Movie can not be added as the Genre type is not selected.");
            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            //var _context.Movies.SingleOrDefault(m => m.Id == movie.Id).ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

            return RedirectToAction("Random","Movies");
        }
        [Route("Movie/Details/{Id}")]
        public ActionResult Details(byte Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(t => t.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            // return View();
            return Content(year + "/" + month);
        }
        
    }
}