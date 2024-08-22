using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateRestaurantTableCommand : IRequest<Result<UpdateRestaurantTableCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? TableName { get; init; }

    public string? TableDescription { get; init; }

    public string? TableLocation { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateRestaurantTableCommandHandler : IRequestHandler<UpdateRestaurantTableCommand, Result<UpdateRestaurantTableCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateRestaurantTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateRestaurantTableCommandDto>> Handle(UpdateRestaurantTableCommand request, CancellationToken cancellationToken)
    {
        var record = _context.RestaurantTable.FirstOrDefault(item => item.TableName == request.TableName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.RestaurantTable.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.TableName = request.TableName;

                entity.TableDescription = request.TableDescription;

                entity.TableLocation = request.TableLocation;

                entity.IsActive = request.IsActive;

                _context.RestaurantTable.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateRestaurantTableCommandDto
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
                Data = new UpdateRestaurantTableCommandDto
                {

                },
                Message = "Record '" + request.TableName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateRestaurantTableCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
