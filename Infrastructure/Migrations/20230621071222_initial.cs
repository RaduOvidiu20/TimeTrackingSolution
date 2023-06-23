using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNames",
                columns: table => new
                {
                    ProjectNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNames", x => x.ProjectNameId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectOwners",
                columns: table => new
                {
                    ProjectOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOwners", x => x.ProjectOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
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
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracking", x => x.TimeTrackingId);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Customers_Customers",
                        column: x => x.Customers,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Employees_Employees",
                        column: x => x.Employees,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_ProjectNames_ProjectNames",
                        column: x => x.ProjectNames,
                        principalTable: "ProjectNames",
                        principalColumn: "ProjectNameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_ProjectOwners_ProjectOwners",
                        column: x => x.ProjectOwners,
                        principalTable: "ProjectOwners",
                        principalColumn: "ProjectOwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTracking_TaskTypes_TaskTypes",
                        column: x => x.TaskTypes,
                        principalTable: "TaskTypes",
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
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectNames");

            migrationBuilder.DropTable(
                name: "ProjectOwners");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
