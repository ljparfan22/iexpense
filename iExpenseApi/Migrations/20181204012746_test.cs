using Microsoft.EntityFrameworkCore.Migrations;

namespace iExpenseApi.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId1",
                table: "Categories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserId1",
                table: "Categories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
