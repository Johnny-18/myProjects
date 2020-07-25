using System.Collections.Generic;
using System.Threading.Tasks;
using DAL_.Entyties;

namespace DAL_.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IEnumerable<Post>> GetPosts(int id);
    }
}
