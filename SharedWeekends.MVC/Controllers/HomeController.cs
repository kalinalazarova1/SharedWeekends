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
                .Take(5)
                .ToList();

            var top = Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.Rating)
                .Take(5)
                .ToList();

            var latest = Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.CreationDate)
                .Take(5)
                .ToList();

            var model = new HomeViewModel()
            {
                LatestWeekends = latest,
                TopUsers = users,
                TopWeekends = top
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}