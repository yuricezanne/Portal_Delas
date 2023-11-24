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

        public DbSet<EventType> EventTypes { get; set; } 
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

            // Configurando a relação entre EventInfo e EventType
            modelBuilder.Entity<EventInfo>()
                .HasOne(e => e.EventType)
                .WithMany()
                .HasForeignKey(e => e.EventTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Adicionando um índice único a CategoryName em JobCategory
            modelBuilder.Entity<EventType>()
                .HasIndex(t => t.TypeId)
                .IsUnique();


            // Configurando a relação entre JobInfo e UserInfo
            modelBuilder.Entity<JobInfo>()
                .HasOne(j => j.CreatedByUser)
                .WithMany(u => u.CreatedJobs)
                .HasForeignKey(j => j.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurando a relação entre EventInfo e EventType
            modelBuilder.Entity<EventInfo>()
                .HasOne(e => e.EventType)
                .WithMany()
                .HasForeignKey(e => e.EventTypeId)
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
