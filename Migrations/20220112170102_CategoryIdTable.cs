using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class CategoryIdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "pRODUCTS1s");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "pRODUCTS1s",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "pRODUCTS1s");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "pRODUCTS1s",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
