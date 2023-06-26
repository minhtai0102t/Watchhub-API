using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_paid",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 14, 21, 45, 67, DateTimeKind.Utc).AddTicks(7540),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 24, 14, 7, 29, 814, DateTimeKind.Utc).AddTicks(130));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 14, 7, 29, 814, DateTimeKind.Utc).AddTicks(130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 24, 14, 21, 45, 67, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.AddColumn<bool>(
                name: "is_paid",
                table: "orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
