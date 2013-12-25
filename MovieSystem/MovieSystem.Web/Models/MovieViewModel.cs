using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSystem.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string PosterUrl { get; set; }
        public string Category { get; set; }
    }
}