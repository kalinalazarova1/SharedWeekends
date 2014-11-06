namespace SharedWeekends.Models
{
    using System;
    using System.Collections.Generic;

    public class Weekend
    {
        private IList<Picture> pictures;

        private ICollection<Like> likes;

        public Weekend()
        {
            this.pictures = new List<Picture>();
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        public decimal PricePerPerson { get; set; }

        public int PersonCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public int LocationId { get; set; }

        public int DefaultPictureIndex { get; set; }

        public virtual IList<Picture> Pictures 
        {
            get
            {
                return this.pictures;
            }
            set
            {
                this.pictures = value;
            }
        }

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
