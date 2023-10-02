using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class mig_remove_review_from_courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Review",
                table: "Courses",
                type: "int",
                nullable: true);
        }
    }
}
