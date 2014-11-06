using AutoMapper;
using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SharedWeekends.MVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<WeekendViewModel> TopWeekends { get; set; }

        public IEnumerable<TopUserViewModel> TopUsers { get; set; }

        public IEnumerable<WeekendViewModel> LatestWeekends { get; set; }
    }

    public class WeekendViewModel : IMapFrom<Weekend>, IHaveCustomMappings
    {
        public byte[] Picture { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int Likes { get; set; }

        public DateTime CreationDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Weekend, WeekendViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(w => w.Author.UserName))
                .ForMember(m => m.Likes, opt => opt.MapFrom(w => w.Likes.Count(l => l.IsLiked) - w.Likes.Count(l => !l.IsLiked)));
        }
    }

    public class TopUserViewModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public int Rating { get; set; }

        public string AvatarUrl { get; set; }
    }
}