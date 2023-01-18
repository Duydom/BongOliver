using BongOliver.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BongOliver.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>()
            // .HasKey(ru => new { ru.UserId, ru.RoleId })
            .HasMany(p => p.users)
            .WithOne(c => c.role)
            .HasForeignKey(p => p.role_id);
            
        }
    }
}