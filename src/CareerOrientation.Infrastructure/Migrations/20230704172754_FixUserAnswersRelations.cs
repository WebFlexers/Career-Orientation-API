using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CareerOrientation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserAnswersRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_QuestionId",
                table: "UserTrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers");

            migrationBuilder.AddColumn<int>(
                name: "TrueFalseAnswerId",
                table: "TrueFalseAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers",
                column: "TrueFalseAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseAnswers_QuestionId",
                table: "TrueFalseAnswers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrueFalseAnswers_Questions_QuestionId",
                table: "UserTrueFalseAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrueFalseAnswers_Questions_QuestionId",
                table: "UserTrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TrueFalseAnswers_QuestionId",
                table: "TrueFalseAnswers");

            migrationBuilder.DropColumn(
                name: "TrueFalseAnswerId",
                table: "TrueFalseAnswers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_QuestionId",
                table: "UserTrueFalseAnswers",
                column: "QuestionId",
                principalTable: "TrueFalseAnswers",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
