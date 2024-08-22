using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllRestaurantTableByIdQuery : IRequest<Result<GetAllRestaurantTableByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetRestaurantTableByIdQueryHandler : IRequestHandler<GetAllRestaurantTableByIdQuery, Result<GetAllRestaurantTableByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRestaurantTableByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllRestaurantTableByIdQueryDto>> Handle(GetAllRestaurantTableByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RestaurantTable.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllRestaurantTableByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    TableName = result.TableName,
                    TableDescription = result.TableDescription,
                    TableLocation = result.TableLocation,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllRestaurantTableByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
