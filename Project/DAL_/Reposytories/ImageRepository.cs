using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using System.Threading.Tasks;

namespace DAL_.Reposytories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(BlogContext context) : base(context)
        {
        }

        public async Task<User> GetUser(int id)
        {
            var image = await context.Images.FindAsync(id);
            return image.User;
        }
    }
}
