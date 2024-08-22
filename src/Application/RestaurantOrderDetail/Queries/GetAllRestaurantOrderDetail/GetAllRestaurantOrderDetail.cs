using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllRestaurantOrderDetailQuery : IRequest<List<GetAllRestaurantOrderDetailQueryDto>>
{

}

public class GetAllRestaurantOrderDetailQueryHandler : IRequestHandler<GetAllRestaurantOrderDetailQuery, List<GetAllRestaurantOrderDetailQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllRestaurantOrderDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllRestaurantOrderDetailQueryDto>> Handle(GetAllRestaurantOrderDetailQuery request, CancellationToken cancellationToken)
    {
        return await (from RestaurantOrderDetail in _context.RestaurantOrderDetail
                      select new GetAllRestaurantOrderDetailQueryDto
                      {
                          Id = RestaurantOrderDetail.Id,
                          UniqueId = RestaurantOrderDetail.UniqueId,
                          RestaurantOrderID = RestaurantOrderDetail.RestaurantOrderID,
                          FoodID = RestaurantOrderDetail.FoodID,
                          OrderDetailFoodPrice = RestaurantOrderDetail.OrderDetailFoodPrice,
                          OrderQuantity = RestaurantOrderDetail.OrderQuantity,
                          OrderTotalAmount = RestaurantOrderDetail.OrderTotalAmount,
                          OrderSource = RestaurantOrderDetail.OrderSource,
                          OrderDetailNotes = RestaurantOrderDetail.OrderDetailNotes,
                          IsActive = RestaurantOrderDetail.IsActive

                      }).ToListAsync();
    }
}
