using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbe.Migrations
{
    public partial class DetailsProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductsProductID",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductsProductID",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductsProductID",
                table: "ProductDetails",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductsProductID",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ProductsProductID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductsProductID",
                table: "ProductDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductsProductID",
                table: "ProductDetails",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }
    }
}
