using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    public class UserViewModel : AdministrationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Avatar URL")]
        public string Avatar { get; set; }

    }
}