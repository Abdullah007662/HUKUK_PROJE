using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class Migpraticaareass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignatureUrl",
                table: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "VarChar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Abouts",
                type: "VarChar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Abouts",
                type: "VarChar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PracticeAreas",
                columns: table => new
                {
                    PracticeAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "VarChar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "VarChar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "VarChar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeAreas", x => x.PracticeAreaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PracticeAreas");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Abouts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "VarChar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Abouts",
                type: "VarChar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureUrl",
                table: "Abouts",
                type: "VarChar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
