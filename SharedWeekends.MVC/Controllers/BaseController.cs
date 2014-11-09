using SharedWeekends.Data;
using SharedWeekends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(IWeekendsData data)
        {
            this.Data = data;
        }

        protected IWeekendsData Data { get; set; }
    }
}