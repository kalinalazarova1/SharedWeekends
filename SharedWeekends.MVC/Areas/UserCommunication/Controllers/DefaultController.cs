using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.UserCommunication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: UserCommunication/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}