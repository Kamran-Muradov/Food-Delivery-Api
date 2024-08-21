using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangedColumnNameUserPromoCodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserPromoCodes",
                newName: "IsUsed");

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedDate" },
                values: new object[] { "f51046", new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2294));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "UserPromoCodes",
                newName: "IsActive");

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
    }
}
