using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductEntryModelDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntries");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "ProductItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProductItems");

            migrationBuilder.CreateTable(
                name: "ProductEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemID = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntries_ProductItems_ProductItemID",
                        column: x => x.ProductItemID,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntries_ProductItemID",
                table: "ProductEntries",
                column: "ProductItemID");
        }
    }
}
