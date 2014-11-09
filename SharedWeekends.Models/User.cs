namespace SharedWeekends.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    
    public class User : IdentityUser
    {
        private ICollection<Weekend> weekends;

        private ICollection<Like> likes;

        private ICollection<Message> messages;

        public User()
        {
            this.weekends = new HashSet<Weekend>();
            this.likes = new HashSet<Like>();
            this.messages = new HashSet<Message>();
        }

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

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
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

        [Required]
        public int Rating { get; set; }

        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
