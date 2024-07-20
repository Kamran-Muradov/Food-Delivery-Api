using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedPivotTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCategories_CategoryId",
                table: "RestaurantCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategories_CategoryId",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RestaurantCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RestaurantCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenuCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MenuCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories",
                columns: new[] { "CategoryId", "MenuId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RestaurantCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RestaurantCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MenuCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MenuCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategories_CategoryId",
                table: "RestaurantCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_CategoryId",
                table: "MenuCategories",
                column: "CategoryId");
        }
    }
}
