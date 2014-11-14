namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class UserViewModel : AdministrationViewModel, IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required]
        public string UserName { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Avatar URL")]
        public string Avatar { get; set; }
    }
}