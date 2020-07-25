using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_.Reposytories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogContext context): base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            var blog = await context.Blogs.FindAsync(id);

            return blog.Posts;
        }
    }
}
