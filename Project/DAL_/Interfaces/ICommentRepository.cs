using DAL_.Entyties;
using System.Threading.Tasks;

namespace DAL_.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<User> GetUser(int id);
    }
}
