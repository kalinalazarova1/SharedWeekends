namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class MessageViewModel : AdministrationViewModel, IMapFrom<Message>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public Guid? Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public string Sender { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public string Receiver { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ForMember(m => m.Receiver, opt => opt.MapFrom(m => m.Receiver.UserName));
        }
    }
}