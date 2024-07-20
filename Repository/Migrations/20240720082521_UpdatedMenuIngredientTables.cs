using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedMenuIngredientTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuIngredients",
                table: "MenuIngredients");

            migrationBuilder.DropIndex(
                name: "IX_MenuIngredients_IngredientId",
                table: "MenuIngredients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenuIngredients");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MenuIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuIngredients",
                table: "MenuIngredients",
                columns: new[] { "IngredientId", "MenuId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuIngredients",
                table: "MenuIngredients");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MenuIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MenuIngredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuIngredients",
                table: "MenuIngredients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuIngredients_IngredientId",
                table: "MenuIngredients",
                column: "IngredientId");
        }
    }
}
