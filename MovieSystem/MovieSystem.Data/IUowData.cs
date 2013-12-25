using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Data
{
    public interface IUowData
    {
        IRepository<Movie> Movies { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Rating> Ratings { get; }

        // IRepository<Appli> Votes { get; }

        int SaveChanges();
    }
}
