using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Logo_in_Brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Brand");
        }
    }
}
