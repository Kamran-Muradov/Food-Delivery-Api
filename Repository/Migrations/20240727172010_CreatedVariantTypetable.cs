using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedVariantTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "MenuVariants");

            migrationBuilder.AddColumn<int>(
                name: "VariantTypeId",
                table: "MenuVariants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VariantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuVariants_VariantTypeId",
                table: "MenuVariants",
                column: "VariantTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuVariants_VariantTypes_VariantTypeId",
                table: "MenuVariants",
                column: "VariantTypeId",
                principalTable: "VariantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuVariants_VariantTypes_VariantTypeId",
                table: "MenuVariants");

            migrationBuilder.DropTable(
                name: "VariantTypes");

            migrationBuilder.DropIndex(
                name: "IX_MenuVariants_VariantTypeId",
                table: "MenuVariants");

            migrationBuilder.DropColumn(
                name: "VariantTypeId",
                table: "MenuVariants");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MenuVariants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
