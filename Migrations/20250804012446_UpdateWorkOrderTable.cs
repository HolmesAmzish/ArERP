using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductionProcess",
                table: "WorkOrders",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionProcess",
                table: "WorkOrders");
        }
    }
}
