using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb56 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 6, 14, 41, 71, DateTimeKind.Utc).AddTicks(7820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 24, 14, 21, 45, 67, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.AddColumn<List<string>>(
                name: "user_addresses",
                table: "users",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ward",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_addresses",
                table: "users");

            migrationBuilder.DropColumn(
                name: "district",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "province",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "street",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ward",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 14, 21, 45, 67, DateTimeKind.Utc).AddTicks(7540),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 25, 6, 14, 41, 71, DateTimeKind.Utc).AddTicks(7820));
        }
    }
}
