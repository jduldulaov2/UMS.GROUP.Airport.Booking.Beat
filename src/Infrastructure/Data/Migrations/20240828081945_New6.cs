using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class New6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingUniqueId",
                table: "RestaurantUserLog",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingUniqueId",
                table: "RestaurantUserLog");
        }
    }
}
