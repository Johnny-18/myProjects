using BLL_.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface IPostService : IService<PostDTO>
    {
        Task<IEnumerable<CommentDTO>> GetComments(int id);
        Task<IEnumerable<ImageDTO>> GetImages(int id);
        Task<IEnumerable<LikeDTO>> GetLikes(int id);
        Task<BlogDTO> GetBlog(int id);
        Task<TagDTO> GetTag(int id);
        Task<IEnumerable<PostDTO>> Search(string searchStr);
    }
}
