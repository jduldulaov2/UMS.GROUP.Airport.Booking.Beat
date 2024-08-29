using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateRestaurantUserLogCommand : IRequest<Result<UpdateRestaurantUserLogCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? BookingNumber { get; init; }

    public string? FullName { get; init; }

    public string? BookingLogs { get; init; }

    public string? BookingStatusId { get; init; }

    public string? BookingUniqueId { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateRestaurantUserLogCommandHandler : IRequestHandler<UpdateRestaurantUserLogCommand, Result<UpdateRestaurantUserLogCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateRestaurantUserLogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateRestaurantUserLogCommandDto>> Handle(UpdateRestaurantUserLogCommand request, CancellationToken cancellationToken)
    {

        var entity = _context.RestaurantUserLog.FirstOrDefault(item => item.UniqueId == request.UniqueId);

        if (entity != null)
        {
            entity.BookingNumber = request.BookingNumber;

            entity.FullName = request.FullName;

            entity.BookingStatusId = request.BookingLogs;

            entity.BookingStatusId = request.BookingStatusId;

            entity.BookingUniqueId = request.BookingUniqueId;

            entity.IsActive = request.IsActive;

            _context.RestaurantUserLog.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new UpdateRestaurantUserLogCommandDto
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
            Data = new UpdateRestaurantUserLogCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
