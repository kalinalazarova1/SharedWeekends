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

    public class UsersController : AdminController
    {
        public UsersController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult CreateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && this.ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = user.UserName,
                    CreatedOn = DateTime.Now,
                    Rating = 0
                };

                this.Data.Users.Add(newUser);
                this.Data.SaveChanges();

                user.Id = newUser.Id;
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Users
                .All()
                .Project()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public JsonResult UpdateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            if (user != null && ModelState.IsValid)
            {
                existingUser.UserName = user.UserName;
                existingUser.ModifiedOn = DateTime.Now;
                existingUser.Rating = user.Rating;

                this.Data.SaveChanges();
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            this.Data.Users.Delete(existingUser);
            this.Data.SaveChanges();

            return this.Json(new[] { user }, JsonRequestBehavior.AllowGet);
        }
    }
}