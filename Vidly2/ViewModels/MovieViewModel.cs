using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieViewModel
    {

        private List<Movie> _Movies;

        public List<Movie> Movies
        {
            get { return _Movies; }
            set
            {
                _Movies = value;
                _HasMovie = (_Movies != null && _Movies.Count > 0) ? true : false;
            }
        }

        private bool _HasMovie;

        public bool HasMovie
        {
            get { return _HasMovie; }
            set { _HasMovie = value; }
        }

    }
}