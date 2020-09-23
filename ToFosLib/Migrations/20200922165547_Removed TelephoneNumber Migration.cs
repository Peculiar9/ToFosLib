using Microsoft.EntityFrameworkCore.Migrations;

namespace ToFosLib.Migrations
{
    public partial class RemovedTelephoneNumberMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "LibraryBranches",
                newName: "Telephone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "LibraryBranches",
                newName: "TelephoneNumber");
        }
    }
}
