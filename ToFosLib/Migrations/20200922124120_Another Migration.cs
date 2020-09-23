using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToFosLib.Migrations
{
    public partial class AnotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fees = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpenTIme = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibraryBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeweyIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_LibraryBranches_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibraryCardId = table.Column<int>(type: "int", nullable: true),
                    HomeLibraryBranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrons_LibraryBranches_HomeLibraryBranchId",
                        column: x => x.HomeLibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patrons_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryBranchId = table.Column<int>(type: "int", nullable: true),
                    CheckedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedOut = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryAssets_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryBranches_LibraryBranchId",
                        column: x => x.LibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryBranchId = table.Column<int>(type: "int", nullable: true),
                    Since = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Until = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibraryCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryAssets_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryBranches_LibraryBranchId",
                        column: x => x.LibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryBranchId = table.Column<int>(type: "int", nullable: true),
                    HoldPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryAssets_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryBranches_LibraryBranchId",
                        column: x => x.LibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryAssetId",
                table: "CheckoutHistories",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryBranchId",
                table: "CheckoutHistories",
                column: "LibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryAssetId",
                table: "Checkouts",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryBranchId",
                table: "Checkouts",
                column: "LibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryCardId",
                table: "Checkouts",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryAssetId",
                table: "Holds",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryBranchId",
                table: "Holds",
                column: "LibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_LocationId",
                table: "LibraryAssets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_HomeLibraryBranchId",
                table: "Patrons",
                column: "HomeLibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "LibraryAssets");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryBranches");
        }
    }
}
