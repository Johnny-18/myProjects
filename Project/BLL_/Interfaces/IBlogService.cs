using BLL_.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface IBlogService : IService<BlogDTO>
    {
        Task<IEnumerable<PostDTO>> GetPosts(int id);
        Task<IEnumerable<BlogDTO>> Search(string searchStr);
    }
}
