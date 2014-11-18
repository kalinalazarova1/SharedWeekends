namespace SharedWeekends.MVC.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;
    
    using SharedWeekends.Data;
    using SharedWeekends.Models;
    using SharedWeekends.MVC.ViewModels;
    
    public class ProfileController : BaseController
    {
        public ProfileController(IWeekendsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = this.Data.Users.All()
                .Project()
                .To<UserViewModel>()
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            return this.View(user);
        }

        [ChildActionOnly]
        public ActionResult GetMyWeekends()
        {
            var userId = this.User.Identity.GetUserId();
            var my = this.Data.Weekends.All()
                .Where(w => w.AuthorId == userId)
                .OrderByDescending(w => w.CreationDate)
                .Project()
                .To<WeekendViewModel>();

            return this.PartialView("_MyWeekendsList", my);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var weekend = this.Data.Weekends.All().Project().To<WeekendViewModel>().FirstOrDefault(w => w.Id == id);
            return this.View("MyWeekendEdit", weekend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WeekendViewModel weekend)
        {
            if (this.ModelState.IsValid)
            {
                var editedWeekend = this.Data.Weekends
                    .All()
                    .FirstOrDefault(w => w.Id == weekend.Id);

                editedWeekend.Title = weekend.Title;
                editedWeekend.Content = weekend.Content;
                editedWeekend.CategoryId = int.Parse(weekend.Category);
                editedWeekend.PictureUrl = weekend.PictureUrl;
                editedWeekend.PeopleCount = weekend.PeopleCount;
                editedWeekend.PricePerPerson = weekend.PricePerPerson;
                editedWeekend.Lattitude = weekend.Lattitude;
                editedWeekend.Longitude = weekend.Longitude;

                this.Data.SaveChanges();
                this.TempData["Message"] = "Weekend successfully edited!";
                return this.RedirectToAction("Index");
            }

            this.TempData["Message"] = "Unable to edit weekend!";
            return this.View(weekend);
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetCategories(string category)
        {
            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();
            this.ViewBag.Selected = category;
            return this.PartialView("_Categories", categories);
        }

        [ChildActionOnly]
        public ActionResult GetMyReviews()
        {
            var userId = this.User.Identity.GetUserId();
            var my = this.Data.Likes.All()
                .Where(l => l.VoterId == userId)
                .OrderByDescending(l => l.CreationDate)
                .Project()
                .To<LikeViewModel>();

            return this.PartialView("_MyReviews", my);
        }

        [HttpGet]
        public ActionResult EditReview(int id)
        {
            var review = this.Data.Likes.All().Project().To<LikeViewModel>().FirstOrDefault(l => l.Id == id);
            return this.View("MyReviewEdit", review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview(LikeViewModel like)
        {
            if (this.ModelState.IsValid)
            {
                var editedLike = this.Data.Likes
                    .All()
                    .FirstOrDefault(l => l.Id == like.Id);

                editedLike.Stars = like.Stars;
                editedLike.Comment = like.Comment;
                
                this.Data.SaveChanges();
                this.TempData["Message"] = "Review successfully edited!";
                return this.RedirectToAction("Index");
            }

            this.TempData["Message"] = "Unable to edit review!";
            return this.View(like);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAvatar(AvatarViewModel model)
        {
            if (model.AvatarFile != null)
            {
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
                user.AvatarPhoto = this.GetImage(model.AvatarFile);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        private byte[] GetImage(HttpPostedFileBase uploadedImage)
        {
            if (uploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    uploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    if (uploadedImage.FileName.Split(new[] { '.' }).Last() == "jpg" || uploadedImage.FileName.Split(new[] { '.' }).Last() == "jpeg")
                    {
                        return content;
                    }
                    else
                    {
                        throw new HttpException(400, "Invalid file format");
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}