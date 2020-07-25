
using System.Collections.Generic;

namespace BLL_.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public UserDTO User { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
    }
}
