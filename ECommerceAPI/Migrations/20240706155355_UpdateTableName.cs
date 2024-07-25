using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_CategoryAttributes_ProductAttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttributes",
                table: "CategoryAttributes");

            migrationBuilder.RenameTable(
                name: "CategoryAttributes",
                newName: "ProductAttributes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_ProductAttributeId",
                table: "ProductAttributeValues",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_ProductAttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributes",
                table: "ProductAttributes");

            migrationBuilder.RenameTable(
                name: "ProductAttributes",
                newName: "CategoryAttributes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttributes",
                table: "CategoryAttributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_CategoryAttributes_ProductAttributeId",
                table: "ProductAttributeValues",
                column: "ProductAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
