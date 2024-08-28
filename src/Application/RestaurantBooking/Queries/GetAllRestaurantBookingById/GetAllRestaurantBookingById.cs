using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantBookingByIdQuery : IRequest<Result<GetAllRestaurantBookingByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetRestaurantBookingByIdQueryHandler : IRequestHandler<GetAllRestaurantBookingByIdQuery, Result<GetAllRestaurantBookingByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRestaurantBookingByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllRestaurantBookingByIdQueryDto>> Handle(GetAllRestaurantBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RestaurantBooking.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllRestaurantBookingByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    BookingReferrenceNumber = result.BookingReferrenceNumber,
                    BookingFromDate = result.BookingFromDate,
                    BookingToDate = result.BookingToDate,
                    BookingSource = result.BookingSource,
                    BookingEstimatedArrivalTime = result.BookingEstimatedArrivalTime,
                    BookingEstimatedDepartureTime = result.BookingEstimatedDepartureTime,
                    BookingStatusID = result.BookingStatusID,
                    BookingPaymentStatusID = result.BookingPaymentStatusID,
                    BookingChargesAmount = result.BookingChargesAmount,
                    BookingExtrasAmount = result.BookingExtrasAmount,
                    BookingPromoAmount = result.BookingPromoAmount,
                    BookingTaxAmount = result.BookingTaxAmount,
                    BookingPaymentSurchargeAmount = result.BookingPaymentSurchargeAmount,
                    BookingTotalAmount = result.BookingTotalAmount,
                    BookingPaidAmount = result.BookingPaidAmount,
                    BookingOutstandingBalanceAmount = result.BookingOutstandingBalanceAmount,
                    BookingNotes = result.BookingNotes,
                    PaymentMethod = result.PaymentMethod,
                    RestaurantID = result.RestaurantID,
                    GuestID = result.GuestID,
                    OrderID = result.OrderID,
                    IsActive = result.IsActive,
                    GuestName = result.GuestName,
                    RestaurantName = result.RestaurantName,
                    NumberOfPax = result.NumberOfPax,
                    SelectedTables = result.SelectedTables
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllRestaurantBookingByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
