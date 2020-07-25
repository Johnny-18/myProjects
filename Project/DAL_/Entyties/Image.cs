using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public int User_Id { get; set; }
        public int Post_Id { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }

    }
}
