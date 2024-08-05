using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateBasketVariantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketVariant_BasketItems_BasketItemId",
                table: "BasketVariant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketVariant",
                table: "BasketVariant");

            migrationBuilder.RenameTable(
                name: "BasketVariant",
                newName: "BasketVariants");

            migrationBuilder.RenameIndex(
                name: "IX_BasketVariant_BasketItemId",
                table: "BasketVariants",
                newName: "IX_BasketVariants_BasketItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketVariants",
                table: "BasketVariants",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 32, 2, 386, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 32, 2, 386, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 32, 2, 386, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 32, 2, 386, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 19, 32, 2, 386, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.AddForeignKey(
                name: "FK_BasketVariants_BasketItems_BasketItemId",
                table: "BasketVariants",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketVariants_BasketItems_BasketItemId",
                table: "BasketVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketVariants",
                table: "BasketVariants");

            migrationBuilder.RenameTable(
                name: "BasketVariants",
                newName: "BasketVariant");

            migrationBuilder.RenameIndex(
                name: "IX_BasketVariants_BasketItemId",
                table: "BasketVariant",
                newName: "IX_BasketVariant_BasketItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketVariant",
                table: "BasketVariant",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasketVariant_BasketItems_BasketItemId",
                table: "BasketVariant",
                column: "BasketItemId",
                principalTable: "BasketItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
