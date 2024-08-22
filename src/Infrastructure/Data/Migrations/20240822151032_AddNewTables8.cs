using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GuestID",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestName",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestName",
                table: "RestaurantBooking");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "RestaurantBooking");

            migrationBuilder.AlterColumn<int>(
                name: "GuestID",
                table: "RestaurantBooking",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
