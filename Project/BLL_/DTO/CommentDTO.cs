using DAL_.Entyties;
using System;

namespace BLL_.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int User_Id { get; set; }
        public int Post_Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
