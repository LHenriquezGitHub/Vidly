﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [MinMaxReleaseDate]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

       
        [Display(Name = "Dated Added")]
        public DateTime DatedAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}