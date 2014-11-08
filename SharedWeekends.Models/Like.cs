﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedWeekends.Models
{
    public class Like
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
    }
}
