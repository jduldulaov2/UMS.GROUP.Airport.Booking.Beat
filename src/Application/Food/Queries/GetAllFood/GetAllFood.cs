using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.FoodCategory.Queries.GetAllFoodCategory;

public record GetAllFoodQuery : IRequest<List<GetAllFoodQueryDto>>
{

}

public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, List<GetAllFoodQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllFoodQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllFoodQueryDto>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
    {
        return await (from food in _context.Food
                      join foodcategory in _context.FoodCategory on food.Id equals foodcategory.Id
                      select new GetAllFoodQueryDto
                      {
                          Id = foodcategory.Id,
                          FoodName = food.FoodName,
                          FoodDescription = food.FoodDescription,
                          FoodPrice = food.FoodPrice,
                          FoodCategoryId = food.FoodCategoryId,
                          FoodCategoryName = foodcategory.CategoryName,
                          IsActive = foodcategory.IsActive == null ? true : foodcategory.IsActive

                      }).ToListAsync();
    }
}
