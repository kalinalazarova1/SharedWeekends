using SharedWeekends.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var users = db.Users
                .OrderByDescending(u => u.Rating)
                .Take(5)
                .Select(TopUserViewModel.FromUser)
                .ToList();

            var top = db.Weekends
                .Select(WeekendViewModel.FromWeekend)
                .OrderByDescending(w => w.Likes)
                .Take(5)
                .ToList();

            var latest = db.Weekends
                .Select(WeekendViewModel.FromWeekend)
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