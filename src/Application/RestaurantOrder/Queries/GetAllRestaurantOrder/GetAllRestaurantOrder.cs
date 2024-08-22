using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantOrderQuery : IRequest<List<GetAllRestaurantOrderQueryDto>>
{

}

public class GetAllRestaurantOrderQueryHandler : IRequestHandler<GetAllRestaurantOrderQuery, List<GetAllRestaurantOrderQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllRestaurantOrderQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllRestaurantOrderQueryDto>> Handle(GetAllRestaurantOrderQuery request, CancellationToken cancellationToken)
    {
        return await (from RestaurantOrder in _context.RestaurantOrder
                      select new GetAllRestaurantOrderQueryDto
                      {
                          Id = RestaurantOrder.Id,
                          UniqueId = RestaurantOrder.UniqueId,
                          OrderReferrenceNumber = RestaurantOrder.OrderReferrenceNumber,
                          OrderSource = RestaurantOrder.OrderSource,
                          OrderStatusID = RestaurantOrder.OrderStatusID,
                          OrderPaymentStatusID = RestaurantOrder.OrderPaymentStatusID,
                          OrderChargesAmount = RestaurantOrder.OrderChargesAmount,
                          OrderExtrasAmount = RestaurantOrder.OrderExtrasAmount,
                          OrderPromoAmount = RestaurantOrder.OrderPromoAmount,
                          OrderTaxAmount = RestaurantOrder.OrderTaxAmount,
                          OrderPaymentSurchargeAmount = RestaurantOrder.OrderPaymentSurchargeAmount,
                          OrderTotalAmount = RestaurantOrder.OrderTotalAmount,
                          OrderPaidAmount = RestaurantOrder.OrderPaidAmount,
                          OrderOutstandingBalanceAmount = RestaurantOrder.OrderOutstandingBalanceAmount,
                          OrderNotes = RestaurantOrder.OrderNotes,
                          RestaurantID = RestaurantOrder.RestaurantID,
                          GuestID = RestaurantOrder.GuestID,
                          GuestName = RestaurantOrder.GuestName,
                          RestaurantName = RestaurantOrder.RestaurantName,
                          IsActive = RestaurantOrder.IsActive

                      }).ToListAsync();
    }
}
