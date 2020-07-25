using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using System.Threading.Tasks;

namespace DAL_.Reposytories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        public async Task<User> GetUser(int id)
        {
            var comment = await context.Comments.FindAsync(id);
            return comment.User;
        }
    }
}
