using _02.Models;
using Microsoft.EntityFrameworkCore;

namespace _02.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Roles.AnyAsync()) return;

            var adminRole = new Role { Name = "admin" };
            var userRole = new Role { Name = "user" };

            context.Roles.AddRange(adminRole, userRole);
            await context.SaveChangesAsync();
        }
    }
}