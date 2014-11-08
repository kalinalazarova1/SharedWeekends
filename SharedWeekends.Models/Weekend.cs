namespace SharedWeekends.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Weekend
    {
        private ICollection<Like> likes;

        public Weekend()
        {
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        public decimal PricePerPerson { get; set; }

        public int PeopleCount { get; set; }
        
        public decimal Lattitude { get; set; }
        
        public decimal Longitude { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            }
        }
    }
}
