using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SKU_String : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandCategory_Brand_BrandsId",
                table: "BrandCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stores_StoreID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Product_ProductID",
                table: "ProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Product_ProductID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Product_ProductID",
                table: "ProductReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Product_StoreID",
                table: "Products",
                newName: "IX_Products_StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Name",
                table: "Products",
                newName: "IX_Products_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Description",
                table: "Products",
                newName: "IX_Products_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Products",
                newName: "IX_Products_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandID",
                table: "Products",
                newName: "IX_Products_BrandID");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandCategory_Brands_BrandsId",
                table: "BrandCategory",
                column: "BrandsId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Products_ProductID",
                table: "ProductDiscounts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Products_ProductID",
                table: "ProductItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductID",
                table: "ProductReviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreID",
                table: "Products",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandCategory_Brands_BrandsId",
                table: "BrandCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Products_ProductID",
                table: "ProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Products_ProductID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductID",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StoreID",
                table: "Product",
                newName: "IX_Product_StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Name",
                table: "Product",
                newName: "IX_Product_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Description",
                table: "Product",
                newName: "IX_Product_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandID",
                table: "Product",
                newName: "IX_Product_BrandID");

            migrationBuilder.AlterColumn<int>(
                name: "SKU",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandCategory_Brand_BrandsId",
                table: "BrandCategory",
                column: "BrandsId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandID",
                table: "Product",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stores_StoreID",
                table: "Product",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Product_ProductID",
                table: "ProductDiscounts",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Product_ProductID",
                table: "ProductItems",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Product_ProductID",
                table: "ProductReviews",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
