using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedBasketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuVariants",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 34, 57, 110, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 34, 57, 110, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 34, 57, 110, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 34, 57, 110, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 34, 57, 110, DateTimeKind.Local).AddTicks(6687));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuVariants",
                table: "BasketItems");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 13, 54, 42, 761, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 13, 54, 42, 761, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 13, 54, 42, 761, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 13, 54, 42, 761, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 13, 54, 42, 761, DateTimeKind.Local).AddTicks(4548));
        }
    }
}
