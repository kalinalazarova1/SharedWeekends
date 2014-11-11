using SharedWeekends.Data;
using SharedWeekends.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace SharedWeekends.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWeekendsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var users = Data.Users
                .All()
                .Project()
                .To<TopUserViewModel>()
                .OrderByDescending(u => u.Rating)
                .Take(3)
                .ToList();

            return View(users);
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetLatestWeekends()
        {
            var latest = Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.CreationDate)
                .Take(4)
                .ToList();
            return PartialView("_Weekends", latest);
        }

        [ChildActionOnly]
        public ActionResult GetTopWeekends()
        {
            var top = Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.Rating)
                .Take(4)
                .ToList();
            return PartialView("_Weekends", top);
        }
    }
}