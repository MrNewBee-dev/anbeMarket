using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbe.Migrations
{
    public partial class add_granty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Granty",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Granty",
                table: "Products");
        }
    }
}
