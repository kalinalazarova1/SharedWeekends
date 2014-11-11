using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    public class WeekendViewModel : AdministrationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public int CategoryId { get; set; }

        public decimal PricePerPerson { get; set; }

        public int PeopleCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        [Display(Name = "Picture URL")]
        public string PictureUrl { get; set; }

    }
}