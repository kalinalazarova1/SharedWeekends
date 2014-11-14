namespace SharedWeekends.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SharedWeekends.Data.Common.Models;

    public class Message : AuditInfo, IDeletableEntity
    {
        public Message()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
