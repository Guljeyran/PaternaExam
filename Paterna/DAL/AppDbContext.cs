using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paterna.Models;

namespace Paterna.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }    
        public DbSet<Setting> Settings { get; set; }    
    }
}
