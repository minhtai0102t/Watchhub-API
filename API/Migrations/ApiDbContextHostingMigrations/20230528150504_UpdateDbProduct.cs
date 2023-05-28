using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDbProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_feedback_ids",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_image_ids",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_name",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "inventory",
                table: "products",
                newName: "product_glass_id");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "products",
                newName: "product_core_id");

            migrationBuilder.AddColumn<int>(
                name: "product_albert_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "brand_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<int>>(
                name: "product_feedback_ids",
                table: "product_types",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "product_image_ids",
                table: "product_types",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_albert_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "brand_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_feedback_ids",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_image_ids",
                table: "product_types");

            migrationBuilder.RenameColumn(
                name: "product_glass_id",
                table: "products",
                newName: "inventory");

            migrationBuilder.RenameColumn(
                name: "product_core_id",
                table: "products",
                newName: "brand_id");

            migrationBuilder.AddColumn<string>(
                name: "product_description",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<int>>(
                name: "product_feedback_ids",
                table: "products",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "product_image_ids",
                table: "products",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
