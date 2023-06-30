using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 30, 9, 4, 32, 982, DateTimeKind.Utc).AddTicks(6881),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 29, 9, 16, 14, 508, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.AddColumn<int>(
                name: "sold_quantity",
                table: "product_types",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sold_quantity",
                table: "product_types");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 9, 16, 14, 508, DateTimeKind.Utc).AddTicks(8007),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 30, 9, 4, 32, 982, DateTimeKind.Utc).AddTicks(6881));
        }
    }
}
