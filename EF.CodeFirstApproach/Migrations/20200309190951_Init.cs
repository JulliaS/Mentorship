using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.CodeFirstApproach.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Instruction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyNetworkId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyAddresses_PharmacyNetworks_PharmacyNetworkId",
                        column: x => x.PharmacyNetworkId,
                        principalTable: "PharmacyNetworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyAddressId = table.Column<int>(nullable: false),
                    MedicineId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinePrices_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrices_PharmacyAddresses_PharmacyAddressId",
                        column: x => x.PharmacyAddressId,
                        principalTable: "PharmacyAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrices_MedicineId",
                table: "MedicinePrices",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrices_PharmacyAddressId",
                table: "MedicinePrices",
                column: "PharmacyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyAddresses_PharmacyNetworkId",
                table: "PharmacyAddresses",
                column: "PharmacyNetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinePrices");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "PharmacyAddresses");

            migrationBuilder.DropTable(
                name: "PharmacyNetworks");
        }
    }
}
