using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDbProduct4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sub_category_id",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "product_type_id",
                table: "sub_categories",
                newName: "category_id");

            migrationBuilder.AddColumn<int>(
                name: "sub_category_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sub_category_id",
                table: "product_types");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "sub_categories",
                newName: "product_type_id");

            migrationBuilder.AddColumn<int>(
                name: "sub_category_id",
                table: "categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
