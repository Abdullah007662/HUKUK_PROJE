using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class MigSmallTitleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SmallTitle",
                table: "Blogs",
                type: "VarChar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SmallTitle",
                table: "Blogs",
                type: "VarChar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VarChar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
