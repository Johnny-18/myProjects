using BLL_.DTO;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface ICommentService : IService<CommentDTO>
    {
        Task<UserDTO> GetUser(int id);
    }
}
