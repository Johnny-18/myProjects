using BLL_.DTO;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface IImageService : IService<ImageDTO>
    {
        Task<UserDTO> GetUser(int id);
    }
}
