using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateRestaurantOrderCommand : IRequest<Result<CreateRestaurantOrderCommandDto>>
{
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

public class CreateRestaurantOrderCommandHandler : IRequestHandler<CreateRestaurantOrderCommand, Result<CreateRestaurantOrderCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateRestaurantOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateRestaurantOrderCommandDto>> Handle(CreateRestaurantOrderCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.RestaurantOrder.Where(p => p.OrderReferrenceNumber == request.OrderReferrenceNumber).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new RestaurantOrder();

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

            _context.RestaurantOrder.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateRestaurantOrderCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreateRestaurantOrderCommandDto
                {

                },
                Message = "Record '" + request.OrderReferrenceNumber + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

