using AutoMapper;
using SharedWeekends.Models;
using SharedWeekends.MVC.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SharedWeekends.MVC.ViewModels
{
    public class TopUserViewModel : IMapFrom<User>
    {
        [Required]
        public string Username { get; set; }

        public int Rating { get; set; }

        public string AvatarUrl { get; set; }
    }
}