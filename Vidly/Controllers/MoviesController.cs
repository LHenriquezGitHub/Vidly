using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = new List<Movie>()
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Trolls" },
                new Movie { Id = 3, Name = "Minion" }
            };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1", Movies = movies.Where(m => m.Id != 3 ).ToList()  },
                new Customer {Name = "Customer 2", Movies = movies.Where(m => m.Id != 2 ).ToList() },
                new Customer {Name = "Customer 3", Movies = movies.Where(m => m.Id != 1 ).ToList() }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movies[0],
                Customers = customers
            };
                        
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy )
        {
            if (!pageIndex.HasValue)pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route(@"movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}