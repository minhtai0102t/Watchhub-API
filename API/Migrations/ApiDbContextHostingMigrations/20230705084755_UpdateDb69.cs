using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb69 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_alberts_albert_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_cores_core_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_glasses_glass_id",
                table: "product_types");

            migrationBuilder.RenameColumn(
                name: "glass_id",
                table: "product_types",
                newName: "product_glass_id");

            migrationBuilder.RenameColumn(
                name: "core_id",
                table: "product_types",
                newName: "product_core_id");

            migrationBuilder.RenameColumn(
                name: "albert_id",
                table: "product_types",
                newName: "product_albert_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_glass_id",
                table: "product_types",
                newName: "IX_product_types_product_glass_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_core_id",
                table: "product_types",
                newName: "IX_product_types_product_core_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_albert_id",
                table: "product_types",
                newName: "IX_product_types_product_albert_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_alberts_product_albert_id",
                table: "product_types",
                column: "product_albert_id",
                principalTable: "product_alberts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_cores_product_core_id",
                table: "product_types",
                column: "product_core_id",
                principalTable: "product_cores",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_glasses_product_glass_id",
                table: "product_types",
                column: "product_glass_id",
                principalTable: "product_glasses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_alberts_product_albert_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_cores_product_core_id",
                table: "product_types");

            migrationBuilder.DropForeignKey(
                name: "FK_product_types_product_glasses_product_glass_id",
                table: "product_types");

            migrationBuilder.RenameColumn(
                name: "product_glass_id",
                table: "product_types",
                newName: "glass_id");

            migrationBuilder.RenameColumn(
                name: "product_core_id",
                table: "product_types",
                newName: "core_id");

            migrationBuilder.RenameColumn(
                name: "product_albert_id",
                table: "product_types",
                newName: "albert_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_product_glass_id",
                table: "product_types",
                newName: "IX_product_types_glass_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_product_core_id",
                table: "product_types",
                newName: "IX_product_types_core_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_types_product_albert_id",
                table: "product_types",
                newName: "IX_product_types_albert_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_alberts_albert_id",
                table: "product_types",
                column: "albert_id",
                principalTable: "product_alberts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_cores_core_id",
                table: "product_types",
                column: "core_id",
                principalTable: "product_cores",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_glasses_glass_id",
                table: "product_types",
                column: "glass_id",
                principalTable: "product_glasses",
                principalColumn: "id");
        }
    }
}
