using IdentityMovie.Areas.Identity.Data;
using IdentityMovie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMovie.Seed
{
    public class DbInitializer : IdbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(UserRole.Admin.ToString()).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(UserRole.Admin.ToString())).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(UserRole.User.ToString())).GetAwaiter().GetResult();
            }
            var x = new ApplicationUser();
            var user = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                PhoneNumber = "9845374117",
                PhoneNumberConfirmed = true,
                Email = "movies@admin.com",
                UserName = "movies@admin.com",
                NormalizedEmail = "MOVIES@ADMIN.COM",
                NormalizedUserName = "MOVIES@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            var userManager = _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
            var result = _context.Users.FirstOrDefault(a => a.Email == "movies@admin.com");
            _userManager.AddToRoleAsync(user, UserRole.Admin.ToString()).GetAwaiter().GetResult();
            await _context.SaveChangesAsync();
        }
    }
}
