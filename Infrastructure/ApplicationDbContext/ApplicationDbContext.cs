using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.AplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Customer>? Customers { get; set; }
        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<ProjectName>? ProjectNames { get; set; }
        public virtual DbSet<ProjectOwner>? ProjectOwners { get; set; }
        public virtual DbSet<TaskType>? TaskTypes { get; set; }
        public virtual DbSet<TimeTracking>? TimeTracking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            modelBuilder.Entity<ProjectName>().ToTable(nameof(ProjectName));
            modelBuilder.Entity<ProjectOwner>().ToTable(nameof(ProjectOwner));
            modelBuilder.Entity<TaskType>().ToTable(nameof(TaskType));
            modelBuilder.Entity<TimeTracking>().ToTable(nameof(TimeTracking));
        }
    }
}
