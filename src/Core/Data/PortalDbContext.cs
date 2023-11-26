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
        public DbSet<UserFavoriteJob> UserFavoriteJobs { get; set; }
        public DbSet<UserFavoriteEvent> UserFavoriteEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a relação entre JobInfo e UserInfo
            modelBuilder.Entity<JobInfo>()
                .HasOne(j => j.CreatedByUser)
                .WithMany(u => u.CreatedJobs)
                .HasForeignKey(j => j.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurando a relação entre EventInfo e UserInfo (criador do evento)
            modelBuilder.Entity<EventInfo>()
                .HasOne(e => e.EventCreatedByUser)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
