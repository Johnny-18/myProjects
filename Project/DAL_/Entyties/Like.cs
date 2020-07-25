using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class Like
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Post_Id { get; set; }

        public User User { get; set; } 
        public Post Post { get; set; }
    }
}
