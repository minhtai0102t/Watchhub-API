using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb57 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "user_addresses",
                table: "users",
                newName: "addresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 6, 25, 29, 809, DateTimeKind.Utc).AddTicks(3210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 25, 6, 14, 41, 71, DateTimeKind.Utc).AddTicks(7820));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "addresses",
                table: "users",
                newName: "user_addresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 6, 14, 41, 71, DateTimeKind.Utc).AddTicks(7820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 25, 6, 25, 29, 809, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "users",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);
        }
    }
}
