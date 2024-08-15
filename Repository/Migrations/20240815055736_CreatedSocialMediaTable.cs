using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedSocialMediaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Key", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(699), "Address", null, null, "28 May" },
                    { 2, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(700), "Phone", null, null, "+9945556622" },
                    { 3, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(702), "Email", null, null, "company@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Platform", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(712), "Linkedin", null, null, "linkedin.com" },
                    { 2, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(713), "Instagram", null, null, "instagram.com" },
                    { 3, null, new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(714), "facebook", null, null, "facebook.com" }
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 15, 9, 57, 35, 667, DateTimeKind.Local).AddTicks(595));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedia");

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

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 19, 14, 31, 146, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 19, 14, 31, 146, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 19, 14, 31, 146, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 19, 14, 31, 146, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 19, 14, 31, 146, DateTimeKind.Local).AddTicks(627));
        }
    }
}
