namespace SharedWeekends.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
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
        public string Content { get; set; }

        [Required]
        public bool IsRead { get; set; }
    }
}
