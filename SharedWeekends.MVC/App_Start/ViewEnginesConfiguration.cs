using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SharedWeekends.MVC
{
    public static class ViewEnginesConfiguration
    {
        public static void RegisterViewEngine(ViewEngineCollection engines){
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}
