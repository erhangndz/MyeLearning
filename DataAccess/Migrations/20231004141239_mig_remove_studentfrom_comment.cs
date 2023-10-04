using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class mig_remove_studentfrom_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_StudentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_StudentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Students_StudentId",
                table: "Comments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
