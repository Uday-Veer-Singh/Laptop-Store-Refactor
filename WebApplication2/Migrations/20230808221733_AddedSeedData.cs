using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "StoreLocations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreLocations",
                newName: "StreetName");

            migrationBuilder.AddColumn<int>(
                name: "Province",
                table: "StoreLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "StoreLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "LaptopStore",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Laptops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Brands_BrandId",
                table: "Laptops",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Brands_BrandId",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "StoreLocations");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "StoreLocations");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "LaptopStore");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "StoreLocations",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StoreLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
