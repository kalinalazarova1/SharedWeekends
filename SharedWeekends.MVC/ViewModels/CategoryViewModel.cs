using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
namespace SharedWeekends.MVC.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}