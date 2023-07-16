using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb75 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_product_types_product_type_id",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "product_type_id",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<int>>(
                name: "product_type_ids",
                table: "orders",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_product_types_product_type_id",
                table: "products",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_product_types_product_type_id",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "product_type_id",
                table: "products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<List<int>>(
                name: "product_type_ids",
                table: "orders",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");

            migrationBuilder.AddForeignKey(
                name: "FK_products_product_types_product_type_id",
                table: "products",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id");
        }
    }
}
