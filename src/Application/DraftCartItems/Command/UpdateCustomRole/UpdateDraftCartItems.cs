using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateDraftCartItemsCommand : IRequest<Result<UpdateDraftCartItemsCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? BookingReservationId { get; init; }

    public int? FoodId { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateDraftCartItemsCommandHandler : IRequestHandler<UpdateDraftCartItemsCommand, Result<UpdateDraftCartItemsCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateDraftCartItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateDraftCartItemsCommandDto>> Handle(UpdateDraftCartItemsCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.DraftCartItems.FirstOrDefault(item => item.UniqueId == request.UniqueId);

        if (entity != null)
        {

            entity.BookingReservationId = request.BookingReservationId;

            entity.FoodId = request.FoodId;

            entity.IsActive = request.IsActive;

            _context.DraftCartItems.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new UpdateDraftCartItemsCommandDto
                {
                    Id = entity.UniqueId,
                    UpdatedDate = DateTime.Now,
                },
                Message = "Updated successfully.",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new UpdateDraftCartItemsCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
