using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableID",
                table: "RestaurantBooking");

            migrationBuilder.DropColumn(
                name: "TableIDOther",
                table: "RestaurantBooking");

            migrationBuilder.AlterColumn<string>(
                name: "BookingEstimatedDepartureTime",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookingEstimatedArrivalTime",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RestaurantBookingTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantBookingID = table.Column<int>(type: "int", nullable: true),
                    RestaurantTableID = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantBookingTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantBookingTable");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingEstimatedDepartureTime",
                table: "RestaurantBooking",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingEstimatedArrivalTime",
                table: "RestaurantBooking",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableID",
                table: "RestaurantBooking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableIDOther",
                table: "RestaurantBooking",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
