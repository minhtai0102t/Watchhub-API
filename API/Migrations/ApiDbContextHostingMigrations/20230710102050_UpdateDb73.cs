using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb73 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "product_glass_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "product_core_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "product_albert_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_alberts_product_albert_id",
                table: "product_types",
                column: "product_albert_id",
                principalTable: "product_alberts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_cores_product_core_id",
                table: "product_types",
                column: "product_core_id",
                principalTable: "product_cores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_types_product_glasses_product_glass_id",
                table: "product_types",
                column: "product_glass_id",
                principalTable: "product_glasses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "product_glass_id",
                table: "product_types",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "product_core_id",
                table: "product_types",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "product_albert_id",
                table: "product_types",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
    }
}
