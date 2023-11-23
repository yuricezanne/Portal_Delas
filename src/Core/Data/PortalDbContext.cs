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
        public DbSet<JobCategory> Categories { get; set; }
        public DbSet<UserFavoriteJob> UserFavoriteJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a relação entre JobInfo e JobCategory
            modelBuilder.Entity<JobInfo>()
                .HasOne(j => j.JobCategory)
                .WithMany()
                .HasForeignKey(j => j.JobCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Adicionando um índice único a CategoryName em JobCategory
            modelBuilder.Entity<JobCategory>()
                .HasIndex(c => c.CategoryId)
                .IsUnique();
        }
    }
}