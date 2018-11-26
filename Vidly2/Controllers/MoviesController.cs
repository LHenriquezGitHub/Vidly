using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {                
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null) { return HttpNotFound(); }

            var viewModel = new MovieFormViewModel(movie)
            {             
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {                    
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieIdDb = _context.Movies.Single(c => c.Id == movie.Id);                
                movieIdDb.Name = movie.Name;
                movieIdDb.ReleaseDate = movie.ReleaseDate;
                movieIdDb.GenreId = movie.GenreId;
                movieIdDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



        /****/
        public ActionResult Details(int? Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == Id);            
            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"},
                new Customer {Id = 3, Name = "Customer 3"}
            };
           

            var customerViewModel = new RandomMovieViewModel { Customers = customers, Movie = movie };

            return View(customerViewModel);
        }

        [Route(@"movies/")]
        public ActionResult Movies()
        {
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }

            return View("ReadOnlyList");
        }

        [Route(@"movies/{Id:regex(\d{1})}")]
        public ActionResult Movies(int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            
            movies.RemoveAll(m => m.Id != Id);

            var movieViewModel = new MovieViewModel { Movies = movies };

            return View(movieViewModel);

            
        }


        [Route(@"movies/released/{year:regex(\d{4})}/{month:range(1,12)}")]
        public  ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}