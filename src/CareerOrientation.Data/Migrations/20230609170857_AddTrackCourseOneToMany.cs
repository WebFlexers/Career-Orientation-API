using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackCourseOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_TrackId",
                table: "Course",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Tracks_TrackId",
                table: "Course",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Tracks_TrackId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TrackId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Course");
        }
    }
}
