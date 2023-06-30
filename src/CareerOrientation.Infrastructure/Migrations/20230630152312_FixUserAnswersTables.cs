using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserAnswersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMultipleChoiceAnswers",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "Value",
                table: "UserTrueFalseAnswers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MultipleChoiceAnswerId",
                table: "UserMultipleChoiceAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMultipleChoiceAnswers",
                table: "UserMultipleChoiceAnswers",
                columns: new[] { "QuestionId", "UserId", "MultipleChoiceAnswerId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMultipleChoiceAnswers_MultipleChoiceAnswerId",
                table: "UserMultipleChoiceAnswers",
                column: "MultipleChoiceAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_MultipleCho~",
                table: "UserMultipleChoiceAnswers",
                column: "MultipleChoiceAnswerId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "MultipleChoiceAnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_Questions_QuestionId",
                table: "UserMultipleChoiceAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_MultipleCho~",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_Questions_QuestionId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMultipleChoiceAnswers",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserMultipleChoiceAnswers_MultipleChoiceAnswerId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserTrueFalseAnswers");

            migrationBuilder.DropColumn(
                name: "MultipleChoiceAnswerId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMultipleChoiceAnswers",
                table: "UserMultipleChoiceAnswers",
                columns: new[] { "QuestionId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers",
                column: "QuestionId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "MultipleChoiceAnswerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
