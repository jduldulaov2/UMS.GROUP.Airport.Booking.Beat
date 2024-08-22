using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateRestaurantBookingCommand : IRequest<Result<CreateRestaurantBookingCommandDto>>
{
    public string? BookingReferrenceNumber { get; init; }

    public string? BookingFromDate { get; init; }

    public string? BookingToDate { get; init; }

    public string? BookingSource { get; init; }

    public string? BookingEstimatedArrivalTime { get; init; }

    public string? BookingEstimatedDepartureTime { get; init; }

    public int? BookingStatusID { get; init; }

    public int? BookingPaymentStatusID { get; init; }

    public float? BookingChargesAmount { get; init; }

    public float? BookingExtrasAmount { get; init; }

    public float? BookingPromoAmount { get; init; }

    public float? BookingTaxAmount { get; init; }

    public float? BookingPaymentSurchargeAmount { get; init; }

    public float? BookingTotalAmount { get; init; }

    public float? BookingPaidAmount { get; init; }

    public float? BookingOutstandingBalanceAmount { get; init; }

    public string? BookingNotes { get; init; }

    public string? PaymentMethod { get; init; }

    public int? RestaurantID { get; init; }

    public string? GuestID { get; init; }

    public int? OrderID { get; init; }

    public string? GuestName { get; init; }

    public string? RestaurantName { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateRestaurantBookingCommandHandler : IRequestHandler<CreateRestaurantBookingCommand, Result<CreateRestaurantBookingCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateRestaurantBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateRestaurantBookingCommandDto>> Handle(CreateRestaurantBookingCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.RestaurantBooking.Where(p => p.BookingReferrenceNumber == request.BookingReferrenceNumber).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new RestaurantBooking();

            entity.BookingReferrenceNumber = request.BookingReferrenceNumber;
            entity.BookingFromDate = request.BookingFromDate;
            entity.BookingToDate = request.BookingToDate;
            entity.BookingSource = request.BookingSource;
            entity.BookingEstimatedArrivalTime = request.BookingEstimatedArrivalTime;
            entity.BookingEstimatedDepartureTime = request.BookingEstimatedDepartureTime;
            entity.BookingStatusID = request.BookingStatusID;
            entity.BookingPaymentStatusID = request.BookingPaymentStatusID;
            entity.BookingChargesAmount = request.BookingChargesAmount;
            entity.BookingExtrasAmount = request.BookingExtrasAmount;
            entity.BookingPromoAmount = request.BookingPromoAmount;
            entity.BookingTaxAmount = request.BookingTaxAmount;
            entity.BookingPaymentSurchargeAmount = request.BookingPaymentSurchargeAmount;
            entity.BookingTotalAmount = request.BookingTotalAmount;
            entity.BookingPaidAmount = request.BookingPaidAmount;
            entity.BookingOutstandingBalanceAmount = request.BookingOutstandingBalanceAmount;
            entity.BookingNotes = request.BookingNotes;
            entity.PaymentMethod = request.PaymentMethod;
            entity.RestaurantID = request.RestaurantID;
            entity.GuestID = request.GuestID;
            entity.OrderID = request.OrderID;
            entity.GuestName = request.GuestName;
            entity.RestaurantName = request.RestaurantName;
            entity.IsActive = request.IsActive;

            _context.RestaurantBooking.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateRestaurantBookingCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                    PrimaryId = entity.Id
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreateRestaurantBookingCommandDto
                {

                },
                Message = "Record '" + request.BookingReferrenceNumber + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

