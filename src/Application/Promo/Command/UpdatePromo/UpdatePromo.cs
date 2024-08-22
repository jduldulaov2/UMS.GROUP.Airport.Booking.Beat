using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdatePromoCommand : IRequest<Result<UpdatePromoCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? PromoCode { get; init; }

    public string? PromoName { get; init; }

    public string? PromoDescription { get; init; }

    public float? PromoPrice { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdatePromoCommandHandler : IRequestHandler<UpdatePromoCommand, Result<UpdatePromoCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdatePromoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdatePromoCommandDto>> Handle(UpdatePromoCommand request, CancellationToken cancellationToken)
    {
        var record = _context.Promo.FirstOrDefault(item => item.PromoName == request.PromoName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.Promo.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.PromoCode = request.PromoCode;

                entity.PromoName = request.PromoName;

                entity.PromoDescription = request.PromoDescription;

                entity.PromoPrice = request.PromoPrice;

                entity.IsActive = request.IsActive;

                _context.Promo.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdatePromoCommandDto
                    {
                        Id = entity.UniqueId,
                        UpdatedDate = DateTime.Now,
                    },
                    Message = "Updated successfully.",
                    ResultType = ResultType.Success,
                };
            }
        }
        else
        {
            return new()
            {
                Data = new UpdatePromoCommandDto
                {

                },
                Message = "Record '" + request.PromoName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdatePromoCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
