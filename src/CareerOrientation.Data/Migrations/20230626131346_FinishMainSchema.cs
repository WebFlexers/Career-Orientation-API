using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinishMainSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Tracks_TrackId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Course_CourseId",
                table: "CourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkill_Skill_SkillId",
                table: "CourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrade_Course_CourseId",
                table: "UserCourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseStatistics_Course_CourseId",
                table: "UserCourseStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSkill",
                table: "CourseSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "CourseSkill",
                newName: "CourseSkills");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSkill_SkillId",
                table: "CourseSkills",
                newName: "IX_CourseSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_TrackId",
                table: "Courses",
                newName: "IX_Courses_TrackId");

            migrationBuilder.AddColumn<int>(
                name: "MultipleChoiceAnswerId",
                table: "MultipleChoiceAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers",
                column: "MultipleChoiceAnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSkills",
                table: "CourseSkills",
                columns: new[] { "CourseId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.CreateTable(
                name: "LikertScaleAnswers",
                columns: table => new
                {
                    LikertScaleAnswerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Option1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Option2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Option3 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Option4 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Option5 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikertScaleAnswers", x => x.LikertScaleAnswerId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionLikertScaleAnswers",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    LikertScaleAnswersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLikertScaleAnswers", x => new { x.QuestionId, x.LikertScaleAnswersId });
                    table.ForeignKey(
                        name: "FK_QuestionLikertScaleAnswers_LikertScaleAnswers_LikertScaleAn~",
                        column: x => x.LikertScaleAnswersId,
                        principalTable: "LikertScaleAnswers",
                        principalColumn: "LikertScaleAnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionLikertScaleAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_QuestionId",
                table: "MultipleChoiceAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLikertScaleAnswers_LikertScaleAnswersId",
                table: "QuestionLikertScaleAnswers",
                column: "LikertScaleAnswersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tracks_TrackId",
                table: "Courses",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkills_Courses_CourseId",
                table: "CourseSkills",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkills_Skills_SkillId",
                table: "CourseSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrade_Courses_CourseId",
                table: "UserCourseGrade",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseStatistics_Courses_CourseId",
                table: "UserCourseStatistics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers",
                column: "QuestionId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "MultipleChoiceAnswerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tracks_TrackId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkills_Courses_CourseId",
                table: "CourseSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSkills_Skills_SkillId",
                table: "CourseSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseGrade_Courses_CourseId",
                table: "UserCourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseStatistics_Courses_CourseId",
                table: "UserCourseStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropTable(
                name: "QuestionLikertScaleAnswers");

            migrationBuilder.DropTable(
                name: "LikertScaleAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropIndex(
                name: "IX_MultipleChoiceAnswers_QuestionId",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSkills",
                table: "CourseSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MultipleChoiceAnswerId",
                table: "MultipleChoiceAnswers");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "CourseSkills",
                newName: "CourseSkill");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSkills_SkillId",
                table: "CourseSkill",
                newName: "IX_CourseSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TrackId",
                table: "Course",
                newName: "IX_Course_TrackId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSkill",
                table: "CourseSkill",
                columns: new[] { "CourseId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Tracks_TrackId",
                table: "Course",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Course_CourseId",
                table: "CourseSkill",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSkill_Skill_SkillId",
                table: "CourseSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseGrade_Course_CourseId",
                table: "UserCourseGrade",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseStatistics_Course_CourseId",
                table: "UserCourseStatistics",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers",
                column: "QuestionId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
