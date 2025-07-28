using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWarehouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "InventoryBalances");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Warehouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Warehouses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Warehouses");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentCapacity",
                table: "Warehouses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxCapacity",
                table: "Warehouses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "InventoryBalances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
