using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreatePromoCommand : IRequest<Result<CreatePromoCommandDto>>
{
    public string? PromoCode { get; init; }
    public string? PromoName { get; init; }

    public string? PromoDescription { get; init; }

    public float? PromoPrice { get; init; }

    public bool? IsActive { get; init; }
}

public class CreatePromoCommandHandler : IRequestHandler<CreatePromoCommand, Result<CreatePromoCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreatePromoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreatePromoCommandDto>> Handle(CreatePromoCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.Promo.Where(p => p.PromoName == request.PromoName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new Promo();

            entity.PromoCode = request.PromoCode;

            entity.PromoName = request.PromoName;

            entity.PromoDescription = request.PromoDescription;

            entity.PromoPrice = request.PromoPrice;

            entity.IsActive = request.IsActive;

            _context.Promo.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreatePromoCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreatePromoCommandDto
                {

                },
                Message = "Record '" + request.PromoName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

