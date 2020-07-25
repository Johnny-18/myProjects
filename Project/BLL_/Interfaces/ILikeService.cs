using BLL_.DTO;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface ILikeService
    {
        Task<bool> SetLike(int userId, int postId);
        Task<bool> DeleteLike(int userId, int postId);
    }
}
