using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class added_image_to_students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");
        }
    }
}
