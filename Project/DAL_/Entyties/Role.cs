using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL_.Entyties
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
    }
}
