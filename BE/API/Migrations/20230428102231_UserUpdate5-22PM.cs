using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate522PM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Users",
                newName: "fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "Users",
                newName: "full_name");
        }
    }
}
