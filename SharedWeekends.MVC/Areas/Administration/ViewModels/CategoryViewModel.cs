namespace SharedWeekends.MVC.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class CategoryViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}