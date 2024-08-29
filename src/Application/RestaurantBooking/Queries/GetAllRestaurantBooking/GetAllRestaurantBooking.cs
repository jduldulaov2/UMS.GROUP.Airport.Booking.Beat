using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantBookingQuery : IRequest<List<GetAllRestaurantBookingQueryDto>>
{

}

public class GetAllRestaurantBookingQueryHandler : IRequestHandler<GetAllRestaurantBookingQuery, List<GetAllRestaurantBookingQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllRestaurantBookingQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllRestaurantBookingQueryDto>> Handle(GetAllRestaurantBookingQuery request, CancellationToken cancellationToken)
    {
        return await (from restaurantbooking in _context.RestaurantBooking
                      orderby restaurantbooking.Id descending
                      select new GetAllRestaurantBookingQueryDto
                      {
                            Id = restaurantbooking.Id,
                            UniqueId = restaurantbooking.UniqueId,
                            BookingReferrenceNumber = restaurantbooking.BookingReferrenceNumber,
                            BookingFromDate = restaurantbooking.BookingFromDate,
                            BookingToDate = restaurantbooking.BookingToDate,
                            BookingSource = restaurantbooking.BookingSource,
                            BookingEstimatedArrivalTime = restaurantbooking.BookingEstimatedArrivalTime,
                            BookingEstimatedDepartureTime = restaurantbooking.BookingEstimatedDepartureTime,
                            BookingStatusID = restaurantbooking.BookingStatusID,
                            BookingPaymentStatusID = restaurantbooking.BookingPaymentStatusID,
                            BookingChargesAmount = restaurantbooking.BookingChargesAmount,
                            BookingExtrasAmount = restaurantbooking.BookingExtrasAmount,
                            BookingPromoAmount = restaurantbooking.BookingPromoAmount,
                            BookingTaxAmount = restaurantbooking.BookingTaxAmount,
                            BookingPaymentSurchargeAmount = restaurantbooking.BookingPaymentSurchargeAmount,
                            BookingTotalAmount = restaurantbooking.BookingTotalAmount,
                            BookingPaidAmount = restaurantbooking.BookingPaidAmount,
                            BookingOutstandingBalanceAmount = restaurantbooking.BookingOutstandingBalanceAmount,
                            BookingNotes = restaurantbooking.BookingNotes,
                            PaymentMethod = restaurantbooking.PaymentMethod,
                            RestaurantID = restaurantbooking.RestaurantID,
                            GuestID = restaurantbooking.GuestID,
                            OrderID = restaurantbooking.OrderID,
                            IsActive = restaurantbooking.IsActive,
                            GuestName = restaurantbooking.GuestName,
                            RestaurantName = restaurantbooking.RestaurantName,
                            NumberOfPax = restaurantbooking.NumberOfPax,
                            SelectedTables = restaurantbooking.SelectedTables

                      }).ToListAsync();
    }
}
