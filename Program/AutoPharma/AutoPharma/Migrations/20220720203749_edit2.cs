using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPharma.Migrations
{
    public partial class edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amman" },
                    { 12, "Ajloun" },
                    { 11, "Al-Karak" },
                    { 9, "Ma'an" },
                    { 8, "Jerash" },
                    { 7, "Mafraq" },
                    { 10, "Al-Tafila" },
                    { 5, "Maadaba" },
                    { 4, "Aqaba" },
                    { 3, "Irbid" },
                    { 2, "Zarqa" },
                    { 6, "Al-Balqaa" }
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
                table: "Branches",
                columns: new[] { "Id", "Address", "Phone", "cityId", "cityName" },
                values: new object[] { 1, "Amman Street", "1000", 1, null });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "Phone", "cityId", "cityName" },
                values: new object[] { 2, "Irbid Street", "2000", 3, null });

            migrationBuilder.InsertData(
                table: "BranchMedicines",
                columns: new[] { "Id", "BranchId", "Count", "LocationId", "MedicineId", "OurPrice" },
                values: new object[,]
                {
                    { 1, 1, 73, 1, 1, 3.75 },
                    { 3, 1, 22, 3, 2, 18.449999999999999 },
                    { 2, 2, 120, 5, 1, 3.75 },
                    { 4, 2, 17, 6, 2, 18.449999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_cityId",
                table: "Branches",
                column: "cityId");

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

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
