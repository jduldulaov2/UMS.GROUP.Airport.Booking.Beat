using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateFoodCommand : IRequest<Result<UpdateFoodCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? FoodName { get; init; }

    public string? FoodDescription { get; init; }

    public float? FoodPrice { get; init; }

    public int? FoodCategoryId { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Result<UpdateFoodCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateFoodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateFoodCommandDto>> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var record = _context.Food.FirstOrDefault(item => item.FoodName == request.FoodName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.Food.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.FoodName = request.FoodName;

                entity.FoodDescription = request.FoodDescription;

                entity.FoodPrice = request.FoodPrice;

                entity.IsActive = request.IsActive;

                _context.Food.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateFoodCommandDto
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
                Data = new UpdateFoodCommandDto
                {

                },
                Message = "Record '" + request.FoodName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateFoodCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
