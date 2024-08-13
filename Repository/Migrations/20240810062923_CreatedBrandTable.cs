using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RestaurantImages");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RestaurantImages");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandLogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandLogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandLogo_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_BrandId",
                table: "Restaurants",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandLogo_BrandId",
                table: "BrandLogo",
                column: "BrandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Brand_BrandId",
                table: "Restaurants",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Brand_BrandId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "BrandLogo");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_BrandId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Restaurants");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RestaurantImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RestaurantImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 23, 12, 1, 764, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 23, 12, 1, 764, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 23, 12, 1, 764, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 23, 12, 1, 764, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 23, 12, 1, 764, DateTimeKind.Local).AddTicks(4093));
        }
    }
}
