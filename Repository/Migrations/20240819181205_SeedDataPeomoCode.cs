using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SeedDataPeomoCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Discount", "ExpiryDate", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "557d39", "kamran_superadmin", new DateTime(2024, 8, 19, 22, 12, 5, 452, DateTimeKind.Local).AddTicks(9845), 20.0, new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 23, 19, 18, 711, DateTimeKind.Local).AddTicks(8211));
        }
    }
}
