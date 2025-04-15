using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class Migdenemeeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.DropIndex(
                name: "IX_PracticeAreas_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "LawTypesID",
                table: "PracticeAreas");
        }
    }
}
