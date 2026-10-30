using _02.Models;
using Microsoft.EntityFrameworkCore;

namespace _02.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
    }
}