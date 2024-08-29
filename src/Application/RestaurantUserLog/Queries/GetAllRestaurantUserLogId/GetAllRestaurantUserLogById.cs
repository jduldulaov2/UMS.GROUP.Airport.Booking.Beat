using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantUserLogByIdQuery : IRequest<Result<GetAllRestaurantUserLogByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetRestaurantUserLogByIdQueryHandler : IRequestHandler<GetAllRestaurantUserLogByIdQuery, Result<GetAllRestaurantUserLogByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRestaurantUserLogByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllRestaurantUserLogByIdQueryDto>> Handle(GetAllRestaurantUserLogByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RestaurantUserLog.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllRestaurantUserLogByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    BookingNumber = result.BookingNumber,
                    FullName = result.FullName,
                    BookingLogs = result.BookingLogs,
                    BookingStatusId = result.BookingStatusId,
                    BookingUniqueId = result.BookingUniqueId,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllRestaurantUserLogByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
