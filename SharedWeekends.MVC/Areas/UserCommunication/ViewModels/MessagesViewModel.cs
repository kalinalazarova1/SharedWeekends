namespace SharedWeekends.MVC.Areas.UserCommunication.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Sender { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Receiver { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Subject { get; set; }

        [StringLength(300, MinimumLength = 3)]
        [Required]
        [UIHint("Content")]
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