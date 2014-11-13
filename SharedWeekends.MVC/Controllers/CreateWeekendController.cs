﻿using SharedWeekends.Data;
using SharedWeekends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class CreateWeekendController : BaseController
    {
        public CreateWeekendController(IWeekendsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeekendViewModel weekend)
        {
            if(ModelState.IsValid)
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

                Data.Weekends.Add(newWeekend);
                Data.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var categories = Data.Categories.All().Project().To<CategoryViewModel>();
            return PartialView("_Categories", categories);
        }
    }
}