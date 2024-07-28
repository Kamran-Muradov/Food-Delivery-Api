using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedDataVariantTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VariantTypes",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 21, 27, 51, 979, DateTimeKind.Local).AddTicks(8311), "Size", null },
                    { 2, new DateTime(2024, 7, 27, 21, 27, 51, 979, DateTimeKind.Local).AddTicks(8313), "Sauce", null },
                    { 3, new DateTime(2024, 7, 27, 21, 27, 51, 979, DateTimeKind.Local).AddTicks(8314), "Drink", null },
                    { 4, new DateTime(2024, 7, 27, 21, 27, 51, 979, DateTimeKind.Local).AddTicks(8315), "Crust", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
