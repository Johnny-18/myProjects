using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(100,ErrorMessage = "Max length of message is 100 symbols!")]
        public string Text { get; set; }
        public int User_Id { get; set; }
        public int Post_Id { get; set; }
        public DateTime Date { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }

        
    }
}
