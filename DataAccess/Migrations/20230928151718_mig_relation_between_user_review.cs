using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class mig_relation_between_user_review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Reviews",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_StudentId",
                table: "Reviews",
                newName: "IX_Reviews_StudentID");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Students_StudentID",
                table: "Reviews",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Students_StudentID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Reviews",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_StudentID",
                table: "Reviews",
                newName: "IX_Reviews_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
