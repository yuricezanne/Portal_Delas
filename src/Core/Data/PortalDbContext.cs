using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Core.Data
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
        {
        }

        public DbSet<EventInfo> Events { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<JobInfo> Jobs { get; set; }
        
    }
}