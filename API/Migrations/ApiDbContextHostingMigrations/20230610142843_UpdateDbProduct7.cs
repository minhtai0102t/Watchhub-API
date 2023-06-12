using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDbProduct7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<String>(
                name: "albert_name",
                table: "product_alberts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<String>(
            name: "core_name",
            table: "product_cores",
            type: "text",
            nullable: true);

            migrationBuilder.AddColumn<String>(
            name: "glass_name",
            table: "product_glasses",
            type: "text",
            nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
