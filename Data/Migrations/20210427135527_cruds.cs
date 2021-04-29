using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.Data.Migrations
{
    public partial class cruds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 200, nullable: false),
                    CategoryDescription = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerModel",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 200, nullable: false),
                    CustomerAddress = table.Column<string>(maxLength: 200, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(maxLength: 200, nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false),
                    CustomerGender = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModel", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseModel",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDescription = table.Column<string>(maxLength: 200, nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    VendorName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseModel", x => x.PurchaseID);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 200, nullable: false),
                    ProductType = table.Column<string>(maxLength: 200, nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 200, nullable: false),
                    ProductManufacturer = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_ProductModel_CategoryModel_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryModel",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailsModel",
                columns: table => new
                {
                    PurchaseDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    PurchaseID = table.Column<int>(nullable: false),
                    PurchaseQuantity = table.Column<string>(maxLength: 100, nullable: false),
                    PurchasePrice = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailsModel", x => x.PurchaseDetailID);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailsModel_ProductModel_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductModel",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailsModel_PurchaseModel_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "PurchaseModel",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesModel",
                columns: table => new
                {
                    SalesModedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesDate = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesModel", x => x.SalesModedID);
                    table.ForeignKey(
                        name: "FK_SalesModel_ProductModel_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "ProductModel",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockModel",
                columns: table => new
                {
                    SalesModedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockModel", x => x.SalesModedID);
                    table.ForeignKey(
                        name: "FK_StockModel_ProductModel_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductModel",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetailsModel",
                columns: table => new
                {
                    SalesDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Manufacturedate = table.Column<DateTime>(nullable: false),
                    Expirydate = table.Column<DateTime>(nullable: false),
                    SalesID = table.Column<int>(nullable: false),
                    PurchaseID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetailsModel", x => x.SalesDetailsID);
                    table.ForeignKey(
                        name: "FK_SalesDetailsModel_CustomerModel_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CustomerModel",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetailsModel_PurchaseModel_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "PurchaseModel",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetailsModel_SalesModel_SalesID",
                        column: x => x.SalesID,
                        principalTable: "SalesModel",
                        principalColumn: "SalesModedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_CategoryID",
                table: "ProductModel",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailsModel_ProductID",
                table: "PurchaseDetailsModel",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailsModel_PurchaseID",
                table: "PurchaseDetailsModel",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsModel_CustomerID",
                table: "SalesDetailsModel",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsModel_PurchaseID",
                table: "SalesDetailsModel",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsModel_SalesID",
                table: "SalesDetailsModel",
                column: "SalesID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesModel_CustomerID",
                table: "SalesModel",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_StockModel_ProductID",
                table: "StockModel",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetailsModel");

            migrationBuilder.DropTable(
                name: "SalesDetailsModel");

            migrationBuilder.DropTable(
                name: "StockModel");

            migrationBuilder.DropTable(
                name: "CustomerModel");

            migrationBuilder.DropTable(
                name: "PurchaseModel");

            migrationBuilder.DropTable(
                name: "SalesModel");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "CategoryModel");
        }
    }
}
