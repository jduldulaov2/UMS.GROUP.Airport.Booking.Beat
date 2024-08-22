using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetAllPromoQuery : IRequest<List<GetAllPromoQueryDto>>
{

}

public class GetAllPromoQueryHandler : IRequestHandler<GetAllPromoQuery, List<GetAllPromoQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllPromoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllPromoQueryDto>> Handle(GetAllPromoQuery request, CancellationToken cancellationToken)
    {
        return await (from Promo in _context.Promo
                      select new GetAllPromoQueryDto
                      {
                          Id = Promo.Id,
                          UniqueId = Promo.UniqueId,
                          PromoCode = Promo.PromoCode,
                          PromoName = Promo.PromoName,
                          PromoDescription = Promo.PromoDescription,
                          PromoPrice = Promo.PromoPrice,
                          IsActive = Promo.IsActive == null ? true : Promo.IsActive

                      }).ToListAsync();
    }
}
