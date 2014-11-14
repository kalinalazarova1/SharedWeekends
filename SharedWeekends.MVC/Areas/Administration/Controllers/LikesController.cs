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

    public class LikesController : AdminController
    {
        public LikesController(IWeekendsData data)
            : base(data)
        {
        }

        // GET: Administration/Likes
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult CreateLike([DataSourceRequest] DataSourceRequest request, LikeViewModel like)
        {
            if (like != null && ModelState.IsValid)
            {
                var newLike = new Like
                {
                    Comment = like.Comment,
                    Stars = like.Stars,
                    Voter = this.Data.Users.All().FirstOrDefault(u => u.UserName == like.Voter),
                    Weekend = this.Data.Weekends.All().FirstOrDefault(w => w.Title == like.Weekend),
                    CreationDate = DateTime.Now,
                    CreatedOn = DateTime.Now
                };

                this.Data.Likes.Add(newLike);
                this.Data.SaveChanges();

                like.Id = newLike.Id;
            }

            return this.Json(new[] { like }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReadLikes([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Likes
                .All()
                .Project()
                .To<LikeViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [HttpPost]
        public JsonResult UpdateLike([DataSourceRequest] DataSourceRequest request, LikeViewModel like)
        {
            var existingLike = this.Data.Likes.All().FirstOrDefault(x => x.Id == like.Id);

            if (like != null && ModelState.IsValid)
            {
                existingLike.Comment = like.Comment;
                existingLike.CreationDate = like.CreationDate;
                existingLike.Stars = like.Stars;
                existingLike.Voter = this.Data.Users.All().FirstOrDefault(u => u.UserName == like.Voter);
                existingLike.ModifiedOn = DateTime.Now;
                existingLike.Weekend = this.Data.Weekends.All().FirstOrDefault(w => w.Title == like.Weekend);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { like }.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteLike([DataSourceRequest] DataSourceRequest request, LikeViewModel like)
        {
            var existingLike = this.Data.Likes.All().FirstOrDefault(x => x.Id == like.Id);

            this.Data.Likes.Delete(existingLike);
            this.Data.SaveChanges();

            return this.Json(new[] { like }, JsonRequestBehavior.AllowGet);
        }
    }
}