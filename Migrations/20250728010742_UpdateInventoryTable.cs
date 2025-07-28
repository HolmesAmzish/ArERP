using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArERP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_InventoryTransactions_TransactionId",
                table: "TransactionLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTransactions",
                table: "InventoryTransactions");

            migrationBuilder.RenameTable(
                name: "InventoryTransactions",
                newName: "Transactions");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "InventoryBalances",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "InventoryTransactions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InventoryBalances",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTransactions",
                table: "InventoryTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_InventoryTransactions_TransactionId",
                table: "TransactionLines",
                column: "TransactionId",
                principalTable: "InventoryTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
