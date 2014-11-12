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
    public class LikeViewModel : AdministrationViewModel, IMapFrom<Like>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Stars { get; set; }

        [Required]
        public string Comment { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Weekend { get; set; }

        [Required]
        public string Voter { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.Weekend, opt => opt.MapFrom(l => l.Weekend.Title));
        }
    }
}