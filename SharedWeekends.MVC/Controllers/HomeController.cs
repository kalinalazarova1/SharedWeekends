namespace SharedWeekends.MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SharedWeekends.Data;
    using SharedWeekends.MVC.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IWeekendsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetTopUsers()
        {
            var users = this.Data.Users
                .All()
                .Project()
                .To<TopUserViewModel>()
                .OrderByDescending(u => u.Rating)
                .Take(3)
                .ToList();

            return this.PartialView("_TopUsers", users);
        }

        public ActionResult About()
        {
            return this.View();
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetLatestWeekends()
        {
            var latest = this.Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.CreationDate)
                .Take(4)
                .ToList();
            return this.PartialView("_Weekends", latest);
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult GetTopWeekends()
        {
            var top = this.Data.Weekends
                .All()
                .Project()
                .To<WeekendViewModel>()
                .OrderByDescending(w => w.Rating)
                .Take(4)
                .ToList();
            return this.PartialView("_Weekends", top);
        }
    }
}