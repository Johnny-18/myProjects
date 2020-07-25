using System;
using System.Collections.Generic;

namespace BLL_.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Blog_Id { get; set; }
        public int Tag_Id { get; set; }
        public DateTime Created { get; set; }
        public BlogDTO Blog { get; set; }
        public TagDTO Tag { get; set; }
        public ICollection<ImageDTO> Images { get; set; }
        public ICollection<LikeDTO> Likes { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
    }
}
