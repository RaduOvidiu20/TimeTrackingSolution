using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectName",
                columns: table => new
                {
                    ProjectNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectName", x => x.ProjectNameId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectOwner",
                columns: table => new
                {
                    ProjectOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOwner", x => x.ProjectOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    TaskTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TimeTracking",
                columns: table => new
                {
                    TimeTrackingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customers = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employees = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectNames = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectOwners = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskTypes = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkedHours = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracking", x => x.TimeTrackingId);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Customer_Customers",
                        column: x => x.Customers,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Employee_Employees",
                        column: x => x.Employees,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_ProjectName_ProjectNames",
                        column: x => x.ProjectNames,
                        principalTable: "ProjectName",
                        principalColumn: "ProjectNameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_ProjectOwner_ProjectOwners",
                        column: x => x.ProjectOwners,
                        principalTable: "ProjectOwner",
                        principalColumn: "ProjectOwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_TaskType_TaskTypes",
                        column: x => x.TaskTypes,
                        principalTable: "TaskType",
                        principalColumn: "TaskTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_Customers",
                table: "TimeTracking",
                column: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_Employees",
                table: "TimeTracking",
                column: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_ProjectNames",
                table: "TimeTracking",
                column: "ProjectNames");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_ProjectOwners",
                table: "TimeTracking",
                column: "ProjectOwners");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_TaskTypes",
                table: "TimeTracking",
                column: "TaskTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTracking");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProjectName");

            migrationBuilder.DropTable(
                name: "ProjectOwner");

            migrationBuilder.DropTable(
                name: "TaskType");
        }
    }
}
