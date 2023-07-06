using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb70 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_types_sub_categories_sub_category_id",
                table: "product_types");

            migrationBuilder.DropIndex(
                name: "IX_product_types_sub_category_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "sub_category_id",
                table: "product_types");

            migrationBuilder.CreateTable(
                name: "products_sub_categories",
                columns: table => new
                {
                    product_type_id = table.Column<int>(type: "integer", nullable: false),
                    sub_category_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_user = table.Column<int>(type: "integer", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_user = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products_sub_categories", x => new { x.product_type_id, x.sub_category_id });
                    table.ForeignKey(
                        name: "FK_products_sub_categories_product_types_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "product_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_sub_categories_sub_categories_sub_category_id",
                        column: x => x.sub_category_id,
                        principalTable: "sub_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_sub_categories_sub_category_id",
                table: "products_sub_categories",
                column: "sub_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products_sub_categories");

            migrationBuilder.AddColumn<int>(
                name: "sub_category_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product_types_sub_category_id",
                table: "product_types",
                column: "sub_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_sub_categories_sub_category_id",
                table: "product_types",
                column: "sub_category_id",
                principalTable: "sub_categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
