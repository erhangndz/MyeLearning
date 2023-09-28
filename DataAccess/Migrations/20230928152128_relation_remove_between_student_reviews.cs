using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class relation_remove_between_student_reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Students_StudentID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_StudentID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentID",
                table: "Reviews",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Students_StudentID",
                table: "Reviews",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }
    }
}
