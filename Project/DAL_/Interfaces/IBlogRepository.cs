using DAL_.Entyties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IEnumerable<Post>> GetPosts(int id);
        void Update(Blog item);
    }
}
