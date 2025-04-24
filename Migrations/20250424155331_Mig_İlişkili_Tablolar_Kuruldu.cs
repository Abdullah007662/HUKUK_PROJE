using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class MigİlişkiliTablolarKuruldu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_LawTypes_LawTypesID",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.AlterColumn<int>(
                name: "LawTypesID",
                table: "PracticeAreas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "PracticeAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LawTypesID",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Denemes",
                columns: table => new
                {
                    DenemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denemes", x => x.DenemeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PracticeAreas_AreaID",
                table: "PracticeAreas",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_LawTypes_LawTypesID",
                table: "Areas",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeAreas_Areas_AreaID",
                table: "PracticeAreas",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_LawTypes_LawTypesID",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_Areas_AreaID",
                table: "PracticeAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas");

            migrationBuilder.DropTable(
                name: "Denemes");

            migrationBuilder.DropIndex(
                name: "IX_PracticeAreas_AreaID",
                table: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "PracticeAreas");

            migrationBuilder.AlterColumn<int>(
                name: "LawTypesID",
                table: "PracticeAreas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LawTypesID",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_LawTypes_LawTypesID",
                table: "Areas",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeAreas_LawTypes_LawTypesID",
                table: "PracticeAreas",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
