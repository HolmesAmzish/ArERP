using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationDeparmentDisplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeApplications_DepartmentId",
                table: "EmployeeApplications",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeApplications_Departments_DepartmentId",
                table: "EmployeeApplications",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeApplications_Departments_DepartmentId",
                table: "EmployeeApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeApplications_DepartmentId",
                table: "EmployeeApplications");
        }
    }
}
