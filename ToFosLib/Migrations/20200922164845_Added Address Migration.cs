using Microsoft.EntityFrameworkCore.Migrations;

namespace ToFosLib.Migrations
{
    public partial class AddedAddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "LibraryBranches",
                newName: "TelephoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patrons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "LibraryBranches",
                newName: "Telephone");
        }
    }
}
