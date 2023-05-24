using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDbUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isVerified",
                table: "users",
                newName: "is_verified");

            migrationBuilder.RenameColumn(
                name: "isAdmin",
                table: "users",
                newName: "is_admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_verified",
                table: "users",
                newName: "isVerified");

            migrationBuilder.RenameColumn(
                name: "is_admin",
                table: "users",
                newName: "isAdmin");
        }
    }
}
