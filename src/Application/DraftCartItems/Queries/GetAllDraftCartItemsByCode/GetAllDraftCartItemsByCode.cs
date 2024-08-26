using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllDraftCartItemsQuery : IRequest<List<GetAllDraftCartItemsQueryDtoByCode>>
{
    public string? DraftCode { get; init; }
}

public class GetAllDraftCartItemsQueryHandler : IRequestHandler<GetAllDraftCartItemsQuery, List<GetAllDraftCartItemsQueryDtoByCode>>
{
    private readonly IApplicationDbContext _context;

    public GetAllDraftCartItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllDraftCartItemsQueryDtoByCode>> Handle(GetAllDraftCartItemsQuery request, CancellationToken cancellationToken)
    {
        return await (from DraftCartItems in _context.DraftCartItems
                      join food in _context.Food on DraftCartItems.FoodId equals food.Id
                      where DraftCartItems.BookingReservationId == request.DraftCode 
                      where DraftCartItems.IsActive != false
                      select new GetAllDraftCartItemsQueryDtoByCode
                      {
                          Id = DraftCartItems.Id,
                          UniqueId = DraftCartItems.UniqueId,
                          BookingReservationId = DraftCartItems.BookingReservationId,
                          CurrentPrice = DraftCartItems.CurrentPrice,
                          CurrentQuantity = DraftCartItems.CurrrentQuantity,
                          CurrentTotal = DraftCartItems.CurrentTotal,
                          FoodId = DraftCartItems.FoodId,
                          FoodName  = food.FoodName,
                          FoodDescription = food.FoodDescription,
                          IsActive = DraftCartItems.IsActive == null ? true : DraftCartItems.IsActive

                      }).ToListAsync();
    }
}
