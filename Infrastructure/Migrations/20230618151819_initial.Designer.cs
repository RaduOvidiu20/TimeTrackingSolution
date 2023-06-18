﻿// <auto-generated />
using System;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230618151819_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Core.Entities.ProjectName", b =>
                {
                    b.Property<Guid>("ProjectNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectNameId");

                    b.ToTable("ProjectNames");
                });

            modelBuilder.Entity("Core.Entities.ProjectOwner", b =>
                {
                    b.Property<Guid>("ProjectOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectOwnerId");

                    b.ToTable("ProjectOwners");
                });

            modelBuilder.Entity("Core.Entities.TaskType", b =>
                {
                    b.Property<Guid>("TaskTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("Core.Entities.TimeTracking", b =>
                {
                    b.Property<Guid>("TimeTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Customers")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Employees")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectNames")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectOwners")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecordStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaskTypes")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkedHours")
                        .HasColumnType("int");

                    b.HasKey("TimeTrackingId");

                    b.HasIndex("Customers");

                    b.HasIndex("Employees");

                    b.HasIndex("ProjectNames");

                    b.HasIndex("ProjectOwners");

                    b.HasIndex("TaskTypes");

                    b.ToTable("TimeTracking");
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
