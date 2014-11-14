namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using SharedWeekends.Data;
    using SharedWeekends.MVC.Controllers;

    [Authorize(Roles = "admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IWeekendsData data)
            : base(data)
        {
        }
    }
}