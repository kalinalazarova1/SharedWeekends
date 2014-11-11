using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    public class HomeController : AdminController
    {
        public HomeController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            var data = new WeekendsData();
            ViewBag.Users = data.Users.All().Project().To<UserViewModel>().ToList();
            return View();
        }
    }
}