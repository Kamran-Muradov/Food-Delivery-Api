using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedDiscountPriceColumbBasketItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "BasketItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedDate" },
                values: new object[] { "21ae97", new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(934));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 15, 0, 203, DateTimeKind.Local).AddTicks(826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "BasketItems");

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedDate" },
                values: new object[] { "557d39", new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9640));
        }
    }
}
