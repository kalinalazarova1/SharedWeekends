using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Administration/Messages
        public ActionResult Index()
        {
            return View();
        }
    }
}