using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllFoodCategoryIdQuery : IRequest<List<GetAllFoodByCategoryIdQueryDto>>
{
    public int? FoodCategoryId { get; set; }
}

public class GetAllFoodCategoryIdQueryHandler : IRequestHandler<GetAllFoodCategoryIdQuery, List<GetAllFoodByCategoryIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllFoodCategoryIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllFoodByCategoryIdQueryDto>> Handle(GetAllFoodCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await (from food in _context.Food
                      join foodcategory in _context.FoodCategory on food.FoodCategoryId equals foodcategory.Id
                      where food.FoodCategoryId == request.FoodCategoryId
                      select new GetAllFoodByCategoryIdQueryDto
                      {
                          Id = food.Id,
                          UniqueId = food.UniqueId,
                          FoodName = food.FoodName,
                          FoodDescription = food.FoodDescription,
                          FoodPrice = food.FoodPrice,
                          FoodCategoryId = food.FoodCategoryId,
                          FoodCategoryName = foodcategory.CategoryName,
                          IsActive = food.IsActive == null ? true : food.IsActive

                      }).ToListAsync();
    }
}
