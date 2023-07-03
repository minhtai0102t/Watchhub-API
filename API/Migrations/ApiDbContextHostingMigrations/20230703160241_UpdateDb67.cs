using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb67 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_glasses_product_type_id",
                table: "product_glasses");

            migrationBuilder.DropIndex(
                name: "IX_product_cores_product_type_id",
                table: "product_cores");

            migrationBuilder.DropIndex(
                name: "IX_product_alberts_product_type_id",
                table: "product_alberts");

            migrationBuilder.CreateIndex(
                name: "IX_product_glasses_product_type_id",
                table: "product_glasses",
                column: "product_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_cores_product_type_id",
                table: "product_cores",
                column: "product_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_alberts_product_type_id",
                table: "product_alberts",
                column: "product_type_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_glasses_product_type_id",
                table: "product_glasses");

            migrationBuilder.DropIndex(
                name: "IX_product_cores_product_type_id",
                table: "product_cores");

            migrationBuilder.DropIndex(
                name: "IX_product_alberts_product_type_id",
                table: "product_alberts");

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
        }
    }
}
