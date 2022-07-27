using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPharma.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MOHPrice = table.Column<double>(type: "float", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacistUserDTO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacistUserDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    { 10, "Al-Tafila" },
                    { 9, "Ma'an" },
                    { 8, "Jerash" },
                    { 7, "Mafraq" },
                    { 11, "Al-Karak" },
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
                    { 12, 2, "A", 2 },
                    { 20, 2, "B", 5 },
                    { 19, 2, "B", 4 },
                    { 18, 2, "B", 3 },
                    { 17, 2, "B", 2 },
                    { 16, 2, "B", 1 },
                    { 15, 2, "A", 5 },
                    { 14, 2, "A", 4 },
                    { 13, 2, "A", 3 },
                    { 11, 2, "A", 1 },
                    { 9, 1, "B", 4 },
                    { 1, 1, "A", 1 },
                    { 8, 1, "B", 3 },
                    { 7, 1, "B", 2 },
                    { 6, 1, "B", 1 },
                    { 5, 1, "A", 5 },
                    { 4, 1, "A", 4 },
                    { 3, 1, "A", 3 },
                    { 2, 1, "A", 2 },
                    { 10, 1, "B", 5 }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Dose", "ExpiredDate", "ImageUri", "Information", "MOHPrice", "Name" },
                values: new object[,]
                {
                    { 7, "250", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/cyclease.jpg", "This medicine is used for cramps", 4.7000000000000002, "cyclease" },
                    { 6, "500", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/Alvedon.jpg", "This medicine is used as a antipyretic", 2.6000000000000001, "Alvedon" },
                    { 5, "200", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/Zithrokan.jpg", "This medicine is used as a Antibiotics", 1.2, "Zithrokan" },
                    { 8, "400", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/DAYQUIL1.jpg", "This medicine is used for cold", 1.1000000000000001, "DAYQUIL" },
                    { 3, "180", new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/FEXON.jpg", "This medicine is used as a Anti-allergic", 4.9500000000000002, "FEXON" },
                    { 2, "500", new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/Penicillin.jpg", "This medicine is used as a antibiotic", 17.649999999999999, "Penicillin " },
                    { 1, "250", new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/panadol.jpg", "This medicine is used as a painkiller", 3.5, "Panadol" },
                    { 4, "220", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/DIAXSUSP.jpg", "This medicine is used as a 	Intestinal antiseptic", 6.9500000000000002, "DIAX SUSP" },
                    { 9, "200", new DateTime(2027, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://autopharmafinal.blob.core.windows.net/images/Excedrin.jpg", "This medicine is used for headache", 9.8000000000000007, "Excedrin" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CityId", "Phone" },
                values: new object[,]
                {
                    { 1, "Amman Street", 1, "1000" },
                    { 2, "Abdon", 1, "1200" },
                    { 3, "Marka", 1, "1300" },
                    { 4, "Sweleh", 1, "1400" },
                    { 5, "Al-sabea", 1, "1500" },
                    { 6, "Al-thamin", 1, "1600" },
                    { 7, "Irbid Street", 3, "2100" },
                    { 8, "Albalad", 3, "2200" },
                    { 9, "AL-ramtha", 3, "2300" },
                    { 10, "Sal", 3, "2400" },
                    { 11, "Irbid Street", 3, "2500" }
                });

            migrationBuilder.InsertData(
                table: "BranchMedicines",
                columns: new[] { "Id", "BranchId", "Count", "LocationId", "MedicineId", "OurPrice" },
                values: new object[,]
                {
                    { 1, 1, 73, 1, 1, 3.75 },
                    { 12, 4, 55, 6, 8, 1.1000000000000001 },
                    { 18, 4, 56, 4, 7, 4.7000000000000002 },
                    { 24, 4, 53, 2, 5, 1.6000000000000001 },
                    { 28, 4, 74, 8, 5, 1.6000000000000001 },
                    { 32, 4, 2, 2, 4, 6.9500000000000002 },
                    { 37, 4, 183, 3, 2, 17.649999999999999 },
                    { 8, 5, 73, 8, 9, 9.8000000000000007 },
                    { 27, 5, 62, 6, 5, 1.6000000000000001 },
                    { 5, 4, 55, 5, 3, 4.9500000000000002 },
                    { 40, 5, 12, 6, 2, 17.649999999999999 },
                    { 42, 6, 14, 8, 2, 17.649999999999999 },
                    { 14, 7, 44, 3, 8, 1.1000000000000001 },
                    { 21, 7, 3, 8, 6, 2.6000000000000001 },
                    { 22, 8, 6, 2, 6, 2.6000000000000001 },
                    { 43, 8, 2, 9, 2, 17.649999999999999 },
                    { 10, 9, 13, 9, 9, 9.8000000000000007 },
                    { 44, 9, 6, 10, 2, 17.649999999999999 },
                    { 7, 11, 53, 1, 9, 9.8000000000000007 },
                    { 16, 6, 88, 2, 7, 4.7000000000000002 },
                    { 41, 3, 14, 7, 2, 17.649999999999999 },
                    { 34, 3, 9, 7, 4, 6.9500000000000002 },
                    { 26, 3, 66, 5, 5, 1.6000000000000001 },
                    { 3, 1, 99, 6, 3, 4.9500000000000002 },
                    { 6, 1, 85, 2, 3, 4.9500000000000002 },
                    { 11, 1, 73, 1, 8, 1.1000000000000001 },
                    { 15, 1, 76, 1, 7, 4.7000000000000002 },
                    { 19, 1, 44, 1, 6, 2.6000000000000001 },
                    { 23, 1, 99, 1, 5, 1.6000000000000001 },
                    { 29, 1, 7, 1, 4, 6.9500000000000002 },
                    { 35, 1, 7, 1, 2, 17.649999999999999 },
                    { 39, 1, 6, 5, 2, 17.649999999999999 },
                    { 2, 2, 120, 5, 1, 3.75 },
                    { 4, 2, 55, 2, 3, 4.9500000000000002 },
                    { 13, 2, 66, 5, 8, 1.1000000000000001 },
                    { 20, 2, 85, 6, 6, 2.6000000000000001 },
                    { 25, 2, 44, 3, 5, 1.6000000000000001 },
                    { 31, 2, 5, 3, 4, 6.9500000000000002 },
                    { 33, 2, 8, 3, 4, 6.9500000000000002 },
                    { 36, 2, 5, 2, 2, 17.649999999999999 },
                    { 9, 3, 76, 4, 9, 9.8000000000000007 },
                    { 17, 3, 63, 3, 7, 4.7000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "BranchMedicines",
                columns: new[] { "Id", "BranchId", "Count", "LocationId", "MedicineId", "OurPrice" },
                values: new object[] { 30, 11, 8, 2, 4, 6.9500000000000002 });

            migrationBuilder.InsertData(
                table: "BranchMedicines",
                columns: new[] { "Id", "BranchId", "Count", "LocationId", "MedicineId", "OurPrice" },
                values: new object[] { 38, 11, 3, 4, 2, 17.649999999999999 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityId",
                table: "Branches",
                column: "CityId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BranchMedicines");

            migrationBuilder.DropTable(
                name: "PharmacistUserDTO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
