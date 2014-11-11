using AutoMapper;
using AutoMapper.QueryableExtensions;
using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedWeekends.MVC.ViewModels
{
    public class LikeViewModel: IMapFrom<Like>, IHaveCustomMappings
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Stars { get; set; }

        [Required]
        public string Comment { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public int WeekendId { get; set; }

        [Display(Name = "Weekend Title")]
        public string WeekendTitle { get; set; }

        [Required]
        public string Voter { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.WeekendTitle, opt => opt.MapFrom(l => l.Weekend.Title));
        }
    }
}