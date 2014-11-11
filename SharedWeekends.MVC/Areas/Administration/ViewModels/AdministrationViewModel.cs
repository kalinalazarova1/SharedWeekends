using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    public abstract class AdministrationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}