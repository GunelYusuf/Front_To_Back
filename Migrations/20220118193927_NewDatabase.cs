using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pRODUCTS1s_cATEGORies_CATEGORY1Id",
                table: "pRODUCTS1s");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sliders",
                maxLength: 260,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(260)",
                oldMaxLength: 260);

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORY1Id",
                table: "pRODUCTS1s",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pRODUCTS1s_cATEGORies_CATEGORY1Id",
                table: "pRODUCTS1s",
                column: "CATEGORY1Id",
                principalTable: "cATEGORies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pRODUCTS1s_cATEGORies_CATEGORY1Id",
                table: "pRODUCTS1s");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Sliders",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 260,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CATEGORY1Id",
                table: "pRODUCTS1s",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_pRODUCTS1s_cATEGORies_CATEGORY1Id",
                table: "pRODUCTS1s",
                column: "CATEGORY1Id",
                principalTable: "cATEGORies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
