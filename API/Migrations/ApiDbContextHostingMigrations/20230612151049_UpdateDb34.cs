using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_additional_information",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_albert_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_core_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_dial_color",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_dial_height",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_dial_width",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_features",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_glass_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_guarantee",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_source",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_waterproof",
                table: "products");

            migrationBuilder.DropColumn(
                name: "productAlberts",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "productCores",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "productGlasses",
                table: "product_types");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 15, 10, 49, 113, DateTimeKind.Utc).AddTicks(9580),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 12, 3, 4, 42, 735, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.AddColumn<string>(
                name: "product_additional_information",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_albert_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_core_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_dial_color",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_dial_height",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_dial_width",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_features",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_glass_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_guarantee",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_source",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_waterproof",
                table: "product_types",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_additional_information",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_albert_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_core_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_dial_color",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_dial_height",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_dial_width",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_features",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_glass_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_guarantee",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_source",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_waterproof",
                table: "product_types");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 3, 4, 42, 735, DateTimeKind.Utc).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 12, 15, 10, 49, 113, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.AddColumn<string>(
                name: "product_additional_information",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_albert_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_core_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_dial_color",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_dial_height",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_dial_width",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_features",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_glass_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_guarantee",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_source",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_waterproof",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "productAlberts",
                table: "product_types",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "productCores",
                table: "product_types",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "productGlasses",
                table: "product_types",
                type: "integer[]",
                nullable: true);
        }
    }
}
