using AutoMapper.QueryableExtensions;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharedWeekends.Models;
using SharedWeekends.MVC.Areas.Administration.ViewModels;
using SharedWeekends.Data;

namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    public class CategoriesController : AdminController
    {
        public CategoriesController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Categories
        public ActionResult Index()
        {
            return View();
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

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
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

            return Json(result);
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

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);

            this.Data.Categories.Delete(existingCategory);
            this.Data.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
    }
}