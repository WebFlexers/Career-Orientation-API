using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCourseGradeConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrade_AspNetUsers_UserId",
                table: "UserCourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrade_Courses_CourseId",
                table: "UserCourseGrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseGrade",
                table: "UserCourseGrade");

            migrationBuilder.DropIndex(
                name: "IX_UserCourseGrade_UserId",
                table: "UserCourseGrade");

            migrationBuilder.RenameTable(
                name: "UserCourseGrade",
                newName: "UserCourseGrades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseGrades",
                table: "UserCourseGrades",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseGrades_CourseId",
                table: "UserCourseGrades",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrades_AspNetUsers_UserId",
                table: "UserCourseGrades",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrades_Courses_CourseId",
                table: "UserCourseGrades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrades_AspNetUsers_UserId",
                table: "UserCourseGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrades_Courses_CourseId",
                table: "UserCourseGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseGrades",
                table: "UserCourseGrades");

            migrationBuilder.DropIndex(
                name: "IX_UserCourseGrades_CourseId",
                table: "UserCourseGrades");

            migrationBuilder.RenameTable(
                name: "UserCourseGrades",
                newName: "UserCourseGrade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseGrade",
                table: "UserCourseGrade",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseGrade_UserId",
                table: "UserCourseGrade",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrade_AspNetUsers_UserId",
                table: "UserCourseGrade",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrade_Courses_CourseId",
                table: "UserCourseGrade",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
