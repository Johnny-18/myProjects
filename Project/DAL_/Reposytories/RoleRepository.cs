using DAL_.Entyties;
using DAL_.Interfaces;
using DAL_.Context;

namespace DAL_.Reposytories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(BlogContext context) : base(context)
        {
        }
    }
}
