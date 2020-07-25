using BLL_.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface ITagService : IService<TagDTO>
    {
        Task<IEnumerable<PostDTO>> GetPosts(int id);
    }
}
