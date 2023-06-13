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
        public virtual DbSet<TimeTracking>? TimeTrackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer)).Property(c=>c.CustomerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().ToTable(nameof(Employee)).Property(e=>e.EmployeeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectName>().ToTable(nameof(ProjectName)).Property(pn=>pn.ProjectNameId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectOwner>().ToTable(nameof(ProjectOwner)).Property(po=>po.ProjectOwnerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskType>().ToTable(nameof(TaskType)).Property(tt=>tt.TaskTypeId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TimeTracking>().ToTable(nameof(TimeTracking)).Property(t=>t.TimeTrackingId).ValueGeneratedOnAdd();
            
            



        }
    }
}
