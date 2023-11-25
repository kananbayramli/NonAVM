using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Tag_and_Video_in_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Product");
        }
    }
}
