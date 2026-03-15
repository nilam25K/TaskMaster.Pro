using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Domain.Entities;

namespace TaskMaster.Pro.Infrastructure.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>()
                .HasOne<UserEntity>()
                .WithMany()
                .HasForeignKey(t => t.AssigneeId);
        }
    }
}
