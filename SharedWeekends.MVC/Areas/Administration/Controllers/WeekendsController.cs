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
    
    public class WeekendsController : AdminController
    {
        public WeekendsController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Weekends
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult CreateWeekend([DataSourceRequest] DataSourceRequest request, WeekendViewModel weekend)
        {
            if (weekend != null && ModelState.IsValid)
            {
                var newWeekend = new Weekend
                {
                    Content = weekend.Content,
                    Author = this.Data.Users.All().FirstOrDefault(u => u.UserName == weekend.Author),
                    Category = this.Data.Categories.All().FirstOrDefault(w => w.Name == weekend.Category),
                    CreationDate = DateTime.Now,
                    Title = weekend.Title,
                    Lattitude = weekend.Lattitude,
                    Longitude = weekend.Longitude,
                    PeopleCount = weekend.PeopleCount,
                    PricePerPerson = weekend.PricePerPerson,
                    PictureUrl = weekend.PictureUrl
                };

                this.Data.Weekends.Add(newWeekend);
                this.Data.SaveChanges();

                weekend.Id = newWeekend.Id;
            }

            return this.Json(new[] { weekend }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReadWeekends([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public JsonResult UpdateWeekend([DataSourceRequest] DataSourceRequest request, WeekendViewModel weekend)
        {
            var existingWeekend = this.Data.Weekends.All().FirstOrDefault(x => x.Id == weekend.Id);

            if (weekend != null && ModelState.IsValid)
            {
                existingWeekend.Content = weekend.Content;
                existingWeekend.Author = this.Data.Users.All().FirstOrDefault(u => u.UserName == weekend.Author);
                existingWeekend.Category = this.Data.Categories.All().FirstOrDefault(w => w.Name == weekend.Category);
                existingWeekend.Title = weekend.Title;
                existingWeekend.Lattitude = weekend.Lattitude;
                existingWeekend.Longitude = weekend.Longitude;
                existingWeekend.PeopleCount = weekend.PeopleCount;
                existingWeekend.PricePerPerson = weekend.PricePerPerson;
                existingWeekend.PictureUrl = weekend.PictureUrl;

                this.Data.SaveChanges();
            }

            return this.Json(new[] { weekend }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteWeekend([DataSourceRequest] DataSourceRequest request, WeekendViewModel weekend)
        {
            var existingWeekend = this.Data.Weekends.All().FirstOrDefault(x => x.Id == weekend.Id);

            this.Data.Weekends.Delete(existingWeekend);
            this.Data.SaveChanges();

            return this.Json(new[] { weekend }, JsonRequestBehavior.AllowGet);
        }
    }
}