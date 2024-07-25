using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttributeValueModelAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_ProductAttributes_SpecificationAttributeId",
                table: "AttributeValues");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_SpecificationAttributeId",
                table: "AttributeValues");

            migrationBuilder.DeleteData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "SpecificationAttributeId",
                table: "AttributeValues");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Name", "Value" },
                values: new object[] { "Color", "Black" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Name", "Value" },
                values: new object[] { "Color", "White" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Name", "Value" },
                values: new object[] { "Size", "Small" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Name", "Value" },
                values: new object[] { "Size", "Medium" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Name", "Value" },
                values: new object[] { "Size", "Large" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AttributeValues");

            migrationBuilder.AddColumn<long>(
                name: "SpecificationAttributeId",
                table: "AttributeValues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "SpecificationAttributeId", "Value" },
                values: new object[] { 1L, "Red" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "SpecificationAttributeId", "Value" },
                values: new object[] { 1L, "Blue" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "SpecificationAttributeId", "Value" },
                values: new object[] { 1L, "Green" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "SpecificationAttributeId", "Value" },
                values: new object[] { 2L, "S" });

            migrationBuilder.UpdateData(
                table: "AttributeValues",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "SpecificationAttributeId", "Value" },
                values: new object[] { 2L, "M" });

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
                columns: new[] { "Id", "SpecificationAttributeId", "Value" },
                values: new object[] { 6L, 2L, "L" });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_SpecificationAttributeId",
                table: "AttributeValues",
                column: "SpecificationAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_ProductAttributes_SpecificationAttributeId",
                table: "AttributeValues",
                column: "SpecificationAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
