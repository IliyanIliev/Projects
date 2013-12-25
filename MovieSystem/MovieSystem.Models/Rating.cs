using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; }

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
