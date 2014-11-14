namespace SharedWeekends.MVC.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class TopUserViewModel : IMapFrom<User>
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        public int Rating { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string AvatarUrl { get; set; }
    }
}