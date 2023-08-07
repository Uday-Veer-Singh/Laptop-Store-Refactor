using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopNumber);
                });

            migrationBuilder.CreateTable(
                name: "StoreLocations",
                columns: table => new
                {
                    StoreNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocations", x => x.StoreNumber);
                });

            migrationBuilder.CreateTable(
                name: "LaptopStore",
                columns: table => new
                {
                    LaptopStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaptopNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopStore", x => x.LaptopStoreId);
                    table.ForeignKey(
                        name: "FK_LaptopStore_Laptops_LaptopNumber",
                        column: x => x.LaptopNumber,
                        principalTable: "Laptops",
                        principalColumn: "LaptopNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaptopStore_StoreLocations_StoreNumber",
                        column: x => x.StoreNumber,
                        principalTable: "StoreLocations",
                        principalColumn: "StoreNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaptopStore_LaptopNumber",
                table: "LaptopStore",
                column: "LaptopNumber");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopStore_StoreNumber",
                table: "LaptopStore",
                column: "StoreNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "LaptopStore");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "StoreLocations");
        }
    }
}
