using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateRestaurantBookingCommand : IRequest<Result<UpdateRestaurantBookingCommandDto>>
{
    public string? UniqueId { get; init; }

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

    public bool? IsActive { get; init; }

    public string? GuestName { get; init; }

    public string? RestaurantName { get; init; }

    public int? NumberOfPax { get; init; }
}

public class UpdateRestaurantBookingCommandHandler : IRequestHandler<UpdateRestaurantBookingCommand, Result<UpdateRestaurantBookingCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateRestaurantBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateRestaurantBookingCommandDto>> Handle(UpdateRestaurantBookingCommand request, CancellationToken cancellationToken)
    {
        var record = _context.RestaurantBooking.FirstOrDefault(item => item.BookingReferrenceNumber == request.BookingReferrenceNumber && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.RestaurantBooking.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
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
                entity.IsActive = request.IsActive;
                entity.GuestName = request.GuestName;
                entity.RestaurantName = request.RestaurantName;
                entity.NumberOfPax = request.NumberOfPax;

                _context.RestaurantBooking.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateRestaurantBookingCommandDto
                    {
                        Id = entity.UniqueId,
                        UpdatedDate = DateTime.Now,
                        PrimaryId = entity.Id
                    },
                    Message = "Updated successfully.",
                    ResultType = ResultType.Success,
                };
            }
        }
        else
        {
            return new()
            {
                Data = new UpdateRestaurantBookingCommandDto
                {

                },
                Message = "Record '" + request.BookingReferrenceNumber + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateRestaurantBookingCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
