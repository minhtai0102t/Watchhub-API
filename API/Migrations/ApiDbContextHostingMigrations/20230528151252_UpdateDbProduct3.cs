using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDbProduct3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                            name: "product_source",
                            table: "products",
                            type: "character varying(1000)",
                            nullable: true);

            migrationBuilder.AddColumn<string>(
            name: "product_guarantee",
            table: "products",
            type: "character varying(1000)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
                            name: "product_dial_width",
                            table: "products",
                            type: "character varying(1000)",
                            nullable: true);
            migrationBuilder.AddColumn<string>(
            name: "product_dial_height",
            table: "products",
            type: "character varying(1000)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
            name: "product_dial_color",
            table: "products",
            type: "character varying(1000)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
            name: "product_waterproof",
            table: "products",
            type: "character varying(1000)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
            name: "product_features",
            table: "products",
            type: "character varying(1000)",
            nullable: true);

            migrationBuilder.AddColumn<string>(
            name: "product_additional_information",
            table: "products",
            type: "character varying(1000)",
            nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
