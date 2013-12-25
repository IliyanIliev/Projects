using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LaptopSystem.Web.Controllers;
using MovieSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public const int PageSize = 3;

        private IQueryable<MovieViewModel> GetAllMovies()
        {
            var allMovies = Data.Movies.All()
                .OrderBy(m => m.Id)
                .Select(m => new MovieViewModel
                {
                    Category = m.Category.Name,
                    Director = m.Director,
                    Id = m.Id,
                    PosterUrl = m.PosterUrl,
                    Title = m.Title,
                    Year = m.Year
                });
            return allMovies;
        }
        /*
        public JsonResult GetSearchMovies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllMovies().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        */
        public JsonResult GetMovieModelData(string text)
        {
            var result = this.Data.Movies.All()
                .Where(m=>m.Title.ToLower().Contains(text.ToLower()))
                .Select(m => new {
                    Title = m.Title,
                    PosterUrl = m.PosterUrl,
                    Year = m.Year
                });

            return Json(result, JsonRequestBehavior.AllowGet);
                
        }

        public ActionResult Index(int? Id)
        {
            int pageNumber = Id.GetValueOrDefault(1);
            var listOfMovies =GetAllMovies().Skip((pageNumber-1)*PageSize).Take(PageSize).ToList();

            ViewBag.Pages = Math.Ceiling((double)Data.Movies.All().Count() / PageSize);

            return View(listOfMovies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}