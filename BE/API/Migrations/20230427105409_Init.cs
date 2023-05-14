using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(name: "user_name", type: "text", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createduser = table.Column<int>(name: "created_user", type: "integer", nullable: false),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "timestamp with time zone", nullable: false),
                    updateduser = table.Column<int>(name: "updated_user", type: "integer", nullable: false),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
