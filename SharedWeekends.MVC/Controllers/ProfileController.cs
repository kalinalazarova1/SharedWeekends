using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using SharedWeekends.MVC.ViewModels;
using SharedWeekends.Models;

namespace SharedWeekends.MVC.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Profile
        public ActionResult Index()
        {
            var user = Data.Users.All()
                .Project()
                .To<UserViewModel>()
                .FirstOrDefault(u => u.Username == User.Identity.Name);

            return View(user);
        }

        [ChildActionOnly]
        public ActionResult GetMyWeekends()
        {
            var userId = User.Identity.GetUserId();
            var my = Data.Weekends.All()
                .Where(w => w.AuthorId == userId)
                .OrderByDescending(w => w.CreationDate)
                .Project()
                .To<WeekendViewModel>();

            return PartialView("_MyWeekendsList", my);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var weekend = Data.Weekends.All().Project().To<WeekendViewModel>().FirstOrDefault(w => w.Id == id);
            return View("MyWeekendEdit", weekend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WeekendViewModel weekend)
        {
            if (ModelState.IsValid)
            {
                var editedWeekend = Data.Weekends
                    .All()
                    .FirstOrDefault(w => w.Id == weekend.Id);

                editedWeekend.Title = weekend.Title;
                editedWeekend.Content = weekend.Content;
                editedWeekend.CategoryId = int.Parse(weekend.Category);
                editedWeekend.PictureUrl = weekend.PictureUrl;
                editedWeekend.PeopleCount = weekend.PeopleCount;
                editedWeekend.PricePerPerson = weekend.PricePerPerson;
                editedWeekend.Lattitude = weekend.Lattitude;
                editedWeekend.Longitude = weekend.Longitude;

                Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetCategories(string category)
        {
            var categories = Data.Categories.All().Project().To<CategoryViewModel>();
            @ViewBag.Selected = category;
            return PartialView("_Categories", categories);
        }
    }
}