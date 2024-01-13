﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Logo_CreatedDate_to_Store : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Stores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StoreLogo",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreLogo",
                table: "Stores");
        }
    }
}
