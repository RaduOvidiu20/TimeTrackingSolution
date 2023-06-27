using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AspNetUsers",
                newName: "Employee");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeesEmployeeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeesEmployeeId",
                table: "AspNetUsers",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeesEmployeeId",
                table: "AspNetUsers",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeesEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeesEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "AspNetUsers",
                newName: "EmployeeId");
        }
    }
}
