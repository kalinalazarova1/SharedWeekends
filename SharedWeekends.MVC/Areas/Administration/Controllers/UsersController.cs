using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SharedWeekends.MVC.Areas.Administration.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using SharedWeekends.Models;

namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    public class UsersController : AdminController
    {
        public UsersController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = user.UserName,
                    CreatedOn = DateTime.Now,
                    Avatar = user.Avatar,
                    Rating = 0
                };

                this.Data.Users.Add(newUser);
                this.Data.SaveChanges();

                user.Id = newUser.Id;
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Users.All().Project().To<UserViewModel>();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            if (user != null && ModelState.IsValid)
            {
                existingUser.UserName = user.UserName;
                existingUser.Avatar = user.Avatar;
                existingUser.ModifiedOn = DateTime.Now;
                existingUser.Rating = user.Rating;

                this.Data.SaveChanges();
            }

            return Json((new[] { user }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            this.Data.Users.Delete(existingUser);
            this.Data.SaveChanges();

            return Json(new[] { user }, JsonRequestBehavior.AllowGet);
        }
    }
}