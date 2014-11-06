using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Controllers
{

    [Authorize(Roles="admin")]
    public class AdminController : BaseController
    {
        public AdminController(IWeekendsData data)
            : base(data)
        {

        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}