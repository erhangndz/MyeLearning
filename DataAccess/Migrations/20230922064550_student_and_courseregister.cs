using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyeLearningProject.Migrations
{
    public partial class student_and_courseregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegister_Courses_CourseID",
                table: "CourseRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegister_Student_StudentID",
                table: "CourseRegister");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegister",
                table: "CourseRegister");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "CourseRegister",
                newName: "CourseRegisters");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegister_StudentID",
                table: "CourseRegisters",
                newName: "IX_CourseRegisters_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegister_CourseID",
                table: "CourseRegisters",
                newName: "IX_CourseRegisters_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegisters",
                table: "CourseRegisters",
                column: "CourseRegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Courses_CourseID",
                table: "CourseRegisters",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Students_StudentID",
                table: "CourseRegisters",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Courses_CourseID",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Students_StudentID",
                table: "CourseRegisters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegisters",
                table: "CourseRegisters");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "CourseRegisters",
                newName: "CourseRegister");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegisters_StudentID",
                table: "CourseRegister",
                newName: "IX_CourseRegister_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegisters_CourseID",
                table: "CourseRegister",
                newName: "IX_CourseRegister_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegister",
                table: "CourseRegister",
                column: "CourseRegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegister_Courses_CourseID",
                table: "CourseRegister",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegister_Student_StudentID",
                table: "CourseRegister",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
