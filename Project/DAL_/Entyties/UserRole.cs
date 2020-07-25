using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_.Entyties
{
    public class UserRole : IdentityUserRole<int>
    {
        [ForeignKey("User")]
        public override int UserId { get; set; }
        [ForeignKey("Post")]
        public override int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
