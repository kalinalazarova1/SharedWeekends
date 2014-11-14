namespace SharedWeekends.MVC.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;
    
    public class WeekendViewModel : IMapFrom<Weekend>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("Picture")]
        public string PictureUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [UIHint("Content")]
        [Required]
        [StringLength(2000, MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string Author { get; set; }

        [UIHint("Stars")]
        public int Rating { get; set; }

        [UIHint("Reviews")]
        public int LikesCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime? CreationDate { get; set; }

        public int PeopleCount { get; set; }

        [UIHint("Currency")]
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
}