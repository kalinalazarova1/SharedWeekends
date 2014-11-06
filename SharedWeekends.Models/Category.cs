namespace SharedWeekends.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Weekend> weekends;

        public Category()
        {
            this.weekends = new HashSet<Weekend>();    
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Weekend> Weekends 
        {
            get
            {
                return this.weekends;
            }
            set
            {
                this.weekends = value;
            }
        }
    }
}
