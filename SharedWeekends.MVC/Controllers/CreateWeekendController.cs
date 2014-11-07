using SharedWeekends.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Controllers
{
    public class CreateWeekendController : BaseController
    {
        public CreateWeekendController(IWeekendsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }
    }
}