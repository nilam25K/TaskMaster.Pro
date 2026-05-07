using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Domain.Entities;
using TaskMaster.Pro.Infrastructure.Identity;

namespace TaskMaster.Pro.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // ← THIS creates ALL Identity tables!

            // Configure your entities here
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            });

            // Seed sample data
            modelBuilder.Entity<ProjectEntity>().HasData(
                new ProjectEntity
                {
                    Id = Guid.Parse("1c4e9548-9b1e-4b5a-9c2d-7e8f3a4b5c6d"),
                    Name = "Test Project 1",
                    OwnerId = Guid.Parse("1c4e9548-9b1e-4b5a-9c2d-7e8f3a4b5c6d")
                }
            );
            //modelBuilder.Entity<TaskEntity>()
            //    .HasOne<UserEntity>()
            //    .WithMany()
            //    .HasForeignKey(t => t.AssigneeId);
        }
    }
}
