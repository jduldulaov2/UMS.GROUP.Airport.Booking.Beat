using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateFoodCategoryCommand : IRequest<Result<UpdateFoodCategoryCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? CategoryName { get; init; }

    public string? CategoryDescription { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateFoodCategoryCommandHandler : IRequestHandler<UpdateFoodCategoryCommand, Result<UpdateFoodCategoryCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateFoodCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateFoodCategoryCommandDto>> Handle(UpdateFoodCategoryCommand request, CancellationToken cancellationToken)
    {
        var record = _context.FoodCategory.FirstOrDefault(item => item.CategoryName == request.CategoryName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.FoodCategory.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.CategoryName = request.CategoryName;

                entity.CategoryDescription = request.CategoryDescription;

                entity.IsActive = request.IsActive;

                _context.FoodCategory.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateFoodCategoryCommandDto
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
                Data = new UpdateFoodCategoryCommandDto
                {

                },
                Message = "Record '" + request.CategoryName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateFoodCategoryCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
