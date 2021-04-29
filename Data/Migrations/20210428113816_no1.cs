using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.Data.Migrations
{
    public partial class no1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockModel_ProductModel_ProductID",
                table: "StockModel");

            migrationBuilder.DropColumn(
                name: "PDID",
                table: "StockModel");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "StockModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockModel_ProductModel_ProductID",
                table: "StockModel",
                column: "ProductID",
                principalTable: "ProductModel",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockModel_ProductModel_ProductID",
                table: "StockModel");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "StockModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PDID",
                table: "StockModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StockModel_ProductModel_ProductID",
                table: "StockModel",
                column: "ProductID",
                principalTable: "ProductModel",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
