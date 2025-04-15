using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class Migyeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "PracticeAreas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticeAreas_AreaID",
                table: "PracticeAreas",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeAreas_Areas_AreaID",
                table: "PracticeAreas",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_Areas_AreaID",
                table: "PracticeAreas");

            migrationBuilder.DropIndex(
                name: "IX_PracticeAreas_AreaID",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "PracticeAreas");
        }
    }
}
