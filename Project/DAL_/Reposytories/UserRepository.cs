using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_.Reposytories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Like>> GetLikes(int id)
        {
            var user = await context.Users.FindAsync(id);

            return user.Likes;
        }

        public async Task<IEnumerable<Comment>> GetComments(int id)
        {
            var user = await context.Users.FindAsync(id);

            return user.Comments;
        }
    }
}
