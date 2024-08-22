using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record GetAllFoodCategoryByIdQuery : IRequest<Result<GetAllFoodCategoryByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetAirportByIdQueryHandler : IRequestHandler<GetAllFoodCategoryByIdQuery, Result<GetAllFoodCategoryByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAirportByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllFoodCategoryByIdQueryDto>> Handle(GetAllFoodCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.FoodCategory.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllFoodCategoryByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    CategoryName = result.CategoryName,
                    CategoryDescription = result.CategoryDescription,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllFoodCategoryByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
