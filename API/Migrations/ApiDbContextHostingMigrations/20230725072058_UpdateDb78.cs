using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb78 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_feedback_ids",
                table: "product_types");

            migrationBuilder.CreateSequence(
                name: "UserSequence");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValueSql: "nextval('\"UserSequence\"')",
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "product_type_id",
                table: "product_feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "product_feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_product_type_id",
                table: "product_feedbacks",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_feedbacks_user_id",
                table: "product_feedbacks",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_feedbacks_product_types_product_type_id",
                table: "product_feedbacks",
                column: "product_type_id",
                principalTable: "product_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_feedbacks_users_user_id",
                table: "product_feedbacks",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_feedbacks_product_types_product_type_id",
                table: "product_feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_product_feedbacks_users_user_id",
                table: "product_feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_product_feedbacks_product_type_id",
                table: "product_feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_product_feedbacks_user_id",
                table: "product_feedbacks");

            migrationBuilder.DropColumn(
                name: "product_type_id",
                table: "product_feedbacks");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "product_feedbacks");

            migrationBuilder.DropSequence(
                name: "UserSequence");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "nextval('\"UserSequence\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<List<int>>(
                name: "product_feedback_ids",
                table: "product_types",
                type: "integer[]",
                nullable: true);
        }
    }
}
