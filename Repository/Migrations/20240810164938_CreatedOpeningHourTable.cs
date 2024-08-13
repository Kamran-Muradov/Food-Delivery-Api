using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedOpeningHourTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandLogo_Brand_BrandId",
                table: "BrandLogo");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Brand_BrandId",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandLogo",
                table: "BrandLogo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "BrandLogo",
                newName: "BrandLogos");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_BrandLogo_BrandId",
                table: "BrandLogos",
                newName: "IX_BrandLogos_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandLogos",
                table: "BrandLogos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningHours_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 20, 49, 37, 536, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 20, 49, 37, 536, DateTimeKind.Local).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 20, 49, 37, 536, DateTimeKind.Local).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 20, 49, 37, 536, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 20, 49, 37, 536, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.CreateIndex(
                name: "IX_OpeningHours_RestaurantId",
                table: "OpeningHours",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandLogos_Brands_BrandId",
                table: "BrandLogos",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Brands_BrandId",
                table: "Restaurants",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandLogos_Brands_BrandId",
                table: "BrandLogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Brands_BrandId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandLogos",
                table: "BrandLogos");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameTable(
                name: "BrandLogos",
                newName: "BrandLogo");

            migrationBuilder.RenameIndex(
                name: "IX_BrandLogos_BrandId",
                table: "BrandLogo",
                newName: "IX_BrandLogo_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandLogo",
                table: "BrandLogo",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.AddForeignKey(
                name: "FK_BrandLogo_Brand_BrandId",
                table: "BrandLogo",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Brand_BrandId",
                table: "Restaurants",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }
    }
}
