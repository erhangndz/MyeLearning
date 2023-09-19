using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class mig_instructor_coverimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Instructors");
        }
    }
}
