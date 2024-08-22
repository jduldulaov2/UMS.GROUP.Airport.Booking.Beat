using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.GROUP.Airport.Booking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CustomRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantFullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingReferrenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingFromDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingToDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingEstimatedArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingEstimatedDepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingStatusID = table.Column<int>(type: "int", nullable: true),
                    BookingPaymentStatusID = table.Column<int>(type: "int", nullable: true),
                    BookingChargesAmount = table.Column<float>(type: "real", nullable: true),
                    BookingExtrasAmount = table.Column<float>(type: "real", nullable: true),
                    BookingPromoAmount = table.Column<float>(type: "real", nullable: true),
                    BookingTaxAmount = table.Column<float>(type: "real", nullable: true),
                    BookingPaymentSurchargeAmount = table.Column<float>(type: "real", nullable: true),
                    BookingTotalAmount = table.Column<float>(type: "real", nullable: true),
                    BookingPaidAmount = table.Column<float>(type: "real", nullable: true),
                    BookingOutstandingBalanceAmount = table.Column<float>(type: "real", nullable: true),
                    BookingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableIDOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: true),
                    GuestID = table.Column<int>(type: "int", nullable: true),
                    TableID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RestaurantBooking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderReferrenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatusID = table.Column<int>(type: "int", nullable: true),
                    OrderPaymentStatusID = table.Column<int>(type: "int", nullable: true),
                    OrderChargesAmount = table.Column<float>(type: "real", nullable: true),
                    OrderExtrasAmount = table.Column<float>(type: "real", nullable: true),
                    OrderPromoAmount = table.Column<float>(type: "real", nullable: true),
                    OrderTaxAmount = table.Column<float>(type: "real", nullable: true),
                    OrderPaymentSurchargeAmount = table.Column<float>(type: "real", nullable: true),
                    OrderTotalAmount = table.Column<float>(type: "real", nullable: true),
                    OrderPaidAmount = table.Column<float>(type: "real", nullable: true),
                    OrderOutstandingBalanceAmount = table.Column<float>(type: "real", nullable: true),
                    OrderNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: true),
                    GuestID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RestaurantOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantOrderID = table.Column<int>(type: "int", nullable: true),
                    FoodID = table.Column<int>(type: "int", nullable: true),
                    OrderSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDetailFoodPrice = table.Column<float>(type: "real", nullable: true),
                    OrderDetailNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RestaurantOrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentReferrenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTableID = table.Column<int>(type: "int", nullable: true),
                    BookingOrderID = table.Column<int>(type: "int", nullable: true),
                    PaymentAmountToBePaid = table.Column<float>(type: "real", nullable: true),
                    PaymentActualAmount = table.Column<float>(type: "real", nullable: true),
                    PaymentRunningBalance = table.Column<float>(type: "real", nullable: true),
                    ProcessedBy = table.Column<float>(type: "real", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: true),
                    GuestID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RestaurantPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RestaurantTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomRole");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "RestaurantBooking");

            migrationBuilder.DropTable(
                name: "RestaurantOrder");

            migrationBuilder.DropTable(
                name: "RestaurantOrderDetail");

            migrationBuilder.DropTable(
                name: "RestaurantPayment");

            migrationBuilder.DropTable(
                name: "RestaurantTable");
        }
    }
}
