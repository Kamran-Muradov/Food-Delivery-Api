using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedCheckoutMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Menus_MenuId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_MenuId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Checkouts");

            migrationBuilder.CreateTable(
                name: "CheckoutMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutMenus_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 15, 10, 40, 142, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 15, 10, 40, 142, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 15, 10, 40, 142, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 15, 10, 40, 142, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 6, 15, 10, 40, 142, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutMenus_CheckoutId",
                table: "CheckoutMenus",
                column: "CheckoutId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutMenus_MenuId",
                table: "CheckoutMenus",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutMenus");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MenuId",
                table: "Checkouts",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Menus_MenuId",
                table: "Checkouts",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
