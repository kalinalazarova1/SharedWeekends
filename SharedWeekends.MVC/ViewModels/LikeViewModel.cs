namespace SharedWeekends.MVC.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class LikeViewModel : IMapFrom<Like>, IHaveCustomMappings
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("Stars")]
        public int Stars { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Comment { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public int WeekendId { get; set; }

        [Display(Name = "Weekend Title")]
        [StringLength(50, MinimumLength = 3)]
        public string WeekendTitle { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string Voter { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.WeekendTitle, opt => opt.MapFrom(l => l.Weekend.Title));
        }
    }
}