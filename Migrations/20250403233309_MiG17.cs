using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    /// <inheritdoc />
    public partial class MiG17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LawTypeID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LawTypesID",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LawTypesID",
                table: "Contacts",
                column: "LawTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_LawTypes_LawTypesID",
                table: "Contacts",
                column: "LawTypesID",
                principalTable: "LawTypes",
                principalColumn: "LawTypesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_LawTypes_LawTypesID",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LawTypesID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LawTypeID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LawTypesID",
                table: "Contacts");
        }
    }
}
