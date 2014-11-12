using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    public class CategoryViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}