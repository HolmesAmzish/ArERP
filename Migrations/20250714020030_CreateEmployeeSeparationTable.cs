using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeSeparationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSeparations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SeparationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeparationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSeparations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSeparations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSeparations_EmployeeId",
                table: "EmployeeSeparations",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSeparations");
        }
    }
}
