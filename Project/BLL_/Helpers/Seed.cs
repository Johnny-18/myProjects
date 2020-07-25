using DAL_.Entyties;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace BLL_.Helpers
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRole()
        {
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role {Name = "Admin"},
                    new Role {Name = "Member"},
                    new Role {Name = "Moderator"},
                    new Role {Name = "Blogger"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }
            }
        }

        public void SeedAdmin()
        {
            if (_userManager.Users.FirstOrDefault(p => p.UserName == "Admin") == null)
            {
                var adminUser = new User
                {
                    UserName = "Admin",
                    FirstName = "1",
                    LastName = "1"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "1_Password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    List<string> roles = new List<string>() { "Admin", "Moderator" };
                    _userManager.AddToRolesAsync(admin, roles).Wait();
                }
            }
        }

        public void SeedModerator()
        {
            if (_userManager.Users.FirstOrDefault(p => p.UserName == "Moderator") == null)
            {
                var adminUser = new User
                {
                    UserName = "Moderator",
                    FirstName = "1",
                    LastName = "1"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "2_Password").Result;

                if (result.Succeeded)
                {
                    var moderator = _userManager.FindByNameAsync("Moderator").Result;
                    _userManager.AddToRolesAsync(moderator, new[] { "Moderator" }).Wait();
                }
            }
        }
    }
}
