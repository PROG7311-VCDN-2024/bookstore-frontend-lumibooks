﻿using System.ComponentModel.DataAnnotations;

namespace Sprint1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}