using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedCreatedByUpdateByColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VariantTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "VariantTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TagImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TagImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SliderImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SliderImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RestaurantTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "RestaurantTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RestaurantImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "RestaurantImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MenuVariants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MenuVariants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MenuIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MenuIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MenuImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MenuImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CheckoutMenus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CheckoutMenus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CategoryImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CategoryImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BrandLogo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BrandLogo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BasketVariants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BasketVariants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 17, 32, 23, 139, DateTimeKind.Local).AddTicks(4261));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VariantTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "VariantTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TagImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TagImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SliderImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SliderImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RestaurantTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RestaurantTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RestaurantImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RestaurantImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MenuVariants");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MenuVariants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MenuIngredients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MenuIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MenuImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MenuImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CheckoutMenus");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CheckoutMenus");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoryImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CategoryImages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BrandLogo");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BrandLogo");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BasketVariants");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BasketVariants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BasketItems");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 29, 23, 257, DateTimeKind.Local).AddTicks(8086));
        }
    }
}
