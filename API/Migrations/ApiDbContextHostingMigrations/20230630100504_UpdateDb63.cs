using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb63 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 30, 10, 5, 3, 935, DateTimeKind.Utc).AddTicks(2515),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 30, 9, 55, 38, 853, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.AddColumn<List<int>>(
                name: "product_type_ids",
                table: "orders",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_type_ids",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 30, 9, 55, 38, 853, DateTimeKind.Utc).AddTicks(1717),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 30, 10, 5, 3, 935, DateTimeKind.Utc).AddTicks(2515));
        }
    }
}
