using Microsoft.EntityFrameworkCore;
using net_restfull_api.Models;

namespace net_restfull_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
    }
}