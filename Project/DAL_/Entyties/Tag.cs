using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL_.Entyties
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Tag()
        {
            Posts = new List<Post>();
        }
    }
}
