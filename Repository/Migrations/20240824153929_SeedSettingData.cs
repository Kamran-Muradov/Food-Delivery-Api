using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SeedSettingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Key", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, "kamran_superadmin", new DateTime(2024, 8, 24, 19, 39, 29, 508, DateTimeKind.Local).AddTicks(294), "Address", null, null, "28 May" },
                    { 2, "kamran_superadmin", new DateTime(2024, 8, 24, 19, 39, 29, 508, DateTimeKind.Local).AddTicks(296), "Phone", null, null, "+9945556622" },
                    { 3, "kamran_superadmin", new DateTime(2024, 8, 24, 19, 39, 29, 508, DateTimeKind.Local).AddTicks(297), "Email", null, null, "company@gmail.com" },
                    { 4, "kamran_superadmin", new DateTime(2024, 8, 24, 19, 39, 29, 508, DateTimeKind.Local).AddTicks(298), "Logo", null, null, "https://res.cloudinary.com/duta72kmn/image/upload/v1723800374/pngwing.com_prtuvw.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
