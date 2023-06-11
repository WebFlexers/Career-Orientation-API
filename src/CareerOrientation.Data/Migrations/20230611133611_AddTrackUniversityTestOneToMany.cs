using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackUniversityTestOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "UniversityTests",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTests_TrackId",
                table: "UniversityTests",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityTests_Tracks_TrackId",
                table: "UniversityTests",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniversityTests_Tracks_TrackId",
                table: "UniversityTests");

            migrationBuilder.DropIndex(
                name: "IX_UniversityTests_TrackId",
                table: "UniversityTests");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "UniversityTests");
        }
    }
}
