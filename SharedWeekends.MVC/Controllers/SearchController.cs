namespace SharedWeekends.MVC.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SharedWeekends.Data;
    using SharedWeekends.MVC.ViewModels;

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

            return this.View();
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
                all = this.Data
                    .Weekends
                    .All()
                    .Where(w => w.CategoryId == id)
                    .OrderByDescending(w => w.CreationDate)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();
            }

            return this.PartialView("_Weekends", all);
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();
            return this.PartialView("_CategoriesList", categories);
        }
    }
}