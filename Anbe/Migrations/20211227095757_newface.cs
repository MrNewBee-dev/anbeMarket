using Microsoft.EntityFrameworkCore.Migrations;

namespace Anbe.Migrations
{
    public partial class newface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JadvaleColor",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductID",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductsProductID",
                table: "Color",
                column: "ProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Products_ProductsProductID",
                table: "Color",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Products_ProductsProductID",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_ProductsProductID",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ProductsProductID",
                table: "Color");

            migrationBuilder.AddColumn<string>(
                name: "JadvaleColor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
