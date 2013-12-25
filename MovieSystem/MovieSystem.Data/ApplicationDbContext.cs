using Microsoft.AspNet.Identity.EntityFramework;
using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieSystem.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Movie> Movies { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Rating> Ratings { get; set; }
    }
}
