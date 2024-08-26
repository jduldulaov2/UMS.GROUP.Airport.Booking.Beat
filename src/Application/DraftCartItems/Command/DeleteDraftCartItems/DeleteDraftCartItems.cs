using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record DeleteDraftCartItemsCommand : IRequest<Result<DeleteDraftCartItemsCommandDto>>
{
    public string? UniqueId { get; init; }
}

public class DeleteDraftCartItemsCommandHandler : IRequestHandler<DeleteDraftCartItemsCommand, Result<DeleteDraftCartItemsCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public DeleteDraftCartItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DeleteDraftCartItemsCommandDto>> Handle(DeleteDraftCartItemsCommand request, CancellationToken cancellationToken)
    {
        // Add new record

        var entity = await _context.DraftCartItems
            .Where(l => l.UniqueId == request.UniqueId)
            .SingleOrDefaultAsync(cancellationToken);

        if(entity != null) {
            _context.DraftCartItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new DeleteDraftCartItemsCommandDto
                {
                    Id = request.UniqueId,
                    DeletedDate = DateTime.Now,
                },
                Message = "deletion success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new DeleteDraftCartItemsCommandDto
                {
                    Id = request.UniqueId,
                    DeletedDate = DateTime.Now,
                },
                Message = "deletion success",
                ResultType = ResultType.Success,
            };
        }
    }
}

