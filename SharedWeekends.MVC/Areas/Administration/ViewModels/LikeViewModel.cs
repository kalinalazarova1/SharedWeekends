using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    public class LikeViewModel : AdministrationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

        public int WeekendId { get; set; }

        public string VoterId { get; set; }
    }
}