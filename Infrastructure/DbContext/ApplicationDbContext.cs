using Core.Entities;
using Core.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<ProjectName> ProjectNames { get; set; } = null!;
    public virtual DbSet<ProjectOwner> ProjectOwners { get; set; } = null!;
    public virtual DbSet<TaskType> TaskTypes { get; set; } = null!;
    public virtual DbSet<TimeTracking> TimeTracking { get; set; } = null!;
}