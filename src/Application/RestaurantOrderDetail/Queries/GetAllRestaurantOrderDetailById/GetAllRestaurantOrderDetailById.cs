using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
public record GetAllRestaurantOrderDetailByIdQuery : IRequest<Result<GetAllRestaurantOrderDetailByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetRestaurantOrderDetailByIdQueryHandler : IRequestHandler<GetAllRestaurantOrderDetailByIdQuery, Result<GetAllRestaurantOrderDetailByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRestaurantOrderDetailByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllRestaurantOrderDetailByIdQueryDto>> Handle(GetAllRestaurantOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RestaurantOrderDetail.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllRestaurantOrderDetailByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    RestaurantOrderID = result.RestaurantOrderID,
                    FoodID = result.FoodID,
                    OrderDetailFoodPrice = result.OrderDetailFoodPrice,
                    OrderQuantity = result.OrderQuantity,
                    OrderTotalAmount = result.OrderTotalAmount,
                    OrderSource = result.OrderSource,
                    OrderDetailNotes = result.OrderDetailNotes,
                    IsActive = result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllRestaurantOrderDetailByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
