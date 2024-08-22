using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateRestaurantOrderCommand : IRequest<Result<UpdateRestaurantOrderCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? OrderReferrenceNumber { get; init; }

    public string? OrderSource { get; init; }

    public int? OrderStatusID { get; init; }

    public int? OrderPaymentStatusID { get; init; }

    public float? OrderChargesAmount { get; init; }

    public float? OrderExtrasAmount { get; init; }

    public float? OrderPromoAmount { get; init; }

    public float? OrderTaxAmount { get; init; }

    public float? OrderPaymentSurchargeAmount { get; init; }

    public float? OrderTotalAmount { get; init; }

    public float? OrderPaidAmount { get; init; }

    public float? OrderOutstandingBalanceAmount { get; init; }

    public string? OrderNotes { get; init; }

    public int? RestaurantID { get; init; }

    public string? GuestID { get; init; }

    public string? GuestName { get; init; }

    public string? RestaurantName { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateRestaurantOrderCommandHandler : IRequestHandler<UpdateRestaurantOrderCommand, Result<UpdateRestaurantOrderCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateRestaurantOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateRestaurantOrderCommandDto>> Handle(UpdateRestaurantOrderCommand request, CancellationToken cancellationToken)
    {
        var record = _context.RestaurantOrder.FirstOrDefault(item => item.OrderReferrenceNumber == request.OrderReferrenceNumber && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.RestaurantOrder.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.OrderReferrenceNumber = request.OrderReferrenceNumber;
                entity.OrderSource = request.OrderSource;
                entity.OrderStatusID = request.OrderStatusID;
                entity.OrderPaymentStatusID = request.OrderPaymentStatusID;
                entity.OrderChargesAmount = request.OrderChargesAmount;
                entity.OrderExtrasAmount = request.OrderExtrasAmount;
                entity.OrderPromoAmount = request.OrderPromoAmount;
                entity.OrderTaxAmount = request.OrderTaxAmount;
                entity.OrderPaymentSurchargeAmount = request.OrderPaymentSurchargeAmount;
                entity.OrderTotalAmount = request.OrderTotalAmount;
                entity.OrderPaidAmount = request.OrderPaidAmount;
                entity.OrderOutstandingBalanceAmount = request.OrderOutstandingBalanceAmount;
                entity.OrderNotes = request.OrderNotes;
                entity.RestaurantID = request.RestaurantID;
                entity.GuestID = request.GuestID;
                entity.GuestName = request.GuestName;
                entity.RestaurantName = request.RestaurantName;
                entity.IsActive = request.IsActive;

                _context.RestaurantOrder.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateRestaurantOrderCommandDto
                    {
                        Id = entity.UniqueId,
                        UpdatedDate = DateTime.Now,
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
                Data = new UpdateRestaurantOrderCommandDto
                {

                },
                Message = "Record '" + request.OrderReferrenceNumber + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateRestaurantOrderCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
