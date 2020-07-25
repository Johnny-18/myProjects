using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage = "Max length of title is 50 symbols!")]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey("Blog")]
        public int Blog_Id { get; set; }
        [ForeignKey("Tag")]
        public int Tag_Id { get; set; }
        public Tag Tag { get; set; }
        public Blog Blog { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Images = new List<Image>();
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }
    }
}
