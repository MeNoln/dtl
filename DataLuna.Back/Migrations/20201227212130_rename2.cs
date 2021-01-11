using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLuna.Back.Migrations
{
    public partial class rename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Players",
                type: "text",
                nullable: true);
        }
    }
}
