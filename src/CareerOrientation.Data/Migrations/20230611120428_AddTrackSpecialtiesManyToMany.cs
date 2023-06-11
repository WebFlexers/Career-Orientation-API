using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackSpecialtiesManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "UniversityTests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "TrackMastersDegrees",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "integer", nullable: false),
                    MastersDegreeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackMastersDegrees", x => new { x.TrackId, x.MastersDegreeId });
                    table.ForeignKey(
                        name: "FK_TrackMastersDegrees_MastersDegrees_MastersDegreeId",
                        column: x => x.MastersDegreeId,
                        principalTable: "MastersDegrees",
                        principalColumn: "MastersDegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackMastersDegrees_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackProfessions",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "integer", nullable: false),
                    ProfessionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackProfessions", x => new { x.TrackId, x.ProfessionId });
                    table.ForeignKey(
                        name: "FK_TrackProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackProfessions_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackMastersDegrees_MastersDegreeId",
                table: "TrackMastersDegrees",
                column: "MastersDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackProfessions_ProfessionId",
                table: "TrackProfessions",
                column: "ProfessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackMastersDegrees");

            migrationBuilder.DropTable(
                name: "TrackProfessions");

            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "UniversityTests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
