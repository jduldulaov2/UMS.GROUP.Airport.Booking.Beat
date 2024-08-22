using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllRestaurantTableQuery : IRequest<List<GetAllRestaurantTableQueryDto>>
{

}

public class GetAllRestaurantTableQueryHandler : IRequestHandler<GetAllRestaurantTableQuery, List<GetAllRestaurantTableQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllRestaurantTableQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllRestaurantTableQueryDto>> Handle(GetAllRestaurantTableQuery request, CancellationToken cancellationToken)
    {
        return await (from RestaurantTable in _context.RestaurantTable
                      select new GetAllRestaurantTableQueryDto
                      {
                          Id = RestaurantTable.Id,
                          UniqueId = RestaurantTable.UniqueId,
                          TableName = RestaurantTable.TableName,
                          TableDescription = RestaurantTable.TableDescription,
                          TableLocation = RestaurantTable.TableLocation,
                          IsActive = RestaurantTable.IsActive == null ? true : RestaurantTable.IsActive

                      }).ToListAsync();
    }
}
