using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DeletedMinOrderColumnRestaurantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "MinimumOrder",
                table: "Restaurants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MinimumOrder",
                table: "Restaurants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Key", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1435), "Address", null, null, "28 May" },
                    { 2, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1437), "Phone", null, null, "+9945556622" },
                    { 3, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1439), "Email", null, null, "company@gmail.com" },
                    { 4, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1440), "Logo", null, null, "https://res.cloudinary.com/duta72kmn/image/upload/v1723783223/Pngtree_food_delivery_logo_design_5392527_mmnqhk.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Platform", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1449), "Linkedin", null, null, "linkedin.com" },
                    { 2, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1450), "Instagram", null, null, "instagram.com" },
                    { 3, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1451), "facebook", null, null, "facebook.com" }
                });

            migrationBuilder.InsertData(
                table: "VariantTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1344), "Size choice", null, null },
                    { 2, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1345), "Sauce choice", null, null },
                    { 3, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1347), "Drink choice", null, null },
                    { 4, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1348), "Crust choice", null, null },
                    { 5, null, new DateTime(2024, 8, 21, 9, 37, 56, 964, DateTimeKind.Local).AddTicks(1348), "Additional ingredients", null, null }
                });
        }
    }
}
