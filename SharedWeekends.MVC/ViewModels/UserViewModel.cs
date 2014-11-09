using AutoMapper;
using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedWeekends.MVC.ViewModels
{
    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int Rating { get; set; }

        public string Avatar { get; set; }

        public int UnreadMessages { get; set; }

        public int ReadMessages { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(m => m.UnreadMessages, opt => opt.MapFrom(u => u.Messages.Count(m => !m.IsRead)))
                .ForMember(m => m.ReadMessages, opt => opt.MapFrom(u => u.Messages.Count(m => m.IsRead)));
        }
    }
}