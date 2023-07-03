using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixStatisticsUserRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId",
                unique: true);
        }
    }
}
