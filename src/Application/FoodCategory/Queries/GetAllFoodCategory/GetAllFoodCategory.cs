using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllFoodCategoryQuery : IRequest<List<GetAllFoodCategoryQueryDto>>
{

}

public class GetMediaDetailQueryHandler : IRequestHandler<GetAllFoodCategoryQuery, List<GetAllFoodCategoryQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllFoodCategoryQueryDto>> Handle(GetAllFoodCategoryQuery request, CancellationToken cancellationToken)
    {
        return await (from foodcategory in _context.FoodCategory
                      select new GetAllFoodCategoryQueryDto
                      {
                          Id = foodcategory.Id,
                          UniqueId = foodcategory.UniqueId,
                          CategoryName = foodcategory.CategoryName,
                          CategoryDescription = foodcategory.CategoryDescription,
                          IsActive = foodcategory.IsActive == null ? true : foodcategory.IsActive

                      }).ToListAsync();
    }
}
