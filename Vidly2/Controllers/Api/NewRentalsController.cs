using System;
using System.Linq;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            if (newRental.MoviesIds.Count == 0) { return BadRequest("No Movie Ids have been given."); }

            //Get customer
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null) { return BadRequest("Invalid Customer ID"); }
            
            //Get movies
            var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MoviesIds.Count) { return BadRequest("One or more MovieIds are invalid."); }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) { return BadRequest("Movie is not available."); }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}