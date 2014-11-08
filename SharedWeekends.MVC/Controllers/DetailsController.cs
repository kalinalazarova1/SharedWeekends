using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SharedWeekends.MVC.ViewModels;
using SharedWeekends.Models;
using Microsoft.AspNet.Identity;

namespace SharedWeekends.MVC.Controllers
{
    public class DetailsController : BaseController
    {
        public DetailsController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Details
        public ActionResult Index(int? id)
        {
            var selected = Data.Weekends.All().Where(w => w.Id == id).Project().To<WeekendViewModel>().First();
            return View(selected);
        }

        [ChildActionOnly]
        public ActionResult GetWeekendLikes(int? id)
        {
            var likes = Data.Likes.All().Where(l => l.WeekendId == id).Project().To<LikeViewModel>();
            return PartialView("_Likes", likes);
        }


        [ChildActionOnly]
        public ActionResult CreateLikeForm(int? id)
        {
            TempData["Id"] = id;
            return PartialView("_CreateLike");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLike(LikeViewModel like)
        {
            if (ModelState.IsValid)
            {
                var newLike = new Like()
                {
                    Comment = like.Comment,
                    CreationDate = DateTime.Now,
                    VoterId = User.Identity.GetUserId(),
                    Stars = like.Stars,
                    WeekendId = like.WeekendId
                };

                Data.Likes.Add(newLike);
                Data.SaveChanges();
            }

            return Redirect("~/Details/Index/" + like.WeekendId);
        }
    }
}