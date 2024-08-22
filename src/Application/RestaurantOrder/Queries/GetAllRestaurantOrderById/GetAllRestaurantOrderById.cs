using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantOrderByIdQuery : IRequest<Result<GetAllRestaurantOrderByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetRestaurantOrderByIdQueryHandler : IRequestHandler<GetAllRestaurantOrderByIdQuery, Result<GetAllRestaurantOrderByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRestaurantOrderByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllRestaurantOrderByIdQueryDto>> Handle(GetAllRestaurantOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RestaurantOrder.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllRestaurantOrderByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    OrderReferrenceNumber = result.OrderReferrenceNumber,
                    OrderSource = result.OrderSource,
                    OrderStatusID = result.OrderStatusID,
                    OrderPaymentStatusID = result.OrderPaymentStatusID,
                    OrderChargesAmount = result.OrderChargesAmount,
                    OrderExtrasAmount = result.OrderExtrasAmount,
                    OrderPromoAmount = result.OrderPromoAmount,
                    OrderTaxAmount = result.OrderTaxAmount,
                    OrderPaymentSurchargeAmount = result.OrderPaymentSurchargeAmount,
                    OrderTotalAmount = result.OrderTotalAmount,
                    OrderPaidAmount = result.OrderPaidAmount,
                    OrderOutstandingBalanceAmount = result.OrderOutstandingBalanceAmount,
                    OrderNotes = result.OrderNotes,
                    RestaurantID = result.RestaurantID,
                    GuestID = result.GuestID,
                    GuestName = result.GuestName,
                    RestaurantName = result.RestaurantName,
                    IsActive = result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllRestaurantOrderByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
