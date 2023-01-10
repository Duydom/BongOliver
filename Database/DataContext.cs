using BongOliver.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BongOliver.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
    }
}