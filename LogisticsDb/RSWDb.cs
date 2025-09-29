using Microsoft.EntityFrameworkCore;
using RCWLogistics.Models;
using RCWLogisticsBackend.Models;
using RSWLogistics.Models;

namespace RSWLogistics.LogisticsDb
{
    public class RSWDb : DbContext
    {
        public RSWDb(DbContextOptions<RSWDb> options) : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Loads> Loads { get; set; }
        public DbSet<Admins> Admins { get; set; }
    }
}
