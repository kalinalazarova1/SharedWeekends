using AutoMapper;
using AutoMapper.QueryableExtensions;
using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharedWeekends.MVC.ViewModels
{
    public class LikeViewModel: IMapFrom<Like>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public int Stars { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public int WeekendId { get; set; }

        public string WeekendTitle { get; set; }

        public string Voter { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.WeekendTitle, opt => opt.MapFrom(l => l.Weekend.Title));
        }
    }
}