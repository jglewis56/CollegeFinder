using CollegeFinder.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeFinder.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions option) : base(option){}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}