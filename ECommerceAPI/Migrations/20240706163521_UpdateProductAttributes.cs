using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_ProductAttributeId",
                table: "ProductAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_Products_ProductId",
                table: "ProductAttributeValues");

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeValues",
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

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductAttributeValues");

            migrationBuilder.RenameColumn(
                name: "ProductAttributeId",
                table: "ProductAttributeValues",
                newName: "AttributeValueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeValues_ProductAttributeId",
                table: "ProductAttributeValues",
                newName: "IX_ProductAttributeValues_AttributeValueId");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductAttributeValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductAttributeValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_ProductAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_AttributeValues_AttributeValueId",
                table: "ProductAttributeValues",
                column: "AttributeValueId",
                principalTable: "AttributeValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_Products_ProductId",
                table: "ProductAttributeValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_AttributeValues_AttributeValueId",
                table: "ProductAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValues_Products_ProductId",
                table: "ProductAttributeValues");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductAttributeValues");

            migrationBuilder.RenameColumn(
                name: "AttributeValueId",
                table: "ProductAttributeValues",
                newName: "ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeValues_AttributeValueId",
                table: "ProductAttributeValues",
                newName: "IX_ProductAttributeValues_ProductAttributeId");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductAttributeValues",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductAttributeValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Size" },
                    { 2L, "Color" }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributeValues",
                columns: new[] { "Id", "ProductAttributeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, null, "S" },
                    { 2L, 1L, null, "M" },
                    { 3L, 1L, null, "L" },
                    { 4L, 2L, null, "Red" },
                    { 5L, 2L, null, "Blue" },
                    { 6L, 2L, null, "Green" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_ProductAttributes_ProductAttributeId",
                table: "ProductAttributeValues",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValues_Products_ProductId",
                table: "ProductAttributeValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
