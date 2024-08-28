using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllRestaurantUserLogQuery : IRequest<List<GetAllRestaurantUserLogQueryDto>>
{

}

public class GetAllRestaurantUserLogQueryHandler : IRequestHandler<GetAllRestaurantUserLogQuery, List<GetAllRestaurantUserLogQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllRestaurantUserLogQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllRestaurantUserLogQueryDto>> Handle(GetAllRestaurantUserLogQuery request, CancellationToken cancellationToken)
    {
        return await (from RestaurantUserLog in _context.RestaurantUserLog
                      select new GetAllRestaurantUserLogQueryDto
                      {
                          Id = RestaurantUserLog.Id,
                          UniqueId = RestaurantUserLog.UniqueId,
                          BookingNumber = RestaurantUserLog.BookingNumber,
                          BookingLogs = RestaurantUserLog.BookingLogs,
                          FullName = RestaurantUserLog.FullName,
                          BookingStatusId = RestaurantUserLog.BookingStatusId,
                          IsActive = RestaurantUserLog.IsActive == null ? true : RestaurantUserLog.IsActive

                      }).ToListAsync();
    }
}
