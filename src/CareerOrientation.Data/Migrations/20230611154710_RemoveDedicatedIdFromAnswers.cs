using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDedicatedIdFromAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_MultipleCho~",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_TrueFalseAnswerId",
                table: "UserTrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TrueFalseAnswers_QuestionId",
                table: "TrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropIndex(
                name: "IX_MultipleChoiceAnswers_QuestionId",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropColumn(
                name: "TrueFalseAnswerId",
                table: "TrueFalseAnswers");

            migrationBuilder.DropColumn(
                name: "MultipleChoiceAnswerId",
                table: "MultipleChoiceAnswers");

            migrationBuilder.RenameColumn(
                name: "TrueFalseAnswerId",
                table: "UserTrueFalseAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "MultipleChoiceAnswerId",
                table: "UserMultipleChoiceAnswers",
                newName: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers",
                column: "QuestionId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_QuestionId",
                table: "UserTrueFalseAnswers",
                column: "QuestionId",
                principalTable: "TrueFalseAnswers",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_QuestionId",
                table: "UserMultipleChoiceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_QuestionId",
                table: "UserTrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "UserTrueFalseAnswers",
                newName: "TrueFalseAnswerId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "UserMultipleChoiceAnswers",
                newName: "MultipleChoiceAnswerId");

            migrationBuilder.AddColumn<int>(
                name: "TrueFalseAnswerId",
                table: "TrueFalseAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "MultipleChoiceAnswerId",
                table: "MultipleChoiceAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueFalseAnswers",
                table: "TrueFalseAnswers",
                column: "TrueFalseAnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceAnswers",
                table: "MultipleChoiceAnswers",
                column: "MultipleChoiceAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueFalseAnswers_QuestionId",
                table: "TrueFalseAnswers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_QuestionId",
                table: "MultipleChoiceAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMultipleChoiceAnswers_MultipleChoiceAnswers_MultipleCho~",
                table: "UserMultipleChoiceAnswers",
                column: "MultipleChoiceAnswerId",
                principalTable: "MultipleChoiceAnswers",
                principalColumn: "MultipleChoiceAnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrueFalseAnswers_TrueFalseAnswers_TrueFalseAnswerId",
                table: "UserTrueFalseAnswers",
                column: "TrueFalseAnswerId",
                principalTable: "TrueFalseAnswers",
                principalColumn: "TrueFalseAnswerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
