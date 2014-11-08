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
        public int Id { get; set; }
        public byte[] Picture { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int Rating { get; set; }

        public int LikesCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime CreationDate { get; set; }

        public int PeopleCount { get; set; }

        public decimal PricePerPerson { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Weekend, WeekendViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(w => w.Author.UserName))
                .ForMember(m => m.Rating, opt => opt.MapFrom(w => w.Likes.Count() > 0 ? w.Likes.Sum(l => l.Stars) / w.Likes.Count() : 0))
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(w => w.Likes.Count()))
                .ForMember(m => m.Category, opt => opt.MapFrom(w => w.Category.Name));
        }
    }

    public class TopUserViewModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public int Rating { get; set; }

        public string AvatarUrl { get; set; }
    }
}