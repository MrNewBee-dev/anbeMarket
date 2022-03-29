using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbe.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Products_ProductsProductID",
                table: "Color");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "Color",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Color_ProductsProductID",
                table: "Color",
                newName: "IX_Color_ProductID");

            migrationBuilder.CreateTable(
                name: "Product_Color",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Color", x => new { x.ColorId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Product_Color_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Color_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Color_ProductId",
                table: "Product_Color",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Products_ProductID",
                table: "Color",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Products_ProductID",
                table: "Color");

            migrationBuilder.DropTable(
                name: "Product_Color");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Color",
                newName: "ProductsProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Color_ProductID",
                table: "Color",
                newName: "IX_Color_ProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Products_ProductsProductID",
                table: "Color",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }
    }
}
