using System.Threading.Tasks;
using DAL_.Entyties;

namespace DAL_.Interfaces
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<User> GetUser(int id);
    }
}
