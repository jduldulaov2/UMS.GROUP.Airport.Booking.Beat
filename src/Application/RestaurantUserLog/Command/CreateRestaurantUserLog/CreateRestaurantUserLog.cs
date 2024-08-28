using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateRestaurantUserLogCommand : IRequest<Result<CreateRestaurantUserLogCommandDto>>
{
    public string? BookingNumber { get; init; }

    public string? FullName { get; init; }

    public string? BookingLogs { get; init; }

    public string? BookingStatusId { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateRestaurantUserLogCommandHandler : IRequestHandler<CreateRestaurantUserLogCommand, Result<CreateRestaurantUserLogCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateRestaurantUserLogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateRestaurantUserLogCommandDto>> Handle(CreateRestaurantUserLogCommand request, CancellationToken cancellationToken)
    {

        var entity = new RestaurantUserLog();

        entity.BookingNumber = request.BookingNumber;

        entity.FullName = request.FullName;

        entity.BookingLogs = request.BookingLogs;

        entity.BookingStatusId = request.BookingStatusId;

        entity.IsActive = request.IsActive;

        _context.RestaurantUserLog.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Data = new CreateRestaurantUserLogCommandDto
            {
                Id = entity.UniqueId,
                CreatedDate = DateTime.Now,
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}

