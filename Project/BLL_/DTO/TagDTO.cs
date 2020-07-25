using DAL_.Entyties;
using System.Collections.Generic;

namespace BLL_.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
