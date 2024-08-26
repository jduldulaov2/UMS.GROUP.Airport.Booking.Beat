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
                      where DraftCartItems.BookingReservationId == request.DraftCode
                      select new GetAllDraftCartItemsQueryDtoByCode
                      {
                          Id = DraftCartItems.Id,
                          UniqueId = DraftCartItems.UniqueId,
                          BookingReservationId = DraftCartItems.BookingReservationId,
                          CurrentPrice = DraftCartItems.CurrentPrice,
                          CurrentQuantity = DraftCartItems.CurrrentQuantity,
                          CurrentTotal = DraftCartItems.CurrentTotal,
                          FoodId = DraftCartItems.FoodId,
                          IsActive = DraftCartItems.IsActive == null ? true : DraftCartItems.IsActive

                      }).ToListAsync();
    }
}
