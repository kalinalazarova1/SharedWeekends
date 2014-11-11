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
    public class MessageViewModel: IMapFrom<Message>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Receiver { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
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