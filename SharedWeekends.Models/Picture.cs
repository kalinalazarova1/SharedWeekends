using System.ComponentModel.DataAnnotations;
namespace SharedWeekends.Models
{
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public virtual Weekend Weekend { get; set; }

        public int WeekendId { get; set; }
    }
}
