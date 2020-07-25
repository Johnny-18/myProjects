using System.Collections.Generic;
using System.Threading.Tasks;
using DAL_.Entyties;

namespace DAL_.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Comment>> GetComments(int id);
        Task<IEnumerable<Image>> GetImages(int id);
        Task<IEnumerable<Like>> GetLikes(int id);
        Task<Blog> GetBlog(int id);
        Task<Tag> GetTag(int id);
    }
}
