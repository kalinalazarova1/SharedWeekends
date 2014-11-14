namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class LikeViewModel : AdministrationViewModel, IMapFrom<Like>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Stars { get; set; }

        [Required]
        public string Comment { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string Weekend { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string Voter { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.Weekend, opt => opt.MapFrom(l => l.Weekend.Title));
        }
    }
}