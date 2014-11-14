namespace SharedWeekends.MVC.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SharedWeekends.Models;
    using SharedWeekends.MVC.Infrastructure.Mapping;
    
    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Category")]
        [Required]
        public string Name { get; set; }
    }
}