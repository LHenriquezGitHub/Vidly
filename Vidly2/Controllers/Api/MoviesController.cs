using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies/
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }
        // GET /api/movies/{Id}/
        [HttpGet]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.Single(c => c.Id == Id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        // POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/{Id}/
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (MovieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, MovieInDb);

            return Ok(_context.SaveChanges());
        }

        // DELETE /api/movies/{Id}/
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (MovieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(MovieInDb);
            return Ok(_context.SaveChanges());
        }
    }
}