using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_ProductAttributes_ProductAttributeId",
                table: "AttributeValues");

            migrationBuilder.RenameColumn(
                name: "ProductAttributeId",
                table: "AttributeValues",
                newName: "SpecificationAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_ProductAttributeId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_SpecificationAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_ProductAttributes_SpecificationAttributeId",
                table: "AttributeValues",
                column: "SpecificationAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_ProductAttributes_SpecificationAttributeId",
                table: "AttributeValues");

            migrationBuilder.RenameColumn(
                name: "SpecificationAttributeId",
                table: "AttributeValues",
                newName: "ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValues_SpecificationAttributeId",
                table: "AttributeValues",
                newName: "IX_AttributeValues_ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_ProductAttributes_ProductAttributeId",
                table: "AttributeValues",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
