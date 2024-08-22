using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.FoodCategory.Queries.GetAllFoodCategoryById;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllFoodByIdQuery : IRequest<Result<GetAllFoodByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetFoodByIdQueryHandler : IRequestHandler<GetAllFoodByIdQuery, Result<GetAllFoodByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetFoodByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllFoodByIdQueryDto>> Handle(GetAllFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Food.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllFoodByIdQueryDto
                {
                    Id = result.Id,
                    FoodName = result.FoodName,
                    FoodDescription = result.FoodDescription,
                    FoodPrice = result.FoodPrice,
                    FoodCategoryId = result.FoodCategoryId,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllFoodByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
