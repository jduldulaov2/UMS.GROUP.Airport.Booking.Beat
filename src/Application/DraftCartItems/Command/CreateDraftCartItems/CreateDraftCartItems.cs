using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateDraftCartItemsCommand : IRequest<Result<CreateDraftCartItemsCommandDto>>
{
    public string? BookingReservationId { get; init; }

    public int? FoodId { get; init; }

    public float? CurrentPrice { get; init; }

    public float? CurrrentQuantity { get; init; }

    public float? CurrentTotal { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateDraftCartItemsCommandHandler : IRequestHandler<CreateDraftCartItemsCommand, Result<CreateDraftCartItemsCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateDraftCartItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateDraftCartItemsCommandDto>> Handle(CreateDraftCartItemsCommand request, CancellationToken cancellationToken)
    {
        // Add new record

        var entity = new DraftCartItems();

        entity.BookingReservationId = request.BookingReservationId;

        entity.FoodId = request.FoodId;

        entity.CurrentPrice = request.CurrentPrice;

        entity.CurrrentQuantity = request.CurrrentQuantity;

        entity.CurrentTotal = request.CurrentTotal;

        entity.IsActive = request.IsActive;

        _context.DraftCartItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Data = new CreateDraftCartItemsCommandDto
            {
                Id = entity.UniqueId,
                CreatedDate = DateTime.Now,
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}

