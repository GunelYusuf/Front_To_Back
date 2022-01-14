using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class produccst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pRODUCTS1s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CATEGORY1Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pRODUCTS1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pRODUCTS1s_cATEGORies_CATEGORY1Id",
                        column: x => x.CATEGORY1Id,
                        principalTable: "cATEGORies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pRODUCTS1s_CATEGORY1Id",
                table: "pRODUCTS1s",
                column: "CATEGORY1Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pRODUCTS1s");
        }
    }
}
