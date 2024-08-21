using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedUserPromoCodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPromoCodes",
                table: "UserPromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_UserPromoCodes_UserId",
                table: "UserPromoCodes");

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPromoCodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPromoCodes",
                table: "UserPromoCodes",
                columns: new[] { "UserId", "PromoCodeId" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1348));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPromoCodes",
                table: "UserPromoCodes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPromoCodes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPromoCodes",
                table: "UserPromoCodes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Discount", "ExpiryDate", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "f51046", "kamran_superadmin", new DateTime(2024, 8, 21, 9, 17, 54, 99, DateTimeKind.Local).AddTicks(2460), 20.0, new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserPromoCodes_UserId",
                table: "UserPromoCodes",
                column: "UserId");
        }
    }
}
