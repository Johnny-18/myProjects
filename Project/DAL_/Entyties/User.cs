using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class User : IdentityUser<int>
    {
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength (20,ErrorMessage = "Password length from 6 to 20 symbols!")]
        [MinLength(6,ErrorMessage = "Password length from 6 to 20 symbols!")]
        public string Password { get; set; }
        public Blog Blog { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public User()
        {
            Likes = new List<Like>();
            UserRoles = new List<UserRole>();
            Comments = new List<Comment>();
            Images = new List<Image>();
        }
    }
}
