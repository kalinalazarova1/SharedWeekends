namespace SharedWeekends.MVC.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [UIHint("Username")]
        public string UserName { get; set; }

        [UIHint("Points")]
        public int Rating { get; set; }

        [UIHint("Avatar")]
        public byte[] Avatar { get; set; }

        public int UnreadMessages { get; set; }

        public int ReadMessages { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(m => m.UnreadMessages, opt => opt.MapFrom(u => u.Messages.Count(m => !m.IsRead && !m.IsDeleted)))
                .ForMember(m => m.ReadMessages, opt => opt.MapFrom(u => u.Messages.Count(m => m.IsRead && !m.IsDeleted)))
                .ForMember(m => m.Avatar, opt => opt.MapFrom(u => u.AvatarPhoto));
        }
    }
}