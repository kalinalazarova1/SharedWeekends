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
    public class MessageViewModel: IMapFrom<Message>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public DateTime CreationDate { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(msg => msg.Id.ToString()))
                .ForMember(m => m.Receiver, opt => opt.MapFrom(m => m.Receiver.UserName));
        }
    }
}