using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb68 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ProductAlbertSequence");

            migrationBuilder.CreateSequence(
                name: "ProductCoreSequence");

            migrationBuilder.CreateSequence(
                name: "ProductGlassSequence");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "vnpay_payment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "vnpay_payment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "albert_id",
                table: "product_types",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "core_id",
                table: "product_types",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "glass_id",
                table: "product_types",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_types",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_glasses",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"ProductGlassSequence\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_cores",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"ProductCoreSequence\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_alberts",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"ProductAlbertSequence\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_albert_id",
                table: "product_types",
                column: "albert_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_core_id",
                table: "product_types",
                column: "core_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_types_glass_id",
                table: "product_types",
                column: "glass_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_product_types_albert_id",
                table: "product_types");

            migrationBuilder.DropIndex(
                name: "IX_product_types_core_id",
                table: "product_types");

            migrationBuilder.DropIndex(
                name: "IX_product_types_glass_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "vnpay_payment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "vnpay_payment");

            migrationBuilder.DropColumn(
                name: "albert_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "core_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "glass_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "product_type_id",
                table: "product_types");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "orders");

            migrationBuilder.DropSequence(
                name: "ProductAlbertSequence");

            migrationBuilder.DropSequence(
                name: "ProductCoreSequence");

            migrationBuilder.DropSequence(
                name: "ProductGlassSequence");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_glasses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"ProductGlassSequence\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_glasses",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_cores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"ProductCoreSequence\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_cores",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "product_alberts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"ProductAlbertSequence\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_alberts",
                type: "integer",
                nullable: true);

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
        }
    }
}
