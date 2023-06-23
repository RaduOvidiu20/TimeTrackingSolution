﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>();
        modelBuilder.Entity<Employee>();
        modelBuilder.Entity<ProjectName>();
        modelBuilder.Entity<ProjectOwner>();
        modelBuilder.Entity<TaskType>();
        modelBuilder.Entity<TimeTracking>();
    }
}