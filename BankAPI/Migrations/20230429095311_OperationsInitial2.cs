using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class OperationsInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationsCount_cardInfos_CardInfoId",
                table: "OperationsCount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationsCount",
                table: "OperationsCount");

            migrationBuilder.RenameTable(
                name: "OperationsCount",
                newName: "operations");

            migrationBuilder.RenameIndex(
                name: "IX_OperationsCount_CardInfoId",
                table: "operations",
                newName: "IX_operations_CardInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operations",
                table: "operations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_operations_cardInfos_CardInfoId",
                table: "operations",
                column: "CardInfoId",
                principalTable: "cardInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operations_cardInfos_CardInfoId",
                table: "operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operations",
                table: "operations");

            migrationBuilder.RenameTable(
                name: "operations",
                newName: "OperationsCount");

            migrationBuilder.RenameIndex(
                name: "IX_operations_CardInfoId",
                table: "OperationsCount",
                newName: "IX_OperationsCount_CardInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationsCount",
                table: "OperationsCount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationsCount_cardInfos_CardInfoId",
                table: "OperationsCount",
                column: "CardInfoId",
                principalTable: "cardInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
