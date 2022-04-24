using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbe.Migrations
{
    public partial class roleinrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleParentID",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_roleParentID",
                table: "AspNetRoles",
                column: "roleParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_roleParentID",
                table: "AspNetRoles",
                column: "roleParentID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_roleParentID",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_roleParentID",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "roleParentID",
                table: "AspNetRoles");
        }
    }
}
