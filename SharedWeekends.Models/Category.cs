namespace SharedWeekends.Models
{
    using SharedWeekends.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category: AuditInfo, IDeletableEntity
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

        public bool IsDeleted { get; set; }
      
        public DateTime? DeletedOn { get; set; }
    }
}
