using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class MiG11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawTypes",
                columns: table => new
                {
                    LawTypesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "VarChar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawTypes", x => x.LawTypesID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawTypes");
        }
    }
}
