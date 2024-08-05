using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedBasketItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MenuVariants",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5582));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MenuVariants",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
