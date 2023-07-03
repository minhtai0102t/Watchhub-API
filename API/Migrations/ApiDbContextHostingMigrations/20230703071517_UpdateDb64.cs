using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_albert_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_core_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_glass_id",
                table: "product_types");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 7, 15, 17, 443, DateTimeKind.Utc).AddTicks(1592),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 30, 10, 5, 3, 935, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_glasses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_cores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_alberts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_product_type_id",
                table: "products",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_brand_id",
                table: "product_types",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_sub_category_id",
                table: "product_types",
                column: "sub_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_glasses_product_type_id",
                table: "product_glasses",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_cores_product_type_id",
                table: "product_cores",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_alberts_product_type_id",
                table: "product_alberts",
                column: "product_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_alberts_product_types_product_type_id",
                table: "product_alberts",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_cores_product_types_product_type_id",
                table: "product_cores",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_glasses_product_types_product_type_id",
                table: "product_glasses",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_brands_brand_id",
                table: "product_types",
                column: "brand_id",
                principalTable: "brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_sub_categories_sub_category_id",
                table: "product_types",
                column: "sub_category_id",
                principalTable: "sub_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_product_alberts_product_types_product_type_id",
                table: "product_alberts");

            migrationBuilder.DropForeignKey(
                name: "FK_product_cores_product_types_product_type_id",
                table: "product_cores");

            migrationBuilder.DropForeignKey(
                name: "FK_product_glasses_product_types_product_type_id",
                table: "product_glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_brands_brand_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_sub_categories_sub_category_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_products_product_types_product_type_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_product_type_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_product_types_brand_id",
                table: "product_types");

            migrationBuilder.DropIndex(
                name: "IX_product_types_sub_category_id",
                table: "product_types");

            migrationBuilder.DropIndex(
                name: "IX_product_glasses_product_type_id",
                table: "product_glasses");

            migrationBuilder.DropIndex(
                name: "IX_product_cores_product_type_id",
                table: "product_cores");

            migrationBuilder.DropIndex(
                name: "IX_product_alberts_product_type_id",
                table: "product_alberts");

            migrationBuilder.DropColumn(
                name: "product_type_id",
                table: "product_glasses");

            migrationBuilder.DropColumn(
                name: "product_type_id",
                table: "product_cores");

            migrationBuilder.DropColumn(
                name: "product_type_id",
                table: "product_alberts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 30, 10, 5, 3, 935, DateTimeKind.Utc).AddTicks(2515),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 7, 3, 7, 15, 17, 443, DateTimeKind.Utc).AddTicks(1592));

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

            migrationBuilder.AddColumn<int>(
                name: "product_glass_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
