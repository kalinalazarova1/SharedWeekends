namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    
    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.Areas.Administration.ViewModels;

    public class CategoriesController : AdminController
    {
        public CategoriesController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Categories
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Name = category.Name,
                    CreatedOn = DateTime.Now
                };

                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();

                category.Id = newCategory.Id;
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Categories
                .All()
                .Project()
                .To<CategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.ModifiedOn = DateTime.Now;
                
                this.Data.SaveChanges();
            }

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);

            this.Data.Categories.Delete(existingCategory);
            this.Data.SaveChanges();

            return this.Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
    }
}