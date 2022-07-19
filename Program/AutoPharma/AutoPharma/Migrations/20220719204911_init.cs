using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPharma.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Cabinet = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Shelf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOHPrice = table.Column<double>(type: "float", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OurPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchMedicines_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchMedicines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "City", "Phone" },
                values: new object[,]
                {
                    { 1, "Amman Street", "Amman", "1000" },
                    { 2, "Irbid Street", "Irbid", "2000" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "BranchId", "Cabinet", "Shelf" },
                values: new object[,]
                {
                    { 1, 1, "A", 1 },
                    { 2, 1, "A", 2 },
                    { 3, 1, "A", 3 },
                    { 4, 2, "A", 1 },
                    { 5, 2, "A", 2 },
                    { 6, 2, "A", 3 }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Dose", "Information", "MOHPrice", "Name" },
                values: new object[,]
                {
                    { 1, "250", "This medicine is used as a painkiller", 3.5, "Panadol" },
                    { 2, "500", "This medicine is used as a antibiotic", 17.649999999999999, "Penicillin " }
                });

            migrationBuilder.InsertData(
                table: "BranchMedicines",
                columns: new[] { "Id", "BranchId", "Count", "LocationId", "MedicineId", "OurPrice" },
                values: new object[,]
                {
                    { 1, 1, 73, 1, 1, 3.75 },
                    { 2, 2, 120, 5, 1, 3.75 },
                    { 3, 1, 22, 3, 2, 18.449999999999999 },
                    { 4, 2, 17, 6, 2, 18.449999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchMedicines_BranchId",
                table: "BranchMedicines",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchMedicines_LocationId",
                table: "BranchMedicines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchMedicines_MedicineId",
                table: "BranchMedicines",
                column: "MedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchMedicines");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Medicines");
        }
    }
}
