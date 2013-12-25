using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Web.Controllers;
using MovieSystem.Web.Models;
using LaptopSystem.Web.Models;
using MovieSystem.Models;
using Microsoft.AspNet.Identity;

namespace MovieSystem.Web.Controllers
{
    public class MovieController : BaseController
    {
        //
        // GET: /Movie/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = Data.Movies.All().Where(m => m.Id == id).Select(m => new MovieDetailsViewModel
            {
                Category = m.Category.Name,
                Comments = m.Comments.Select(c => new CommentViewModel
                {
                    AuthorUsername = c.Author.UserName,
                    Content = c.Content,
                    Id = c.Id
                }).OrderByDescending(c=>c.Id),
                Description = m.Description,
                Director = m.Director,
                Id = m.Id,
                PosterUrl = m.PosterUrl,
                Title = m.Title,
                Year = m.Year

            }).FirstOrDefault();
            return View(movie);
        }

        public ActionResult ByGenre(string name)
        {
            var listOfMovies = Data.Movies.All()
                .Where(m => m.Category.Name.ToLower() == name.ToLower())
                .Select(m => new MovieViewModel
            {
                Category = m.Category.Name,
                Director = m.Director,
                Id = m.Id,
                PosterUrl = m.PosterUrl,
                Title = m.Title,
                Year = m.Year
            }).ToList();
            return View(listOfMovies);
        }

        public ActionResult ByTitle(string movieSearch)
        {
            var listOfMovies = Data.Movies.All()
                .Where(m => m.Title.ToLower().Contains(movieSearch.ToLower()))
                .Select(m => new MovieViewModel
                {
                    Category = m.Category.Name,
                    Director = m.Director,
                    Id = m.Id,
                    PosterUrl = m.PosterUrl,
                    Title = m.Title,
                    Year = m.Year
                }).ToList();
            return View(listOfMovies);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                this.Data.Comments.Add(new Comment
                {
                    AuthorId = User.Identity.GetUserId(),
                    Content = commentModel.Comment,
                    MovieId = commentModel.MovieId
                });
                this.Data.SaveChanges();
                var viewModel = new CommentViewModel {AuthorUsername = User.Identity.GetUserName(), Content = commentModel.Comment};
                return PartialView("_CommentPartial", viewModel);
            }
            else
	        {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
	        }

        }
    }
}