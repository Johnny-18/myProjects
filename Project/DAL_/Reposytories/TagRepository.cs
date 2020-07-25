using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_.Reposytories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            var tag = await context.Tags.FindAsync(id);

            return tag.Posts;
        }
    }
}
