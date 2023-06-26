using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb54 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropColumn(
                name: "order_detail_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "orders",
                newName: "total_amount");

            migrationBuilder.RenameColumn(
                name: "total_money_amount",
                table: "orders",
                newName: "payment_method_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 14, 7, 29, 814, DateTimeKind.Utc).AddTicks(130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 52, 1, 227, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.AddColumn<bool>(
                name: "is_paid",
                table: "orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "order_info",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "order_status",
                table: "orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_paid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_info",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_status",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "total_amount",
                table: "orders",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "payment_method_id",
                table: "orders",
                newName: "total_money_amount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 52, 1, 227, DateTimeKind.Utc).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 24, 14, 7, 29, 814, DateTimeKind.Utc).AddTicks(130));

            migrationBuilder.AddColumn<int>(
                name: "order_detail_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_user = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    money_amount = table.Column<int>(type: "integer", nullable: false),
                    product_ids = table.Column<List<int>>(type: "integer[]", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_user = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_user = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    order_status_name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_user = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status", x => x.id);
                });
        }
    }
}
