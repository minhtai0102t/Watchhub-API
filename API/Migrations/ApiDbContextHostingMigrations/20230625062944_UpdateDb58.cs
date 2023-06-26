using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb58 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 6, 29, 44, 733, DateTimeKind.Utc).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 25, 6, 25, 29, 809, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.AlterColumn<string>(
                name: "addresses",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 6, 25, 29, 809, DateTimeKind.Utc).AddTicks(3210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 25, 6, 29, 44, 733, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.AlterColumn<List<string>>(
                name: "addresses",
                table: "users",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
