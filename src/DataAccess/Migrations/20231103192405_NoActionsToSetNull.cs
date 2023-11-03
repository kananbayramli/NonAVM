using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NoActionsToSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_ProductItems_ProductItemID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductItems_ProductItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Baskets_BasketID",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_BasketID",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductItemID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "ProductItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductItemID",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProductItemName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductItemID",
                table: "OrderDetails",
                column: "ProductItemID",
                unique: true,
                filter: "[ProductItemID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_ProductItems_ProductItemID",
                table: "BasketItems",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductItems_ProductItemID",
                table: "OrderDetails",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressID",
                table: "Orders",
                column: "ShippingAddressID",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "Shippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_ProductItems_ProductItemID",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductItems_ProductItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductItemID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductItemName",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "BasketID",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductItemID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_BasketID",
                table: "ProductItems",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductItemID",
                table: "OrderDetails",
                column: "ProductItemID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_BasketID",
                table: "BasketItems",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_ProductItems_ProductItemID",
                table: "BasketItems",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductItems_ProductItemID",
                table: "OrderDetails",
                column: "ProductItemID",
                principalTable: "ProductItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressID",
                table: "Orders",
                column: "ShippingAddressID",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingID",
                table: "Orders",
                column: "ShippingID",
                principalTable: "Shippings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Baskets_BasketID",
                table: "ProductItems",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
