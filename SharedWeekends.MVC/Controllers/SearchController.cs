using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class SearchController : BaseController
    {
        public SearchController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Search
        public ActionResult Index()
        {
            var all = Data
                .Weekends
                .All()
                .OrderByDescending(w => w.CreationDate)
                .Project()
                .To<WeekendViewModel>()
                .ToList();

            return View();
        }

        public ActionResult FilterByCategory(int id)
        {
            IEnumerable<WeekendViewModel> all;
            if (id == 0)
            {
                all = Data
                    .Weekends
                    .All()
                    .OrderByDescending(w => w.CreationDate)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();
            }
            else
            {
                all = Data
                    .Weekends
                    .All()
                    .Where(w => w.CategoryId == id)
                    .OrderByDescending(w => w.CreationDate)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();
            }

            return PartialView("_Weekends", all);
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var categories = Data.Categories.All().Project().To<CategoryViewModel>();
            return PartialView("_CategoriesList", categories);
        }
    }
}