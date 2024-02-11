using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class StoreContextSeeding
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> _roleManager)
        {
            if (await _roleManager.RoleExistsAsync("Admin") is false)
            {
                var rolesData = File.ReadAllText("../Repository/Data/DataSeeding/Roles.json");
                var roles = JsonSerializer.Deserialize<List<IdentityRole>>(rolesData);

                if (roles?.Count() > 0)
                {
                    foreach (var role in roles)
                    {
                        await _roleManager.CreateAsync(role);
                    }
                }
            }
        }

        public static async Task SeedAdminAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var adminData = File.ReadAllText("../Repository/Data/DataSeeding/Admin.json");
                var admin = JsonSerializer.Deserialize<AppUser>(adminData);

                if (admin is not null)
                {
                    await _userManager.CreateAsync(admin, "Pa$$w0rd");
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
