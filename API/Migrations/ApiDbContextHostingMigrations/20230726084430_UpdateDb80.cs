using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    /// <inheritdoc />
    public partial class UpdateDb80 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vnpay_id",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vnpay_payment_OrderID",
                table: "vnpay_payment",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vnpay_payment_UserID",
                table: "vnpay_payment",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_vnpay_payment_orders_OrderID",
                table: "vnpay_payment",
                column: "OrderID",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vnpay_payment_users_UserID",
                table: "vnpay_payment",
                column: "UserID",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vnpay_payment_orders_OrderID",
                table: "vnpay_payment");

            migrationBuilder.DropForeignKey(
                name: "FK_vnpay_payment_users_UserID",
                table: "vnpay_payment");

            migrationBuilder.DropIndex(
                name: "IX_vnpay_payment_OrderID",
                table: "vnpay_payment");

            migrationBuilder.DropIndex(
                name: "IX_vnpay_payment_UserID",
                table: "vnpay_payment");

            migrationBuilder.DropColumn(
                name: "vnpay_id",
                table: "orders");
        }
    }
}
