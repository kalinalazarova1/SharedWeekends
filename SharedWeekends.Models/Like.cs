namespace SharedWeekends.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SharedWeekends.Data.Common.Models;
    
    public class Like : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public int Stars { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Weekend Weekend { get; set; }

        public int WeekendId { get; set; }

        public virtual User Voter { get; set; }

        public string VoterId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
