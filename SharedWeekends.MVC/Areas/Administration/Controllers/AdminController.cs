using SharedWeekends.Data;
using SharedWeekends.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.Controllers
{
    [Authorize(Roles = "admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IWeekendsData data)
            : base(data)
        {
        }
    }
}