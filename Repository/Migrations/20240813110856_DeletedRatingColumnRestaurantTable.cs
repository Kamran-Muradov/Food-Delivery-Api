using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DeletedRatingColumnRestaurantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_CheckoutId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 13, 15, 8, 56, 192, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 13, 15, 8, 56, 192, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 13, 15, 8, 56, 192, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 13, 15, 8, 56, 192, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 13, 15, 8, 56, 192, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CheckoutId",
                table: "Reviews",
                column: "CheckoutId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_CheckoutId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 12, 11, 26, 54, 241, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 12, 11, 26, 54, 241, DateTimeKind.Local).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 12, 11, 26, 54, 241, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 12, 11, 26, 54, 241, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 12, 11, 26, 54, 241, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CheckoutId",
                table: "Reviews",
                column: "CheckoutId");
        }
    }
}
