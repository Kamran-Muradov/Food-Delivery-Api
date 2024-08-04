using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class UpdatedRestaurantCategoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategories_Categories_CategoryId",
                table: "RestaurantCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                table: "RestaurantCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories");

            migrationBuilder.RenameTable(
                name: "RestaurantCategories",
                newName: "RestaurantTags");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "RestaurantTags",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantCategories_RestaurantId",
                table: "RestaurantTags",
                newName: "IX_RestaurantTags_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTags",
                table: "RestaurantTags",
                columns: new[] { "TagId", "RestaurantId" });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagImages_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 57, 54, 519, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 57, 54, 519, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 57, 54, 519, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 57, 54, 519, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.CreateIndex(
                name: "IX_TagImages_TagId",
                table: "TagImages",
                column: "TagId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTags_Restaurants_RestaurantId",
                table: "RestaurantTags",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTags_Tags_TagId",
                table: "RestaurantTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTags_Restaurants_RestaurantId",
                table: "RestaurantTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTags_Tags_TagId",
                table: "RestaurantTags");

            migrationBuilder.DropTable(
                name: "TagImages");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTags",
                table: "RestaurantTags");

            migrationBuilder.RenameTable(
                name: "RestaurantTags",
                newName: "RestaurantCategories");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "RestaurantCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantTags_RestaurantId",
                table: "RestaurantCategories",
                newName: "IX_RestaurantCategories_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantCategories",
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId" });

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 19, 20, 45, 204, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 19, 20, 45, 204, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 19, 20, 45, 204, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "VariantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 19, 20, 45, 204, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategories_Categories_CategoryId",
                table: "RestaurantCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCategories_Restaurants_RestaurantId",
                table: "RestaurantCategories",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
