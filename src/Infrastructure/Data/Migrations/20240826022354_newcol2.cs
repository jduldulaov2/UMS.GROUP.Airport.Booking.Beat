using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class newcol2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookingReservationId",
                table: "DraftCartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CurrentPrice",
                table: "DraftCartItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CurrentTotal",
                table: "DraftCartItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CurrrentQuantity",
                table: "DraftCartItems",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "DraftCartItems");

            migrationBuilder.DropColumn(
                name: "CurrentTotal",
                table: "DraftCartItems");

            migrationBuilder.DropColumn(
                name: "CurrrentQuantity",
                table: "DraftCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "BookingReservationId",
                table: "DraftCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
