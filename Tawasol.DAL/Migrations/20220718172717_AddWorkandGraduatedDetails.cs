using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tawasol.DAL.Migrations
{
    public partial class AddWorkandGraduatedDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Graduated",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Work",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Graduated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Work",
                table: "AspNetUsers");
        }
    }
}
