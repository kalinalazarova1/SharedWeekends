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
        private static readonly int PageSize = 3;

        public SearchController(IWeekendsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.TempData["CategoryId"] = 0;
            this.TempData["Page"] = 0;
            
            return this.View();
        }

        public ActionResult FilterByCategory(int? id, int page)
        {
            var currentPage = (int)TempData["Page"] + page < 0 ? 0 : (int)TempData["Page"] + page;
            if (page == 0)
            {
                currentPage = 0;
            }

            IEnumerable<WeekendViewModel> all;
            if (id == 0)
            {
                all = this.Data
                    .Weekends
                    .All()
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(SearchController.PageSize * currentPage)
                    .Take(SearchController.PageSize)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();

                this.TempData["CategoryId"] = id;
            }
            else if (id == null && (int)this.TempData["CategoryId"] != 0)
            {
                var categoryId = (int)this.TempData["CategoryId"];
                all = this.Data
                    .Weekends
                    .All()
                    .Where(w => w.CategoryId == categoryId)
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(SearchController.PageSize * currentPage)
                    .Take(SearchController.PageSize)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();

                this.TempData["CategoryId"] = categoryId;
            }
            else if (id == null && (int)this.TempData["CategoryId"] == 0)
            {
                var categoryId = (int)this.TempData["CategoryId"];
                all = this.Data
                    .Weekends
                    .All()
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(SearchController.PageSize * currentPage)
                    .Take(SearchController.PageSize)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();

                this.TempData["CategoryId"] = categoryId;
            }
            else
            {
                all = this.Data
                    .Weekends
                    .All()
                    .Where(w => w.CategoryId == id)
                    .OrderByDescending(w => w.CreationDate)
                    .Take(SearchController.PageSize)
                    .Project()
                    .To<WeekendViewModel>()
                    .ToList();

                this.TempData["CategoryId"] = id;
            }

            this.TempData["Page"] = currentPage;
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