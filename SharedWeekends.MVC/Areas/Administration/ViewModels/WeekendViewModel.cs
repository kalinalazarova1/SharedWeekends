using AutoMapper;
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
    public class WeekendViewModel : AdministrationViewModel, IMapFrom<WeekendViewModel>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Creation Date")]
        [HiddenInput(DisplayValue = false)]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Category { get; set; }

        public decimal PricePerPerson { get; set; }

        public int PeopleCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        [Display(Name = "Picture URL")]
        public string PictureUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Weekend, WeekendViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(w => w.Author.UserName))
                .ForMember(m => m.Category, opt => opt.MapFrom(w => w.Category.Name));
        }
    }
}