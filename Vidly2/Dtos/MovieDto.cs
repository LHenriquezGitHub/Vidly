using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public byte GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; } = new DateTime(1900, 1, 1);

        public DateTime DatedAdded { get; set; } = new DateTime(1900, 1, 1);

        public byte NumberInStock { get; set; }
    }
}