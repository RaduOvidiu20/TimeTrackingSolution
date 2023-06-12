﻿// <auto-generated />
using System;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProjectName", b =>
                {
                    b.Property<Guid>("ProjectNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectNameId");

                    b.ToTable("ProjectName", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProjectOwner", b =>
                {
                    b.Property<Guid>("ProjectOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectOwnerId");

                    b.ToTable("ProjectOwner", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TaskType", b =>
                {
                    b.Property<Guid>("TaskTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskType", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TimeTracking", b =>
                {
                    b.Property<Guid>("TimeTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Customers")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Employees")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectNames")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectOwners")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecordStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaskTypes")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("WorkedHours")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("TimeTrackingId");

                    b.HasIndex("Customers");

                    b.HasIndex("Employees");

                    b.HasIndex("ProjectNames");

                    b.HasIndex("ProjectOwners");

                    b.HasIndex("TaskTypes");

                    b.ToTable("TimeTracking", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TimeTracking", b =>
                {
                    b.HasOne("Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employees")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ProjectName", "ProjectName")
                        .WithMany()
                        .HasForeignKey("ProjectNames")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ProjectOwner", "ProjectOwner")
                        .WithMany()
                        .HasForeignKey("ProjectOwners")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("ProjectName");

                    b.Navigation("ProjectOwner");

                    b.Navigation("TaskType");
                });
#pragma warning restore 612, 618
        }
    }
}
