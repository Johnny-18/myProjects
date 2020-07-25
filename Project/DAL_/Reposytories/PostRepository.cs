using System.Collections.Generic;
using System.Threading.Tasks;
using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;

namespace DAL_.Reposytories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetComments(int id)
        {
            var post = await context.Posts.FindAsync(id);

            return post.Comments;
        }

        public async Task<IEnumerable<Image>> GetImages(int id)
        {
            var post = await context.Posts.FindAsync(id);

            return post.Images;
        }

        public async Task<IEnumerable<Like>> GetLikes(int id)
        {
            var post = await context.Posts.FindAsync(id);

            return post.Likes;
        }

        public async Task<Blog> GetBlog(int id)
        {
            var post = await context.Posts.FindAsync(id);

            return post.Blog;
        }

        public async Task<Tag> GetTag(int id)
        {
            var post = await context.Posts.FindAsync(id);

            return post.Tag;
        }
    }
}
