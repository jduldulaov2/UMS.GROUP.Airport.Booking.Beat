using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllPromoByIdQuery : IRequest<Result<GetAllPromoByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetPromoByIdQueryHandler : IRequestHandler<GetAllPromoByIdQuery, Result<GetAllPromoByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPromoByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllPromoByIdQueryDto>> Handle(GetAllPromoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Promo.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllPromoByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    PromoName = result.PromoName,
                    PromoDescription = result.PromoDescription,
                    PromoPrice = result.PromoPrice,
                    PromoCode = result.PromoCode,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllPromoByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
