using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareerOrientation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09ee559f-f86d-417c-8c55-abc0046a8816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "113b0e44-ee1b-4dc3-ba25-2393cec690a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9fa5f30-2881-44c6-b440-dac2a8965dd3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "207ba7ef-25df-4f1e-b04f-dff6e4910b60", "4ebd4127-cd04-44ad-b1f6-9f740a95c81e", "Student", "STUDENT" },
                    { "527fd383-52b2-4568-aba3-157f5256a103", "365a2d28-bff0-4d7b-a6bd-d1e4542e2d0c", "ProspectiveStudent", "PROSPECTIVESTUDENT" },
                    { "ff256579-11e1-4916-92c2-bd8623751707", "cb665326-a701-49a7-a799-4a8027d64074", "GraduateStudent", "GRADUATESTUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "MultipleChoiceAnswers",
                keyColumn: "MultipleChoiceAnswerId",
                keyValue: 52,
                column: "IsCorrect",
                value: true);

            migrationBuilder.UpdateData(
                table: "MultipleChoiceAnswers",
                keyColumn: "MultipleChoiceAnswerId",
                keyValue: 240,
                column: "IsCorrect",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "207ba7ef-25df-4f1e-b04f-dff6e4910b60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527fd383-52b2-4568-aba3-157f5256a103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff256579-11e1-4916-92c2-bd8623751707");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09ee559f-f86d-417c-8c55-abc0046a8816", "0d236b92-68ae-4a0a-baaf-5c7815893ce7", "ProspectiveStudent", "PROSPECTIVESTUDENT" },
                    { "113b0e44-ee1b-4dc3-ba25-2393cec690a2", "3815c6a7-54c9-4b60-8452-aa7aee35718c", "GraduateStudent", "GRADUATESTUDENT" },
                    { "d9fa5f30-2881-44c6-b440-dac2a8965dd3", "898d9d2b-cb7b-4647-aa56-0e08aced32c4", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "MultipleChoiceAnswers",
                keyColumn: "MultipleChoiceAnswerId",
                keyValue: 52,
                column: "IsCorrect",
                value: false);

            migrationBuilder.UpdateData(
                table: "MultipleChoiceAnswers",
                keyColumn: "MultipleChoiceAnswerId",
                keyValue: 240,
                column: "IsCorrect",
                value: false);
        }
    }
}
