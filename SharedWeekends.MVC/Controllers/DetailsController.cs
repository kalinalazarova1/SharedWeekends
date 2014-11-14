namespace SharedWeekends.MVC.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;
    
    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.ViewModels;
    
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
            var userId = this.User.Identity.GetUserId();
            if (this.Data.Likes.All().Any(l => (l.WeekendId == id && l.VoterId == userId) || (selected.Author == this.User.Identity.Name)))
            {
                this.ViewBag.HasLikedThis = true;
            }
            else
            {
                this.ViewBag.HasLikedThis = false;
            }
           
            return this.View(selected);
        }

        [ChildActionOnly]
        public ActionResult GetWeekendLikes(int? id)
        {
            var likes = this.Data.Likes.All().Where(l => l.WeekendId == id).Project().To<LikeViewModel>().ToList();
            return this.PartialView("_Likes", likes);
        }

        [ChildActionOnly]
        public ActionResult CreateLikeForm(int? id)
        {
            this.TempData["Id"] = id;
            return this.PartialView("_CreateLike");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLike(LikeViewModel like)
        {
            if (this.ModelState.IsValid)
            {
                like.Voter = User.Identity.Name;
                like.CreationDate = DateTime.Now;
                var newLike = new Like()
                {
                    Comment = like.Comment,
                    CreationDate = like.CreationDate,
                    VoterId = User.Identity.GetUserId(),
                    Stars = like.Stars,
                    WeekendId = like.WeekendId
                };

                this.Data.Likes.Add(newLike);
                this.Data.SaveChanges();
                this.Data.Weekends.All().FirstOrDefault(w => w.Id == newLike.WeekendId).Author.Rating += newLike.Stars;
                this.Data.SaveChanges();
            }

            return this.PartialView("_SingleLike", like);
        }
    }
}