using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsGraduateToUniStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "UniversityStudents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsGraduate",
                table: "UniversityStudents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGraduate",
                table: "UniversityStudents");

            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "UniversityStudents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
