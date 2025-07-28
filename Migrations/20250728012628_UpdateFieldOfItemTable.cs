using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldOfItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unit",
                table: "Items",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Items",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Items",
                newName: "unit");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Items",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");
        }
    }
}
