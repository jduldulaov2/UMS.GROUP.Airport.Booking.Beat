using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateRestaurantTableCommand : IRequest<Result<CreateRestaurantTableCommandDto>>
{
    public string? TableName { get; init; }
    public string? TableDescription { get; init; }

    public string? TableLocation { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateRestaurantTableCommandHandler : IRequestHandler<CreateRestaurantTableCommand, Result<CreateRestaurantTableCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateRestaurantTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateRestaurantTableCommandDto>> Handle(CreateRestaurantTableCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.RestaurantTable.Where(p => p.TableName == request.TableName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new RestaurantTable();

            entity.TableName = request.TableName;

            entity.TableDescription = request.TableDescription;

            entity.TableLocation = request.TableLocation;

            entity.IsActive = request.IsActive;

            _context.RestaurantTable.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateRestaurantTableCommandDto
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
                Data = new CreateRestaurantTableCommandDto
                {

                },
                Message = "Record '" + request.TableName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

