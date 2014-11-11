using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SharedWeekends.MVC.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Category")]
        [Required]
        public string Name { get; set; }
    }
}