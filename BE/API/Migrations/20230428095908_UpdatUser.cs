using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mail",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
