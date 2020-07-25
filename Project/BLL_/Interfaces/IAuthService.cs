using BLL_.DTO;
using System.Threading.Tasks;

namespace BLL_.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> Register(UserForRegisterDTO user);
        Task<UserDTO> LogIn(UserForLoginDTO user);
        Task<string> GenerateToken(UserDTO user, string keyWord);
        Task<bool> AddRole(string userEmail, string role);
    }
}
