using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;

namespace DAL_.Reposytories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(BlogContext context) : base(context)
        {
        }
    }
}
