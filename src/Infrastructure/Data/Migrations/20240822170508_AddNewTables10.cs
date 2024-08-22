using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "OrderQuantity",
                table: "RestaurantOrderDetail",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OrderTotalAmount",
                table: "RestaurantOrderDetail",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderQuantity",
                table: "RestaurantOrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderTotalAmount",
                table: "RestaurantOrderDetail");
        }
    }
}
