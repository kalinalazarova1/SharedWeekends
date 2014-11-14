namespace SharedWeekends.MVC.Controllers
{
    using System;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    
    using Microsoft.AspNet.Identity;
    
    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.ViewModels;

    public class CreateWeekendController : BaseController
    {
        public CreateWeekendController(IWeekendsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(WeekendViewModel weekend)
        {
            if (this.ModelState.IsValid)
            {
                var newWeekend = new Weekend()
                {
                    AuthorId = User.Identity.GetUserId(),
                    CreationDate = DateTime.Now,
                    Title = weekend.Title,
                    Content = weekend.Content,
                    CategoryId = int.Parse(weekend.Category),
                    PictureUrl = weekend.PictureUrl,
                    PeopleCount = weekend.PeopleCount,
                    PricePerPerson = weekend.PricePerPerson,
                    Lattitude = weekend.Lattitude,
                    Longitude = weekend.Longitude
                };

                this.Data.Weekends.Add(newWeekend);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();
            return this.PartialView("_Categories", categories);
        }
    }
}