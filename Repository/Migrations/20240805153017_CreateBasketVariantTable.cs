using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateBasketVariantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuVariants",
                table: "BasketItems");

            migrationBuilder.CreateTable(
                name: "BasketVariant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketVariant_BasketItems_BasketItemId",
                        column: x => x.BasketItemId,
                        principalTable: "BasketItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 30, 16, 782, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 30, 16, 782, DateTimeKind.Local).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 30, 16, 782, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 30, 16, 782, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 30, 16, 782, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.CreateIndex(
                name: "IX_BasketVariant_BasketItemId",
                table: "BasketVariant",
                column: "BasketItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketVariant");

            migrationBuilder.AddColumn<string>(
                name: "MenuVariants",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 17, 49, 41, 646, DateTimeKind.Local).AddTicks(5582));
        }
    }
}
