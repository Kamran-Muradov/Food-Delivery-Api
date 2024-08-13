using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Checkouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 11, 20, 40, 19, 15, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 11, 20, 40, 19, 15, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 11, 20, 40, 19, 15, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 11, 20, 40, 19, 15, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 11, 20, 40, 19, 15, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_RestaurantId",
                table: "Checkouts",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CheckoutId",
                table: "Reviews",
                column: "CheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Restaurants_RestaurantId",
                table: "Checkouts",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Restaurants_RestaurantId",
                table: "Checkouts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_RestaurantId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Checkouts");

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 22, 10, 31, 166, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 22, 10, 31, 166, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 22, 10, 31, 166, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 22, 10, 31, 166, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 22, 10, 31, 166, DateTimeKind.Local).AddTicks(4858));
        }
    }
}
