using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionsToLikertScale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_QuestionLikertScaleAnswers_LikertScaleAnswersId",
                table: "QuestionLikertScaleAnswers",
                column: "LikertScaleAnswersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionLikertScaleAnswers");

            migrationBuilder.DropTable(
                name: "LikertScaleAnswers");
        }
    }
}
