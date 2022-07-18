using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tawasol.DAL.Migrations
{
    public partial class CoverViewEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Heigth",
                table: "CoverPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostionX",
                table: "CoverPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostionY",
                table: "CoverPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "CoverPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heigth",
                table: "CoverPhoto");

            migrationBuilder.DropColumn(
                name: "PostionX",
                table: "CoverPhoto");

            migrationBuilder.DropColumn(
                name: "PostionY",
                table: "CoverPhoto");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CoverPhoto");
        }
    }
}
