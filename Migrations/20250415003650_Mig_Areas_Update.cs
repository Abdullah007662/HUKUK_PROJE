using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class MigAreasUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.DropIndex(
                name: "IX_PracticeAreas_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "LawTypesID",
                table: "PracticeAreas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "PracticeAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "PracticeAreas",
                type: "VarChar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LawTypesID",
                table: "PracticeAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticeAreas_LawTypesID",
                table: "PracticeAreas",
                column: "LawTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID");
        }
    }
}
