using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAttributesandValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_ProductAttributes_AttributeId",
                table: "AttributeValues");

            migrationBuilder.RenameColumn(
                name: "AttributeId",
                table: "AttributeValues",
                newName: "ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_ProductAttributeId");

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Color" },
                    { 2L, "Size" }
                });

            migrationBuilder.InsertData(
                table: "AttributeValues",
                columns: new[] { "Id", "ProductAttributeId", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, "Red" },
                    { 2L, 1L, "Blue" },
                    { 3L, 1L, "Green" },
                    { 4L, 2L, "S" },
                    { 5L, 2L, "M" },
                    { 6L, 2L, "L" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_ProductAttributes_ProductAttributeId",
                table: "AttributeValues",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_ProductAttributes_ProductAttributeId",
                table: "AttributeValues");

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "ProductAttributeId",
                table: "AttributeValues",
                newName: "AttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_ProductAttributeId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_ProductAttributes_AttributeId",
                table: "AttributeValues",
                column: "AttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
