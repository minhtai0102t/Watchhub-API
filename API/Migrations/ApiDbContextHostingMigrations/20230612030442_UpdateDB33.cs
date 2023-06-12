using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDB33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 3, 4, 42, 735, DateTimeKind.Utc).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 12, 3, 1, 12, 803, DateTimeKind.Utc).AddTicks(4619));

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_source = table.Column<string>(type: "text", nullable: true),
                    product_guarantee = table.Column<string>(type: "text", nullable: true),
                    product_dial_width = table.Column<string>(type: "text", nullable: true),
                    product_dial_height = table.Column<string>(type: "text", nullable: true),
                    product_dial_color = table.Column<string>(type: "text", nullable: true),
                    product_waterproof = table.Column<string>(type: "text", nullable: true),
                    product_features = table.Column<string>(type: "text", nullable: true),
                    product_additional_information = table.Column<string>(type: "text", nullable: true),
                    product_type_id = table.Column<int>(type: "integer", nullable: false),
                    product_albert_id = table.Column<int>(type: "integer", nullable: false),
                    product_core_id = table.Column<int>(type: "integer", nullable: false),
                    product_glass_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_user = table.Column<int>(type: "integer", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_user = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 3, 1, 12, 803, DateTimeKind.Utc).AddTicks(4619),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 12, 3, 4, 42, 735, DateTimeKind.Utc).AddTicks(1996));
        }
    }
}
