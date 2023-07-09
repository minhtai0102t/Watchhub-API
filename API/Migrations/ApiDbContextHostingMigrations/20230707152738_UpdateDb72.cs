using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb72 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_sub_categories_category_id",
                table: "sub_categories",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_sub_categories_categories_category_id",
                table: "sub_categories",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sub_categories_categories_category_id",
                table: "sub_categories");

            migrationBuilder.DropIndex(
                name: "IX_sub_categories_category_id",
                table: "sub_categories");
        }
    }
}
